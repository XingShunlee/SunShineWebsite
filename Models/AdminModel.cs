using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ehaikerv202010.Models
{
    /// <summary>
    /// 管理员模型
    /// </summary>
    public class Administrator
    {
        public Administrator()
        {
        }
        public Administrator(Administrator rhs)
        {
            Account = rhs.Account;
            Password = rhs.Password;
            LoginIP = rhs.LoginIP;
            LoginTime = rhs.LoginTime;
            AdministratorID = rhs.AdministratorID;
            LoginGuid = Guid.Empty;


        }
        [Key]
        public int AdministratorID { get; set; }

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
        [Display(Name = "权限")]
        public string sPermission { set; get; }
        [Display(Name = "组ID")]
        public int GroupId { set; get; }
    }
    /// <summary>
    /// 添加管理员模型
    /// </summary>
    public class AddAdminViewModel
    {
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
        [StringLength(20, MinimumLength = 6, ErrorMessage = "{0}长度少于{1}个字符")]
        [Display(Name = "密码")]
        public string Password { get; set; }
        [Display(Name = "管理等级")]
        public int AdmLevel { get; set; }
    }
}
