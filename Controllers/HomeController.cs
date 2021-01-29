using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using ehaikerv202010.Models;

namespace ehaikerv202010.Controllers
{
    public class HomeController : Controller
    {
        private IMemoryCache _memoryCache;
        public HomeController(IMemoryCache chache){
            _memoryCache =chache;
        }
        public IActionResult Index()
        {
            string cachekey ="key";
            string result =string.Empty;
            if(!_memoryCache.TryGetValue(cachekey,out result)){
                result = $"LineZero(DateTime.Now";
                _memoryCache.Set(cachekey,result);
            }
            ViewBag.Cache =result;
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
