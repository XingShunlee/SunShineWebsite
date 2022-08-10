using ehaikerv202010.helpers;

namespace ehaikerv202010.Filters
{
    public class EncodeService
    {
        public string EncodeString(string s)
        {
            return JSCoderHelper.escape(s);
        }
        public string DecodeString(string s)
        {
            return JSCoderHelper.unescape(s);
        }
    }
}
