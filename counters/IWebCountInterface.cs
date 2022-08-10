using ehaiker;
using Microsoft.AspNetCore.Http;

namespace ehaikerv202010.Filters
{
    public interface IWebCountInterface
    {
        void StartWrite();
        void StopWrite();
        void InitData();
        void accessMethod(HttpContext request, EhaikerContext _cont);
        void timer();
    }
}
