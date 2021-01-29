using ehaiker.Auth;
using ehaiker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using RoleService = ehaiker.Auth.RoleService;

namespace ehaiker.WebAPI
{
    public class PlatformController : ApiController
    {
        private AdministratorManager adminManager;
        private MemberShipManager memberManager;
        // GET api/default1
        /*[System.Web.Mvc.HttpGet]
        public async Task<JsonResult> Get(int pageindex = 1, int rows = 50)
        {
           // UserRepository users = new UserRepository(context);
            //检查是否超级管理员，直接返回非法操作
            //pageindex = pageindex > 0 ? pageindex : 1;

            //try
            //{
            //    var query = context.Users.Where(x => x.IsMain == true).AsQueryable();
            //    var count = query.Count();
            //    var pagecount = count % rows == 0 ? count / rows : count / rows + 1;
            //    var pageobj = query.OrderByDescending(r => r.GroupID)
            //        .Skip((pageindex - 1) * rows)
            //        .Take(rows)
            //        .ToList();
            //    //
            //    return new JsonResult { Data = new { status = 0, msg = "会员查询成功", data = pageobj.ToList(), count },
            //        JsonRequestBehavior = JsonRequestBehavior.AllowGet, ContentEncoding = Encoding.UTF8 };
            //}
            //catch
            //{
            //    return new JsonResult
            //    {
            //        Data = new { status = -1, msg = "未知错误，操作失误" },
            //        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
            //        ContentEncoding = Encoding.UTF8
            //    };
            //}
        }*/
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/default1/5
        /*public async Task<JsonResult> Get(int id)
        {
            
                
        }*/

        // POST api/default1
        public void Post([FromBody]string value)
        {
        }

        // PUT api/default1/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/default1/5
        public void Delete(int id)
        {
        }
        [System.Web.Mvc.HttpPost]
        public JsonResult Login(string ehaiker_parameter)
        {
            adminManager = new AdministratorManager();
            membershiplogin juser = JsonHelper.DeserializeJsonToObject<membershiplogin>(ehaiker_parameter);
            LoginMessage msg = new LoginMessage();
            msg.msg = "未知错误";
            msg.SuccessCode = "-1000";
            msg.UserLogUrl = "/Ehaiker/memshiplogin";
            if (ModelState.IsValid)
            {
                if (System.Web.HttpContext.Current.Session["ValidateCode"].ToString() != juser.verificat_code)
                {
                    ModelState.AddModelError("code", "validate code is error");
                    msg.msg = "验证码错误";
                    msg.SuccessCode = "10000";
                    return new JsonResult {
                        Data =JsonHelper.SerializeObject(msg),
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                        ContentEncoding = Encoding.UTF8 };
                }
                string _passowrd = Security.Sha256(juser.Password);
                var _response = adminManager.Verify(juser.Account, _passowrd);
                if (_response == 1)
                {
                    var _admin = adminManager.Find(juser.Account);

                    _admin.LoginTime = DateTime.Now;
                    _admin.LoginIP = Request.RequestUri.Host.ToString();
                    adminManager.Update(_admin);
                    adminManager.SaveChanges();
                    //创建一个用户对象
                    Administrator jsonUserInfo = new Administrator(_admin);
                    //密码不能传到客户端---
                    jsonUserInfo.Password = "fuckyou!";
                    //创建Cookie对象
                    //将序列化之后的Json串以UTF-8编码，再存入Cookie
                    string adminsession = HttpUtility.UrlEncode(JsonHelper.SerializeObject(jsonUserInfo),
                        Encoding.GetEncoding("UTF-8"));

                    //写入session
                    System.Web.HttpContext.Current.Session.Add("AdminUser", adminsession);
                    //设置信息
                    msg.msg = "欢迎您";
                    msg.SuccessCode = "0";
                    msg.Account = juser.Account;
                    msg.UserInfoUrl = "/AdminHome/Index";
                    msg.UserLogUrl = "/Ehaiker/logout";
                    // msg.UserName = _admin.UserName;
                    //使用Form验证
                    UserInfo userData = new UserInfo();
                    userData.UserId = _admin.AdministratorID;
                    userData.GroupId = _admin.GroupId;
                    userData.UserName = _admin.Account;
                    userData.perItem = string.Format("userPermissionMenu_{0}", userData.GroupId);
                    userData.perskey = string.Format("userPermission_{0}", userData.GroupId);
                    // msg.VIPLevel = _admin.VIPLevel;
                    // 登录状态10分钟内有效
                    MyFormsPrincipal<UserInfo>.SignIn(_admin.Account, userData, 100, juser.is_auto);
                    //读取权限
                    RoleService sSVR = new RoleService();
                    List<Permission> lp = null;
                    if (userData.GroupId == 1)
                    {
                        lp = sSVR.GetPermissions();
                    }
                    else
                    {
                        lp = sSVR.GetGroupPermissions(userData.GroupId);
                    };
                    List<MenuItem> ls = sSVR.GetFormatMgrMenu(lp);
                    HttpRuntime.Cache.Insert(userData.perskey, lp);
                    HttpRuntime.Cache.Insert(userData.perItem, ls);
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
            return new JsonResult {
                Data = msg,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                ContentEncoding = Encoding.UTF8
            };
        }
        [System.Web.Mvc.HttpPost]
        public JsonResult memshiplogin(string ehaiker_parameter)
        {
            
        // FormCollection collection；
        memberManager = new MemberShipManager();
            membershiplogin juser = JsonHelper.DeserializeJsonToObject<membershiplogin>(ehaiker_parameter);
            LoginMessage msg = new LoginMessage();
            msg.msg = "未知错误";
            msg.SuccessCode = "-1000";
            msg.UserLogUrl = "/Ehaiker/memshiplogin";
            if (ModelState.IsValid)
            {

                if (HttpContext.Current.Session["ValidateCode"].ToString() != juser.verificat_code)
                {
                    ModelState.AddModelError("code", "validate code is error");
                    msg.msg = "验证码错误";
                    msg.SuccessCode = "10000";
                    return new JsonResult{Data = msg,
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                        ContentEncoding = Encoding.UTF8
                    };
                }
                string _passowrd = Security.Sha256(juser.Password);
                var _response = memberManager.Verify(juser.Account, _passowrd);
                if (_response == 1)
                {
                    var _admin = memberManager.Find(juser.Account);

                    _admin.LoginTime = DateTime.Now;
                    _admin.LoginIP = Request.RequestUri.Host.ToString();

                    memberManager.Update(_admin);
                    memberManager.SaveChanges();
                    //创建一个用户对象
                    MemberShip jsonUserInfo = new MemberShip(_admin);
                    //写入session
                    MemUserDataManager.AddSessionData( "memshipUserInfo", jsonUserInfo);
                    MemberShipInfomationRepository memship = new MemberShipInfomationRepository();
                    var user = memship.GetDbSet().FirstOrDefault(r => r.UserId == _admin.UserId);
                    if (user != null)
                    {
                        MemUserDataManager.AddSessionData("memshipUserInfomation", user);
                        msg.UMoney = user.UMoney;
                        msg.TMoney = user.TMoney;
                    }
                    //设置信息
                    msg.msg = "欢迎您";
                    msg.SuccessCode = "0";
                    msg.Account = juser.Account;
                    msg.UserInfoUrl = "/personal";
                    msg.UserLogUrl = "/Ehaiker/logout";
                    msg.UserName = _admin.UserName;
                    msg.VIPLevel = _admin.VIPLevel;
                    msg.UserId = _admin.UserId;
                    //使用Form验证
                    UserInfo userData = new UserInfo();
                    userData.UserId = _admin.UserId;
                    userData.GroupId = 1;
                    userData.UserName = _admin.UserName;
                    userData.perItem = string.Format("userPermissionMenu_{0}", userData.UserId);
                    userData.perskey = string.Format("userPermission_{0}", userData.UserId);
                    // 登录状态100分钟内有效
                    MyFormsPrincipal<UserInfo>.SignIn(_admin.UserName, userData, 100, juser.is_auto);
                    //读取权限
                    RoleService sSVR = new RoleService();
                    List<Permission> lp = sSVR.GetPermissionById(userData.UserId);
                    List<MenuItem> ls = sSVR.GetFormatMenu(lp);
                    HttpRuntime.Cache.Insert(userData.perskey, lp);
                    HttpRuntime.Cache.Insert(userData.perItem, ls);
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
            return new JsonResult { Data = msg, JsonRequestBehavior = JsonRequestBehavior.AllowGet, ContentEncoding = Encoding.UTF8 };
        }
    }
}
