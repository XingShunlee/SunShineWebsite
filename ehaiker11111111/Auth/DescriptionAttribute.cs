using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ehaiker.Auth
{
    /// <summary>
    /// Description Attribute
    /// </summary>
    public class DescriptionAttribute : Attribute
    {
       public DescriptionAttribute()
        {
            isGet= true;
            ShowInMgrbar = false;
        }
        public string Name
        {
            set;
            get;
        }
        public int No
        {
            set;
            get;
        }
        public bool isGet //用于生产权限菜单，当为0的时候，post方式，不显示
        {
            set;
            get;
        }
        public Boolean ShowInMgrbar //用于生产权限菜单，当为0的时候，显示在管理员菜单中
        {
            set;
            get;
        }
    }
}