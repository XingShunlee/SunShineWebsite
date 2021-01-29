using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ehaiker.Auth
{
    public class MenuItem
    {
        public string MenuString { set; get; }
        public List<Permission> items { set; get; }
    }
}