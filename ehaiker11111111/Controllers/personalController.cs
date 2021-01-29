using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ehaiker.Models;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.IO;
using ehaiker.Auth;

namespace ehaiker.Controllers
{

    [MemberShipAuthorizeAttribute]
    [Description(No = 2, Name = "个人中心")]
    public class personalController : Controller
    {
       
        // GET: /personal/
       
        public ActionResult Index()
        {
            //没有登录
            MemberShip cookie = MemUserDataManager.GetMemSessionData<MemberShip>("memshipUserInfo");
            if (cookie != null)
            {
                return View(cookie);
            }
            else
            {
                MemberShip user = new MemberShip() { UserName = "游客", UserId = 0, Password = "0" };

                return View(user);
            }
        }
       
        [Description(No = 1, Name = "用户信息")]
        public ActionResult UserInfo()
        {

            MemberShip juser = MemUserDataManager.GetMemSessionData<MemberShip>("memshipUserInfo");
            return View(juser);
        }
        [Description(No = 2, Name = "支付中心")]
        public ActionResult PayBill()
        {
            MemberShip cookie = MemUserDataManager.GetMemSessionData<MemberShip>("memshipUserInfo");
            if (cookie != null)
            {
                return View(cookie);
            }
            return View();
        }
        [Description(No = 3, Name = "我的账单")]
        public ActionResult MyBill(int pageindex = 1, int pagesize = 10)
        {

            IRepository<PaybillApproveModel> _noteRepository = new PaybillApproveRepository(); ;
            int nCount = _noteRepository.List().Count();
            //
            if (nCount > 0)
            {
                var query = _noteRepository.List().AsQueryable();
                var count = query.Count();
                var pagecount = count % pagesize == 0 ? count / pagesize : count / pagesize + 1;
                var findItems = query.OrderByDescending(r => r.CreateTime)
                    .Skip((pageindex - 1) * pagesize)
                    .Take(pagesize)
                    .ToList();
                var notes = new Tuple<List<PaybillApproveModel>, int>(findItems, pagecount);
                ViewBag.PageCount = notes.Item2;//总页数
                ViewBag.PageIndex = pageindex;//当前页
                ViewBag.PageSize = pagesize;//页面显示
                ViewBag.PageUri = "../personal/MyBill";
                return View(notes.Item1);
            }
            ViewBag.PageCount = 1;//总页数
            ViewBag.PageIndex = 1;//当前页
            ViewBag.PageSize = pagesize;//页面显示
            ViewBag.PageUri = "../personal/MyBill";
            List<PaybillApproveModel> tlst = new List<PaybillApproveModel>();
            return View(tlst);
        }
        [Description(No = 4, Name = "新密码")]
        public ActionResult NewPassword()
        {
            return View();
        }
        [Description(No = 5, Name = "显示个人游戏分享")]
        public ActionResult show(int pageindex = 1, int pagesize = 10)
        {
            IRepository<GameStrategies> _noteRepository;
            IRepository<GameType> _noteTypeRepository;
            _noteRepository = new GameStrategiesRepository();
            _noteTypeRepository = new GameTypeRepository();
            int nCount = _noteRepository.List().Count();
            //
            MemberShip loginuser = MemUserDataManager.GetMemSessionData<MemberShip>("memshipUserInfo");
            if (loginuser != null && nCount > 0)
            {
                var query = _noteRepository.GetDbSet()
                    .Where(r => r.Author == loginuser.Account).AsQueryable();
                var count = query.Count();
                var pagecount = count % pagesize == 0 ? count / pagesize : count / pagesize + 1;
                var findItems = query.OrderByDescending(r => r.CreateTime)
                    .Skip((pageindex - 1) * pagesize)
                    .Take(pagesize)
                    .ToList();
                var notes = new Tuple<List<GameStrategies>, int>(findItems, pagecount);
                ViewBag.PageCount = notes.Item2;//总页数
                ViewBag.PageIndex = pageindex;//当前页
                ViewBag.PageSize = pagesize;//页面显示
                ViewBag.PageUri = "../personal/show";
                return View(notes.Item1);
            }
            ViewBag.PageCount = 1;//总页数
            ViewBag.PageIndex = 1;//当前页
            ViewBag.PageSize = pagesize;//页面显示
            ViewBag.PageUri = "../personal/show";
            List<GameStrategies> tlst = new List<GameStrategies>();
            return View(tlst);
            
        }
        [Description(No = 6, Name = "打开游戏分享界面")]
        public ActionResult Add()
        {
             IRepository<GameStrategies> _noteRepository;
             IRepository<GameType> _noteTypeRepository;
            _noteRepository = new GameStrategiesRepository();
            _noteTypeRepository = new GameTypeRepository();
            var types = _noteTypeRepository.List();
            GameStrategiesModel n = new GameStrategiesModel { Title = "请输入" };
            ViewBag.Types = types.Select(r => new SelectListItem { Text = r.Name, Value = r.GameId.ToString() });
            return View(n);
        }
        //用户修改密码
        [HttpPost]
        [Description(No = 7, Name = "激活密码功能",isGet=false)]
        public JsonResult NewPassWordEx(string ehaiker_parameter)
        {
            LoginMessage msg = new LoginMessage();
            msg.SuccessCode = "-1000";
            msg.msg = "未知错误";
            if (ModelState.IsValid)
            {
                MemberShip loginuser = MemUserDataManager.GetMemSessionData<MemberShip>("memshipUserInfo");
                if (loginuser != null)
                {
                   //网页端数据
                    membershiplogin juser = JsonHelper.DeserializeJsonToObject<membershiplogin>(ehaiker_parameter);
                    //验证数据
                    if( Session["ValidPassword_user_ehaiker"]==null||
                        string.IsNullOrEmpty( Session["ValidPassword_user_ehaiker"].ToString()) )
                    {
                        msg.msg = "非法用户";
                        return Json(msg, JsonRequestBehavior.AllowGet);
                    }
                    string valid = Session["ValidPassword_user_ehaiker"].ToString();
                    if (valid != juser.verificat_code)
                    {
                        msg.msg = "激活码有误";
                        return Json(msg, JsonRequestBehavior.AllowGet);;
                    }
                   //激活信密码
                    loginuser.Password = Security.Sha256(juser.Password);
                    IRepository<MemberShip> memshipMgr = new MemberShipManager();
                    memshipMgr.Update(loginuser);
                    memshipMgr.SaveChanges();
                    msg.SuccessCode = "0";
                    msg.msg = "密码激活成功";
                    //更新全局数据
                    MemUserDataManager.UpdateSessionData("memshipUserInfo", loginuser);
                }

            }

            return Json(msg, JsonRequestBehavior.AllowGet);
        }
        //PassValidMail
        [HttpPost]
        [Description(No = 8, Name = "发送激活邮件", isGet = false)]
        public JsonResult PassValidMail(string ehaiker_parameter)
        {
            LoginMessage msg = new LoginMessage();
            msg.SuccessCode = "-1000";
            msg.msg = "未知错误";
            if (ModelState.IsValid)
            {
                MemberShip loginuser = MemUserDataManager.GetMemSessionData<MemberShip>("memshipUserInfo");
                if (loginuser != null)
                {
                    IRepository<GameStrategies> _noteRepository;
                    IRepository<GameType> _noteTypeRepository;
                    _noteRepository = new GameStrategiesRepository();
                    _noteTypeRepository = new GameTypeRepository();
                    membershiplogin juser = JsonHelper.DeserializeJsonToObject<membershiplogin>(ehaiker_parameter);
                    //查看是否有该用户记录
                    //实时验证码
                    string validcode = Security.Sha256(string.Format("{0}{1}{2}", loginuser.UserId,
                        loginuser.Password, DateTime.Now.ToLongTimeString()));
                    var noticestring = 
                        string.Format("<h2>尊敬的{0},您好：</h2>您的新密码激活码为{1}，请前往会员中心激活第三步",
                        loginuser.UserName, validcode);
                    SendEmail(juser.Account, noticestring,"密码验证");
                    Session["ValidPassword_user_ehaiker"] = validcode;
                    msg.SuccessCode = "0";
                    msg.msg = "邮件发送成功";
                }
                else
                msg.msg = "非法用户";
            }

            return Json(msg, JsonRequestBehavior.AllowGet);
        }
        //增加一个游戏攻略
        [HttpPost]
        [Description(No = 9, Name = "增加游戏攻略文章", isGet = false)]
        public JsonResult Add(string ehaiker_parameter)
        {
            int ret = 0;
            string errMsg = "操作失败！";
            int errorCode = 0;
            if (ModelState.IsValid)
            {
                MemberShip loginuser = MemUserDataManager.GetMemSessionData<MemberShip>("memshipUserInfo");
                if (loginuser != null)
                {
                    IRepository<GameStrategies> _noteRepository;
                IRepository<GameType> _noteTypeRepository;
                _noteRepository = new GameStrategiesRepository();
                _noteTypeRepository = new GameTypeRepository();
                GameStrategies juser = JsonHelper.DeserializeJsonToObject<GameStrategies>(ehaiker_parameter);
                //设置相关系统
                juser.Author = loginuser.Account;
                juser.CreateTime=DateTime.Now;
                juser.LastEditTime=DateTime.Now;
                juser.Content =
                Microsoft.JScript.GlobalObject.unescape(juser.Content);
                juser.Content = System.Text.RegularExpressions.Regex.Replace(juser.Content, "/(?!<(img|p|span).*?>)<.*?>/g", "");
                _noteRepository.Add(juser);
                ret = _noteRepository.SaveChanges();
                errMsg = "操作成功";
                }
                
            }
            var retjson = new { ErrorCode = errorCode, iSuccessCode = ret, msg = errMsg };
            return Json(retjson, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [Description(No = 10, Name = "修改游戏分享文章", isGet = false)]
        public JsonResult Edit(string ehaiker_parameter)
        {
            int ret = 0;
            string errMsg = "操作失败！";
            int errorCode = 0;
            if (ModelState.IsValid)
            {
                MemberShip loginuser = MemUserDataManager.GetMemSessionData<MemberShip>("memshipUserInfo");
                if (loginuser != null)
                {
                    IRepository<GameStrategies> _noteRepository;
                    IRepository<GameType> _noteTypeRepository;
                    _noteRepository = new GameStrategiesRepository();
                    _noteTypeRepository = new GameTypeRepository();
                    GameStrategies juser = JsonHelper.DeserializeJsonToObject<GameStrategies>(ehaiker_parameter);
                    //设置相关系统
                    var notes = _noteRepository.GetDbSet().Where(r => r.Id == juser.Id &&
                    r.Author == loginuser.Account).FirstOrDefault();
                    if (notes != null)
                    {
                        notes.LastEditTime = DateTime.Now;
                        notes.Title = juser.Title;
                        notes.GameId = juser.GameId;
                        notes.Content =
                            Microsoft.JScript.GlobalObject.unescape(juser.Content);
                       
                        try
                        {
                            _noteRepository.Update(notes);
                            _noteRepository.SaveChanges();
                            ret = 1;
                            errMsg = "操作成功";
                        }
                        catch (Exception e)
                        {
                            ret =0;
                            errMsg = "操作失败";
                            errorCode = 301;
                        }
                        
                    }
                }

            }
            var retjson = new { ErrorCode = errorCode, iSuccessCode = ret, msg = errMsg };
            return Json(retjson, JsonRequestBehavior.AllowGet);
        }
        public ActionResult showDetail(int wenzhangID = 1)
        {
            //
            IRepository<GameType> _noteTypeRepository;
            _noteTypeRepository = new GameTypeRepository();
            var types = _noteTypeRepository.List();
            MemberShip loginuser = MemUserDataManager.GetMemSessionData<MemberShip>("memshipUserInfo");
            if (loginuser != null)
            {

                IRepository<GameStrategies> _noteRepository = new GameStrategiesRepository();
                var notes = _noteRepository.GetDbSet().Where(r => r.Id == wenzhangID &&
                    r.Author ==loginuser.Account).FirstOrDefault();
                if (notes != null)
                {
                    ViewBag.Types = types.Select(r => new SelectListItem { Text = r.Name, Value = r.GameId.ToString(), Selected = (r.GameId==notes.GameId) });
                    GameStrategies item = notes as GameStrategies;
                  //  var replstring = notes.Content.Replace("</p> <p>", "\n");
                 //   notes.Content = replstring.Replace("<p>", "");
                //    notes.Content = notes.Content.Replace("</ p>", "");
                    return View(item);
                }
                else
                {
                    ViewBag.Types = types.Select(r => new SelectListItem { Text = r.Name, Value = r.GameId.ToString() });
                    GameStrategies item = new GameStrategies { Author = " " };
                    return View(item);
                }
            }
            GameStrategies tlst = new GameStrategies();
            return View(tlst);

        }
        [HttpPost]
        //用户下订单
        [Description(No = 11, Name = "用户充值", isGet = false)]
        public JsonResult BookVIP(string ehaiker_parameter)
        {
            LoginMessage msg = new LoginMessage();
            msg.msg = "未知错误";
            msg.SuccessCode = "-1000";
            msg.UserLogUrl = "/personal/BookVIP";
            MemberShip loginuser = MemUserDataManager.GetMemSessionData<MemberShip>("memshipUserInfo");
            if (loginuser != null)
            {

                IRepository<MemberShip> _noteRepository = new MemberShipManager();
                var notes = _noteRepository.GetDbSet().Where(r => r.UserId == loginuser.UserId &&
                    r.Account == loginuser.Account).FirstOrDefault();
                if (notes == null)
                {
                    return Json(msg, JsonRequestBehavior.AllowGet);
                }
                //正常用户操作：
                PaybillModel  bill = JsonHelper.DeserializeJsonToObject<PaybillModel>(ehaiker_parameter);
                bill.PayDeleteMask = false;
                bill.PayForDateTime = DateTime.Now;
                bill.PayState = 0;
                bill.UserId = loginuser.UserId;
                bill.CreateTime = bill.PayForDateTime;
                bill.PayForWhat = "充值";
                bill.PayIdentity = Security.Sha256(string.Format("{0}{1}{2}",bill.UserId,bill.PayValue,bill.PayForDateTime.ToString()));
                PaybillRepository paybill = new PaybillRepository();
                paybill.Add(bill);
                if(paybill.SaveChanges()>0 )
                {
                    //发送邮件
                    ;//写入日志
                    string info = string.Format("[{0}]billID:{1} userid:{2} paytime:{3} dele successed\t", DateTime.Now, bill.PayBillID,
                        bill.UserId, bill.PayForDateTime);
                    string root = Server.MapPath("~/");
                    string logf = string.Format("{0}/log/bill.log", root); 
                    MyLog.FileOut(logf, info);
                    var noticestring = string.Format("<h2>尊敬的{0},您好：</h2>您的支付订单已经成功生成，已经发送到您的邮箱，详情请前往会员中心查看", loginuser.UserName, msg);
                    SendEmail(loginuser.Account, noticestring,"充值信息");
                    msg.SuccessCode = "10000";
                    msg.msg = "充值成功";
                }
            }
            return Json(msg, JsonRequestBehavior.AllowGet);
        }
         [HttpPost]
         [Description(No = 12, Name = "上传头像", isGet = false)]
        public JsonResult UploadFile()
        {
            LoginMessage msg = new LoginMessage();
            msg.msg = "未知错误";
            msg.SuccessCode = "-1000";
            MemberShip loginUser = MemUserDataManager.GetMemSessionData<MemberShip>("memshipUserInfo");
            
            HttpFileCollectionBase files = Request.Files;

            string error = string.Empty;
            string res = string.Empty;
             int filelen=files[0].ContentLength;
            //~/UploadFiles/Icon/UserName/
            string fileroot = string.Format("~/UploadFiles/Icon/{0}/", loginUser.Account);
            string filePath = Server.MapPath(fileroot) ;
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
             //获取文件信息：防止改名字的文件上传
              string fileName = files[0].FileName;
                 loginUser.Icon = fileroot + fileName;
            
                 try
                 {
                     files[0].SaveAs(Path.Combine(filePath, fileName));
                 }
             catch(Exception e)
                 {
                      msg.msg =  "保存文件失败"+e.Message;
                     return Json(msg, JsonRequestBehavior.AllowGet);
                 }
                 FileUploadHelper.FileExtension[] fe = { FileUploadHelper.FileExtension.JPG, 
                         FileUploadHelper.FileExtension.PNG, 
                         FileUploadHelper.FileExtension.GIF };
                 if (!FileUploadHelper.CheckTrueFileNameEx(files[0].InputStream, fe
                     ))
                 {
                      msg.msg  = "非法的文件格式";
                     return Json(msg, JsonRequestBehavior.AllowGet);
                 }
                 
                IRepository<MemberShip> memshipMgr = new MemberShipManager();
                loginUser.Icon = string.Format("../UploadFiles/Icon/{0}/{1}", loginUser.Account, fileName);
                memshipMgr.Update(loginUser);
                MemUserDataManager.UpdateSessionData("memshipUserInfo", loginUser);
                msg.msg = loginUser.Icon;
                msg.SuccessCode = "0";
            return Json(msg, JsonRequestBehavior.AllowGet);
        }
        //发送邮件通知
        private bool SendEmail(string email, string noticestring , string Subjectstring)
        {
            try
            {
                MailMessage mailmsg = new MailMessage();
                mailmsg.From = new MailAddress("lixingshunnick@126.com");
                mailmsg.To.Add(email);
                mailmsg.Subject = Subjectstring;
                StringBuilder contentBuilder = new StringBuilder();
                contentBuilder.Append(Subjectstring);
                contentBuilder.Append(noticestring);

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
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

    }
}
