using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ehaiker.Auth
{
    /// <summary>
    /// 逻辑组权限绑定表，每个组对应某些权限
    /// </summary>
    public class GroupPermissionBinder
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