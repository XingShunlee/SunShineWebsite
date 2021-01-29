using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ehaiker.Auth
{
    /// <summary>
    /// 角色权限绑定
    /// </summary>
    public class RolePermissionBinder
    {
        [Key]
        public virtual int Id //项ID
        {
            set;
            get;
        }
        public virtual int ControllerNo //角色ID
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
        //权限字符串，","隔开
        public virtual string OwnPermissions
        {
            set;
            get;
        }
    }
}