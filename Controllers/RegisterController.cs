using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ehaiker.Models;
using System.Text;
using ehaiker;
using ehaiker.SMS;
using Microsoft.AspNetCore.Mvc;
using ehaikerv202010;
using Microsoft.AspNetCore.Http;

namespace ehaiker.Controllers
{
    public class RegisterController : Controller
    {
        private MemberShipManager memberManager;
        private EhaikerContext DbContext;
        public RegisterController(EhaikerContext _cont)
        {
            DbContext = _cont;


        }
        public ActionResult Index()
        {
            //没有登录
            Object cookie = HttpContext.Session.GetString("memshipUserInfo");
            if (cookie != null)
            {
                //从Cookie对象中取出Json串
                string jsonUserInfo = HttpUtility.UrlDecode(cookie.ToString(), Encoding.GetEncoding("UTF-8"));
                MemberShip juser = JsonHelper.DeserializeJsonToObject<MemberShip>(jsonUserInfo);
                return RedirectToAction("Index","EHaiker");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public JsonResult SmsSend(string ehaiker_parameter)
        {
            HttpContext.Session.SetString("ValidateSMSCode", "1111");
            return Json("11100");//暂时未开通短信注册
            SMSCode juser = JsonHelper.DeserializeJsonToObject<SMSCode>(ehaiker_parameter);
            //验证发送的短信验证码：
            ValidateCode vCode = new ValidateCode();
            string code = vCode.CreateValidateCode(6);
            string ret = ECloundHelper.sendSmsCode(juser.Account, 1, code);
            HttpContext.Session.SetString("ValidateSMSCode",  code);
            return Json(ret);
        }
        [HttpPost]
        public JsonResult SmsRegister(string ehaiker_parameter)
        {

            // FormCollection collection；
            memberManager = new MemberShipManager(DbContext);
            membershiplogin juser = JsonHelper.DeserializeJsonToObject<membershiplogin>(ehaiker_parameter);
            LoginMessage msg = new LoginMessage();
            msg.msg = "未知错误";
            msg.SuccessCode = "-1000";
            msg.UserLogUrl = "/Account/Index";
            if (ModelState.IsValid)
            {
                
                if (HttpContext.Session.GetString("ValidateCode")== null || HttpContext.Session.GetString("ValidateCode") != juser.verificat_code)
                {
                    ModelState.AddModelError("code", "validate code is error");
                    msg.msg = "验证码错误";
                    msg.SuccessCode = "10000";
                    return Json(msg);
                }
                //验证手机验证码---
                if (HttpContext.Session.GetString("ValidateSMSCode") == null || HttpContext.Session.GetString("ValidateSMSCode") != juser.verificat_smscode)
                {
                    ModelState.AddModelError("code", "validate code is error");
                    msg.msg = "手机验证码错误";
                    msg.SuccessCode = "10000";
                    return Json(msg);
                }
                string _passowrd = Security.Sha256(juser.Password);
                if (memberManager.HasAccounts(juser.Account) == false  )
                {
                    //创建一个用户对象
                    MemberShip newUserInfo = new MemberShip();
                    newUserInfo.CreateTime = DateTime.Now;
                    newUserInfo.LoginTime = DateTime.Now;
                    newUserInfo.LoginIP = Request.Host.Host;
                    newUserInfo.MobilePhone = juser.MobilePhone;
                    newUserInfo.Account = juser.Account;
                    newUserInfo.Password = _passowrd;
                    newUserInfo.UserName = juser.Account;
                    newUserInfo.VIPLevel = 0;
                    newUserInfo.LastSignTime = DateTime.Now;
                   //保存到数据库
                    memberManager.Add(newUserInfo);
                    if (memberManager.SaveChanges()>0)
                    {
                        //插入用户信息
                        MemberShipInfomation userinfomation = new MemberShipInfomation();
                        userinfomation.UserId = newUserInfo.UserId;
                        userinfomation.isValid = 0;
                        MemberShipInfomationRepository _ptrInfos = new MemberShipInfomationRepository(DbContext);
                        _ptrInfos.Add(userinfomation);
                        _ptrInfos.SaveChanges(); 
                        //增加session
                        string sessionuserInfomation = HttpUtility.UrlEncode(JsonHelper.SerializeObject(userinfomation),
                      Encoding.GetEncoding("UTF-8"));
                        HttpContext.Session.SetString("memshipUserInfomation", sessionuserInfomation);
                    }
                    //创建Cookie对象
                    MemUserDataManager.AddSessionData(HttpContext,"memshipUserInfo", newUserInfo);
                    //设置信息
                    msg.msg = "欢迎您";
                    msg.SuccessCode = "0";
                    msg.Account = juser.Account;
                    msg.UserInfoUrl = "/personal";
                    msg.UserLogUrl = "/Account/logout";
                    msg.UserName = newUserInfo.UserName;
                    msg.VIPLevel = newUserInfo.VIPLevel;
                    msg.MobilePhone = newUserInfo.MobilePhone;
                }
                else 
                {
                    msg.msg = "用户已经存在";
                    msg.SuccessCode = "10001";
                    ModelState.AddModelError("account", "用户不存在");
                }
                
            }
            return Json(msg);
        }
        [HttpPost]
        public JsonResult EmailRegister(string ehaiker_parameter)
        {

            // FormCollection collection；
            memberManager = new MemberShipManager(DbContext);
            membershiplogin juser = JsonHelper.DeserializeJsonToObject<membershiplogin>(ehaiker_parameter);
            LoginMessage msg = new LoginMessage();
            msg.msg = "未知错误";
            msg.SuccessCode = "-1000";
            msg.UserLogUrl = "/Account/Index";
            if (ModelState.IsValid)
            {

                if (HttpContext.Session.GetString("ValidateCode") == null || HttpContext.Session.GetString("ValidateCode") != juser.verificat_code)
                {
                    ModelState.AddModelError("code", "validate code is error");
                    msg.msg = "验证码错误";
                    msg.SuccessCode = "10000";
                    return Json(msg);
                }
               
                if (memberManager.HasAccounts(juser.Account) == false)
                {
                    string _passowrd = Security.Sha256(juser.Password);
                    //创建一个用户对象
                    MemberShip newUserInfo = new MemberShip();
                    newUserInfo.CreateTime = DateTime.Now;
                    newUserInfo.LoginTime = newUserInfo.CreateTime;
                    newUserInfo.LoginIP = HttpContext.Connection.RemoteIpAddress.MapToIPv4()?.ToString();
                    newUserInfo.Account = juser.Account;
                    newUserInfo.Password = _passowrd;
                    newUserInfo.UserName = juser.Account;
                    newUserInfo.VIPLevel = 0;
                    newUserInfo.MobilePhone ="13418185408";
                    newUserInfo.LastSignTime = DateTime.Now;
                    //保存到数据库
                    memberManager.Add(newUserInfo);
                    if (memberManager.SaveChanges() > 0)
                    {
                        //插入用户信息
                        MemberShipInfomation userinfomation = new MemberShipInfomation();
                        userinfomation.UserId = newUserInfo.UserId;
                        userinfomation.isValid = 0;
                        MemberShipInfomationRepository _ptrInfos = new MemberShipInfomationRepository(DbContext);
                        _ptrInfos.Add(userinfomation);
                        _ptrInfos.SaveChanges();
                        //增加session
                        string sessionuserInfomation = HttpUtility.UrlEncode(JsonHelper.SerializeObject(userinfomation),
                      Encoding.GetEncoding("UTF-8"));
                        MemUserDataManager.AddSessionData(HttpContext, "memshipUserInfomation", sessionuserInfomation);
                    }
                    
                    //将写入到客户端
                    MemUserDataManager.AddSessionData(HttpContext, "memshipUserInfo", newUserInfo);
                    //设置信息
                    msg.msg = "欢迎您";
                    msg.SuccessCode = "0";
                    msg.Account = juser.Account;
                    msg.UserInfoUrl = "/personal";
                    msg.UserLogUrl = "/Account/logout";
                    msg.UserName = newUserInfo.UserName;
                    msg.VIPLevel = newUserInfo.VIPLevel;
                    msg.MobilePhone = newUserInfo.MobilePhone;
                }
                else
                {
                    msg.msg = "用户已经存在";
                    msg.SuccessCode = "10001";
                    ModelState.AddModelError("account", "用户不存在");
                }

            }
            return Json(msg);
        }
    }
    
}
