﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ehaiker.Auth
{
    /// <summary>
    /// 逻辑组
    /// </summary>
    public class Group
    {
        [Key]
        public virtual int Id //组ID
        {
            set;
            get;
        }
        public virtual string Name//组名字
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