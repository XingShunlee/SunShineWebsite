using ehaiker;
using ehaikerv202010.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ehaikerv202010.Controllers
{
    public class ITBlogController : Controller
    {
        private ehaiker.EhaikerContext DbContext;
        public ITBlogController(EhaikerContext _cont)
        {
           
            DbContext = _cont;

        }
        public IActionResult Index(int page=0)
        {
            ViewBag.PageIndex = page;//当前页
            return View("bsIndex");
        }
        [HttpPost]//GameStrategies
        public JsonResult GetBlogs(int page = 1, int rows = 10, int type =-1, string name=null )
        {
            page = page > 0 ? page : 1;
            ItBlogRepository _noteRepository;
            _noteRepository = new ItBlogRepository(DbContext);
            var query = new List<ItBlogModel>();
            if (type != -1)
            {
                query = _noteRepository.GetDbSet().Where(r => r.IsIdentified > 0 && r.IsUnVisible < 1).ToList();
             
            }
            else
            {
                query = (from c in _noteRepository.GetDbSet()
                         where c.Title.Contains(name) && c.IsIdentified > 0 && c.IsUnVisible < 1
                         select c).ToList();

            }
            var count = query.Count();
            var pagecount = count % rows == 0 ? count / rows : count / rows + 1;
            var findItems = query.OrderByDescending(r => r.LastEditTime)
                .Skip((page - 1) * rows)
                .Take(rows)
                .ToList();
            var notes = new Tuple<List<ItBlogModel>, int>(findItems, pagecount);
            var tt = new { Total = notes.Item2, data = notes.Item1 };
            return Json(tt);
            //return Json(findItems);

        }
    }
}
