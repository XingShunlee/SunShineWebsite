using ehaiker.Models;
using ehaikerv202010;
using ehaikerv202010.Filters;
using ehaikerv202010.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace ehaiker.Controllers
{
    public class AdminLoginController : Controller
    {

        private EhaikerContext DbContext;
        public AdminLoginController(EhaikerContext _cont)
        {
            DbContext = _cont;

        }
        // [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        [HttpPost]
        [PermissionControlAttribute(1, "管理员登录", "管理员登录", 0, 0, 1)]
        public JsonResult Login(string ehaiker_parameter)
        {
            membershiplogin juser = JsonHelper.DeserializeJsonToObject<membershiplogin>(ehaiker_parameter);
            LoginMessage msg = new LoginMessage();
            AdministratorManager adminManager = new AdministratorManager(DbContext);
            msg.msg = "未知错误";
            msg.SuccessCode = "-1000";
            msg.UserLogUrl = "/AdminLogin/Index";
            if (ModelState.IsValid)
            {

                if (HttpContext.Session.GetString("ValidateCode") != juser.verificat_code)
                {
                    ModelState.AddModelError("code", "validate code is error");
                    msg.msg = "验证码错误";
                    msg.SuccessCode = "10000";
                    return Json(msg);
                }
                string _passowrd = Security.Sha256(juser.Password);
                var _response = adminManager.Verify(juser.Account, _passowrd);
                if (_response == 1)
                {
                    var _admin = adminManager.Find(juser.Account);

                    _admin.LoginTime = DateTime.Now;
                    //  _admin.LoginIP = HttpContext.Connection.RemoteIpAddress.MapToIPv4()?.ToString(); ;
                    _admin.LoginIP = HttpContext.Request.Headers["X-Real-IP"].FirstOrDefault();
                    if (_admin.LoginGuid != Guid.Empty.ToString())
                    {
                        _admin.LoginGuid = Guid.NewGuid().ToString();
                        MemUserDataManager.RemoveSessionData(HttpContext, "AdminUser");
                    }
                    adminManager.Update(_admin);
                    adminManager.SaveChanges();
                    //创建一个用户对象
                    Administrator jsonUserInfo = new Administrator(_admin);
                    //密码不能传到客户端---
                    jsonUserInfo.Password = "fuckyou!";
                    //创建Cookie对象
                    //将序列化之后的Json串以UTF-8编码，再存入Cookie

                    //写入session
                    MemUserDataManager.AddSessionData(HttpContext, "AdminUser", jsonUserInfo);
                    //设置信息
                    msg.msg = "欢迎您";
                    msg.SuccessCode = "0";
                    msg.Account = juser.Account;
                    msg.UserInfoUrl = "/ManagerMain/Index";
                    msg.UserLogUrl = "/AdminLogin/logout";
                    msg.UserName = _admin.Account;
                    //使用Form验证
                    /*UserInfo userData = new UserInfo();
                    userData.UserId = _admin.AdministratorID;
                    userData.GroupId = _admin.GroupId;
                    userData.UserName = _admin.Account;
                    userData.perItem = string.Format("userPermissionMenu_{0}", userData.GroupId);
                    userData.perskey = string.Format("userPermission_{0}", userData.GroupId);*/
                    // msg.VIPLevel = _admin.VIPLevel;
                    // 登录状态10分钟内有效
                    //  MyFormsPrincipal<UserInfo>.SignIn(_admin.Account, userData, 100, juser.is_auto);
                    //读取权限
                    //  RoleService sSVR = new RoleService();
                    //  List<Permission> lp = null;
                    /*if(userData.GroupId==1)
                    {
                        lp = sSVR.GetPermissions();
                    }
                    else
                    {
                        lp =sSVR.GetGroupPermissions(userData.GroupId);
                    };
                    List<MenuItem> ls = sSVR.GetFormatMgrMenu(lp);
                    HttpRuntime.Cache.Insert(userData.perskey, lp);
                    HttpRuntime.Cache.Insert(userData.perItem, ls);*/
                }
                else if (_response == 2)
                {
                    msg.msg = "用户不存在";
                    msg.SuccessCode = "10001";
                    ModelState.AddModelError("account", "用户不存在");
                }
                else if (_response == 3)
                {
                    msg.msg = "密码错误";
                    msg.SuccessCode = "10002";
                    ModelState.AddModelError("password", "密码错误");
                }
                else
                {
                    ModelState.AddModelError("", "未知错误");
                }
            }
            return Json(msg);
        }
        [AllowAnonymous]
        public ActionResult Index()
        {
            Administrator sessionUser = MemUserDataManager.GetMemSessionData<Administrator>(HttpContext, "Adminuser");
            if (sessionUser != null)
            {
                return RedirectToRoute(new { Controller = "ManagerMain", Action = "Index" });
            }
            LoginViewModel user = new LoginViewModel() { Accounts = "游客", Password = "0" };

            return View(user);
        }
        [NoPermissionRequiredAttribute]
        [AdminLoginStateRequiredAttribute]
        public ActionResult Logout()
        {
            //更新数据库
            Administrator sessionUser = MemUserDataManager.GetMemSessionData<Administrator>(HttpContext, "Adminuser");
            if (sessionUser != null)
            {
                AdministratorManager ship = new AdministratorManager(DbContext);

                var _admin = ship.Find(sessionUser.Account);
                _admin.LoginGuid = Guid.Empty.ToString();
                ship.Update(_admin);
            }
            //没有登录
            MemUserDataManager.RemoveSessionData(HttpContext, "AdminUser");
            return RedirectToRoute(new { Controller = "Home", Action = "Index" });

        }
        /// <summary>
        /// 验证码生成
        /// </summary>
        /// <returns></returns>
        //验证码
        public ActionResult GetValidateCode()
        {
            ValidateCode vCode = new ValidateCode();
            string code = vCode.CreateValidateCode(5);
            HttpContext.Session.SetString("ValidateCode", code);
            byte[] bytes = vCode.CreateValidateGraphic(code);
            return File(bytes, @"image/jpeg");
        }
    }
}
