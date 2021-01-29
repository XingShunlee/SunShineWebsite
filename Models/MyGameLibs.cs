using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ehaikerv202010.Models
{
    public class MyGameLibs
    {
        [Key]
        public int IndexID { get; set; }

        /// <summary>
        /// 项名称
        /// </summary>
        [Display(Name = "外部游戏ID")]
        public int GameID { get; set; }
        [Display(Name = "会员ID")]
        public int MemberShipID { get; set; }

        /// <summary>
        /// 项名称
        /// </summary>
        [Display(Name = "项名称")]
        public string ItemName { get; set; }
        [Display(Name = "游戏类型：APP|页游|端游")]
        public int Gametype { get; set; }
    }
}
