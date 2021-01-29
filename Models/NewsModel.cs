using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ehaikerv202010.Models
{
    public class NewsModel
    {
        public int Id { set; get; }
        [Required]
        [MaxLength(1024)]
        public string Title { set; get; }
        [Required]
        public string Content { set; get; }
        public DateTime ReleaseTime { set; get; }
        [Display(Name = "最后更新")]
        public DateTime LastEditTime { set; get; }
        [Display(Name = "新闻类型")]
        public int NewsTypeId { set; get; }//游戏类型
        [Display(Name = "作者")]
        public string Announcer { set; get; }
        [Display(Name = "原作者")]
        public string ReferAthor { set; get; }
        [Display(Name = "推荐等级")]
        public int Rank { set; get; }
        //Recommendation level
        [Display(Name = "头条等级")]
        public int toplevel { set; get; }
        [Display(Name = "浏览量")]
        public int readers { set; get; }
    }
}
