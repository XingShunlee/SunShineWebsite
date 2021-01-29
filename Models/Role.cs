using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ehaiker.Auth
{
    /// <summary>
    /// 角色
    /// </summary>
    public class Role
    {
        [Key]
        public virtual int Id //角色ID
        {
            set;
            get;
        }
        public virtual string Name//角色名字
        {
            set;
            get;
        }
        public virtual string Description//描述
        {
            set;
            get;
        }
        
        public virtual DateTime CreateTime
        {
            set;
            get;
        }
        public virtual int IsValidatedOK
        {
            set;
            get;
        }
    }
}