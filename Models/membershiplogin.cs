using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ehaiker.Models
{
    public class membershiplogin
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
        [StringLength(256, ErrorMessage = "{0}长度少于{1}个字符")]
        [Display(Name = "密码")]
        public string Password { get; set; }

        /// <summary>
        /// 登录IP
        /// </summary>
        [Display(Name = "验证码")]
        public string verificat_code { get; set; }
        /// <summary>
        /// 登录IP
        /// </summary>
        [Display(Name = "手机验证码")]
        public string verificat_smscode { get; set; }
        /// <summary>
        /// 登录时间
        /// </summary>
        [Display(Name = "自动登录")]
        public bool is_auto { get; set; }
        /// <summary>
        /// 用户手机
        /// </summary>
        [Display(Name = "手机号码")]
        public string MobilePhone { set; get; }
    }
}