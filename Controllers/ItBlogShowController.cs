using ehaiker;
using ehaiker.Models;
using ehaikerv202010.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ehaikerv202010.Controllers
{
    public class ItBlogShowController : Controller
    {
        private ehaiker.EhaikerContext DbContext;
        public ItBlogShowController(EhaikerContext _cont)
        {

            DbContext = _cont;

        }
        public IActionResult Index(int Id = 1)
        {
            ViewBag.loging = 0;
            MemberShip cookie = MemUserDataManager.GetMemSessionData<MemberShip>(HttpContext, "memshipUserInfo");
            if (cookie != null)
                ViewBag.loging = 0;
            ItBlogRepository _noteRepository = new ItBlogRepository(DbContext);
            var notes = _noteRepository.GetDbSet().Where(r => r.Id == Id).FirstOrDefault();
            if (notes != null)
            {
                ItBlogModel item = notes as ItBlogModel;
                
                ViewBag.comments = new List<CommentModel> { new CommentModel { comment = "還沒有評論" } };
                
                return View(item);
            }
            else
            {
                ItBlogModel item = new ItBlogModel
                { Author = " " };
                ViewBag.comments = new List<CommentModel> { new CommentModel { comment = "還沒有評論" } };
                return View(item);
            }
        }
    }
}
