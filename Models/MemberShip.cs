using System;
using System.ComponentModel.DataAnnotations;
namespace ehaiker.Models
{
    public class MemberShip
    {
        public MemberShip()
        {
            MobilePhone = "0";
            SignCount = 0;
            LastSignTime = null;
            Icon = "/public/avatar/08.jpg";
            LoginGuid = Guid.Empty;
        }
        public MemberShip(MemberShip rhs)
        {
            Account = rhs.Account;
            Password = rhs.Password;
            LoginIP = rhs.LoginIP;
            CreateTime = rhs.CreateTime;
            LoginTime = rhs.LoginTime;
            VIPLevel = rhs.VIPLevel;
            UserId = rhs.UserId;
            UserName = rhs.UserName;
            MobilePhone = rhs.MobilePhone;
            SignCount = rhs.SignCount;
            LastSignTime = rhs.LastSignTime;
            Icon = rhs.Icon;
            LoginGuid = Guid.Empty;

        }
        [Key]
        public int UserId { get; set; }

        /// <summary>
        /// 帐号
        /// </summary>
        [Required(ErrorMessage = "必须输入{0}")]
        [StringLength(30, MinimumLength = 4, ErrorMessage = "{0}长度为{2}-{1}个字符")]
        [Display(Name = "帐号")]
        public string Account { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "必须输入{0}")]
        [StringLength(256, ErrorMessage = "{0}长度少于{1}个字符")]
        [Display(Name = "密码")]
        public string Password { get; set; }

        /// <summary>
        /// 登录IP
        /// </summary>
        [Display(Name = "登录IP")]
        public string LoginIP { get; set; }
        [Display(Name = "登录验证")]
        public Nullable<Guid> LoginGuid { get; set; }

        /// <summary>
        /// 登录时间
        /// </summary>
        [Display(Name = "登录时间")]
        public Nullable<DateTime> LoginTime { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// vip等级
        /// </summary>
        [Display(Name = "vip等级")]
        public int VIPLevel { get; set; }

        /// <summary>
        /// 用户图像
        /// </summary>
        [Display(Name = "图像")]
        public string Icon { set; get; }
        /// <summary>
        /// 用户昵称
        /// </summary>
         [Display(Name = "显示昵称")]
        public string UserName { set; get; }
         /// <summary>
         /// 用户手机
         /// </summary>
         [StringLength(11, MinimumLength = 0, ErrorMessage = "{0}长度为{2}-{1}个字符")]
         [Display(Name = "手机号码")]
         public string MobilePhone { set; get; }
         [Display(Name = "签到天数")]
         public int SignCount { set; get; }
         [Display(Name = "最后签到时间")]
         public Nullable<DateTime> LastSignTime { get; set; }
         /// <summary>
         /// 用户昵称
         /// </summary>
         [Display(Name = "权限")]
         public string sPermission { set; get; }
         [Display(Name = "组ID")]
         public int GroupId { set; get; }
        [Display(Name = "账号状态")]
        public int nStatus { set; get; }
        

    }
    
}