using ehaiker.Models;
using ehaikerv202010;
using ehaikerv202010.Filters;
using ehaikerv202010.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ehaiker.Controllers
{
    //[ehaiker.Auth.Description(No = 5, Name = "新闻中心", ShowInMgrbar = true)]
    public class NewsCenterController : Controller
    {
        private EhaikerContext DbContext;
        private INoteCountInterface _WebCount;
        private readonly Microsoft.Extensions.Logging.ILogger _logger;
        public NewsCenterController(EhaikerContext _cont, INoteCountInterface _IWebCount,
            ILogger<NewsCenterController> logger)
        {
            DbContext = _cont;
            _WebCount = _IWebCount;
            _logger = logger;
        }
        //
        // GET: /NewsCenter/
        public ActionResult Index(int page = 1, int pagesize = 10)
        {
            page = page > 0 ? page : 1;
            List<NewsModel> tlst = new List<NewsModel>();
            return View("bsIndex", tlst);

        }
        //按页获取数据
        [HttpPost]//GameStrategies
        public JsonResult GetPageInfo(int page = 1, int rows = 10)
        {
            page = page > 0 ? page : 1;
            NewsesRepository newsManager = new NewsesRepository(DbContext);
            if (page >= 1)
            {

                var notes = newsManager.PageList(page, rows);//可能会增加标志位

                ViewBag.PageIndex = page;//当前页
                var tt = new { Total = notes.Item2, data = notes.Item1 };
                return Json(tt);
            }
            var tt1 = new { Total = 0, data = new { } };
            return Json(tt1);


        }
        //外部查看，不用登录
        public ActionResult showDetail(int newsID = 1)
        {
            //记录浏览人数
            if (_WebCount != null)
            {
                _WebCount.accessMethod(HttpContext, DbContext);
            }
            IRepository<GameType> _noteTypeRepository;
            _noteTypeRepository = new GameTypeRepository(DbContext);
            var types = _noteTypeRepository.List();

            //从Cookie对象中取出Json串

            IRepository<NewsModel> _noteRepository = new NewsesRepository(DbContext);
            var notes = _noteRepository.GetDbSet().Where(r => r.Id == newsID).FirstOrDefault();
            if (notes != null)
            {
                ViewBag.Types = types.Select(r => new SelectListItem { Text = r.Name, Value = r.GameId.ToString(), Selected = (r.GameId == notes.NewsTypeId) });
                NewsModel item = notes as NewsModel;
                item.Content = Regex.Unescape(item.Content);
                return View(item);
            }
            else
            {
                ViewBag.Types = types.Select(r => new SelectListItem { Text = r.Name, Value = r.GameId.ToString() });
                NewsModel item = new NewsModel { Announcer = " " };
                return View(item);
            }
        }
        //火爆推荐
        [HttpPost]
        public JsonResult NewsHotItems()
        {
            IRepository<NewsModel> _noteRepository;
            _noteRepository = new NewsesRepository(DbContext);
            var tt = _noteRepository.GetDbSet().Where(r => r.IsUnVisible <= 0).OrderByDescending(r => r.LastEditTime).Take(10).ToList();
            return Json(tt);
        }
        [AdminLoginStateRequired]
        public ActionResult ShowNewsEx()
        {
            return View("ShowNewsEx");
        }
        [HttpPost]
        [AdminLoginStateRequired]
        public JsonResult GetShowNews(int page = 1, int pagesize = 10)
        {
            page = page > 0 ? page : 1;
            IRepository<NewsModel> _noteRepository;
            IRepository<GameType> _noteTypeRepository;
            _noteRepository = new NewsesRepository(DbContext);
            _noteTypeRepository = new GameTypeRepository(DbContext);
            int nCount = _noteRepository.List().Count();
            //

            if (nCount > 0)
            {
                //从Cookie对象中取出Json串
                var query = _noteRepository.GetDbSet().AsQueryable();
                var count = query.Count();
                var pagecount = count % pagesize == 0 ? count / pagesize : count / pagesize + 1;
                var findItems = query.OrderByDescending(r => r.LastEditTime)
                    .Skip((page - 1) * pagesize)
                    .Take(pagesize)
                    .ToList();
                var notes = new Tuple<List<NewsModel>, int>(findItems, pagecount);
                ViewBag.PageCount = notes.Item2;//总页数
                ViewBag.PageIndex = page;//当前页
                ViewBag.PageSize = pagesize;//页面显示
                ViewBag.PageUri = "../NewsCenter/ShowNewsEx";
                var tt0 = new { Total = notes.Item2, data = notes.Item1 };
                return Json(tt0);
            }
            ViewBag.PageCount = 1;//总页数
            ViewBag.PageIndex = 1;//当前页
            ViewBag.PageSize = pagesize;//页面显示
            ViewBag.PageUri = "../NewsCenter/ShowNewsEx";

            var tt = new { Total = 0, data = 0 };
            return Json(tt);

        }

        [LoginStateRequiredAttribute]
        // [ehaiker.Auth.Description(No = 1, Name = "会员新闻管理", ShowInMgrbar = true)]
        public ActionResult ShowNews(int page = 1, int pagesize = 10)
        {
            page = page > 0 ? page : 1;
            IRepository<NewsModel> _noteRepository;
            IRepository<GameType> _noteTypeRepository;
            _noteRepository = new NewsesRepository(DbContext);
            _noteTypeRepository = new GameTypeRepository(DbContext);
            int nCount = _noteRepository.List().Count();
            //
            Administrator admin = MemUserDataManager.GetMemSessionData<Administrator>(HttpContext, "AdminUser");
            if (admin != null && nCount > 0)
            {
                //从Cookie对象中取出Json串
                var query = _noteRepository.GetDbSet()
                    .Where(r => r.Announcer == admin.Account).AsQueryable();
                var count = query.Count();
                var pagecount = count % pagesize == 0 ? count / pagesize : count / pagesize + 1;
                var findItems = query.OrderByDescending(r => r.LastEditTime)
                    .Skip((page - 1) * pagesize)
                    .Take(pagesize)
                    .ToList();
                var notes = new Tuple<List<NewsModel>, int>(findItems, pagecount);
                ViewBag.PageCount = notes.Item2;//总页数
                ViewBag.PageIndex = page;//当前页
                ViewBag.PageSize = pagesize;//页面显示
                ViewBag.PageUri = "../NewsCenter/ShowNews";
                return View(notes.Item1);
            }
            ViewBag.PageCount = 1;//总页数
            ViewBag.PageIndex = 1;//当前页
            ViewBag.PageSize = pagesize;//页面显示
            ViewBag.PageUri = "../NewsCenter/ShowNews";
            List<NewsModel> tlst = new List<NewsModel>();
            return View(tlst);

        }
        //[AuthAuthorizeAttribute]
        //  [ehaiker.Auth.Description(No = 2, Name = "新闻发布", ShowInMgrbar = true)]

        //
        [HttpPost]
        [AdminLoginStateRequiredAttribute]
        public JsonResult Add(string ehaiker_parameter)
        {
            string ret = "0";
            string errMsg = "操作失败！";
            if (ModelState.IsValid)
            {
                Administrator admin = MemUserDataManager.GetMemSessionData<Administrator>(HttpContext, "AdminUser");
                if (admin != null)
                {
                    //从Cookie对象中取出Json串
                    IRepository<NewsModel> _noteRepository;
                    IRepository<GameType> _noteTypeRepository;
                    _noteRepository = new NewsesRepository(DbContext);
                    _noteTypeRepository = new GameTypeRepository(DbContext);
                    NewsModel juser = JsonHelper.DeserializeJsonToObject<NewsModel>(ehaiker_parameter);
                    //设置相关系统
                    juser.Announcer = admin.Account;
                    juser.ReleaseTime = DateTime.Now;
                    juser.LastEditTime = DateTime.Now;

                    //juser.Content = JSCoderHelper.unescape(juser.Content);
                    if (!string.IsNullOrEmpty(juser.Content))
                    {
                        //只保留几个标签
                        juser.Content = System.Text.RegularExpressions.Regex.Replace(juser.Content, "/(?!<(img|p|span).*?>)<.*?>/g", "");
                        //
                        juser.Content = Regex.Escape(juser.Content);
                    }
                    _noteRepository.Add(juser);
                    ret = _noteRepository.SaveChanges().ToString();
                    errMsg = "操作成功！";
                }

            }
            var retjson = new { ErrorCode = 0, iSuccessCode = ret, msg = errMsg };
            return Json(retjson);
        }
        [HttpPost]
        [AdminLoginStateRequiredAttribute]
        // [ehaiker.Auth.Description(No = 3, Name = "新闻编辑", ShowInMgrbar = false,isGet=false)]
        public JsonResult Edit(string ehaiker_parameter)
        {
            string ret = "0";
            string errMsg = "操作失败！";
            int errorCode = 0;
            if (ModelState.IsValid)
            {
                Administrator admin = MemUserDataManager.GetMemSessionData<Administrator>(HttpContext, "AdminUser");
                if (admin != null)
                {
                    //从Cookie对象中取出Json串
                    IRepository<NewsModel> _noteRepository;
                    IRepository<GameType> _noteTypeRepository;
                    _noteRepository = new NewsesRepository(DbContext);
                    _noteTypeRepository = new GameTypeRepository(DbContext);
                    NewsModel juser = JsonHelper.DeserializeJsonToObject<NewsModel>(ehaiker_parameter);
                    //设置相关系统
                    var notes = _noteRepository.GetDbSet().Where(r => r.Id == juser.Id &&
                    r.Announcer == admin.Account).FirstOrDefault();
                    if (notes != null)
                    {
                        notes.LastEditTime = DateTime.Now;
                        notes.Title = juser.Title;
                        notes.NewsTypeId = juser.NewsTypeId;
                        notes.Content = juser.Content;
                        if (!string.IsNullOrEmpty(juser.Content))
                        {
                            //只保留几个标签
                            juser.Content = System.Text.RegularExpressions.Regex.Replace(juser.Content, "/(?!<(img|p|span).*?>)<.*?>/g", "");
                            //
                            juser.Content = Regex.Escape(juser.Content);
                        }
                        try
                        {
                            _noteRepository.Update(notes);
                            _noteRepository.SaveChanges();
                            ret = "1";
                            errMsg = "操作成功！";
                        }
                        catch (Exception e)
                        {
                            ret = "0";
                            errMsg = "操作失败！";
                        }
                    }
                }

            }
            var retjson = new { ErrorCode = errorCode, iSuccessCode = ret, msg = errMsg };
            return Json(retjson);
        }
        //删除公告
        [AdminLoginStateRequiredAttribute]
        public JsonResult NewsDel(int uid)
        {
            if (ModelState.IsValid)
            {
                Administrator admin = MemUserDataManager.GetMemSessionData<Administrator>(HttpContext, "AdminUser");
                if (admin != null)
                {
                    IRepository<NewsModel> cmmtmgr = new NewsesRepository(DbContext);
                    if (uid != 0)
                    {
                        NewsModel sh = cmmtmgr.GetById(uid);
                        if (sh != null)
                        {
                            cmmtmgr.Delete(uid);
                            cmmtmgr.SaveChanges();
                            var ttok = new { Total = 0, data = 0 };
                            return Json(ttok);
                        }
                    }
                }
            }
            var tt = new { Total = 0, data = 0 };
            return Json(tt);
        }
        //隐藏公告
        [AdminLoginStateRequiredAttribute]
        public JsonResult NewsHidden(int uid)
        {
            if (ModelState.IsValid)
            {
                Administrator admin = MemUserDataManager.GetMemSessionData<Administrator>(HttpContext, "AdminUser");
                if (admin != null)
                {
                    IRepository<NewsModel> cmmtmgr = new NewsesRepository(DbContext);
                    if (uid != 0)
                    {
                        NewsModel sh = cmmtmgr.GetById(uid);
                        if (sh != null)
                        {
                            sh.IsUnVisible = 1;
                            cmmtmgr.Update(sh);
                            cmmtmgr.SaveChanges();
                            var ttok = new { Total = 0, data = 0 };
                            return Json(ttok);
                        }
                    }
                }
            }
            var tt = new { Total = 0, data = 0 };
            return Json(tt);
        }
        //恢复公告
        [AdminLoginStateRequiredAttribute]
        public JsonResult NewsRecover(int uid)
        {
            if (ModelState.IsValid)
            {
                Administrator admin = MemUserDataManager.GetMemSessionData<Administrator>(HttpContext, "AdminUser");
                if (admin != null)
                {
                    IRepository<NewsModel> cmmtmgr = new NewsesRepository(DbContext);
                    if (uid != 0)
                    {
                        NewsModel sh = cmmtmgr.GetById(uid);
                        if (sh != null)
                        {
                            sh.IsUnVisible = 0;
                            cmmtmgr.Update(sh);
                            cmmtmgr.SaveChanges();
                            var ttok = new { Total = 0, data = 0 };
                            return Json(ttok);
                        }
                    }
                }
            }
            var tt = new { Total = 0, data = 0 };
            return Json(tt);
        }
        [AdminLoginStateRequiredAttribute]
        public ActionResult ShowDetailEx(int newsID = 1)
        {
            //

            IRepository<GameType> _noteTypeRepository;
            _noteTypeRepository = new GameTypeRepository(DbContext);
            var types = _noteTypeRepository.List();
            Administrator admin = MemUserDataManager.GetMemSessionData<Administrator>(HttpContext, "AdminUser");
            if (admin != null)
            {
                //从Cookie对象中取出Json串


                IRepository<NewsModel> _noteRepository = new NewsesRepository(DbContext);
                var notes = _noteRepository.GetDbSet().Where(r => r.Id == newsID &&
                    r.Announcer == admin.Account).FirstOrDefault();
                if (notes != null)
                {
                    ViewBag.Types = types.Select(r => new SelectListItem { Text = r.Name, Value = r.GameId.ToString(), Selected = (r.GameId == notes.NewsTypeId) });
                    NewsModel item = notes as NewsModel;
                    item.Content = Regex.Unescape(item.Content);
                    return View(item);
                }
                else
                {
                    ViewBag.Types = types.Select(r => new SelectListItem { Text = r.Name, Value = r.GameId.ToString() });
                    NewsModel item = new NewsModel { Announcer = " " };
                    return View(item);
                }
            }
            NewsModel tlst = new NewsModel();
            return View(tlst);

        }
    }
}
