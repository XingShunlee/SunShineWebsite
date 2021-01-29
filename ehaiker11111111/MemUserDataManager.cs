using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ehaiker.Models;
using System.Text;
using System.Web.Mvc;

namespace ehaiker
{
    public class MemUserDataManager
    {
        //更新数据到内存
        public static void UpdateSessionData(string key, object memuser)
        {
            //更新全局数据
            string toJsonstring = HttpUtility.UrlEncode(JsonHelper.SerializeObject(memuser),
               Encoding.GetEncoding("UTF-8"));
            HttpContext.Current.Session[key]=toJsonstring;
        }
        public static void AddSessionData(string key, Object memuser)
        {
            //更新全局数据
            string toJsonstring = HttpUtility.UrlEncode(JsonHelper.SerializeObject(memuser),
               Encoding.GetEncoding("UTF-8"));
            HttpContext.Current.Session.Add(key, toJsonstring);
        }
        public static void RemoveSessionData( string key)
        {
            Object cookie = HttpContext.Current.Session[key];
            if (cookie != null)
            {
                HttpContext.Current.Session.Remove(key);
            }
        }
        public static T GetMemSessionData<T>(string key) where T : class
        {
            //没有登录
            Object cookieobj = HttpContext.Current.Session[key];
            if (cookieobj != null)
            {
                //从Cookie对象中取出Json串
                string jsonUserInfo = HttpUtility.UrlDecode(cookieobj.ToString(), Encoding.UTF8);
                T juser = JsonHelper.DeserializeJsonToObject<T>(jsonUserInfo);
                return juser;
            }
            return default(T);
        }
    }
}