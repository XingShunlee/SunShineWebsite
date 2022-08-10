using System.ComponentModel.DataAnnotations;
//图文项
namespace ehaiker.Models
{
    public class SupplierModel
    {
        [Key]
        public int ItemID { get; set; }

        /// <summary>
        /// 项名称
        /// </summary>
        [Display(Name = "供应商名称")]
        public string ItemName { get; set; }

        /// <summary>
        /// 介绍图片
        /// </summary>
        [Display(Name = "描述图片")]
        public string ImgDescUri { get; set; }

        /// <summary>
        /// 登录IP
        /// </summary>
        [Display(Name = "焦点图片")]
        public string ImgHoverUri { get; set; }

        /// <summary>
        /// 目标链接
        /// </summary>
        [Display(Name = "目标链接")]
        public string hrefUri { get; set; }

    }
}