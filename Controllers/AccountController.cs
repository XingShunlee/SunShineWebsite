using ehaiker;
using ehaiker.Models;
using ehaikerv202010.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ehaikerv202010.Controllers
{
    public class AccountController : Controller
    {
        private EhaikerContext DbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AccountController(EhaikerContext _cont, IHttpContextAccessor httpContextAccessor)
        {
            DbContext = _cont;
            _httpContextAccessor = httpContextAccessor;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
        [LoginStateRequiredAttribute]
        public async Task<IActionResult> Index()
        {
            IActionResult t = await Task.Run(() =>
           { return View(); });
            return t;
        }
        [NoPermissionRequiredAttribute]
        public ActionResult Login()
        {
            //没有登录
            MemberShip cookie = MemUserDataManager.GetMemSessionData<MemberShip>(HttpContext, "memshipUserInfo");
            if (cookie != null)
            {
                //从Cookie对象中取出Json串
                return RedirectToRoute(new { Controller = "Personal", Action = "Index" });
            }
            else
            {
                MemberShip user = new MemberShip() { UserName = "游客", UserId = 0, Password = "0", UserGuid = Guid.NewGuid().ToString() };

                return View("Login", user);
            }
        }
        [NoPermissionRequiredAttribute]
        [LoginStateRequiredAttribute]
        public ActionResult Logout()
        {
            //更新数据库
            MemberShip sessionUser = MemUserDataManager.GetMemSessionData<MemberShip>(HttpContext, "memshipUserInfo");
            if (sessionUser != null)
            {
                MemberShipManager ship = new MemberShipManager(DbContext);

                var _admin = ship.Find(sessionUser.Account);
                _admin.LoginGuid = Guid.Empty.ToString();
                ship.Update(_admin);
            }
            //没有登录
            MemUserDataManager.RemoveSessionData(HttpContext, "memshipUserInfo");
            //clear all the user information
            MemUserDataManager.RemoveSessionData(HttpContext, "memshipInfomation");
            HttpContext.Session.Clear();
            MemberShip user = new MemberShip() { UserName = "游客", UserId = 0, Password = "0" };
            //Forms验证
            // FormsAuthentication.SignOut();
            return View("Login", user);

        }
        /// <summary>
        /// 获取用户签到信息
        /// </summary>
        /// <returns></returns>
        // [Description(No = 1, Name = "获取签到状态")]
        [LoginStateRequiredAttribute]
        [NoPermissionRequired]
        public JsonResult GetSignStatus()
        {
            LoginMessage msg = new LoginMessage();
            msg.msg = "未知错误";
            msg.SuccessCode = "-10000";

            string controllerName = RouteData.Values["Controller"].ToString();
            string actionName = RouteData.Values["Action"].ToString();
            msg.UserLogUrl = controllerName + actionName;
            //在cookie中查询用户信息
            MemberShip sessionUser = MemUserDataManager.GetMemSessionData<MemberShip>(HttpContext, "memshipUserInfo");
            if (sessionUser != null)
            {
                if (sessionUser == null)
                {
                    return Json(msg);
                }
                //获取最近登录的时间
                DateTime signtime = (DateTime)sessionUser.LastSignTime;
                if (DateTime.Now.Day - signtime.Day == 0 && signtime.Month == DateTime.Now.Month)
                {
                    msg.SuccessCode = "10000";
                    //已经签到
                    return Json(msg);
                }
            }

            //判断用户登录情况，到会员表查询2个数据
            return Json(msg);
        }
        //用户签到
        // [Description(No = 2, Name = "签到")]
        [LoginStateRequiredAttribute]
        [NoPermissionRequired]
        public JsonResult SiginClick()
        {
            LoginMessage msg = new LoginMessage();
            msg.msg = "未知错误";
            msg.SuccessCode = "-1000";

            string controllerName = RouteData.Values["Controller"].ToString();
            string actionName = RouteData.Values["Action"].ToString();
            msg.UserLogUrl = controllerName + actionName;
            //在cookie中查询用户信息
            MemberShip sessionUser = MemUserDataManager.GetMemSessionData<MemberShip>(HttpContext, "memshipUserInfo");
            if (sessionUser != null)
            {

                //已经签到
                DateTime signtime = (DateTime)sessionUser.LastSignTime;
                if (DateTime.Now.Day - signtime.Day == 0 && signtime.Month == DateTime.Now.Month)
                {
                    msg.SuccessCode = "30000";
                    //已经签到
                    return Json(msg);
                }//增加连续签到天数
                else if (signtime.Month == DateTime.Now.Month && DateTime.Now.Day - signtime.Day == 1)
                {
                    //更新最近签到时间和天数
                    sessionUser.LastSignTime = DateTime.Now;
                    sessionUser.SignCount = sessionUser.SignCount + 1;
                    msg.SuccessCode = "10000";
                }
                else
                {
                    msg.SuccessCode = "20000";
                    //更新最近签到时间和天数
                    sessionUser.LastSignTime = DateTime.Now;
                    sessionUser.SignCount = 1;

                }
                MemberShipManager mManager = new MemberShipManager(DbContext);
                mManager.Update(sessionUser);
                mManager.SaveChanges();
            }
            //判断用户登录情况，到会员表查询2个数据
            return Json(msg);
        }
        //获取用户信息
        //[Description(No = 3, Name = "获取用户信息")]
        [LoginStateRequiredAttribute]
        [NoPermissionRequired]
        public JsonResult GetUserInfo()
        {
            LoginMessage msg = new LoginMessage();
            msg.msg = "未知错误";
            msg.SuccessCode = "-1000";
            MemberShipInfomation sessionUserInfo = MemUserDataManager.GetMemSessionData<MemberShipInfomation>(HttpContext, "memshipInfomation");
            if (sessionUserInfo != null)
            {
                msg.SuccessCode = "30000";
                msg.UMoney = sessionUserInfo.UMoney;
                msg.TMoney = sessionUserInfo.TMoney;
            }
            return Json(msg);
        }
        ///////////////////////////////////////////////////////////////////////////////////////
        [HttpPost]
        public JsonResult Login(string ehaiker_parameter)
        {
            membershiplogin juser = JsonHelper.DeserializeJsonToObject<membershiplogin>(ehaiker_parameter);
            LoginMessage msg = new LoginMessage();
            msg.msg = "未知错误";
            msg.SuccessCode = "-1000";
            msg.UserLogUrl = "/Account/Login";
            if (ModelState.IsValid)
            {

                if (HttpContext.Session.GetString("ValidateCode") != juser.verificat_code)
                {
                    ModelState.AddModelError("code", "validate code is error");
                    msg.msg = "验证码错误";
                    msg.SuccessCode = "10000:" + HttpContext.Session.GetString("ValidateCode");
                    msg.Account = juser.Account;
                    return Json(msg);
                }
                string _passowrd = Security.Sha256(juser.Password);
                MemberShipManager ship = new MemberShipManager(DbContext);
                var _response = ship.Verify(juser.Account, _passowrd);
                if (_response == 1)
                {
                    var _admin = ship.Find(juser.Account);
                    //判断是否为重复登录
                    if (_admin.LoginGuid != Guid.Empty.ToString())
                    {
                        //已经登录，清空session，重新登录
                        MemUserDataManager.RemoveSessionData(HttpContext, "memshipUserInfo");
                        HttpContext.Session.Clear();
                    }


                    _admin.LoginTime = DateTime.Now;
                    // _admin.LoginIP = HttpContext.Connection.RemoteIpAddress.MapToIPv4()?.ToString();
                    _admin.LoginIP = HttpContext.Request.Headers["X-Real-IP"].FirstOrDefault();
                    _admin.LoginGuid = Guid.NewGuid().ToString();
                    ship.Update(_admin);
                    ship.SaveChanges();
                    //创建一个用户对象
                    MemberShip jsonUserInfo = new MemberShip(_admin);
                    //密码不能传到客户端---
                    jsonUserInfo.Password = "fuckyou!";
                    //创建Cookie对象
                    //将序列化之后的Json串以UTF-8编码，再存入Cookie

                    //写入session
                    MemUserDataManager.AddSessionData(HttpContext, "memshipUserInfo", jsonUserInfo);
                    MemberShipInfomationRepository UserInfoMgr = new MemberShipInfomationRepository(DbContext);
                    MemberShipInfomation UserInfo = UserInfoMgr.GetByUserId(_admin.UserGuid);
                    //write the user information
                    MemUserDataManager.AddSessionData(HttpContext, "memshipInfomation", UserInfo);
                    //设置信息
                    msg.msg = "欢迎您";
                    msg.SuccessCode = "0";
                    msg.Account = juser.Account;
                    msg.UserInfoUrl = "/Personal/Index";
                    msg.UserLogUrl = "/Account/logout";
                    // msg.UserName = _admin.UserName;
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
        //////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 验证码生成
        /// </summary>
        /// <returns></returns>
        //验证码
        public ActionResult GetValidateCode()
        {
            ValidateCode vCode = new ValidateCode();
            string code = vCode.CreateValidateCode(5);
            HttpContext.Session.SetString("ValidateCode", code); //HttpContext.Session.GetString("ValidateCode")
            byte[] bytes = vCode.CreateValidateGraphic(code);
            return File(bytes, @"image/jpeg");
        }
    }
}