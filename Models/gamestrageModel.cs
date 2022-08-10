using System;
using System.ComponentModel.DataAnnotations;

namespace ehaikerv202010.Models
{
    public class GameStrategies
    {
        public int Id { set; get; }
        [Required]
        [MaxLength(1024)]
        public string Title { set; get; }
        [Required]
        public string Content { set; get; }
        public DateTime CreateTime { set; get; }
        [Display(Name = "最后更新")]
        public DateTime LastEditTime { set; get; }
        [Display(Name = "游戏类型")]
        public int GameId { set; get; }//游戏类型
        [Display(Name = "作者")]
        public string Author { set; get; }
        [Display(Name = "原作者")]
        public string ReferAthor { set; get; }
        [Display(Name = "原网址")]
        public string ReferUri { set; get; }
        [Display(Name = "推荐等级")]
        public int Rank { set; get; }
        //Recommendation level
        [Display(Name = "头条等级")]
        public int toplevel { set; get; }
        [Display(Name = "浏览量")]
        public int readers { set; get; }
        [Display(Name = "审核标志")]
        public int IsIdentified { set; get; }
        [Display(Name = "提交者ID")]
        public string UserGuid { set; get; }
        [Display(Name = "查看等级")]
        public int VipLevel { set; get; }
        [Display(Name = "查看需要多少钱")]
        public int lookupvalue { set; get; }
        [Display(Name = "隐藏标志")]
        public int IsUnVisible { set; get; }
    }

    public class GameStrategiesModel
    {
        public int Id { set; get; }
        [Required]
        [MaxLength(1024)]
        public string Title { set; get; }
        [Required]
        public string Content { set; get; }
        public DateTime CreateTime { set; get; }
        public DateTime LastEditTime { set; get; }
        [Display(Name = "游戏类型")]
        public int GameId { set; get; }//游戏类型
        [Display(Name = "作者")]
        public string Author { set; get; }
        [Display(Name = "原作者")]
        public string ReferAthor { set; get; }
        [Display(Name = "原网址")]
        public string ReferUri { set; get; }
        [Display(Name = "推荐等级")]
        public int Rank { set; get; }
        //Recommendation level
        [Display(Name = "头条等级")]
        public int toplevel { set; get; }
        [Display(Name = "浏览量")]
        public int readers { set; get; }
        [Display(Name = "审核标志")]
        public int IsIdentified { set; get; }
        [Display(Name = "提交者ID")]
        public string UserGuid { set; get; }
        [Display(Name = "查看等级")]
        public int lookupLevel { set; get; }
        [Display(Name = "查看需要多少钱")]
        public int lookupvalue { set; get; }
    }
}
