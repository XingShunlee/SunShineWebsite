using System.ComponentModel.DataAnnotations;

namespace ehaikerv202010.Models
{
    public class MyItBlogModel
    {
        [Key]
        public int IndexID { get; set; }

        /// <summary>
        /// 项名称
        /// </summary>
        [Display(Name = "外部blogID")]
        public int BlogID { get; set; }
        [Display(Name = "会员ID")]
        public string UserGuid { get; set; }

        /// <summary>
        /// 项名称
        /// </summary>
        [Display(Name = "项名称")]
        public string ItemName { get; set; }
        [Display(Name = "blog类型：待定")]
        public int blogtype { get; set; }
    }
}
