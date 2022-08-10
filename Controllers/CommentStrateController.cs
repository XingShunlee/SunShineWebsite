using ehaiker;
using ehaiker.Managers;
using ehaiker.Models;
using ehaikerv202010.Filters;
using ehaikerv202010.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ehaikerv202010.Controllers
{
    //manage the comments
    public class CommentStrateController : Controller
    {
        private EhaikerContext DbContext;
        private IHostingEnvironment _env;
        public CommentStrateController(EhaikerContext _cont, IHostingEnvironment env)
        {
            DbContext = _cont;
            _env = env;
        }
        [AdminLoginStateRequiredAttribute]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [AdminLoginStateRequiredAttribute]
        public JsonResult GetComments(int page = 1, int rows = 10)
        {
            page = page > 0 ? page : 1;
            GameCommentManager cmmtmgr = new GameCommentManager(DbContext);
            var query = new List<CommentModel>();

            query = cmmtmgr.List();
            var count = query.Count();
            var pagecount = count % rows == 0 ? count / rows : count / rows + 1;
            var findItems = query.OrderByDescending(r => r.CreateTime)
                .Skip((page - 1) * rows)
                .Take(rows)
                .ToList();
            var notes = new Tuple<List<CommentModel>, int>(findItems, pagecount);

            ViewBag.PageIndex = page;//当前页
            var tt = new { Total = notes.Item2, data = notes.Item1 };
            return Json(tt);
        }
        [HttpPost]
        [AdminLoginStateRequiredAttribute]
        public JsonResult commentPass(int uid)
        {
            GameCommentManager cmmtmgr = new GameCommentManager(DbContext);
            if (uid != 0)
            {
                CommentModel sh = cmmtmgr.GetBycommentId(uid);
                if (sh != null)
                {
                    sh.IsChecked = 1;
                    cmmtmgr.Update(sh);
                    cmmtmgr.SaveChanges();
                }
            }
            var tt = new { Total = 0, data = 0 };
            return Json(tt);

        }

        [HttpPost]
        [AdminLoginStateRequiredAttribute]
        [PermissionControlAttribute(1, "删除评论", "删除评论", 0, 0, 1)]
        public JsonResult commentDel(int uid)
        {
            GameCommentManager cmmtmgr = new GameCommentManager(DbContext);
            if (uid != 0)
            {
                CommentModel sh = cmmtmgr.GetBycommentId(uid);
                if (sh != null)
                {
                    cmmtmgr.Delete(uid);
                    cmmtmgr.SaveChanges();
                }
            }
            var tt = new { Total = 0, data = 0 };
            return Json(tt);
        }
        [HttpPost]
        [LoginStateRequiredAttribute]
        [PermissionControlAttribute(2, "修改评论", "修改评论", 0, 0, 1)]
        public JsonResult commentSave(int uid, string customerContent)
        {
            GameCommentManager cmmtmgr = new GameCommentManager(DbContext);
            GameStrategiesRepository GamelistManager = new GameStrategiesRepository(DbContext);
            MemberShip cookie = MemUserDataManager.GetMemSessionData<MemberShip>(HttpContext, "memshipUserInfo");
            if (uid != 0)
            {
                CommentModel sh = new CommentModel();
                GameStrategies gitem = GamelistManager.GetById(uid);
                if (gitem != null)
                {
                    sh.GameStrateID = uid;
                    sh.GameID = gitem.GameId;
                    sh.GameName = gitem.Title;
                    sh.UserId = cookie.UserId;
                    sh.UserName = cookie.UserName;
                    sh.comment = customerContent;
                    sh.CreateTime = DateTime.Now;
                    sh.IsChecked = 0;
                    cmmtmgr.Add(sh);
                    cmmtmgr.SaveChanges();
                }
            }
            var tt = new { Code = 0, data = 0 };
            return Json(tt);
        }
    }
}