using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
//图文项
namespace ehaiker.Models
{
    public class GameModel
    {
        [Key]
        public int ItemID { get; set; }

        /// <summary>
        /// 项名称
        /// </summary>
        [Display(Name = "项名称")]
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
        public string targetUri { get; set; }

        /// <summary>
        /// 运营商
        /// </summary>
        [Display(Name = "运营服务商")]
        public string supporter { get; set; }
        /// <summary>
        /// 制造商
        /// </summary>
        [Display(Name = "制造商")]
        public string producer { get; set; }
        /// <summary>
        /// 游戏描述
        /// </summary>
        [Display(Name = "游戏介绍")]
        public string gameDescription { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "资源")]
        public string resourcefrom { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        [Display(Name = "采集时间")]
        public DateTime MineTime { get; set; }
        /// <summary>
        /// 推荐等级
        /// </summary>
        [Display(Name = "推荐等级")]
        public int TopLevel { get; set; }
        [Display(Name = "评分")]
        public float grade { get; set; }

        [Display(Name = "游戏类型：APP|页游|端游")]
        public int Gametype { get; set; }
        [Display(Name = "上线时间")]
        public DateTime StartTime { get; set; }
        [Display(Name = "结束时间")]
        public DateTime EndTime { get; set; }
        [Display(Name = "作者")]
        public string Announcer { set; get; }
        [Display(Name = "原作者")]
        public string ReferAthor { set; get; }
        [Display(Name = "关键词")]
        public string Keywords { set; get; }
        [Display(Name = "审核标志")]
        public int IsIdentified { set; get; }
        [Display(Name = "提交者ID")]
        public int AuthorID { set; get; }
    }
}