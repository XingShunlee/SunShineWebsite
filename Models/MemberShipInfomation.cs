using System.ComponentModel.DataAnnotations;
/*
 * 用户详细信息类--与用户表想关联
 */
namespace ehaiker.Models
{
    public class MemberShipInfomation
    {
        public MemberShipInfomation()
        {

        }
        /// <summary>
        /// 索引ID
        /// </summary>
        [Key]
        public int IndexId { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        [Display(Name = "用户GUID")]
        public string UserGuid { get; set; }
        /// <summary>
        /// 人民币
        /// </summary>
        [Display(Name = "元")]
        public decimal UMoney { set; get; }

        /// <summary>
        /// vip等级
        /// </summary>
        [Display(Name = "平台币")]
        public decimal TMoney { set; get; }

        /// <summary>
        /// 是否激活
        /// </summary>
        /// [Display(Name = "图像")]
        public int isValid { set; get; }
        /// <summary>
        /// 是否激活邮箱
        /// </summary>
        /// [Display(Name = "图像")]
        public int isMailValid { set; get; }
        /// <summary>
        /// 是否身份证激活
        /// </summary>
        /// [Display(Name = "图像")]
        public int isIdentityValid { set; get; }
        /// <summary>
        /// 身份证号码
        /// </summary>
        /// [Display(Name = "图像")]
        public string IdentityCard { set; get; }
    }
}