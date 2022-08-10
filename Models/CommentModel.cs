using System;
using System.ComponentModel.DataAnnotations;

namespace ehaiker.Models
{
    public class CommentModel
    {
        [Key]
        public int CommentID { get; set; }
        //[ForeignKey("Id")]
        public int GameID { get; set; }
        public int GameStrateID { get; set; }
        /// <summary>
        /// 项名称
        /// </summary>
        [Display(Name = "游戲名稱")]
        public string GameName { get; set; }
        [Display(Name = "用戶名稱")]
        public string UserName { get; set; }
        [Display(Name = "用戶ID")]
        public int UserId { get; set; }
        /// <summary>
        /// 介绍图片
        /// </summary>
        [Display(Name = "評論")]
        public string comment { get; set; }

        [Display(Name = "創建时间")]
        public DateTime? CreateTime { get; set; }
        [Display(Name = "是否审核")]
        public int IsChecked { get; set; }
    }
}