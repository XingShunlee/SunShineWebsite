using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ehaiker.Models
{
    public class PaybillModel
    {
        [Key]
        [Display(Name = "账单ID")]
        public int PayBillID{set;get;}
        [Display(Name = "会员ID")]
        public int UserId { get; set; }
        [Display(Name = "支付内容")]
        public string PayForWhat { get; set; }
        [Display(Name = "支付类型0：-支付宝 1：微信 2：在线支付")]
        public int PayType { get; set; }
        [Display(Name = "支付凭证")]
        public string PayIdentity { get; set; }
        [Display(Name = "支付状态")]
        public int PayState { get; set; }
        [Display(Name = "支付数值")]
        public int PayValue { get; set; }
        [Display(Name = "支付时间")]
        public DateTime PayForDateTime { get; set; }
        [Display(Name = "删除标志")]
        public int PayDeleteMask { get; set; }
        [Display(Name="创建时间")]
        public DateTime CreateTime{set;get;}
    }
    public class PaybillApproveModel
    {
        [Key]
        [Display(Name = "审批ID")]
        public int PayBillApproveID { set; get; }
        [Display(Name = "账单ID")]
        public int PayBillID { get; set; }
        [Display(Name = "审批语")]
        public string ApproveForWhat { get; set; }
        public int PayType { get; set; }
        [Display(Name = "审批结果")]
        public int PayState { get; set; }
        [Display(Name = "审批时间")]
        public DateTime PayForDateTime { get; set; }
        [Display(Name = "删除标志")]
        public int ApproveDeleteMask { get; set; }
        [Display(Name = "创建时间")]
        public DateTime CreateTime { set; get; }
        [Display(Name = "支付金额")]
        public int PayValue { get; set; }
    }
}