using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using ehaiker;
using ehaiker.Models;
using ehaikerv202010.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ehaikerv202010.Controllers
{
    
    public class VIPBillController : Controller
    {
        private EhaikerContext DbContext;
        public VIPBillController(EhaikerContext _cont)
        {
            DbContext = _cont;

        }
        [LoginStateRequiredAttribute]
        public IActionResult Index()
        {
            MemberShip cookie = MemUserDataManager.GetMemSessionData<MemberShip>(HttpContext, "memshipUserInfo");
            if (cookie != null)
            {
                return View("Index", cookie);
            }
            else
            {
                return RedirectToRoute(new { Controller = "Account", Action = "Index" });
            }
        }
        [HttpPost]
        //用户下订单
        // [Description(No = 11, Name = "用户充值", isGet = false)]
        [LoginStateRequiredAttribute]
        public JsonResult BookVIP(string ehaiker_parameter)
        {
            LoginMessage msg = new LoginMessage();
            msg.msg = "未知错误";
            msg.SuccessCode = "-1000";
            msg.UserLogUrl = "/VIPBill/BookVIP";
            MemberShip loginuser = MemUserDataManager.GetMemSessionData<MemberShip>(HttpContext, "memshipUserInfo");
            if (loginuser != null)
            {

                IRepository<MemberShip> _noteRepository = new MemberShipManager(DbContext);
                var notes = _noteRepository.GetDbSet().Where(r => r.UserId == loginuser.UserId &&
                    r.Account == loginuser.Account).FirstOrDefault();
                if (notes == null)
                {
                    return Json(msg);
                }
                //正常用户操作：
                PaybillModel bill = JsonHelper.DeserializeJsonToObject<PaybillModel>(ehaiker_parameter);
                bill.PayDeleteMask = 0;
                bill.PayForDateTime = DateTime.Now;
                bill.PayState = 0;
                bill.UserId = loginuser.UserId;
                bill.CreateTime = bill.PayForDateTime;
                bill.PayForWhat = "充值";
                bill.PayIdentity = Security.Sha256(string.Format("{0}{1}{2}", bill.UserId, bill.PayValue, bill.PayForDateTime.ToString()));
                PaybillRepository paybill = new PaybillRepository(DbContext);
                paybill.Add(bill);
                if (paybill.SaveChanges() > 0)
                {
                    //发送邮件
                    ;//写入日志
                    string info = string.Format("[{0}]billID:{1} userid:{2} paytime:{3} dele successed\t", DateTime.Now, bill.PayBillID,
                        bill.UserId, bill.PayForDateTime);
                    //  string root = Server.MapPath("~/"); 
                    //  string logf = string.Format("{0}/log/bill.log", root); 
                    //MyLog.FileOut(logf, info);
                    var noticestring = string.Format("<h2>尊敬的{0},您好：</h2>您的支付订单已经成功生成，已经发送到您的邮箱，详情请前往会员中心查看", loginuser.UserName, msg);
                    SendMail.SendEmail(loginuser.Account, noticestring, "充值信息");
                    msg.SuccessCode = "10000";
                    msg.msg = "充值成功";
                }
            }
            
            return Json(msg);
        }
        [HttpPost]
        [LoginStateRequiredAttribute]
        public JsonResult MyBill(int pageindex = 1, int pagesize = 10,int type=10000)
        {
            var query = new List<PaybillApproveModel>();
            IRepository<PaybillApproveModel> _noteRepository = new PaybillApproveRepository(DbContext); 
            if(type==10000)
            {
                query = _noteRepository.List();
            }
            else
            {
                query = _noteRepository.GetDbSet().Where(r=>r.PayState==type).ToList();
            }
            
            int nCount = _noteRepository.List().Count();
            //
            if (nCount > 0)
            {
                
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
                ViewBag.PageUri = "../VIPBill";
                var tt1 = new { Total = notes.Item2, data = notes.Item1 };
                return Json(tt1);
            }
            ViewBag.PageCount = 1;//总页数
            ViewBag.PageIndex = 1;//当前页
            ViewBag.PageSize = pagesize;//页面显示
            ViewBag.PageUri = "../VIPBill/Index";
            var tt = new { Total =0, data = "" };
            return Json(tt);
        }
       
    }
}