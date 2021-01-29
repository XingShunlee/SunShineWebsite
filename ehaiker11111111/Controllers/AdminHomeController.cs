using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ehaiker.Models;
using System.Web.Mvc;
using System.EnterpriseServices;
using ehaiker;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Text;
using System.IO;
using ehaiker.Auth;
using System.Web.Security;

namespace ehaiker.Controllers
{
     [ ehaiker.Auth.Description(No = 4, Name = "管理员功能",ShowInMgrbar=true)]
    [AdminAuthorize]
    public class AdminHomeController : Controller
    {
        private AdministratorManager adminManager;
        private MemberShipManager memshipManager;
        public AdminHomeController()
        {
            adminManager = new AdministratorManager();
            memshipManager = new MemberShipManager();
        }
        public ActionResult Index()
        {
            RoleService sSVR = new RoleService();
            List<MenuItem> ls;
            if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                var ticket = (System.Web.HttpContext.Current.User.Identity as FormsIdentity).Ticket;
                var userData = (System.Web.HttpContext.Current.User as MyFormsPrincipal<UserInfo>).UserData;
                ls = HttpRuntime.Cache.Get(userData.perItem) as List<MenuItem>;
                ViewBag.PerList = ls.ToList();
            }
           
            return View("NewIndex", ViewBag.PerList);
        }
        [HttpPost]
        public JsonResult Index(int page,int rows,int ID = 0)
        {
            Tuple<List<Administrator>, int> pager = null;
            pager = adminManager.PageList(this,page, rows);
            var tt = new { total = pager.Item2, rows = pager.Item1.ToList() };
            return Json(tt, JsonRequestBehavior.AllowGet); ;
        }
        /// <summary>
        /// 重置密码【Ninesky】
        /// </summary>
        /// <param name="id">管理员ID</param>
        /// <returns></returns>
        [HttpPost]
        [AuthAuthorize]
        public JsonResult ResetPassword(string ehaiker_parameter)
        {
            Administrator juser = JsonHelper.DeserializeJsonToObject<Administrator>(ehaiker_parameter);
            string _password = "1234567";
            int _resp = adminManager.ChangePassword(juser.AdministratorID, Security.Sha256(_password));
           
            return Json(_resp, JsonRequestBehavior.AllowGet);
        }
        public ActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        public ActionResult InternalView()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        public ActionResult Privacy()
        {
            return View();
        }
        //管理员管理
         [ehaiker.Auth.Description(No = 1, Name = "管理员功能", ShowInMgrbar = true)]
         [AuthAuthorize]
        public ActionResult ManagerInfo()
        {
            ViewData["Message"] = "网站后台管理";

            return View("ManagerInfo");
        }
        //会员员管理
         [ehaiker.Auth.Description(No = 2, Name = "会员功能", ShowInMgrbar = true)]
         [AuthAuthorize]
        public ActionResult MemberInfo()
        {
            ViewData["Message"] = "会员管理系统";

            return View("MemberInfo");
        }
        //试玩上线管理
          [ehaiker.Auth.Description(No = 3, Name = "游戏上线功能", ShowInMgrbar = true)]
          [AuthAuthorize]
        public ActionResult GameItemManage()
        {
            ViewData["Message"] = "网站后台管理";

            return View("GameItemManage");
        }
          //权限管理
          [ehaiker.Auth.Description(No = 4, Name = "权限管理", ShowInMgrbar = true)]
          [AuthAuthorize]
          public ActionResult PerMissionManage()
          {
              RoleService sSVR = new RoleService();
              List<Permission> lp = null;
              if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
              {
                  var ticket = (System.Web.HttpContext.Current.User.Identity as FormsIdentity).Ticket;
                  var userData = (System.Web.HttpContext.Current.User as MyFormsPrincipal<UserInfo>).UserData;
                  lp = HttpRuntime.Cache.Get(userData.perskey) as List<Permission>;
                  ViewBag.PerList = sSVR.GetFormatMenu(lp).ToList();
                  ViewBag.RoleList = sSVR.GetCanAssignGroup(userData.GroupId);
                  ViewBag.admin = sSVR.GetSitePerson(userData.GroupId);
                  ViewBag.isSp = userData.GroupId == 1 ? true : false;
              }
              return View("PermissionMgr");
          }
          [HttpPost]
          [AuthAuthorize]
          public ActionResult GetGroupRoles()
          {
              int errorCode = 102;
              string msg = "操作失败";
              RoleService sSVR = new RoleService();
              IList<RolePermissionBinder> r = null;
              if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
              {
                  var ticket = (System.Web.HttpContext.Current.User.Identity as FormsIdentity).Ticket;
                  var userData = (System.Web.HttpContext.Current.User as MyFormsPrincipal<UserInfo>).UserData;
                  r = sSVR.GetCanAssignGroup(userData.GroupId);
                  msg = "操作成功";
                  errorCode = 0;
              }
              var josonret = r.Select(p => new { Id = p.Id, Name = p.Name }).ToList(); ;
              return Json(josonret, JsonRequestBehavior.AllowGet);
          }
      //  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public ActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = "0" });
        }
        [HttpPost]
        [AuthAuthorize]
        [ehaiker.Auth.Description(No = 5, Name = "修改管理组", isGet = false)]
        public JsonResult EditGroup(string ehaiker_parameter)
        {
            var _response = 0;
            int errcode = 100;
            string msg = "操作失败";
            if (ModelState.IsValid)
            {
                Administrator juser = JsonHelper.DeserializeJsonToObject<Administrator>(ehaiker_parameter);
                if (adminManager.HasAccounts(juser.Account))
                {
                    //如果已经有，那么进行更新
                    Administrator aduser = adminManager.GetById(juser.AdministratorID);
                    if (aduser != null)
                    {
                        aduser.GroupId = juser.GroupId;
                        aduser.LoginIP = Request.UserHostAddress;
                        adminManager.Update(aduser);
                        _response = adminManager.SaveChanges();
                        msg = "操作成功";
                        errcode = 0;
                    }
                }
            }
            var josonret = new { ErrorCode = errcode, msg = msg, iSuccessCode = _response };
            return Json(josonret, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [AuthAuthorize]
        [ehaiker.Auth.Description(No =6, Name = "修改管理密码",isGet=false)]
        public JsonResult EditPassword(string ehaiker_parameter)
        {
            var _response = 0;
            int errcode = 100;
            string msg = "操作失败";
            if (ModelState.IsValid)
            {
                Administrator juser = JsonHelper.DeserializeJsonToObject<Administrator>(ehaiker_parameter);
                if (adminManager.HasAccounts(juser.Account) )
                {
                    //如果已经有，那么进行更新
                    Administrator aduser =adminManager.GetById(juser.AdministratorID);
                    if (aduser != null)
                    {
                        aduser.Password = Security.Sha256(juser.Password);
                        aduser.LoginIP = Request.UserHostAddress;
                        adminManager.Update(aduser);
                        _response = adminManager.SaveChanges();
                        msg = "操作成功";
                        errcode = 0;
                    }
                }
            }
            var josonret = new { ErrorCode = errcode, msg = msg, iSuccessCode = _response };
            return Json(josonret, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [ehaiker.Auth.Description(No = 7, Name = "增加管理员", isGet = false)]
        [AuthAuthorize]
        public JsonResult AddNew(string ehaiker_parameter)
        {
            var _response = 0;
            if (ModelState.IsValid)
            {
                Administrator juser = JsonHelper.DeserializeJsonToObject<Administrator>(ehaiker_parameter);
                if (adminManager.HasAccounts(juser.Account))
                {
                    _response = 0;
                }
                else
                {
                    Administrator aduser = new Administrator();
                    aduser.Account = juser.Account;
                    aduser.Password = Security.Sha256(juser.Password);
                    aduser.CreateTime = DateTime.Now;
                    aduser.LoginTime = DateTime.Now;
                    aduser.LoginIP = Request.UserHostAddress;
                    adminManager.Add(aduser);
                    _response = adminManager.SaveChanges();
                    return Json(_response, JsonRequestBehavior.AllowGet);

                }
            }
            return Json(_response, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [ehaiker.Auth.Description(No = 8, Name = "删除管理员", isGet = false)]
        [AuthAuthorize]
        public JsonResult DelAdmin(string ids)
        {
            string[] sids = ids.Split(',');
            List<int> idarr= new List<int>();
            foreach (var item in sids)
            {
                idarr.Add(Convert.ToInt32(item));
            }
            var _response  =adminManager.DeleteArray(idarr.ToArray());
            return Json(_response, JsonRequestBehavior.AllowGet); ;
        }
        ////-------------------------------------------会员系统--------------------
        [HttpPost]
        public JsonResult GetMemberInfo(int ID = 0)
        {
            var tt = new { total = memshipManager.List().Count(), rows = memshipManager.List().ToList() };
            return Json(tt, JsonRequestBehavior.AllowGet); ;
        }
        [HttpPost]
        public JsonResult ResetMemshipPassword(string ehaiker_parameter)
        {
            MemberShip juser = JsonHelper.DeserializeJsonToObject<MemberShip>(ehaiker_parameter);
            string _password = "1234567";
            int _resp = memshipManager.ChangePassword(juser.UserId, Security.Sha256(_password));

            return Json(_resp, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [AuthAuthorize]
        [ehaiker.Auth.Description(No = 9, Name = "删除会员", isGet = false)]
        public JsonResult DelMemShip(string ids)
        {
            string[] sids = ids.Split(',');
            int[] idarr = Array.ConvertAll<string, int>(sids, r => int.Parse(r));
            var _response = memshipManager.DeleteArray(idarr.ToArray());
            return Json(_response, JsonRequestBehavior.AllowGet); ;
        }
        [HttpPost]
        public JsonResult MemshipEdit(string ehaiker_parameter)
        {
            MemberShip juser = JsonHelper.DeserializeJsonToObject<MemberShip>(ehaiker_parameter);
           
            int _resp = memshipManager.ChangePassword(juser.UserId, Security.Sha256(juser.Password));

            return Json(_resp, JsonRequestBehavior.AllowGet);
        }
        //-----------------------------gamelist----
        [HttpPost]
        public JsonResult GetGameListInfo(int type = 1, string name = "")
        {
            GameListManager mgr = new GameListManager();
            if (type == -1)
            {
                var titems = mgr.GetDbSet().Where(r => r.ItemName.Contains(name)).ToList();
                var tt = new { total = titems.Count(), rows = titems.ToList() };
                return Json(tt, JsonRequestBehavior.AllowGet); 
            }
            else
            {
                var tt = new { total = mgr.List().Count(), rows = mgr.List().ToList() };
                return Json(tt, JsonRequestBehavior.AllowGet); ;
            }
            
        }
        [HttpPost]
        public JsonResult GetGameType()
        {
            IRepository<GameType> _noteTypeRepository;
            _noteTypeRepository = new GameTypeRepository();
            var types = _noteTypeRepository.List();
            var gametypelist = types.Select(r => new SelectListItem { Text = r.Name, Value = r.GameId.ToString() });
            return Json(types, JsonRequestBehavior.AllowGet); 
        }
        /// <summary>
        /// 修改游戏上线
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GameItemEdit(string ehaiker_parameter)
        {
            GameModel nmodel = JsonHelper.DeserializeJsonToObject<GameModel>(ehaiker_parameter);
            IRepository<GameModel> _GameRepository = new GameListManager();
            _GameRepository.Update(nmodel);
            int  _resp = _GameRepository.SaveChanges();
            return Json(_resp, JsonRequestBehavior.AllowGet);
        }
        //增加游戏上线
        [HttpPost]
        [ehaiker.Auth.Description(No = 10, Name = "增加游戏上线项目", isGet = false)]
        [AuthAuthorize]
        public JsonResult AddGameItem(string ehaiker_parameter)
        {
            int ret = 0;
            if (ModelState.IsValid)
            {
                    GameListManager _GameRepository = new GameListManager();
                    GameModel Item = JsonHelper.DeserializeJsonToObject<GameModel>(ehaiker_parameter);
                    //设置相关系统
                    Item.EndTime = DateTime.Now;
                    Item.StartTime = DateTime.Now;
                    Item.MineTime= DateTime.Now;
                    Item.TopLevel = 0;
                    Item.grade = (float)5.0;
                    _GameRepository.Add(Item);
                    ret = _GameRepository.SaveChanges();
                    if (ret > 0)
                    {
                        GameModel newRet = _GameRepository.Find(Item.ItemName);
                        ret = newRet.ItemID;
                    }

            }

            return Json(ret, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 删除上线项目
        /// </summary>
        /// <returns></returns> 
        /// 

        [HttpPost]
        [AuthAuthorize]
        [ehaiker.Auth.Description(No = 11, Name = "删除游戏上线项目", isGet = false)]
        public JsonResult DelGameItem(string ehaiker_parameter)
        {
            int ret = 0;
            if (ModelState.IsValid)
            {
                GameListManager _GameRepository = new GameListManager();
                GameModel Item = JsonHelper.DeserializeJsonToObject<GameModel>(ehaiker_parameter);
                //设置相关系统
                Item.EndTime = DateTime.Now;
                Item.StartTime = DateTime.Now;
                Item.TopLevel = 0;
                _GameRepository.Delete(Item.ItemID);
                ret = _GameRepository.SaveChanges();
            }

            return Json(ret, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 获取描述图片
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetDescImgs()
        {
            //枚举图片文件
            string imgurl = Server.MapPath("~/Common/public/games");
            var imgs = FindImg(imgurl, "../Common/public/games/");
            var tt = new { total = imgs.Count(), data = imgs.ToList() };
            return Json(tt, JsonRequestBehavior.AllowGet); ;
        }
         //获取管理的所有权限
        [HttpPost]
        public JsonResult GetPermissions(int page, int rows, int groupid = 0)
        {
            RoleService sSVR = new RoleService();
            List<Permission> lp = null;
            Tuple<List<Permission>, int> pager = null;
            if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                var ticket = (System.Web.HttpContext.Current.User.Identity as FormsIdentity).Ticket;
                var userData = (System.Web.HttpContext.Current.User as MyFormsPrincipal<UserInfo>).UserData;
                //如果是超级管理员，忽视组
                if (userData.GroupId == 1)
                {
                    pager = sSVR.GetPermissionPageList(page, rows);
                }
                else
                {
                    pager = sSVR.GetGroupPermissionPageList(page, rows, userData.GroupId);
                }
                lp = pager.Item1;
                ViewBag.PerList = lp.ToList();
            }
            var tt = new { total = pager.Item2, rows = lp.ToList() };
            return Json(tt, JsonRequestBehavior.AllowGet); ;
        }
         [HttpPost]
        public JsonResult GetGroupPermissions(int groupid)
         {
             RoleService sSVR = new RoleService();
            // List<MenuItem> ls;
             List<Permission> lp = null;
             lp = sSVR.GetGroupPermissions(groupid);
             var tt = new { Ids = lp.Select(r => r.Id).ToList(), rows = lp.ToList() };
             return Json(tt, JsonRequestBehavior.AllowGet); ;
         }
         
         [HttpPost]
         public JsonResult GetSitePermissions(int userId)
         {
             RoleService sSVR = new RoleService();
            // List<MenuItem> ls;
             List<Permission> lp = null;
             lp = sSVR.GetSitePermission( userId );
             var tt = new { Ids = lp.Select(r => r.Id).ToList(), rows = lp.ToList() };
             return Json(tt, JsonRequestBehavior.AllowGet); ;
         }
         [HttpPost]
         [AuthAuthorize]
         [ehaiker.Auth.Description(No = 12, Name = "保存权限", isGet = false)]
         public JsonResult SaveSitePermissions(int userId,int groupid,string ids)
         {
             RoleService sSVR = new RoleService();
             //不要相信客户端的东西，进行权限校验
             var arr = ids.Split(',');
             int[] iarr = Array.ConvertAll<string, int>(arr, r => int.Parse(r) );
             //
             List<Permission> lp = null;
             lp = sSVR.GetGroupPermissions(groupid);
             var groupIds = lp.Select(r => r.Id).ToList();
             var arrb = groupIds.ToArray();
             //如果出现一个非组内id，非法修改
            if(IsSubArray(iarr,arrb))
            {
              int changeCnt= sSVR.saveSitePermission(userId,ids);
              var tt = new { changecnt = changeCnt };
             return Json(tt, JsonRequestBehavior.AllowGet); ;
            }
              var tt1 = new { changecnt = 0 };
             return Json(tt1, JsonRequestBehavior.AllowGet);
         }
         [HttpPost]
         [AuthAuthorize]
         [ehaiker.Auth.Description(No = 13, Name = "保存管理组权限", isGet = false)]
         public JsonResult SaveGroupPermissions(int groupid, string ids)
         {
             RoleService sSVR = new RoleService();
             //不要相信客户端的东西，进行权限校验
             int changeCnt = sSVR.saveRolePermission(groupid, ids);
            var tt = new { changecnt = changeCnt };
            return Json(tt, JsonRequestBehavior.AllowGet); 
         }
         [HttpPost]
         [AuthAuthorize]
         [ehaiker.Auth.Description(No = 14, Name = "增加管理组", isGet = false)]
         public JsonResult AddNewAdminGroup(string newgroup, string groupdesc)
         {
             if(string.IsNullOrEmpty(newgroup))
             {
                 var tt1 = new { changecnt = 0 };
                 return Json(tt1, JsonRequestBehavior.AllowGet);
             }
             RoleService sSVR = new RoleService();
             RolePermissionBinder newper = new RolePermissionBinder();
             newper.Description = groupdesc;
             newper.Name = newgroup;
             newper.Permissions = "";
             int changeCnt = sSVR.AddRole(newper);
             var tt = new { Id = changeCnt };
             return Json(tt, JsonRequestBehavior.AllowGet);
         }
        public ActionResult Logout()
        {
            //Forms验证
            FormsAuthentication.SignOut();
            //没有登录
            Object cookie = Session["AdminUser"];
            if (cookie != null)
            {
                //cookie是不能实现Session的功能的
                Session.Remove("AdminUser");
            }
            //Session.Timeout = 5;
            Session["AdminUser"] = null;
            Session.Clear();
            return Redirect("../EHaiker/Index");

        }
        private List<string> FindImg(string sSource,string prefix)
        {
            var files = Directory.GetFiles(sSource, "*.*", SearchOption.TopDirectoryOnly)
 .Where(s => s.EndsWith(".png") || s.EndsWith(".jpg") || s.EndsWith(".gif"));
            List<string> filelist = new List<string>();
            foreach (string file in files)
            {
                System.IO.FileInfo fi = new System.IO.FileInfo(file);
                if (fi.Extension == ".jpg" || fi.Extension == ".png" || fi.Extension == ".gif")
                {
                    string dname = prefix + fi.Name;
                    filelist.Add(dname);
                }
            }
            return filelist;
        }
         //比较权限是否相等
        private static bool IsSubArray(int[] arr1, int[] arr2)
        {
            var q = from a in arr1 join b in arr2 on a equals b select a;
            bool flag = arr1.Length <= arr2.Length && q.Count() == arr1.Length;
            return flag;
        }
        
    }
}
