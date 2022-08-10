using ehaiker.kefu;
using ehaiker.Managers;
using ehaikerv202010.Filters;
using ehaikerv202010.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ehaiker.Controllers
{
    // [ehaiker.Auth.Description(No = 6, Name = "客服系统", ShowInMgrbar = true)]
    public class CSServerController : Controller
    {
        private CSService csService;
        private KeFuService userService;
        private EhaikerContext DbContext;
        public CSServerController(EhaikerContext _cont)
        {
            DbContext = _cont;
            csService = new CSService(_cont);
            userService = new KeFuService(_cont);
        }
        //
        // GET: /CS/
        // [ehaiker.Auth.Description(No = 1, Name = "客服状态登录",ShowInMgrbar=true)]
        [AdminLoginStateRequiredAttribute]
        public ActionResult LoginStatusService()
        {
            return View(goKefuServer());
        }
        public ActionResult Index()
        {
            //会员和非会员统一调度到客户端
            return View("weChat_404");

        }

        //客服发送信息
        [HttpPost]
        [AdminLoginStateRequiredAttribute]
        // [ehaiker.Auth.Description(No = 2, Name = "客服发送消息",isGet=false)]
        public JsonResult saveUserChatRecord(String userContent,
               String id)
        {
            try
            {
                if (id == null || id == "")
                {
                    return Json("请选择用户");
                }
                userContent = userContent.Trim();
                KefuServiceStatus user = MemUserDataManager.GetMemSessionData<KefuServiceStatus>(HttpContext, "KeFuUser");
                if (!String.IsNullOrEmpty(userContent))
                {
                    SendMsg_kefu(System.Text.RegularExpressions.Regex.Replace(userContent, "/%28%3F%21%3C%28img%7Cp%7Cspan%29.*%3F%3E%29%3C.*%3F%3E/g", ""), Convert.ToInt32(id), user.kfUserId);
                    csService.SaveChangeInChatRecord();
                }
                else
                {
                    return Json(new { ErrorCode = 500, iSuccessCode = false, msg = "内容不能为空" });
                }
                return Json(new { ErrorCode = 0, iSuccessCode = true, msg = "发送成功" });
            }
            catch (Exception e)
            {
                return Json(new { ErrorCode = 100, iSuccessCode = false, msg = e.Message });
            }
        }

        /**
             * 从数据库读取所有聊天记录，展示在页面上
             * 客服和用户公用同一个方法，
             * idTemp：为user_id时表示客服，为customer_id时表示用户
             * id：客服读消息时用到的用户id
             * oldId：上一次读取新消息的记录，保证每次读取的都是最新消息
             * @return
             */

        [AdminLoginStateRequiredAttribute]
        [HttpPost]
        //[ehaiker.Auth.Description(No = 3, Name = "获取聊天消息", isGet = false)]
        public JsonResult getSAllChatRecord(String idTemp,
         String id,
         int oldId)
        {
            ChatRecord csChatRecord = new ChatRecord();

            Customer customer = new Customer();
            try
            {

                //判断是用户页面还是客服页面读取数据库消息
                //客服
                KefuServiceStatus user = MemUserDataManager.GetMemSessionData<KefuServiceStatus>(HttpContext, "KeFuUser");
                csChatRecord.customerId = Convert.ToInt32(id);
                customer.customerId = Convert.ToInt32(id);
                customer.headImg = "C.jpg";
                customer.kfUserId = user.kfUserId;
                csService.updateHeadImgState(customer);
                userService.SaveChangeInCustomer();
                csChatRecord.kfUserId = user.kfUserId;


                csChatRecord.RecordId = oldId;
                List<ChatRecord> alllist = csService.getAllChatRecord(csChatRecord);
                return Json(new { ErrorCode = 0, iSuccessCode = true, obj = alllist != null ? alllist.ToArray() : new List<ChatRecord>().ToArray() });
            }
            catch (Exception e)
            {
                return Json(new { ErrorCode = 500, iSuccessCode = false });
            }
        }
        /**
         * 客服界面->登录到状态服务器
         * 需要相关权限
         */
        [AdminLoginStateRequiredAttribute]
        private String goKefuServer()
        {
            //---登录状态到服务器
            try
            {

                KefuServiceStatus user = MemUserDataManager.GetMemSessionData<KefuServiceStatus>(HttpContext, "KeFuUser");
                if (user != null)
                {
                    userService.LoginService(user);
                    userService.SaveChangeInKefu();
                }
                else//还没有登录，注册到状态服务器
                {
                    Administrator admin = MemUserDataManager.GetMemSessionData<Administrator>(HttpContext, "AdminUser");
                    KefuServiceStatus userTemp = new KefuServiceStatus();
                    userTemp.kfUserId = admin.AdministratorID;
                    userTemp.UserName = admin.Account;
                    userTemp.Account = admin.Account;
                    userTemp.GroupId = admin.GroupId;
                    userTemp.isOnline = 1;
                    userTemp.CurrentPeople = 0;
                    userService.LoginService(userTemp);
                    userService.SaveChangeInKefu();
                    MemUserDataManager.AddSessionData(HttpContext, "KeFuUser", userTemp);
                }

                return "WeChat_KeFu";
            }
            catch (Exception e)
            {
                return "weChat_404";
            }
        }

        /**
         * 用户下线，清空所有与他相关的消息
         */

        [HttpPost]
        [AdminLoginStateRequiredAttribute]
        public JsonResult KefuOffline()
        {
            KefuServiceStatus kefu = MemUserDataManager.GetMemSessionData<KefuServiceStatus>(HttpContext, "KeFuUser");
            if (kefu == null)
            {
                string kfmsg = string.Format("会话过期，请重新登录!");
                return Json(new { ErrorCode = 10000, iSuccessCode = false, msg = kfmsg });
            }
            kefu.isOnline = 0;
            kefu.CurrentPeople = 0;
            userService.LoginOutService(kefu);
            userService.SaveChangeInKefu();
            //向他服务的客人推送下线消息
            KeFuCustomerRepository rds = new KeFuCustomerRepository(DbContext);
            var query = rds.GetDbSet().AsNoTracking().Where(r => r.kfUserId == kefu.kfUserId);
            if (query != null)
            {
                foreach (var cust in query)
                {
                    SendMsg_kefu("客服已经离线，请留言", cust.customerId, cust.kfUserId);
                    cust.kfUserId = 0;
                    csService.updateKefu(cust);
                }
                csService.SaveChangeInChatRecord();
            }

            return Json(new { ErrorCode = 0, iSuccessCode = true, msg = "发送成功" });
        }

        /**
         * 获取当前正在沟通的用户
         * @return
         */
        [HttpPost]
        [AdminLoginStateRequiredAttribute]
        //[ehaiker.Auth.Description(No = 4, Name = "获取聊天列表", isGet = false)]
        public JsonResult getCustomerList()
        {
            KefuServiceStatus user = MemUserDataManager.GetMemSessionData<KefuServiceStatus>(HttpContext, "KeFuUser");

            List<Customer> customerList = csService.getCustomerList(user.kfUserId);
            return Json(new { iSuccessCode = 1, obj = customerList.ToArray() });
        }
        //-----转接功能
        [HttpPost]
        [AdminLoginStateRequiredAttribute]
        public JsonResult ChangeKefu(String id)
        {
            KefuServiceStatus user = MemUserDataManager.GetMemSessionData<KefuServiceStatus>(HttpContext, "KeFuUser");

            List<Customer> customerList = csService.getCustomerList(user.kfUserId);
            if (String.IsNullOrEmpty(id))
            {
                for (int i = 0; i < customerList.Count; i++)
                {
                    Customer cs = customerList[i];
                    if (cs == null )
                        continue;
                    KefuServiceStatus kf = userService.GetService(cs.kfUserId);
                    //跳過自己 2020-9-6
                    if (cs.kfUserId == user.kfUserId)
                    {
                        cs.kfUserId = 0;
                        SendMsg_kefu("客服已经离线，请留言", cs.customerId, 10000);
                        csService.SaveChangeInChatRecord();
                        continue;
                    }
                    if (kf != null)
                    {
                        cs.kfUserId = kf.kfUserId;
                        csService.updateKefu(cs);
                        user.CurrentPeople -= 1;
                        userService.updateCurrentPeople(user);
                        userService.SaveChangeInKefu();
                        //向用户发送提示
                        string kfmsg = string.Format("{0}为您服务，祝您生活愉快!", kf.UserName);
                        SendMsg_kefu(kfmsg, cs.customerId, kf.kfUserId);
                        csService.SaveChangeInChatRecord();
                    }
                    else
                    {
                        cs.kfUserId = 0;
                        csService.updateKefu(cs);
                        user.CurrentPeople -= 1;
                        userService.updateCurrentPeople(user);
                        userService.SaveChangeInKefu();
                        SendMsg_kefu("客服已经离线，请留言", cs.customerId, 10000);
                        csService.SaveChangeInChatRecord();
                    }

                }
               
            }
            else
            {
                for (int i = 0; i < customerList.Count; i++)
                {
                    Customer cs = customerList[i];
                    if (cs.customerId == Convert.ToInt32(id))
                    {
                        KefuServiceStatus kf = userService.GetService(cs.kfUserId);
                        //跳過自己 2020-9-6
                        if (cs.kfUserId == user.kfUserId)
                        {
                            cs.kfUserId = 0;
                            SendMsg_kefu("客服已经离线，请留言", cs.customerId, 10000);
                            csService.SaveChangeInChatRecord();
                            break;
                        }
                        if (kf != null)
                        {
                            cs.kfUserId = kf.kfUserId;
                            csService.updateKefu(cs);
                            user.CurrentPeople -= 1;
                            userService.updateCurrentPeople(user);
                            //向用户发送提示
                            string kfmsg = string.Format("{0}为您服务，祝您生活愉快!", kf.UserName);
                            SendMsg_kefu(kfmsg, cs.customerId, kf.kfUserId);
                            csService.SaveChangeInChatRecord();
                        }
                        else
                        {
                            string kfmsg = string.Format("移交失败！没有可移交的对象!");
                            SendMsg_kefu(kfmsg, cs.customerId, cs.kfUserId);
                            csService.SaveChangeInChatRecord();
                            return Json(new { ErrorCode = 302, iSuccessCode = 0, msg = kfmsg });
                        }
                        break;
                    }
                }
            }
            return Json(new { iSuccessCode = 1, ErrorCode = 0, msg = "切换成功" });
        }
        //向用户发送信息
        private void SendMsg_kefu(string kfcontent, int customerId, int kefuId)
        {

            ChatRecord csChatRecord = new ChatRecord();
            //获取当前时间
            String datetime = DateTime.Now.ToString();
            //封装csChatRecord对象
            csChatRecord.kfUserId = kefuId;
            csChatRecord.customerId = customerId; ;
            csChatRecord.Time = datetime;
            string userContent = kfcontent.Trim();
            if (!String.IsNullOrEmpty(userContent))
            {
                csChatRecord.kfContent = userContent;
                //将csChatRecord对象保存到数据库
                csService.saveUserChatRecord(csChatRecord);
            }
        }
        //----------------------------
    }
}
