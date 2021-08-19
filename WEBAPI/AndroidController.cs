using ehaiker;
using ehaiker.Models;
using ehaikerv202010.Filters;
using ehaikerv202010.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ehaikerv202010.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class AndroidController : ControllerBase
    {
        private EhaikerContext DbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AndroidController(EhaikerContext _cont, IHttpContextAccessor httpContextAccessor)
        {
            DbContext = _cont;
            _httpContextAccessor = httpContextAccessor;
        }
       [HttpPost]
        public JsonResult Login(string ehaiker_parameter)
        {
            string value = HttpContext.Request.Form["ehaiker_parameter"];
            membershiplogin juser = JsonHelper.DeserializeJsonToObject<membershiplogin>(value);
            LoginMessage msg = new LoginMessage();
            msg.msg = "未知错误";
            msg.SuccessCode = "-1000";
            msg.UserLogUrl = HttpContext.Session.GetString("ValidateCode");
              if (ModelState.IsValid)
            {

                if (HttpContext.Session.GetString("ValidateCode") != juser.verificat_code)
                {
                    ModelState.AddModelError("code", "validate code is error");
                    msg.msg = "验证码错误";
                    msg.SuccessCode = "10000:" + HttpContext.Session.GetString("ValidateCode");
                    msg.Account = juser.Account;
                    return new JsonResult(msg);
                }
                string _passowrd = Security.Sha256(juser.Password);
                MemberShipManager ship = new MemberShipManager(DbContext);
                var _response = ship.Verify(juser.Account, _passowrd);
                if (_response == 1)
                {
                    var _admin = ship.Find(juser.Account);
                    //判断是否为重复登录
                    if (_admin.LoginGuid != Guid.Empty)
                    {
                        //已经登录，清空session，重新登录
                        MemUserDataManager.RemoveSessionData(HttpContext, "memshipUserInfo");
                        HttpContext.Session.Clear();
                    }


                    _admin.LoginTime = DateTime.Now;
                    // _admin.LoginIP = HttpContext.Connection.RemoteIpAddress.MapToIPv4()?.ToString();
                    _admin.LoginIP = HttpContext.Request.Headers["X-Real-IP"].FirstOrDefault();
                    _admin.LoginGuid = Guid.NewGuid();
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
                    MemberShipInfomation UserInfo = UserInfoMgr.GetById(_admin.UserId);
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
            return new JsonResult(msg);
        }
        //////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 验证码生成
        /// </summary>
        /// <returns></returns>
        //验证码
        [HttpGet]
        public ActionResult GetValidateCode()
        {
            ValidateCode vCode = new ValidateCode();
            string code = vCode.CreateValidateCode(5);
            HttpContext.Session.SetString("ValidateCode", code); //HttpContext.Session.GetString("ValidateCode")
            byte[] bytes = vCode.CreateValidateGraphic(code);
            return File(bytes, @"image/jpeg");
        }
        [HttpPost]
        [LoginStateRequiredAttribute]
        public JsonResult AddNewGameStrage(string Item_parameter)
        {
            int errorCode = 0;
            string errMsg = "操作失败！";
            string value = HttpContext.Request.Form["Item_parameter"];
            if (ModelState.IsValid)
            {
                GameStrategies gameItem = JsonHelper.DeserializeJsonToObject<GameStrategies>(value);
                if (gameItem != null)
                {
                    MemberShip cookie = MemUserDataManager.GetMemSessionData<MemberShip>(HttpContext, "memshipUserInfo");

                    GameStrategiesRepository GamelistManager = new GameStrategiesRepository(DbContext);
                    //
                    gameItem.CreateTime = DateTime.Now;
                    gameItem.LastEditTime = DateTime.Now;
                    gameItem.readers = 1;
                    //防止脚本注入
                    if (!string.IsNullOrEmpty(gameItem.Title))
                        gameItem.Title = System.Text.RegularExpressions.Regex.Replace(gameItem.Title, "/(?!<(img|p|span).*?>)<.*?>/g", "");
                    if (!string.IsNullOrEmpty(gameItem.Content))
                        gameItem.Content = System.Text.RegularExpressions.Regex.Replace(gameItem.Content, "/(?!<(img|p|span).*?>)<.*?>/g", "");
                    //作者
                    gameItem.Author = cookie.Account;
                    gameItem.AuthorID = cookie.UserId;
                    gameItem.IsIdentified = 0;
                    GamelistManager.Add(gameItem);
                    GamelistManager.SaveChanges();
                    errMsg = "操作成功";
                    var retjson = new { ErrorCode = errorCode, iSuccessCode = 0, msg = errMsg };
                    return new JsonResult(retjson);
                }
            }
            var tt = new { ErrorCode = 10000, msg = "未知错误" };
            return new JsonResult(tt);
        }
        [HttpGet]
        public JsonResult Loginq1()
        {
            LoginMessage msg = new LoginMessage();
            msg.msg = "未知错误";
            msg.SuccessCode = HttpContext.Session.GetString("ValidateCode");
            msg.UserLogUrl = "";
            return new JsonResult(msg);
        }
    }
}
