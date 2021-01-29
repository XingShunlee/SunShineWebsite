using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ehaiker.Models
{
    public class LoginMessage
    {
        public string Account { get; set; }
        public string UserName { set; get; }
        public string MobilePhone { set; get; }
        public int VIPLevel { get; set; }
        public int UserId { get; set; }
        public string UserInfoUrl { set; get; }
        public string UserLogUrl { set; get; }
        public int ErrorCode { set; get; }
        public string SuccessCode { set; get; }
        public string msg { set; get; }
        public decimal UMoney { set; get; }
        public decimal TMoney { set; get; }
    }
    
}