using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ehaiker.Models;
using System.Net.Mail;
using System.Text;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using ehaikerv202010;
using ehaiker.SMS;

namespace ehaiker.Controllers
{
    public class ServicesCenterController : Controller
    {
        private EhaikerContext DbContext;
        public ServicesCenterController(EhaikerContext _cont)
        {
            DbContext = _cont;
        }
        //
        // GET: /ServicesCenter/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ForgetPassword()
        {
            return View();
        }
        public ActionResult ManageForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public JsonResult SmsSend(string ehaiker_parameter)
        {

            HttpContext.Session.Set("ValidateSMSCode", Encoding.Default.GetBytes("1111"));
          //  return Json("11100");//暂时未开通短信注册
            SMSCode juser = JsonHelper.DeserializeJsonToObject<SMSCode>(ehaiker_parameter);
            //验证发送的短信验证码：
            ValidateCode vCode = new ValidateCode();
            string code = vCode.CreateValidateCode(6);
            string ret = ECloundHelper.sendSmsCode(juser.Account, 1, code);
            HttpContext.Session.Set("ValidateSMSCode", Encoding.Default.GetBytes(code));
            return Json(ret);
        }
        [HttpPost]
        public JsonResult Mail_ForgetPassword(string ehaiker_parameter)
        {
            membershiplogin juser = JsonHelper.DeserializeJsonToObject<membershiplogin>(ehaiker_parameter);
            LoginMessage msg = new LoginMessage();
            msg.msg = "发送成功";
            msg.SuccessCode = "0";
            msg.UserLogUrl = "/Account/Index";
            SendEmail(juser.Account, "10000",juser);
            return Json(msg);
        }
        [HttpPost]
        public JsonResult Mail_ManagerForgetPassword(string ehaiker_parameter)
        {
            membershiplogin juser = JsonHelper.DeserializeJsonToObject<membershiplogin>(ehaiker_parameter);
            LoginMessage msg = new LoginMessage();
            msg.msg = "发送成功";
            msg.SuccessCode = "0";
            msg.UserLogUrl = "/Account/Index";
            SendEmail(juser.Account, "10000", juser,true);
            return Json(msg);
        }
        [HttpPost]
        public JsonResult SmsForgetPassword(string ehaiker_parameter)
        {
            membershiplogin juser = JsonHelper.DeserializeJsonToObject<membershiplogin>(ehaiker_parameter);
            LoginMessage msg = new LoginMessage();
            msg.msg = "发送成功";
            msg.SuccessCode = "0";
            msg.UserLogUrl = "/Account/Index";
            byte[] sessionobj;
            HttpContext.Session.TryGetValue("ValidateCode", out sessionobj);
            if (sessionobj == null || sessionobj.ToString() != juser.verificat_code)
            {
                ModelState.AddModelError("code", "validate code is error");
                msg.msg = "验证码错误";
                msg.SuccessCode = "10000";
                return Json(msg);
            }
            //验证手机验证码---
            HttpContext.Session.TryGetValue("ValidateSMSCode", out sessionobj);
            if (sessionobj == null || sessionobj.ToString() != juser.verificat_smscode)
            {
                ModelState.AddModelError("code", "validate code is error");
                msg.msg = "手机验证码错误";
                msg.SuccessCode = "10000";
                return Json(msg);
            }
            MemberShipManager memberManager = new MemberShipManager(DbContext);
             string _passowrd = Security.Sha256(juser.Password);
                var _response = memberManager.Verify(juser.Account, _passowrd);
                if (_response == 1)
                {
                    var _admin = memberManager.Find(juser.Account);
                    if (_admin != null)
                    {
                        memberManager.ChangePassword(_admin.UserId, Security.Sha256("1234567"));
                    }
                    msg.msg = "密码已经重置为默认，请登录修改";
                    msg.SuccessCode = "0";
                }
            return Json(msg);
        }
        [HttpPost]
        public JsonResult SmsForgetPasswordEx(string ehaiker_parameter)
        {
            membershiplogin juser = JsonHelper.DeserializeJsonToObject<membershiplogin>(ehaiker_parameter);
            LoginMessage msg = new LoginMessage();
            msg.msg = "发送成功";
            msg.SuccessCode = "0";
            msg.UserLogUrl = "/Account/Index";
            byte[] sessionobj;
            HttpContext.Session.TryGetValue("ValidateCode", out sessionobj);
            if (sessionobj == null || sessionobj.ToString() != juser.verificat_code)
            {
                ModelState.AddModelError("code", "validate code is error");
                msg.msg = "验证码错误";
                msg.SuccessCode = "10000";
                return Json(msg);
            }
            //验证手机验证码---
            HttpContext.Session.TryGetValue("ValidateSMSCode", out sessionobj);
            if (sessionobj == null || sessionobj.ToString() != juser.verificat_smscode)
            {
                ModelState.AddModelError("code", "validate code is error");
                msg.msg = "手机验证码错误";
                msg.SuccessCode = "10000";
                return Json(msg);
            }
            AdministratorManager adminManager = new AdministratorManager(DbContext);
            string _passowrd = Security.Sha256(juser.Password);
            var _response = adminManager.Verify(juser.Account, _passowrd);
            if (_response == 1)
            {
                var _admin = adminManager.Find(juser.Account);
                if (_admin != null)
                {
                    adminManager.ChangePassword(_admin.AdministratorID, Security.Sha256("1234567"));
                }
                msg.msg = "密码已经重置为默认，请登录修改";
                msg.SuccessCode = "0";
            }
            return Json(msg);
        }
        //邮箱修改密码
        public ActionResult ResetPassword(int userID, int resetcode,string a)
        {
            string secretparam = System.Web.HttpUtility.UrlDecode(a, System.Text.Encoding.GetEncoding("UTF-8"));
            if (userID == 0 || resetcode != 10000)
                return Redirect("../static/failed.html");

            MemberShipManager memberManager = new MemberShipManager(DbContext);
            var _admin = memberManager.GetDbSet().Where(r=>r.UserId==userID && r.Account==secretparam ).FirstOrDefault();
            if (_admin != null)
            {
                memberManager.ChangePassword(userID, Security.Sha256("1234567"));
            }
            return Redirect("../static/success.html");
        }



        //---发送邮件功能
        private void SendEmail(string email, string activeCode,membershiplogin juser,bool IsManager=false)
        {
            MailMessage mailmsg = new MailMessage();
            mailmsg.From = new MailAddress("lixingshunnick@126.com");
            mailmsg.To.Add(email);
            mailmsg.Subject = "请点击下面的链接完成密码重置";
            StringBuilder contentBuilder = new StringBuilder();
            contentBuilder.Append("请点击下面的链接完成密码重置");
            if (IsManager == true)
            {
                AdministratorManager adminManager = new AdministratorManager(DbContext);
                var _admin = adminManager.Find(juser.Account);
                string encodeparam = string.Format("{0}", _admin.Account);

                string url = string.Format(@"<a href='http://www.esometea.xyz/servicesCenter/ResetPasswordEx?userID={0}&resetcode={1}&a={2}'>重设密码</a>",
                    _admin.AdministratorID, 10000, System.Web.HttpUtility.UrlEncode(encodeparam, System.Text.Encoding.GetEncoding("UTF-8")));
                contentBuilder.Append(url);
            }
            else
            {
                MemberShipManager memberManager = new MemberShipManager(DbContext);
                var _admin = memberManager.Find(juser.Account);
                string encodeparam = string.Format("{0}", _admin.Account);

                string url = string.Format(@"<a href='http://www.esometea.xyz/servicesCenter/ResetPassword?userID={0}&resetcode={1}&a={2}'>重设密码</a>",
                    _admin.UserId, 10000, System.Web.HttpUtility.UrlEncode(encodeparam, System.Text.Encoding.GetEncoding("UTF-8")));
                contentBuilder.Append(url);
            }
          
           // HtmlEncode();
            
            mailmsg.Body = contentBuilder.ToString();
            mailmsg.IsBodyHtml = true;
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.126.com";
            client.Port = 25;
            NetworkCredential credetial = new NetworkCredential();
            credetial.UserName = "lixingshunnick";
            credetial.Password = "ehaiker126";
            client.Credentials = credetial;
            client.Send(mailmsg);

        }
    }
    public class SMSCode
    {
        public string Account { set; get; }
        public string action { set; get; }
        public string function { set; get; }
        public int result;
        public string msg { set; get; }
        public string trade_id { set; get; }
        public int pay_count { set; get; }
        public int success_count { set; get; }
    }
}
