using System.Web;

namespace ehaikerv202010.helpers
{
    public static class JSCoderHelper
    {
        //些方法支持汉字
        public static string escape(string s)
        {
            if (string.IsNullOrEmpty(s))
                return string.Empty;

            return HttpUtility.UrlEncode(s);

        }
        //把JavaScript的escape()转换过去的字符串解释回来
        //些方法支持汉字
        public static string unescape(string s)
        {
            if (string.IsNullOrEmpty(s))
                return string.Empty;

            return HttpUtility.UrlDecode(s); ;

        }
    }
}
