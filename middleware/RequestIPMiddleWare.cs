using ehaiker;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class RequestIPMiddleWare
{
    private readonly Microsoft.AspNetCore.Http.RequestDelegate _Next;
    private readonly Microsoft.Extensions.Logging.ILogger _logger;
    private readonly EhaikerContext _DBContext;
    public static object locker = new object();//添加一个对象作为锁
    private static List<Dictionary<string, Int32>> accessNumMapList = new List<Dictionary<String, Int32>>();
    public static List<string> iplist = new List<string>();
    ///接受传入参数
    public string Str { get; set; }
    public RequestIPMiddleWare(RequestDelegate next, ILogger<RequestIPMiddleWare> logger, string s, EhaikerContext _context)
    {
        _Next = next;
        _logger = logger;
        Str = s;
        _DBContext = _context;
    }
    public async Task Invoke(HttpContext context)
    {
        _logger.LogInformation("\n _______logging user infomation for using middleware..___________\n");
        _logger.LogInformation("user IP:" + context.Connection.RemoteIpAddress.ToString());

        if (context.Session.GetString("AspnetCore") == null)
        {
            context.Session.SetString("AspnetCore", DateTime.Now.ToString());
        }
        _logger.LogInformation("user visted:__" + context.Session.GetString("AspnetCore"));
        _logger.LogInformation("\n _______logging user infomation for using middleware...ok___________\n");
        //
        await _Next.Invoke(context);
    }


}
//该中间件扩展接口

public static class Extensions
{
    public static IApplicationBuilder UseRequestIP(this IApplicationBuilder builder, string s)
    {
        return builder.UseMiddleware<RequestIPMiddleWare>(s);
    }

}