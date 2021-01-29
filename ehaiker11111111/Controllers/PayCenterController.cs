using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ehaiker.Models;
using System.Text;
using System.Net.Mail;
using System.Net;
using ehaiker.Auth;

namespace ehaiker.Controllers
{
    [AdminAuthorize]
    [Description(No = 3, Name = "支付中心页面")]
    public class PayCenterController : Controller
    {
        //
        // GET: /PayCenter/
        [Description(No = 1, Name = "支付中心首页",ShowInMgrbar = true)]
        public ActionResult Index(int pageindex = 1, int pagesize = 10)
        {
            IRepository<PaybillModel> _noteRepository = new PaybillRepository(); ;
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
                var notes = new Tuple<List<PaybillModel>, int>(findItems, pagecount);
                ViewBag.PageCount = notes.Item2;//总页数
                ViewBag.PageIndex = pageindex;//当前页
                ViewBag.PageSize = pagesize;//页面显示
                ViewBag.PageUri = "../PayCenter/Index";
                return View(notes.Item1);
            }
            ViewBag.PageCount = 1;//总页数
            ViewBag.PageIndex = 1;//当前页
            ViewBag.PageSize = pagesize;//页面显示
            ViewBag.PageUri = "../PayCenter/Index";
            List<PaybillModel> tlst = new List<PaybillModel>();
            return View(tlst);
        }
        ///删除账单(伪)
        ///
        [Description(No = 2, Name = "删除支付订单")]
        [AuthAuthorize]
        [HttpPost]
        public JsonResult DeleteOrder(string KeyValue)
        {
            PaybillRepository paybill = new PaybillRepository();
            try
            {
                string msg = "删除成功";
                if (!string.IsNullOrEmpty(KeyValue))
                {
                    string[] array = KeyValue.Split(',');
                    foreach (var item in array)
                    {
                        PaybillModel oldbill = paybill.GetById(Convert.ToInt32(item));
                        oldbill.PayDeleteMask = true ;
                        paybill.Update(oldbill);
                        if (paybill.SaveChanges() > 0)
                        {
                            ;//写入日志
                            string info = string.Format("[{0}]billID:{1} userid:{2} paytime:{3} dele successed\t", DateTime.Now.ToString(), oldbill.PayBillID,
                                oldbill.UserId, oldbill.PayForDateTime.ToString());
                            string root = Server.MapPath("~/");
                            string logf = string.Format("{0}/log/paybill.log", root); 
                            MyLog.FileOut(logf, info);
                        }
                        else
                        {
                            string info = string.Format("[{0}]billID:{1} userid:{2} paytime:{3} delete failed\t", DateTime.Now.ToString(), oldbill.PayBillID,
                               oldbill.UserId, oldbill.PayForDateTime.ToString());
                            string root = Server.MapPath("~/");
                            string logf = string.Format("{0}/log/paybill.log", root); 
                            MyLog.FileOut(logf, info);
                        }
                        
                    }
                }
                else
                {
                     msg = "删除失败";
                }
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                string msg = "删除失败";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }
        ///
        ///审批订单订单:1-通过 0-初始状态 -1-退回
        [Description(No = 3, Name = "审批支付订单")]
        [AuthAuthorize]
        [HttpPost]
        public JsonResult SetPayBillState(string KeyValue, int PayForState)
        {
            //----这里要加上管理员登录验证
            PaybillRepository paybill = new PaybillRepository();
            string msg = "操作失败";
            try
            {
                
                if (!string.IsNullOrEmpty(KeyValue))
                {
                    string[] array = KeyValue.Split(',');
                    foreach (var item in array)
                    {
                        PaybillModel oldbill = paybill.GetById(Convert.ToInt32(item));
                        //订单验证--
                        if (oldbill == null)
                        {
                            msg = "非法订单";
                            return Json(msg, JsonRequestBehavior.AllowGet); 
                        }
                        //找到会员ID，更新会员信息
                        MemberShipInfomationRepository memship = new MemberShipInfomationRepository();
                        var user = memship.GetDbSet().Where(r => r.UserId == oldbill.UserId).FirstOrDefault();
                        if (user != null)
                        {
                            //订单状态更改
                            oldbill.PayState = PayForState;
                            paybill.Update(oldbill);
                            if (paybill.SaveChanges() > 0  )
                            {
                                string info = string.Format("[{0}]billID:{1} userid:{2} paytime:{3} value:{4} paybill update successed\t", DateTime.Now, oldbill.PayBillID,
                                    oldbill.UserId, oldbill.PayForDateTime.ToString(), oldbill.PayValue);
                                //生成一个审批记录
                                PaybillApproveModel newApprove = new PaybillApproveModel();
                                newApprove.ApproveDeleteMask = false;
                                newApprove.CreateTime = DateTime.Now;
                                newApprove.PayBillID = oldbill.PayBillID;
                                newApprove.PayForDateTime = oldbill.PayForDateTime;
                                newApprove.PayState = oldbill.PayState;
                                newApprove.PayType = oldbill.PayType;
                                switch (PayForState)
                                {
                                    case 1:
                                        newApprove.ApproveForWhat = "充值通过管理员审批";
                                        break;
                                    case -1:
                                        newApprove.ApproveForWhat = "充值申请已经撤销";
                                        break;
                                }
                                
                                PaybillApproveRepository paybillapproves = new PaybillApproveRepository();
                                paybillapproves.Add(newApprove);
                                if(paybillapproves.SaveChanges()>0 )
                                 {
                                     //增加用户平台币
                                     if (oldbill.PayValue > 0 && oldbill.PayState>0)
                                     {
                                         user.TMoney = user.TMoney + oldbill.PayValue;
                                         memship.Update(user);
                                         if (memship.SaveChanges()> 0)
                                         {
                                             //更新session
                                         }
                                     }
                                     string log = string.Format("[{0}]billID:{1} userid:{2} payvalue:{3}paytime:{4} create approvebill successed\t", DateTime.Now.ToString(), oldbill.PayBillID,
                                     oldbill.UserId,oldbill.PayValue, oldbill.PayForDateTime.ToString());
                                     string root = Server.MapPath("~/");
                                     string logf = string.Format("{0}/log/paybill.log", root); 
                                     MyLog.FileOut(logf, log);
                                    //发送邮件通知
                                     MemberShipManager memshipMgr = new MemberShipManager();
                                     var loguser = memshipMgr.GetDbSet().Where(r => r.UserId == oldbill.UserId).FirstOrDefault();
                                     if (loguser != null && oldbill.PayState > 0)
                                    {
                                        var noticestring = "";
                                        if(oldbill.PayState>0)
                                        {
                                            msg = "审核通过";
                                            noticestring = string.Format("<h2>尊敬的{0},您好：</h2>您的支付凭证已进行处理，处理结果为：{1}，详情请前往会员中心查看",
                                                loguser.UserName, msg);
                                        }else{
                                            msg = "充值撤销";
                                            noticestring = string.Format("<h2>尊敬的{0},您好：</h2>您的支付凭证已进行处理，处理结果为：{1}，详情请前往会员中心查看",
                                                loguser.UserName, msg);
                                        }
                                         SendEmail(loguser.Account,noticestring);
                                    }
                                   
                                    msg = "操作成功";
                                     return Json(msg, JsonRequestBehavior.AllowGet);
                                 }
                                else
                                {
                                    msg = "操作失败";
                                    string log = string.Format("[{0}]billID:{1} userid:{2} paytime:{3} create approvebill Failed\t", DateTime.Now, oldbill.PayBillID,
                                      oldbill.UserId, oldbill.PayForDateTime);
                                    string root = Server.MapPath("~/");
                                    string logf = string.Format("{0}/log/paybill.log", root); 
                                    MyLog.FileOut(logf, log);
                                    return Json(msg, JsonRequestBehavior.AllowGet);
                                }
                                ;//写入日志
                                
                            }
                            else
                            {
                                msg = "没有该用户信息";
                                string info = string.Format("[{0}]billID:{1} userid:{2} paytime:{3} paybill update failed\t", DateTime.Now, oldbill.PayBillID,
                                   oldbill.UserId, oldbill.PayForDateTime);
                                string root = Server.MapPath("~/");
                                string logf = string.Format("{0}/log/paybill.log", root); 
                                MyLog.FileOut(logf, info);
                                return Json(msg, JsonRequestBehavior.AllowGet);
                            }

                        }
                    }
                }
                else
                {
                    msg = "操作失败";
                }
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                msg = "操作失败";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }
        //发送邮件通知
        private bool SendEmail(string email, string noticestring, bool IsManager = false)
        {
            try
            {
                MailMessage mailmsg = new MailMessage();
                mailmsg.From = new MailAddress("lixingshunnick@126.com");
                mailmsg.To.Add(email);
                mailmsg.Subject = "充值审核通过";
                StringBuilder contentBuilder = new StringBuilder();
                contentBuilder.Append("充值审核通过");
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
