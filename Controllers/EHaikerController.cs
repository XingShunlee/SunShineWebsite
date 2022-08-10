using ehaiker.Models;
using ehaikerv202010.Filters;
using ehaikerv202010.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ehaiker.Controllers
{
    /// [Description(No = 1, Name = "首页功能")]

    public class EHaikerController : Controller
    {
        private EhaikerContext DbContext;
        public EHaikerController(EhaikerContext _cont)
        {
            DbContext = _cont;
        }
        private MemberShipManager memberManager;
        private GameListManager GamelistManager;
        private SupplierListManager SupplierlistMgr;
        // GET: /EHaiker/
        // [ServiceFilter(typeof(LoginAuthorize))]
        [NoPermissionRequiredAttribute]
        [AllowAnonymous]
        public ActionResult Index()
        {
            //没有登录
            MemberShip cookie = MemUserDataManager.GetMemSessionData<MemberShip>(HttpContext, "memshipUserInfo");
            if (cookie != null)
            {
                //从Cookie对象中取出Json串
                return View("Index", cookie);
            }
            else
            {
                MemberShip user = new MemberShip() { UserName = "游客", UserId = 0, Password = "0" };

                return View("Index", user);
            }
            //return View();
        }


        //---------------------------------游戏推荐--
        [HttpPost]
        public JsonResult GameTopMost(int type = 0)
        {
            GamelistManager = new GameListManager(DbContext);
            if (type == 0)
            {
                var tt = GamelistManager.GetDbSet().Where(r => r.IsIdentified == 1).ToList();
                return Json(tt);
            }
            else
            {
                //取前8条记录
                var tt = GamelistManager.GetDbSet().Where(r => r.Gametype == type && r.IsIdentified == 1).Take(8).ToList();
                return Json(tt);
            }


        }
        //火爆推荐
        [HttpPost]
        public JsonResult GameHotItems()
        {
            GamelistManager = GamelistManager != null ? GamelistManager : new GameListManager(DbContext);
            var tt = GamelistManager.GetDbSet().GroupBy(r => r.TopLevel).Take(8).ToList();
            return Json(tt);
        }
        //游戏攻略推荐
        [HttpPost]//GameStrategies
        public JsonResult GetGameStrategies(int page = 1, int rows = 5, int type = 0)
        {
            GameStrategiesRepository _noteRepository;
            _noteRepository = new GameStrategiesRepository(DbContext);
            var query = new List<GameStrategies>();
            if (type == 0)
            {
                query = _noteRepository.GetDbSet().Where(r => r.IsIdentified == 1).ToList();


            }
            else
            {
                query = _noteRepository.GetDbSet().Where(r => r.GameId == type && r.IsIdentified == 1).Take(5).ToList();
            }
            var count = query.Count();
            var pagecount = count % rows == 0 ? count / rows : count / rows + 1;
            var notes = query.OrderByDescending(r => r.CreateTime)
                .Skip((page - 1) * rows)
                .Take(rows)
                .ToList();
            return Json(notes);
        }
        //供应商
        //火爆推荐
        [HttpPost]
        public JsonResult getSupplierInfo()
        {
            SupplierlistMgr = new SupplierListManager(DbContext);
            var tt = SupplierlistMgr.List().Take(6).ToList();
            return Json(tt);
        }

    }
}
