using ehaiker.Models;
using ehaiker.SMS;
using ehaikerv202010;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;

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
                return RedirectToAction("Index", "EHaiker");
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
            HttpContext.Session.SetString("ValidateSMSCode", code);
            return Json(ret);
        }
        [HttpPost]
        public JsonResult SmsSendEmail(string ehaiker_parameter)
        {
            SMSCode juser = JsonHelper.DeserializeJsonToObject<SMSCode>(ehaiker_parameter);
            //验证发送的短信验证码：
            ValidateCode vCode = new ValidateCode();
            string code = vCode.CreateValidateCode(6);
            string ret = "";
            bool bsend = SendEmail(juser.Account, code);
            if (bsend)
            {
                ret = "0";
            }
            HttpContext.Session.SetString("ValidateEmailCode", code);
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

                if (HttpContext.Session.GetString("ValidateCode") == null || HttpContext.Session.GetString("ValidateCode") != juser.verificat_code)
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
                if (memberManager.HasAccounts(juser.Account) == false)
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
                    newUserInfo.UserGuid = Guid.NewGuid().ToString();
                    //保存到数据库
                    memberManager.Add(newUserInfo);
                    if (memberManager.SaveChanges() > 0)
                    {
                        //插入用户信息
                        MemberShipInfomation userinfomation = new MemberShipInfomation();
                        userinfomation.UserGuid = newUserInfo.UserGuid;
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
                //Emailcode ValidateEmailCode
                if (HttpContext.Session.GetString("ValidateEmailCode") == null || HttpContext.Session.GetString("ValidateEmailCode") != juser.verificat_smscode)
                {
                    ModelState.AddModelError("code", "validate code is error");
                    msg.msg = "邮箱验证码错误";
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
                    newUserInfo.MobilePhone = "13418185408";
                    newUserInfo.LastSignTime = DateTime.Now;
                    newUserInfo.UserGuid = Guid.NewGuid().ToString();
                    //保存到数据库
                    memberManager.Add(newUserInfo);
                    if (memberManager.SaveChanges() > 0)
                    {
                        //插入用户信息
                        MemberShipInfomation userinfomation = new MemberShipInfomation();
                        userinfomation.UserGuid = newUserInfo.UserGuid;
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
        private bool SendEmail(string email, string activeCode)
        {
            MailMessage mailmsg = new MailMessage();
            mailmsg.From = new MailAddress("lixingshunnick@126.com");
            mailmsg.To.Add(email);
            mailmsg.Subject = "欢迎注册本站用户";
            StringBuilder contentBuilder = new StringBuilder();
            contentBuilder.Append("欢迎注册本站用户");
            string url = string.Format(@"你的验证码为:{0}", activeCode);
            contentBuilder.Append(url);
            // HtmlEncode();

            mailmsg.Body = contentBuilder.ToString();
            mailmsg.IsBodyHtml = false;
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.126.com";
            client.Port = 25;
            NetworkCredential credetial = new NetworkCredential();
            credetial.UserName = "lixingshunnick";
            credetial.Password = "UTXGEJFQTCJNDAHQ";
            client.Credentials = credetial;
            try
            {
                client.Send(mailmsg);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }

}
