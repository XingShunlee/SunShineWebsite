using System.ComponentModel.DataAnnotations;

namespace ehaiker.Auth
{
    public class Permission
    {
        /// <summary>
        /// Permission Id
        /// </summary>
        [Key]
        public int Id { set; get; }
        public virtual int GlobalNo { set; get; }

        /// <summary>
        /// Permission Action Name
        /// </summary>
        public string ChineseActionName { set; get; }
        /// <summary>
        /// Controller
        /// </summary>
        public string Controller { set; get; }

        /// <summary>
        /// Action
        /// </summary>
        public string Action { set; get; }
        public string Description { set; get; }
        /// <summary>
        /// 1---是get 0---post，默认该方法位post
        /// </summary>
        public int isGet { set; get; }
        //控制显示再管理面板
        public int ShowInManagerBar { set; get; }
        [Display(Name = "等级控制")]
        public int VisitLevel { set; get; }
    }
}