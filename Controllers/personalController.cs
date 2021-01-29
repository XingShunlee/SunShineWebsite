using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ehaiker.Models;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using ehaikerv202010;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;
using ehaikerv202010.Models;

namespace ehaiker.Controllers
{

    //[MemberShipAuthorizeAttribute]
   // [Description(No = 2, Name = "个人中心")]
    public class personalController : Controller
    {

        // GET: /personal/
        private EhaikerContext DbContext;
        private IHostingEnvironment _env;
        private GameListManager GamelistManager;
        public personalController(EhaikerContext _cont,IHostingEnvironment env)
        {
            DbContext = _cont;
            _env = env;


        }
        public ActionResult Index()
        {
            //没有登录
            MemberShip cookie = MemUserDataManager.GetMemSessionData<MemberShip>(HttpContext,"memshipUserInfo");
            if (cookie != null)
            {
                return View(cookie);
            }
            else
            {
                return RedirectToRoute(new { Controller = "Account", Action = "Index" });
            }
        }
       
       // [Description(No = 1, Name = "用户信息")]
        public ActionResult UserInfo()
        {

            MemberShip juser = MemUserDataManager.GetMemSessionData<MemberShip>(HttpContext, "memshipUserInfo");
            return View(juser);
        }
      //  [Description(No = 2, Name = "支付中心")]
        public ActionResult PayBill()
        {
            MemberShip cookie = MemUserDataManager.GetMemSessionData<MemberShip>(HttpContext, "memshipUserInfo");
            if (cookie != null)
            {
                return View(cookie);
            }
            return View();
        }
      //  [Description(No = 3, Name = "我的账单")]
        public ActionResult MyBill(int pageindex = 1, int pagesize = 10)
        {

            IRepository<PaybillApproveModel> _noteRepository = new PaybillApproveRepository(DbContext); ;
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
       // [Description(No = 4, Name = "新密码")]
        public ActionResult NewPassword()
        {
            return View();
        }
       // [Description(No = 5, Name = "显示个人游戏分享")]
        public ActionResult show(int pageindex = 1, int pagesize = 10)
        {
            IRepository<GameStrategies> _noteRepository;
            IRepository<GameType> _noteTypeRepository;
            _noteRepository = new GameStrategiesRepository(DbContext);
            _noteTypeRepository = new GameTypeRepository(DbContext);
            int nCount = _noteRepository.List().Count();
            //
            MemberShip loginuser = MemUserDataManager.GetMemSessionData<MemberShip>(HttpContext, "memshipUserInfo");
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
       // [Description(No = 6, Name = "打开游戏分享界面")]
       
        //用户修改密码
        [HttpPost]
        //[Description(No = 7, Name = "激活密码功能",isGet=false)]
        public JsonResult NewPassWordEx(string ehaiker_parameter)
        {
            LoginMessage msg = new LoginMessage();
            msg.SuccessCode = "-1000";
            msg.msg = "未知错误";
            if (ModelState.IsValid)
            {
                MemberShip loginuser = MemUserDataManager.GetMemSessionData<MemberShip>(HttpContext, "memshipUserInfo");
                if (loginuser != null)
                {
                   //网页端数据
                    membershiplogin juser = JsonHelper.DeserializeJsonToObject<membershiplogin>(ehaiker_parameter);
                    //验证数据
                    if(HttpContext.Session.GetString("ValidPassword_user_ehaiker")==null||
                        string.IsNullOrEmpty(HttpContext.Session.GetString("ValidPassword_user_ehaiker")) )
                    {
                        msg.msg = "非法用户";
                        return Json(msg);
                    }
                    string valid = HttpContext.Session.GetString("ValidPassword_user_ehaiker");
                    if (valid != juser.verificat_code)
                    {
                        msg.msg = "激活码有误";
                        return Json(msg);;
                    }
                   //激活信密码
                    loginuser.Password = Security.Sha256(juser.Password);
                    IRepository<MemberShip> memshipMgr = new MemberShipManager(DbContext);
                    memshipMgr.Update(loginuser);
                    memshipMgr.SaveChanges();
                    msg.SuccessCode = "0";
                    msg.msg = "密码激活成功";
                    //更新全局数据
                    MemUserDataManager.UpdateSessionData(HttpContext, "memshipUserInfo", loginuser);
                }

            }

            return Json(msg);
        }
        //PassValidMail
        [HttpPost]
        //[Description(No = 8, Name = "发送激活邮件", isGet = false)]
        public JsonResult PassValidMail(string ehaiker_parameter)
        {
            LoginMessage msg = new LoginMessage();
            msg.SuccessCode = "-1000";
            msg.msg = "未知错误";
            if (ModelState.IsValid)
            {
                MemberShip loginuser = MemUserDataManager.GetMemSessionData<MemberShip>(HttpContext, "memshipUserInfo");
                if (loginuser != null)
                {
                    IRepository<GameStrategies> _noteRepository;
                    IRepository<GameType> _noteTypeRepository;
                    _noteRepository = new GameStrategiesRepository(DbContext);
                    _noteTypeRepository = new GameTypeRepository(DbContext);
                    membershiplogin juser = JsonHelper.DeserializeJsonToObject<membershiplogin>(ehaiker_parameter);
                    //查看是否有该用户记录
                    //实时验证码
                    string validcode = Security.Sha256(string.Format("{0}{1}{2}", loginuser.UserId,
                        loginuser.Password, DateTime.Now.ToLongTimeString()));
                    var noticestring = 
                        string.Format("<h2>尊敬的{0},您好：</h2>您的新密码激活码为{1}，请前往会员中心激活第三步",
                        loginuser.UserName, validcode);
                    SendMail.SendEmail(juser.Account, noticestring,"密码验证");
                    HttpContext.Session.SetString("ValidPassword_user_ehaiker", validcode);
                    msg.SuccessCode = "0";
                    msg.msg = "邮件发送成功";
                }
                else
                msg.msg = "非法用户";
            }

            return Json(msg);
        }
       
        
       
         [HttpPost]
        // [Description(No = 12, Name = "上传头像", isGet = false)]
        public async Task<JsonResult> UploadFile()
        {
            LoginMessage msg = new LoginMessage();
            msg.msg = "未知错误";
            msg.SuccessCode = "-1000";
            MemberShip loginUser = MemUserDataManager.GetMemSessionData<MemberShip>(HttpContext, "memshipUserInfo");
            
            var files = Request.Form.Files;

            string error = string.Empty;
            string res = string.Empty;
             long filelen=files[0].Length;
            //~/UploadFiles/Icon/UserName/
            string fileroot = string.Format("~/UploadFiles/Icon/{0}/", loginUser.Account);
            string filePath = _env.WebRootPath+(fileroot) ;
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            //获取文件信息：防止改名字的文件上传
            string fileName = files[0].FileName;
            loginUser.Icon = fileroot + fileName;

            try
            {
                using (var stream = new FileStream(Path.Combine(filePath, fileName), FileMode.Create))
                {
                    await files[0].CopyToAsync(stream);
                }
                    ;// files[0].Save(Path.Combine(filePath, fileName));
            }
            catch (Exception e)
            {
                msg.msg = "保存文件失败" + e.Message;
                return Json(msg);
            }
            FileUploadHelper.FileExtension[] fe = { FileUploadHelper.FileExtension.JPG,
                    FileUploadHelper.FileExtension.PNG,
                    FileUploadHelper.FileExtension.GIF };
            if (!FileUploadHelper.CheckTrueFileName(files[0].FileName, fe
                ))
            {
                msg.msg = "非法的文件格式";
                return Json(msg);
            }

            IRepository<MemberShip> memshipMgr = new MemberShipManager(DbContext);
            loginUser.Icon = string.Format("../UploadFiles/Icon/{0}/{1}", loginUser.Account, fileName);
            memshipMgr.Update(loginUser);
            MemUserDataManager.UpdateSessionData(HttpContext, "memshipUserInfo", loginUser);
            msg.msg = loginUser.Icon;
                msg.SuccessCode = "0";
            return Json(msg);
        }
      
        //
        [HttpPost]
        public JsonResult MyStoreGame(int type = 0)
        {
            MyGameStragesManager GamelistManager = new MyGameStragesManager(DbContext);
            if (type == 0)
            {
                var tt = GamelistManager.List();
                return Json(tt);
            }
            else
            {
                MemberShip loginuser = MemUserDataManager.GetMemSessionData<MemberShip>(HttpContext, "memshipUserInfo");
                int memshipID = 0;
                if (loginuser != null)
                {
                    memshipID = loginuser.UserId;
                }
                    //取前8条记录
                    var tt = GamelistManager.GetDbSet()?.Where(r => r.Gametype == type&& r.MemberShipID == memshipID).Take(8).ToList();
                return Json(tt);
            }


        }
        [HttpPost]
        public JsonResult MyGames(int type = 0)
        {
            MyGameManager GamelistManager = new MyGameManager(DbContext);
            if (type == 0)
            {
                var tt = GamelistManager.List();
                return Json(tt);
            }
            else
            {
                MemberShip loginuser = MemUserDataManager.GetMemSessionData<MemberShip>(HttpContext, "memshipUserInfo");
                int memshipID = 0;
                if (loginuser != null)
                {
                    memshipID = loginuser.UserId;
                }
                //取前8条记录
                var tt = GamelistManager.GetDbSet()?.Where(r => r.Gametype == type && r.MemberShipID == memshipID).Take(8).ToList();
                return Json(tt);
            }


        }

    }
}
