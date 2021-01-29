using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ehaiker.Models;
using ehaiker.Managers;
using Microsoft.AspNetCore.Mvc;
using ehaikerv202010.Models;

namespace ehaiker.Controllers
{
    public class GameStrategiesController : Controller
    {
        private IRepository<GameStrategies> _noteRepository ;
              
        private IRepository<GameType> _noteTypeRepository;
        private EhaikerContext DbContext;

        public GameStrategiesController(EhaikerContext _cont)
        {
            DbContext = _cont;
            _noteRepository = new GameStrategiesRepository(DbContext);
            _noteTypeRepository = new GameTypeRepository(DbContext);
          
        }
        
        public ActionResult Index(int page=0)
        {
            ViewBag.PageIndex = page;//当前页
            return View("bsIndex");
        }
       
        ///
        [HttpPost]//GameStrategies
        public JsonResult GetGameStrategies(int page=1, int rows=10, int type = 1, string name = "")
        {
            page = page > 0 ? page : 1;
            GameStrategiesRepository _noteRepository;
            _noteRepository = new GameStrategiesRepository(DbContext);
            var query = new List<GameStrategies>();
            if (type != -1)
            {
               
                if (type == 0)
                {
                    query = _noteRepository.List();
                }
                else
                {
                    query = _noteRepository.GetDbSet().Where(r => r.GameId == type).ToList();
                }
               
               
            }
            else
            {
                query = (from c in _noteRepository.GetDbSet()
                         where c.Title.Contains(name)
                         select c).ToList();
               
            }
            var count = query.Count();
            var pagecount = count % rows == 0 ? count / rows : count / rows + 1;
            var findItems = query.OrderByDescending(r => r.LastEditTime)
                .Skip((page - 1) * rows)
                .Take(rows)
                .ToList();
            var notes = new Tuple<List<GameStrategies>, int>(findItems, pagecount);

            ViewBag.PageIndex = page;//当前页
            var tt = new { Total = notes.Item2, data = notes.Item1 };
            return Json(tt);

        }
    }
}