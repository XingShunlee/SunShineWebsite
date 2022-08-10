using ehaiker;
using ehaiker.Models;
using ehaikerv202010.Filters;
using ehaikerv202010.helpers;
using ehaikerv202010.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ehaikerv202010.Controllers
{
   
    public class MyItBlogController : Controller
    {
        private EhaikerContext DbContext;
        private IHostingEnvironment _env;
        public MyItBlogController(EhaikerContext _cont, IHostingEnvironment env)
        {
            _env = env;
            DbContext = _cont;

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
        public ActionResult ShowMyItBlogs()
        {
            return View("ShowMyItBlogs");
        }
        ///
        [HttpPost]
        [LoginStateRequiredAttribute]
        public JsonResult GetOwnerItBlogs(int page = 1, int rows = 10, int type = 1, string name = "")
        {
            page = page > 0 ? page : 1;
            ItBlogRepository ItBlogMgr = new ItBlogRepository(DbContext);
            var query1 = new List<ItBlogModel>();
            MemberShip loginuser = MemUserDataManager.GetMemSessionData<MemberShip>(HttpContext, "memshipUserInfo");

            if (type != -1 && loginuser != null)
            {

                if (type == 0)
                {

                    query1 = (
                              from d in ItBlogMgr.GetDbSet()
                              where d.UserGuid == loginuser.UserGuid
                              select d).ToList();
                }
                else
                {
                    query1 = (
                              from d in ItBlogMgr.GetDbSet()
                              where d.UserGuid == loginuser.UserGuid && d.blogtype == type
                              select d).ToList();
                }

            }
            else
            {
                query1 = (
                         from d in ItBlogMgr.GetDbSet()
                         where d.Title.Contains(name) && d.UserGuid == loginuser.UserGuid
                         select d).ToList();

            }
            var count = query1.Count();
            var pagecount = count % rows == 0 ? count / rows : count / rows + 1;
            var findItems = query1.OrderByDescending(r => r.LastEditTime)
                .Skip((page - 1) * rows)
                .Take(rows)
                .ToList();
            var notes = new Tuple<List<ItBlogModel>, int>(findItems, pagecount);

            ViewBag.PageIndex = page;//当前页
            var tt = new { Total = notes.Item2, data = notes.Item1 };
            return Json(tt);

        }
        //修改攻略
        [LoginStateRequiredAttribute]
        public ActionResult showDetail(int Id = -1)
        {
            
            
            MemberShip loginuser = MemUserDataManager.GetMemSessionData<MemberShip>(HttpContext, "memshipUserInfo");
            if (loginuser != null)
            {

                ItBlogRepository _noteRepository = new ItBlogRepository(DbContext);
                var notes = _noteRepository.GetDbSet().Where(r => r.Id == Id &&
                    r.UserGuid == loginuser.UserGuid).FirstOrDefault();
                if (notes != null)
                {
                    ViewBag.Types = new List<SelectListItem> { new SelectListItem { Text = "技术博客", Value = "0", Selected = true } };
                    ItBlogModel item = notes as ItBlogModel;
                    //  var replstring = notes.Content.Replace("</p> <p>", "\n");
                    //   notes.Content = replstring.Replace("<p>", "");
                    //    notes.Content = notes.Content.Replace("</ p>", "");
                    return View(item);
                }
                else
                {
                    ViewBag.Types = new List<SelectListItem> { new SelectListItem { Text = "技术博客", Value = "0", Selected = true } };
                    ItBlogModel item = new ItBlogModel { Author = " " };
                    return View(item);
                }
            }
            ViewBag.Types = new List<SelectListItem> { new SelectListItem { Text = "技术博客", Value = "0", Selected = true } };
            ItBlogModel tlst = new ItBlogModel();
            return View(tlst);

        }

        [LoginStateRequiredAttribute]
        public ActionResult NewItBlog()
        {
            ViewBag.Types = new List<SelectListItem> { new SelectListItem { Text = "技术博客", Value = "0", Selected = true } };
            return View("NewItBlog");
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
                    ItBlogRepository _noteRepository;
                    _noteRepository = new ItBlogRepository(DbContext);
                    ItBlogModel juser = JsonHelper.DeserializeJsonToObject<ItBlogModel>(ehaiker_parameter);
                    //设置相关系统
                    var notes = _noteRepository.GetDbSet().Where(r => r.Id == juser.Id &&
                    r.UserGuid == loginuser.UserGuid).FirstOrDefault();
                    if (notes != null)
                    {
                        notes.LastEditTime = DateTime.Now;
                        notes.Title = juser.Title;
                        notes.blogtype = juser.blogtype;
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
        public JsonResult AddNewItBlog(string Item_parameter)
        {
            int errorCode = 0;
            string errMsg = "操作失败！";
            if (ModelState.IsValid)
            {
                ItBlogModel gameItem = JsonHelper.DeserializeJsonToObject<ItBlogModel>(Item_parameter);
                if (gameItem != null)
                {
                    MemberShip cookie = MemUserDataManager.GetMemSessionData<MemberShip>(HttpContext, "memshipUserInfo");

                    ItBlogRepository ItBlogMgr = new ItBlogRepository(DbContext);
                    //
                    gameItem.CreateTime = DateTime.Now;
                    gameItem.LastEditTime = DateTime.Now;
                    gameItem.readers = 1;
                    //防止脚本注入
                    if (!string.IsNullOrEmpty(gameItem.Title))
                        gameItem.Title = System.Text.RegularExpressions.Regex.Replace(gameItem.Title, "/(?!<(img|p|span).*?>)<.*?>/g", "");
                    if (!string.IsNullOrEmpty(gameItem.Content))
                        gameItem.Content = System.Text.RegularExpressions.Regex.Replace(gameItem.Content, "/(?!<(img|p|span).*?>)<.*?>/g", "");
                    if (!string.IsNullOrEmpty(gameItem.ReferUri))
                        gameItem.ReferUri = System.Text.RegularExpressions.Regex.Replace(gameItem.ReferUri, "/(?!<(img|p|span).*?>)<.*?>/g", "");
                    //作者
                    gameItem.Author = cookie.UserName;
                    gameItem.UserGuid = cookie.UserGuid;
                    gameItem.IsIdentified = 0;
                    ItBlogMgr.Add(gameItem);
                    ItBlogMgr.SaveChanges();
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
        public JsonResult SaveMyItBlogs(int gid)
        {
            int errorCode = 0;
            string errMsg = "操作失败！";
            ItBlogRepository ItBlogMgr = new ItBlogRepository(DbContext);
            ItBlogModel gitem = ItBlogMgr.GetById(gid);
            MemberShip cookie = MemUserDataManager.GetMemSessionData<MemberShip>(HttpContext, "memshipUserInfo");
            if (gitem != null)
            {
                MyItBlogsManager mgr = new MyItBlogsManager(DbContext);
                MyItBlogModel item = new MyItBlogModel();
                item.BlogID = gitem.Id;
                item.blogtype = gitem.blogtype;
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
            ItBlogRepository ItBlogMgr = new ItBlogRepository(DbContext);
            MemberShip cookie = MemUserDataManager.GetMemSessionData<MemberShip>(HttpContext, "memshipUserInfo");
            if (cookie != null)
            {
                MyItBlogsManager mgr = new MyItBlogsManager(DbContext);
                mgr.SafeDelete(gid, cookie.UserGuid);
                mgr.SaveChanges();
                errMsg = "操作成功";
                var retjson = new { ErrorCode = errorCode, iSuccessCode = 0, msg = errMsg };
                return Json(retjson);
            }
            var tt = new { ErrorCode = 10000, msg = "未知错误" };
            return Json(tt);

        }
        //我收藏的文章
        [HttpPost]
        [LoginStateRequiredAttribute]
        public JsonResult GetMyItBlogs(int page = 1, int rows = 10)
        {
            MemberShip loginuser = MemUserDataManager.GetMemSessionData<MemberShip>(HttpContext, "memshipUserInfo");
            MyItBlogsManager mgr = new MyItBlogsManager(DbContext);
            page = page > 0 ? page : 1;

            var query = new List<MyItBlogModel>();
            query = mgr.GetDbSet().Where(r => r.UserGuid == loginuser.UserGuid).ToList();

            var count = query.Count();
            var pagecount = count % rows == 0 ? count / rows : count / rows + 1;
            var findItems = query.OrderByDescending(r => r.IndexID)
                .Skip((page - 1) * rows)
                .Take(rows)
                .ToList();
            var notes = new Tuple<List<MyItBlogModel>, int>(findItems, pagecount);

            ViewBag.PageIndex = page;//当前页
            var tt = new { Total = notes.Item2, data = notes.Item1 };
            return Json(tt);
        }
    }
}