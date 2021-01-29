using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ehaiker.Managers;
using ehaiker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.AspNetCore.Http;
using ehaikerv202010;
using ehaikerv202010.Models;

namespace ehaiker.Controllers
{
    public class GameStrategiesShowController : Controller
    {
        private EhaikerContext DbContext;
        private IMemoryCache _memoryCache;
        public GameStrategiesShowController(EhaikerContext _cont, IMemoryCache memcache)
        {
            DbContext = _cont;
            _memoryCache = memcache;
        }
        public ActionResult Index(int Id = 1)
        {
            webCounter countobj = null;
            string counterstring ="gamestrateTimer";
            if(!_memoryCache.TryGetValue<webCounter>(counterstring, out countobj))
            {
                webCounter gamewenzhan = new webCounter();
                gamewenzhan.DoCountEvent += Gamewenzhan_DoCountEvent;
                gamewenzhan.GetItemCountEvent += Gamewenzhan_GetItemCountEvent;
                gamewenzhan.StartWrite();
                _memoryCache.Set<webCounter>(counterstring, gamewenzhan);
                countobj = gamewenzhan;
            }
            
            if (countobj != null)
            {
                countobj.accessMethod(HttpContext);
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
                 IRepository<CommentModel> _commentRepository  = new GameCommentManager(DbContext);
                List<CommentModel> comments = _commentRepository.GetDbSet().Where(r => r.GameStrateID == Id && r.IsChecked>0)?.ToList();
               if (comments != null)
                {
                    ViewBag.comments = comments;
                }
                else
                {
                    ViewBag.comments = new List<CommentModel> { new CommentModel { comment="還沒有評論" } };
                }
                return View(item);
            }
            else
            {
                GameStrategies item = new GameStrategies 
                {Author=" " };
                ViewBag.comments = new List<CommentModel> { new CommentModel { comment = "還沒有評論" } };
                return View(item);
            }
        }
         private void Gamewenzhan_DoCountEvent(object sender, CountItemdEventArgs<string> e)
        {
            try
            {
                int id = Convert.ToInt32(e.Value);
                ehaiker.Models.IRepository<GameStrategies> _noteRepository = new GameStrategiesRepository(DbContext);
                var notes = _noteRepository.GetDbSet().Where(r => r.Id == id).FirstOrDefault();
                if (notes != null)
                {
                    GameStrategies item = notes as GameStrategies;
                    item.readers = e.count;
                    _noteRepository.Update(item);
                }
            }
            catch
            {
                ;
            }
        }
        private void Gamewenzhan_GetItemCountEvent(object sender, CountItemdEventArgs<string> e)
        {
            int id = Convert.ToInt32(e.Value);
            ehaiker.Models.IRepository<GameStrategies> _noterepository = new GameStrategiesRepository(DbContext);
            var notes = _noterepository.GetDbSet().Where(r => r.Id == id).FirstOrDefault();
            if (notes != null)
            {
                GameStrategies item = notes as GameStrategies;
                e.count = item.readers + e.count;
            }
        }
    }
}
