using ehaiker.Managers;
using ehaiker.Models;
using ehaikerv202010.Filters;
using ehaikerv202010.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace ehaiker.Controllers
{
    public class GameStrategiesShowController : Controller
    {
        private EhaikerContext DbContext;
        private IMemoryCache _memoryCache;
        private IWebCountInterface _WebCount;
        private readonly Microsoft.Extensions.Logging.ILogger _logger;
        public GameStrategiesShowController(EhaikerContext _cont, IMemoryCache memcache,
            IWebCountInterface _IWebCount, ILogger<GameStrategiesShowController> logger)
        {
            DbContext = _cont;
            _memoryCache = memcache;
            _WebCount = _IWebCount;
            _logger = logger;
        }
        public ActionResult Index(int Id = 1)
        {
            //webCounter countobj = null;
            //string counterstring ="gamestrateTimer";
            //if(!_memoryCache.TryGetValue<webCounter>(counterstring, out countobj))
            //{
            //    webCounter gamewenzhan = new webCounter();
            //    gamewenzhan.DoCountEvent += Gamewenzhan_DoCountEvent;
            //    gamewenzhan.GetItemCountEvent += Gamewenzhan_GetItemCountEvent;
            //    gamewenzhan.StartWrite();
            //    _memoryCache.Set<webCounter>(counterstring, gamewenzhan);
            //    countobj = gamewenzhan;
            //}
            if (_WebCount != null)
            {
                _WebCount.accessMethod(HttpContext, DbContext);
            }
            ViewBag.loging = 0;
            MemberShip cookie = MemUserDataManager.GetMemSessionData<MemberShip>(HttpContext, "memshipUserInfo");
            if (cookie != null)
                ViewBag.loging = 1;
            IRepository<GameStrategies> _noteRepository = new GameStrategiesRepository(DbContext);
            var notes = _noteRepository.GetDbSet().Where(r => r.Id == Id).FirstOrDefault();
            if (notes != null)
            {
                GameStrategies item = notes as GameStrategies;
                IRepository<CommentModel> _commentRepository = new GameCommentManager(DbContext);
                List<CommentModel> comments = _commentRepository.GetDbSet().Where(r => r.GameStrateID == Id && r.IsChecked > 0)?.ToList();
                if (comments != null)
                {
                    ViewBag.comments = comments;
                }
                else
                {
                    ViewBag.comments = new List<CommentModel> { new CommentModel { comment = "還沒有評論" } };
                }
                return View(item);
            }
            else
            {
                GameStrategies item = new GameStrategies
                { Author = " " };
                ViewBag.comments = new List<CommentModel> { new CommentModel { comment = "還沒有評論" } };
                return View(item);
            }
        }


    }
}
