using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using ehaiker.Models;
using ehaikerv202010;
using ehaikerv202010.Filters;
using ehaikerv202010.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ehaiker.Controllers
{
    public class MyGameCenterController : Controller
    {
        private EhaikerContext DbContext;
        private IHostingEnvironment _env;
        public MyGameCenterController(EhaikerContext _cont, IHostingEnvironment env)
        {
            DbContext = _cont;
            _env = env;
        }
        public ActionResult Index()
        {
            MemberShip cookie = MemUserDataManager.GetMemSessionData<MemberShip>(HttpContext, "memshipUserInfo");
            if (cookie != null)
            {
                return View("bsIndex", cookie);
            }
            else
            {
                MemberShip user = new MemberShip() { UserName = "游客", UserId = 0, Password = "0" };

                return View("bsIndex", user);
            }
        }
        [HttpPost]//GameStrategies
        [LoginStateRequiredAttribute]
        public JsonResult GetGameListInfo(int page = 1, int rows = 10, int type = 1,string name="")
        {
            page = page > 0 ? page : 1;
            MyGameManager GameManager = new MyGameManager(DbContext);
            GameListManager GamelistManager = new GameListManager(DbContext);
            MemberShip loginuser = MemUserDataManager.GetMemSessionData<MemberShip>(HttpContext, "memshipUserInfo");
            var query1 = new List<GameModel>();
            if (type >= 0)
            {
                var query = new List<MyGameLibs> () ;
               
                if (type==0)
                {
                        query1 = (from c in GamelistManager.GetDbSet()
                                 from d in GameManager.GetDbSet()
                                  where loginuser.UserId == d.MemberShipID
                                  select c).ToList();
                }
                else
                {
                    query1 = (from c in GamelistManager.GetDbSet()
                               from d in GameManager.GetDbSet()
                               where c.Gametype == d.Gametype && loginuser.UserId == d.MemberShipID
                              select c).ToList();
                }
                
            }
            else
            {

                query1 = (from c in GamelistManager.GetDbSet()
                         from d in GameManager.GetDbSet()
                         where c.ItemName.Contains(name) && c.ItemID == d.GameID && c.Gametype == d.Gametype
                         select c).ToList();
               
            }
            var count = query1.Count();
            var pagecount = count % rows == 0 ? count / rows : count / rows + 1;
            var findItems = query1.OrderByDescending(r => r.TopLevel)
                .Skip((page - 1) * rows)
                .Take(rows)
                .ToList();
            var notes = new Tuple<List<GameModel>, int>(findItems, pagecount);

            ViewBag.PageIndex = page;//当前页
            var tt = new { Total = notes.Item2, data = notes.Item1 };
            return Json(tt);

        }
        [LoginStateRequiredAttribute]
        public ActionResult NewGameItem()
        {
            IRepository<GameType> _noteTypeRepository;
            _noteTypeRepository = new GameTypeRepository(DbContext);
            var types = _noteTypeRepository.List();
            ViewBag.GameTypes = types.Select(r => new SelectListItem { Text = r.Name, Value = r.GameId.ToString() });
            return View("NewGameItem");
        }
        [LoginStateRequiredAttribute]
        public ActionResult ShowMyGames() {
            return View("myGameIndex");
        }
        [HttpPost]
        [LoginStateRequiredAttribute]
        public JsonResult AddNewGameItem(string Item_parameter)
        {
            GameModel gameItem = JsonHelper.DeserializeJsonToObject<GameModel>(Item_parameter);
            if (gameItem != null)
            {
                MemberShip cookie = MemUserDataManager.GetMemSessionData<MemberShip>(HttpContext, "memshipUserInfo");

                GameListManager GamelistManager = new GameListManager(DbContext);
                //
                gameItem.MineTime = DateTime.Now;
                gameItem.StartTime = DateTime.Now;
                gameItem.EndTime = DateTime.Now.AddDays(1);
                //过滤脚本
                if (!string.IsNullOrEmpty(gameItem.gameDescription))
                    gameItem.gameDescription = System.Text.RegularExpressions.Regex.Replace(gameItem.gameDescription, "/(?!<(img|p|span).*?>)<.*?>/g", "");
                if (!string.IsNullOrEmpty(gameItem.ItemName))
                    gameItem.ItemName = System.Text.RegularExpressions.Regex.Replace(gameItem.ItemName, "/(?!<(img|p|span).*?>)<.*?>/g", "");
                if (!string.IsNullOrEmpty(gameItem.Keywords))
                    gameItem.Keywords = System.Text.RegularExpressions.Regex.Replace(gameItem.Keywords, "/(?!<(img|p|span).*?>)<.*?>/g", "");
                if (!string.IsNullOrEmpty(gameItem.producer))
                    gameItem.producer = System.Text.RegularExpressions.Regex.Replace(gameItem.producer, "/(?!<(img|p|span).*?>)<.*?>/g", "");
                if (!string.IsNullOrEmpty(gameItem.supporter))
                    gameItem.supporter = System.Text.RegularExpressions.Regex.Replace(gameItem.supporter, "/(?!<(img|p|span).*?>)<.*?>/g", "");
                if (!string.IsNullOrEmpty(gameItem.ImgHoverUri))
                    gameItem.ImgHoverUri = System.Text.RegularExpressions.Regex.Replace(gameItem.ImgHoverUri, "/(?!<(img|p|span).*?>)<.*?>/g", "");
                if (!string.IsNullOrEmpty(gameItem.ImgDescUri))
                    gameItem.ImgDescUri = System.Text.RegularExpressions.Regex.Replace(gameItem.ImgDescUri, "/(?!<(img|p|span).*?>)<.*?>/g", "");
                //作者
                gameItem.Announcer = cookie.Account;
                gameItem.AuthorID = cookie.UserId;
                gameItem.IsIdentified = 0;
                GamelistManager.Add(gameItem);
                GamelistManager.SaveChanges();
                var tt0 = new { code = 0, data = "添加成功" };
                return Json(tt0);
            }
            var tt = new { code = 10000, data = "未知错误" };
            return Json(tt);
        }
        [HttpPost]
        [LoginStateRequiredAttribute]
        public JsonResult GetDescImgs()
        {
            //枚举图片文件
            string imgurl = _env.WebRootPath + ("/public/games");
            var imgs = FileUploadHelper.FindImg(imgurl, "../public/games/");
            var tt = new { total = imgs.Count(), data = imgs.ToList() };
            return Json(tt); ;
        }
        [HttpPost]
        [LoginStateRequiredAttribute]
        public JsonResult SaveMyGameItem(int gid)
        {
            int errorCode = 0;
            string errMsg = "操作失败！";
            GameListManager GamelistManager = new GameListManager(DbContext);
            GameModel gitem = GamelistManager.GetById(gid);
            MemberShip cookie = MemUserDataManager.GetMemSessionData<MemberShip>(HttpContext, "memshipUserInfo");
            if (gitem != null)
            {
                MyGameManager mgr = new MyGameManager(DbContext);
                MyGameLibs item = new MyGameLibs();
                item.GameID = gitem.ItemID;
                item.Gametype = gitem.Gametype;
                item.ItemName = gitem.ItemName;
                item.MemberShipID = cookie.UserId;
                mgr.Add(item);
                mgr.SaveChanges();
                errMsg = "操作成功";
                var retjson = new { ErrorCode = errorCode, iSuccessCode = 0, msg = errMsg };
                return Json(retjson);
            }
            var tt = new { ErrorCode = 10000, msg = "未知错误" };
            return Json(tt);

        }
        //ShowMyGames
        [HttpPost]//GameStrategies
        [LoginStateRequiredAttribute]
        public JsonResult GetMyGameListInfo(int page = 1, int rows = 10, int type = 1)
        {
            page = page > 0 ? page : 1;
            MemberShip loginuser = MemUserDataManager.GetMemSessionData<MemberShip>(HttpContext, "memshipUserInfo");
            MyGameManager GameManager = new MyGameManager(DbContext);
            GameListManager GamelistManager = new GameListManager(DbContext);
            var query1 = new List<GameModel>();
            if (type >= 0)
            {
                var query = new List<MyGameLibs>();

                if (type == 0)
                {
                    query1 = (from c in GamelistManager.GetDbSet()
                              from d in GameManager.GetDbSet()
                              where c.ItemID == d.GameID && loginuser.UserId==d.MemberShipID
                              select c).ToList();
                }
                else
                {
                    query1 = (from c in GamelistManager.GetDbSet()
                              from d in GameManager.GetDbSet()
                              where c.ItemID == d.GameID && c.Gametype == d.Gametype && loginuser.UserId == d.MemberShipID
                              select c).ToList();
                }

            }
           
            var count = query1.Count();
            var pagecount = count % rows == 0 ? count / rows : count / rows + 1;
            var findItems = query1.OrderByDescending(r => r.TopLevel)
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
