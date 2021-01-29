using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ehaiker.Models;
using System.Text;
using ehaiker;
using System.Runtime.Remoting.Messaging;
using System.Web.Security;
using ehaiker.Auth;

namespace ehaiker.Controllers
{
    [Description(No = 1, Name = "首页功能")]
    public class EHaikerController : Controller
    {
        private MemberShipManager memberManager;
        private GameListManager GamelistManager;
        private SupplierListManager SupplierlistMgr;
        // GET: /EHaiker/
       
        public ActionResult Index()
        {
            //没有登录
            MemberShip cookie = MemUserDataManager.GetMemSessionData<MemberShip>("memshipUserInfo");
            if(cookie != null)
            {
                //从Cookie对象中取出Json串
                return View("Index", cookie);
            }
            else
            {
                MemberShip user = new MemberShip() { UserName = "游客", UserId = 0, Password = "0" };

                return View("Index", user);
            }
        }
        public ActionResult Login()
        {
            //没有登录
            MemberShip cookie = MemUserDataManager.GetMemSessionData<MemberShip>("memshipUserInfo");
            if(cookie != null)
            {
                //从Cookie对象中取出Json串
                return RedirectToRoute(new {Controller="Personal",Action="Index" });
            }
            else
            {
                MemberShip user = new MemberShip() { UserName = "游客", UserId = 0, Password = "0" };

                return View("Login", user);
            }
        }
       
        public ActionResult Logout()
        {
            //没有登录
            MemUserDataManager.RemoveSessionData("memshipUserInfo");
            Session.Clear();
             MemberShip user = new MemberShip() { UserName = "游客", UserId = 0, Password = "0" };
            //Forms验证
             FormsAuthentication.SignOut();
             return View("Index", user);
            
        }
        //会员登录---
      //  [AllowAnonymous]
       // [ValidateAntiForgeryToken]
        [HttpPost]
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
               
                if (Session["ValidateCode"].ToString() != juser.verificat_code)
                {
                    ModelState.AddModelError("code", "validate code is error");
                    msg.msg = "验证码错误";
                    msg.SuccessCode = "10000";
                    return Json(msg);
                }
                string _passowrd = Security.Sha256(juser.Password);
                var _response = memberManager.Verify(juser.Account, _passowrd);
                if (_response == 1)
                {
                    var _admin = memberManager.Find(juser.Account);
                   
                    _admin.LoginTime = DateTime.Now;
                    _admin.LoginIP = Request.UserHostAddress;
                   
                    memberManager.Update(_admin);
                    memberManager.SaveChanges();
                    //创建一个用户对象
                    MemberShip jsonUserInfo = new MemberShip(_admin);
                    //写入session
                    MemUserDataManager.AddSessionData("memshipUserInfo", jsonUserInfo);
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
                   userData.UserId=_admin.UserId;
                   userData.GroupId=1;
                    userData.UserName = _admin.UserName;
                    userData.perItem = string.Format("userPermissionMenu_{0}", userData.UserId);
                    userData.perskey = string.Format("userPermission_{0}", userData.UserId);
                    // 登录状态100分钟内有效
                    MyFormsPrincipal<UserInfo>.SignIn(_admin.UserName, userData, 100,juser.is_auto);
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
            return Json(msg, JsonRequestBehavior.AllowGet);
        }
        //---------------------------------游戏推荐--
        [HttpPost]
        public JsonResult GameTopMost(int type = 0)
        {
            GamelistManager = new GameListManager();
            if (type == 0)
            {
               var tt = GamelistManager.List();
               return Json(tt);
            }
            else
            {
                //取前8条记录
                var tt = GamelistManager.GetDbSet().Where(r => r.Gametype == type).Take(8).ToList();
                return Json(tt);
            }
            
            
        }
        //火爆推荐
        [HttpPost]
        public JsonResult GameHotItems()
        {
            GamelistManager = GamelistManager !=null ? GamelistManager : new GameListManager();
            var tt = GamelistManager.GetDbSet().GroupBy(r=>r.TopLevel).Take(8).ToList();
            return Json(tt);
        }
            //游戏攻略推荐
        [HttpPost]//GameStrategies
        public JsonResult GetGameStrategies(int page = 1, int rows = 5, int type = 0)
        {
            GameStrategiesRepository _noteRepository;
            _noteRepository = new GameStrategiesRepository();
            var query = new List<GameStrategies>();
            if (type == 0)
            {
                query = _noteRepository.GetDbSet().ToList();


            }
            else
            {
                query = _noteRepository.GetDbSet().Where(r => r.GameId == type).Take(5).ToList();
            }
            var count = query.Count();
            var pagecount = count % rows == 0 ? count / rows : count / rows + 1;
            var notes = query.OrderByDescending(r => r.CreateTime)
                .Skip((page - 1) * rows)
                .Take(rows)
                .ToList();
            return Json(notes);
        }
        //供应商
        //火爆推荐
        [HttpPost]
        public JsonResult getSupplierInfo()
        {
            SupplierlistMgr = new SupplierListManager();
            var tt = SupplierlistMgr.List().Take(6).ToList();
            return Json(tt);
        }
        /// <summary>
        /// 获取用户签到信息
        /// </summary>
        /// <returns></returns>
        [Description(No = 1, Name = "获取签到状态")]
        public JsonResult GetSignStatus()
        {
            LoginMessage msg = new LoginMessage();
            msg.msg = "未知错误";
            msg.SuccessCode = "-10000";

            string controllerName = RouteData.Values["Controller"].ToString();
            string actionName = RouteData.Values["Action"].ToString();
            msg.UserLogUrl = controllerName + actionName;
            //在cookie中查询用户信息
            MemberShip sessionUser = MemUserDataManager.GetMemSessionData<MemberShip>("memshipUserInfo");
            if (sessionUser != null)
            {
                if (sessionUser == null)
                {
                    return Json(msg, JsonRequestBehavior.AllowGet);
                }
                //获取最近登录的时间
                DateTime signtime = (DateTime)sessionUser.LastSignTime;
                if (DateTime.Now.Day -signtime.Day == 0 && signtime.Month == DateTime.Now.Month)
                {
                    msg.SuccessCode = "10000";
                    //已经签到
                    return Json(msg, JsonRequestBehavior.AllowGet);
                }
            }

            //判断用户登录情况，到会员表查询2个数据
            return Json(msg, JsonRequestBehavior.AllowGet);
        }
        //用户签到
        [Description(No = 2, Name = "签到")]
        [AuthAuthorizeAttribute]
        public JsonResult SiginClick()
        {
            LoginMessage msg = new LoginMessage();
            msg.msg = "未知错误";
            msg.SuccessCode = "-1000";

            string controllerName = RouteData.Values["Controller"].ToString();
            string actionName = RouteData.Values["Action"].ToString();
            msg.UserLogUrl = controllerName + actionName;
            //在cookie中查询用户信息
            MemberShip sessionUser = MemUserDataManager.GetMemSessionData<MemberShip>("memshipUserInfo");
            if (sessionUser != null)
            {
                
                //已经签到
                DateTime signtime = (DateTime)sessionUser.LastSignTime;
                if (DateTime.Now.Day - signtime.Day == 0 && signtime.Month == DateTime.Now.Month)
                {
                    msg.SuccessCode = "30000";
                    //已经签到
                    return Json(msg, JsonRequestBehavior.AllowGet);
                }//增加连续签到天数
                else if (signtime.Month == DateTime.Now.Month && DateTime.Now.Day-signtime.Day == 1)
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
                MemberShipManager mManager = new MemberShipManager();
                mManager.Update(sessionUser);
                mManager.SaveChanges();
            }
            //判断用户登录情况，到会员表查询2个数据
            return Json(msg, JsonRequestBehavior.AllowGet);
        }
        //获取用户信息
        [Description(No = 3, Name = "获取用户信息")]
        [AuthAuthorizeAttribute]
        public JsonResult GetUserInfo()
        {
            LoginMessage msg = new LoginMessage();
            msg.msg = "未知错误";
            msg.SuccessCode = "-1000";
            MemberShipInfomation sessionUserInfo = MemUserDataManager.GetMemSessionData<MemberShipInfomation>("memshipUserInfomation");
            if (sessionUserInfo != null)
            {
                msg.SuccessCode = "30000";
                msg.UMoney = sessionUserInfo.UMoney;
                msg.TMoney = sessionUserInfo.TMoney;
            }
            return Json(msg, JsonRequestBehavior.AllowGet);
        }
        //验证码
        public ActionResult GetValidateCode()
        {
            ValidateCode vCode = new ValidateCode();
            string code = vCode.CreateValidateCode(5);
            Session["ValidateCode"] = code;
            byte[] bytes = vCode.CreateValidateGraphic(code);
            return File(bytes, @"image/jpeg");
        }
    }
}
