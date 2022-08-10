using ehaiker.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ehaiker.Controllers
{
    public class GameCenterController : Controller
    {
        private EhaikerContext DbContext;
        public GameCenterController(EhaikerContext _cont)
        {
            DbContext = _cont;
        }
        public ActionResult Index()
        {
            return View("bsIndex");
        }
        [HttpPost]//GameStrategies
        public JsonResult GetGameListInfo(int page = 1, int rows = 10, int type = 1, string name = "")
        {
            page = page > 0 ? page : 1;
            GameListManager GamelistManager = new GameListManager(DbContext);
            var query = new List<GameModel>();
            if (type >= 0)
            {

                if (type == 0)
                {
                    query = GamelistManager.GetDbSet().Where(r => r.IsIdentified > 0).ToList();
                }
                else
                {
                    query = GamelistManager.GetDbSet().Where(r => r.Gametype == type && r.IsIdentified > 0).ToList();
                }


            }
            else
            {

                query = (from c in GamelistManager.GetDbSet()
                         where c.ItemName.Contains(name) && c.IsIdentified > 0
                         select c).ToList();

            }
            var count = query.Count();
            var pagecount = count % rows == 0 ? count / rows : count / rows + 1;
            var findItems = query.OrderByDescending(r => r.TopLevel)
                .Skip((page - 1) * rows)
                .Take(rows)
                .ToList();
            var notes = new Tuple<List<GameModel>, int>(findItems, pagecount);

            ViewBag.PageIndex = page;//当前页
            var tt = new { Total = notes.Item2, data = notes.Item1 };
            return Json(tt);

        }
    }
}
