using ehaikerv202010;
using Microsoft.AspNetCore.Http;
using System;
using System.Text;
using System.Web;

namespace ehaiker
{
    public class MemUserDataManager
    {
        //更新数据到内存
        public static void UpdateSessionData(HttpContext Current, string key, object memuser)
        {
            //更新全局数据
            string toJsonstring = HttpUtility.UrlEncode(JsonHelper.SerializeObject(memuser),
               Encoding.GetEncoding("UTF-8"));
            Current.Session.SetString(key, toJsonstring);
        }
        public static void AddSessionData(HttpContext Current, string key, Object memuser)
        {
            //更新全局数据
            string toJsonstring = HttpUtility.UrlEncode(JsonHelper.SerializeObject(memuser),
               Encoding.GetEncoding("UTF-8"));
            Current.Session.SetString(key, toJsonstring);
        }
        public static void RemoveSessionData(HttpContext Current, string key)
        {
            Object cookie = Current.Session.GetString(key);
            if (cookie != null)
            {
                Current.Session.Remove(key);
            }
        }
        public static T GetMemSessionData<T>(HttpContext Current, string key) where T : class
        {
            //没有登录
            string cookieobj = Current.Session.GetString(key);
            if (!string.IsNullOrEmpty(cookieobj))
            {
                //从Cookie对象中取出Json串
                string jsonUserInfo = HttpUtility.UrlDecode(cookieobj, Encoding.UTF8);
                T juser = JsonHelper.DeserializeJsonToObject<T>(jsonUserInfo);
                return juser;
            }
            return default(T);
        }
    }
}