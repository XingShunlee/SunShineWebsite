using ehaiker.Models;
using ehaikerv202010;
using ehaikerv202010.Filters;
using ehaikerv202010.helpers;
using ehaikerv202010.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ehaiker.Controllers
{
    public class MyGameStrategiesController : Controller
    {
        private IRepository<MyGameStrage> _noteRepository;

        private IRepository<GameType> _noteTypeRepository;
        private EhaikerContext DbContext;
        private IHostingEnvironment _env;
        public MyGameStrategiesController(EhaikerContext _cont, IHostingEnvironment env)
        {
            _env = env;
            DbContext = _cont;
            _noteRepository = new MyGameStragesManager(DbContext);
            _noteTypeRepository = new GameTypeRepository(DbContext);

        }
        [LoginStateRequiredAttribute]
        public ActionResult Index(int page = 0)
        {
            ViewBag.PageIndex = page;//当前页
            MemberShip cookie = MemUserDataManager.GetMemSessionData<MemberShip>(HttpContext, "memshipUserInfo");
            if (cookie != null)
            {
                return View("bsIndex", cookie);
            }
            else
            {
                MemberShip user = new MemberShip() { UserName = "游客", UserId = 0, Password = "0", UserGuid = Guid.NewGuid().ToString() };

                return View("bsIndex", user);
            }
        }
        [LoginStateRequiredAttribute]
        public ActionResult ShowMyGameStrages()
        {
            return View("GameStragesList");
        }
        ///
        [HttpPost]//GameStrategies
        [LoginStateRequiredAttribute]
        public JsonResult GetGameStrategies(int page = 1, int rows = 10, int type = 1, string name = "")
        {
            page = page > 0 ? page : 1;
            GameStrategiesRepository _GameStragies = new GameStrategiesRepository(DbContext);
            var query1 = new List<GameStrategies>();
            MemberShip loginuser = MemUserDataManager.GetMemSessionData<MemberShip>(HttpContext, "memshipUserInfo");

            if (type != -1 && loginuser != null)
            {

                if (type == 0)
                {

                    query1 = (
                              from d in _GameStragies.GetDbSet()
                              where d.UserGuid == loginuser.UserGuid
                              select d).ToList();
                }
                else
                {
                    query1 = (
                              from d in _GameStragies.GetDbSet()
                              where d.UserGuid == loginuser.UserGuid && d.GameId == type
                              select d).ToList();
                }

            }
            else
            {
                query1 = (
                         from d in _GameStragies.GetDbSet()
                         where d.Title.Contains(name) && d.UserGuid == loginuser.UserGuid
                         select d).ToList();

            }
            var count = query1.Count();
            var pagecount = count % rows == 0 ? count / rows : count / rows + 1;
            var findItems = query1.OrderByDescending(r => r.LastEditTime)
                .Skip((page - 1) * rows)
                .Take(rows)
                .ToList();
            var notes = new Tuple<List<GameStrategies>, int>(findItems, pagecount);

            ViewBag.PageIndex = page;//当前页
            var tt = new { Total = notes.Item2, data = notes.Item1 };
            return Json(tt);

        }
        //修改攻略
        [LoginStateRequiredAttribute]
        public ActionResult showDetail(int Id = 1)
        {
            //
            IRepository<GameType> _noteTypeRepository;
            _noteTypeRepository = new GameTypeRepository(DbContext);
            var types = _noteTypeRepository.List();
            MemberShip loginuser = MemUserDataManager.GetMemSessionData<MemberShip>(HttpContext, "memshipUserInfo");
            if (loginuser != null)
            {

                IRepository<GameStrategies> _noteRepository = new GameStrategiesRepository(DbContext);
                var notes = _noteRepository.GetDbSet().Where(r => r.Id == Id &&
                    r.UserGuid == loginuser.UserGuid).FirstOrDefault();
                if (notes != null)
                {
                    ViewBag.Types = types.Select(r => new SelectListItem { Text = r.Name, Value = r.GameId.ToString(), Selected = (r.GameId == notes.GameId) });
                    GameStrategies item = notes as GameStrategies;
                    //  var replstring = notes.Content.Replace("</p> <p>", "\n");
                    //   notes.Content = replstring.Replace("<p>", "");
                    //    notes.Content = notes.Content.Replace("</ p>", "");
                    return View(item);
                }
                else
                {
                    ViewBag.Types = types.Select(r => new SelectListItem { Text = r.Name, Value = r.GameId.ToString() });
                    GameStrategies item = new GameStrategies { Author = " " };
                    return View(item);
                }
            }
            ViewBag.Types = types.Select(r => new SelectListItem { Text = r.Name, Value = r.GameId.ToString() });
            GameStrategies tlst = new GameStrategies();
            return View(tlst);

        }

        [LoginStateRequiredAttribute]
        public ActionResult NewGameStrage()
        {
            IRepository<GameType> _noteTypeRepository;
            _noteTypeRepository = new GameTypeRepository(DbContext);
            var types = _noteTypeRepository.List();
            ViewBag.GameTypes = types.Select(r => new SelectListItem { Text = r.Name, Value = r.GameId.ToString() });
            return View("NewGameStrage");
        }

        [HttpPost]
        //[Description(No = 10, Name = "修改游戏分享文章", isGet = false)]
        [LoginStateRequiredAttribute]
        public JsonResult Edit(string ehaiker_parameter)
        {
            int ret = 0;
            string errMsg = "操作失败！";
            int errorCode = 0;
            if (ModelState.IsValid)
            {
                MemberShip loginuser = MemUserDataManager.GetMemSessionData<MemberShip>(HttpContext, "memshipUserInfo");
                if (loginuser != null)
                {
                    IRepository<GameStrategies> _noteRepository;
                    IRepository<GameType> _noteTypeRepository;
                    _noteRepository = new GameStrategiesRepository(DbContext);
                    _noteTypeRepository = new GameTypeRepository(DbContext);
                    GameStrategies juser = JsonHelper.DeserializeJsonToObject<GameStrategies>(ehaiker_parameter);
                    //设置相关系统
                    var notes = _noteRepository.GetDbSet().Where(r => r.Id == juser.Id &&
                    r.UserGuid == loginuser.UserGuid).FirstOrDefault();
                    if (notes != null)
                    {
                        notes.LastEditTime = DateTime.Now;
                        notes.Title = juser.Title;
                        notes.GameId = juser.GameId;
                        notes.IsIdentified = 0;//需要重新审核
                        notes.Content =
                            // Microsoft.JScript.GlobalObject.unescape(juser.Content);
                            JSCoderHelper.unescape(juser.Content);

                        try
                        {
                            _noteRepository.Update(notes);
                            _noteRepository.SaveChanges();
                            ret = 1;
                            errMsg = "操作成功";
                        }
                        catch (Exception e)
                        {
                            ret = 0;
                            errMsg = "操作失败";
                            errorCode = 301;
                        }

                    }
                }

            }
            var retjson = new { ErrorCode = errorCode, iSuccessCode = ret, msg = errMsg };
            return Json(retjson);
        }

        [HttpPost]
        [LoginStateRequiredAttribute]
        public JsonResult AddNewGameStrage(string Item_parameter)
        {
            int errorCode = 0;
            string errMsg = "操作失败！";
            if (ModelState.IsValid)
            {
                GameStrategies gameItem = JsonHelper.DeserializeJsonToObject<GameStrategies>(Item_parameter);
                if (gameItem != null)
                {
                    MemberShip cookie = MemUserDataManager.GetMemSessionData<MemberShip>(HttpContext, "memshipUserInfo");

                    GameStrategiesRepository GamelistManager = new GameStrategiesRepository(DbContext);
                    //
                    gameItem.CreateTime = DateTime.Now;
                    gameItem.LastEditTime = DateTime.Now;
                    gameItem.readers = 1;
                    //防止脚本注入
                    if (!string.IsNullOrEmpty(gameItem.Title))
                        gameItem.Title = System.Text.RegularExpressions.Regex.Replace(gameItem.Title, "/(?!<(img|p|span).*?>)<.*?>/g", "");
                    if (!string.IsNullOrEmpty(gameItem.Content))
                        gameItem.Content = System.Text.RegularExpressions.Regex.Replace(gameItem.Content, "/(?!<(img|p|span).*?>)<.*?>/g", "");
                    //ReferUri
                    if (!string.IsNullOrEmpty(gameItem.ReferUri))
                        gameItem.ReferUri = System.Text.RegularExpressions.Regex.Replace(gameItem.ReferUri, "/(?!<(img|p|span).*?>)<.*?>/g", "");
                    //作者
                    gameItem.Author = cookie.UserName;
                    gameItem.UserGuid = cookie.UserGuid;
                    gameItem.IsIdentified = 0;
                    GamelistManager.Add(gameItem);
                    GamelistManager.SaveChanges();
                    errMsg = "操作成功";
                    var retjson = new { ErrorCode = errorCode, iSuccessCode = 0, msg = errMsg };
                    return Json(retjson);
                }
            }
            var tt = new { ErrorCode = 10000, msg = "未知错误" };
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
        public JsonResult MyStrategies(int gid)
        {
            int errorCode = 0;
            string errMsg = "操作失败！";
            GameStrategiesRepository GamelistManager = new GameStrategiesRepository(DbContext);
            GameStrategies gitem = GamelistManager.GetById(gid);
            MemberShip cookie = MemUserDataManager.GetMemSessionData<MemberShip>(HttpContext, "memshipUserInfo");
            if (gitem != null)
            {
                MyGameStragesManager mgr = new MyGameStragesManager(DbContext);
                MyGameStrage item = new MyGameStrage();
                item.GameID = gitem.Id;
                item.Gametype = gitem.GameId;
                item.ItemName = gitem.Title;
                item.UserGuid = cookie.UserGuid;
                mgr.Add(item);
                mgr.SaveChanges();
                errMsg = "操作成功";
                var retjson = new { ErrorCode = errorCode, iSuccessCode = 0, msg = errMsg };
                return Json(retjson);
            }
            var tt = new { ErrorCode = 10000, msg = "未知错误" };
            return Json(tt);

        }
        [HttpPost]
        [LoginStateRequiredAttribute]
        public JsonResult CancelItem(int gid)
        {
            int errorCode = 0;
            string errMsg = "操作失败！";
            GameStrategiesRepository GamelistManager = new GameStrategiesRepository(DbContext);
            MemberShip cookie = MemUserDataManager.GetMemSessionData<MemberShip>(HttpContext, "memshipUserInfo");
            if (cookie != null)
            {
                MyGameStragesManager mgr = new MyGameStragesManager(DbContext);
                mgr.SafeDelete(gid, cookie.UserGuid);
                mgr.SaveChanges();
                errMsg = "操作成功";
                var retjson = new { ErrorCode = errorCode, iSuccessCode = 0, msg = errMsg };
                return Json(retjson);
            }
            var tt = new { ErrorCode = 10000, msg = "未知错误" };
            return Json(tt);

        }
        [HttpPost]
        [LoginStateRequiredAttribute]
        public JsonResult GetMyGameStrategies(int page = 1, int rows = 10)
        {
            MemberShip loginuser = MemUserDataManager.GetMemSessionData<MemberShip>(HttpContext, "memshipUserInfo");
            MyGameStragesManager mgr = new MyGameStragesManager(DbContext);
            page = page > 0 ? page : 1;

            var query = new List<MyGameStrage>();
            query = mgr.GetDbSet().Where(r => r.UserGuid == loginuser.UserGuid).ToList();

            var count = query.Count();
            var pagecount = count % rows == 0 ? count / rows : count / rows + 1;
            var findItems = query.OrderByDescending(r => r.IndexID)
                .Skip((page - 1) * rows)
                .Take(rows)
                .ToList();
            var notes = new Tuple<List<MyGameStrage>, int>(findItems, pagecount);

            ViewBag.PageIndex = page;//当前页
            var tt = new { Total = notes.Item2, data = notes.Item1 };
            return Json(tt);
        }
    }
}