using System;
using System.Collections.Generic;
using System.Linq;
using ehaiker.Models;
using ehaiker.Managers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ehaiker.kefu;
using ehaikerv202010.Filters;

namespace ehaiker.Controllers
{
    // [ehaiker.Auth.Description(No = 6, Name = "客服系统", ShowInMgrbar = true)]
    
    public class CSController : Controller
    {
        private CSService csService ;
        private KeFuService userService ;
        private EhaikerContext DbContext;
        public CSController(EhaikerContext _cont)
        {
            DbContext = _cont;
            csService = new CSService(_cont);
            userService = new KeFuService(_cont);
        }
        
        public ActionResult Index()
        {
            //会员和非会员统一调度到客户端
            return View("weChat_404");
            
        }
        public ActionResult Customer()
        {
            //从Cookie对象中取出Json串
            return View(goCustomer());
            
        }
        //用户发送信息
        [HttpPost]
        public JsonResult saveCustomerChatRecord( String customerContent) 
        {
            
		ChatRecord csChatRecord = new ChatRecord();
		try {
            Customer customer = MemUserDataManager.GetMemSessionData<Customer>(HttpContext,"customer");
            if (customer == null)
            {
                //string kfmsg = string.Format("非常抱歉，请刷新网页!");
                return Json(new { ErrorCode = 10000, iSuccessCode = 0, msg = "非常抱歉，请刷新网页!" });
            }
			 KefuServiceStatus user = null;
            //判断是否客服离线，离线就重新分配一个客服
            KeFuRepository kefuStatus = new KeFuRepository(DbContext);

            var kefu = kefuStatus.GetDbSet().AsNoTracking().FirstOrDefault(r => r.kfUserId == customer.kfUserId);
            user = kefu;
            if (kefu == null ||
                kefu.isOnline == 0)
            {
                user = userService.GetService();
                if(user != null)
                  customer.kfUserId = user.kfUserId;
            }
			
            if (user == null) 
            {
               // string kfmsg = string.Format("非常抱歉，目前客服不在线，请联系QQ客服，祝您生活愉快!");
              //  SendMsg_kefu(kfmsg, customer.customerId, 10000);
                //csService.SaveChangeInChatRecord();
                    //如果是临时客户，清空信息
                    MemberShip sessionUser = MemUserDataManager.GetMemSessionData<MemberShip>(HttpContext,"memshipUserInfo");
                    if (sessionUser == null && customer != null)//臨時客戶
                    {
                        //清空聊天記錄
                        // csService.clearChatrecords(customer.customerId);
                        //csService.SaveChangeInChatRecord();
                        ;  //清空臨時用戶
                      //  csService.clearCustomers(customer.customerId);
                      //  csService.SaveChangeInCustomer();
                    }
                   // MemUserDataManager.RemoveSessionData(HttpContext,"customer");
                   // return Json(new { ErrorCode = 10000, iSuccessCode = true, msg = "发送成功" });
            }
			//获取当前时间 
            String datetime = DateTime.Now.ToString();
			//封装csChatRecord对象
			csChatRecord.kfUserId= customer.kfUserId;
			csChatRecord.customerId=customer.customerId;
			csChatRecord.Time=datetime ;
			customerContent = customerContent.Trim();
			if( !String.IsNullOrEmpty(customerContent ) )
            {
                string s = System.Text.RegularExpressions.Regex.Replace(customerContent, "/%28%3F%21%3C%28img%7Cp%7Cspan%29.*%3F%3E%29%3C.*%3F%3E/g", "");
				csChatRecord.customerContent=s;
				//将csChatRecord对象保存到数据库
				csService.saveCustomerChatRecord(csChatRecord);
                csService.SaveChangeInChatRecord();
			}
            else
            {
                return Json(new { ErrorCode = 301, iSuccessCode = false, msg = "内容不能为空" });
			}
			customer.headImg="C_new.jpg";//把它的头像增加一个点
			csService.updateHeadImgState(customer);
            csService.SaveChangeInChatRecord();
            return Json(new { ErrorCode = 0, iSuccessCode = true, msg = "发送成功" });
		}catch (Exception e) {
            return Json(new { ErrorCode = 500, iSuccessCode = false, msg = e.Message });
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
	//@RequestMapping(value = "/getAllChatRecord")
	//@ResponseBody
    [HttpPost]
   //客戶獲取聊天信息，已經和客服進行分流
	public JsonResult getAllChatRecord( String idTemp,
			 String id,
			 int oldId) {
		ChatRecord csChatRecord = new ChatRecord();
		Customer customer = new Customer();
		try {
            
			//判断是用户页面还是客服页面读取数据库消息
			if(idTemp=="customer_id"){
				customer = MemUserDataManager.GetMemSessionData<Customer>(HttpContext,"customer");
				csChatRecord.customerId=customer.customerId;
                csChatRecord.kfUserId = customer.kfUserId;
                }
           
            csChatRecord.RecordId=oldId;
			List<ChatRecord> alllist = csService.CgetAllChatRecord(csChatRecord);
            return Json(new { ErrorCode = 0, iSuccessCode = true, obj =alllist!= null? alllist.ToArray():new List<ChatRecord>().ToArray() });
		} catch (Exception e) {
            return Json(new { ErrorCode = 500, iSuccessCode = false });
		}
	}
    
    /**
     * 客服界面->登录到状态服务器
     * 需要相关权限
     */
    
    
	/**
	 * 用户界面
	 * @return 
	 */
	//@RequestMapping(value = "/goCustomer")
	public String goCustomer() {

		KefuServiceStatus userTemp = new KefuServiceStatus();
		Customer customer = new Customer();
		try {
			Customer customer2 =  MemUserDataManager.GetMemSessionData<Customer>(HttpContext,"customer");
            //客人第一次
			if(customer2 == null){

                MemberShip sessionUser = MemUserDataManager.GetMemSessionData<MemberShip>(HttpContext,"memshipUserInfo");
                if (sessionUser != null)//我们的会员
                {
                    customer.kfUserId = userTemp.kfUserId;
                    customer.customerId = sessionUser.UserId;//登记ID和用户名
                    customer.UserName = sessionUser.UserName;
                }
                else//非会员，分配以个临时ID和名字
                {
                    Random rnd = new Random();
                    int number = 5000 + (int)((rnd.Next() * 100) + 1);
                    customer.UserName = "临时用户" + number;
                    customer.kfUserId = userTemp.kfUserId;
                    customer.customerId = number;
                }
                customer.kfUserId = 0;
				//获取所有在线客服每个人正在接待的用户人数，找出最闲的客服
                userTemp = userService.GetService();
                if (userTemp != null)
                {
                    //修改当前客服接待人数，currentPeople+1
                    userService.updateCurrentPeople(userTemp);
                    userService.SaveChangeInKefu();
                    if (sessionUser != null)//我们的会员
                    {
                        customer.kfUserId = userTemp.kfUserId;
                    }
                    else//非会员，分配以个临时ID和名字
                    {
                        customer.kfUserId = userTemp.kfUserId;
                    }
                    //设置当前用户的在线状态
                    customer.isOnline = 1;
                    customer.headImg = "C.jpg";
                    csService.insertCustomer(customer);
                    csService.SaveChangeInCustomer();
                    //在这里设置
                   // MemUserDataManager.AddSessionData("KeFuUser", userTemp);
                    MemUserDataManager.AddSessionData(HttpContext,"customer", customer);
                    //向用户发送提示
                    string kfmsg = string.Format("{0}为您服务，祝您生活愉快!", userTemp.UserName);
                    SendMsg_kefu(kfmsg, customer.customerId,customer.kfUserId);
                    csService.SaveChangeInChatRecord();
                }
                else//目前客服不在线，告知客户QQ联系
                {
                    userTemp = new KefuServiceStatus();
                    userTemp.Account = "systemkefu";
                    userTemp.kfUserId = 100000;
                    userTemp.UserName = "系统回复";
                    customer.isOnline = 1;
                    customer.headImg = "C.jpg";
                    customer.kfUserId = userTemp.kfUserId;
                    MemUserDataManager.AddSessionData(HttpContext,"customer", customer);
                    //MemUserDataManager.AddSessionData("KeFuUser", userTemp);
                    string kfmsg = string.Format("非常抱歉，目前客服不在线，请联系QQ客服，祝您生活愉快!");
                    SendMsg_kefu(kfmsg, customer.customerId, userTemp.kfUserId);
                    csService.SaveChangeInChatRecord();
                }
			}else{//客户重新回到客户端界面，设置在线状态
				customer2.isOnline=1;
				csService.updateCustomerOnline(customer2);
                csService.SaveChangeInCustomer();
			}
			return "weChat_customer";
		} catch (Exception e) {
                //刪除記錄
                MemUserDataManager.RemoveSessionData(HttpContext,"customer");
                return "weChat_404";
		}
	}
	/**
	 * 用户下线，清空所有与他相关的消息
	 */
	
  
    [HttpPost]
    public JsonResult customerOffline()
    {
        Customer customer = MemUserDataManager.GetMemSessionData<Customer>(HttpContext,"customer");
        if(customer != null)
        {
            customer.isOnline = 0;
            customer.headImg = "C.jpg";
            customer.kfUserId = 0;//取消客服服务
        }
        //如果是临时客户，清空信息
        MemberShip sessionUser = MemUserDataManager.GetMemSessionData<MemberShip>(HttpContext,"memshipUserInfo");
        if (sessionUser == null && customer != null)//臨時客戶
        {
            csService.clearChatrecords(customer.customerId);
            csService.SaveChangeInChatRecord();
            //清空记录
            csService.clearCustomers(customer.customerId);
            csService.SaveChangeInCustomer();
        }
        else if(customer != null)
        {
            csService.updateCustomerOnline(customer);
            csService.SaveChangeInCustomer();
        }
        
        MemUserDataManager.RemoveSessionData(HttpContext,"customer");
        return Json(new { ErrorCode = 0, iSuccessCode = true, msg = "退出成功" });
    }
	/**
	 * 获取当前正在沟通的用户
	 * @return
	 */
    

 //向用户发送信息
    private void SendMsg_kefu(string kfcontent,int customerId,int kefuId)
    {
       
		    ChatRecord csChatRecord = new ChatRecord();
			//获取当前时间
            String datetime = DateTime.Now.ToString();
			//封装csChatRecord对象
            csChatRecord.kfUserId = kefuId;
            csChatRecord.customerId = customerId;;
			csChatRecord.Time=datetime;
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
