using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ehaiker.Models;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using ehaikerv202010;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;
using ehaikerv202010.Filters;
using ehaiker.Managers;
using ehaikerv202010.Models;

namespace ehaiker.Controllers
{

    //[MemberShipAuthorizeAttribute]
   // [Description(No = 2, Name = "个人中心")]
    public class ManagerMainController : Controller
    {

        // GET: /personal/
        private EhaikerContext DbContext;
        private IHostingEnvironment _env;
        public ManagerMainController(EhaikerContext _cont,IHostingEnvironment env)
        {
            DbContext = _cont;
            _env = env;


        }
        public ActionResult Index()
        {
            //没有登录
            Administrator cookie = MemUserDataManager.GetMemSessionData<Administrator>(HttpContext, "AdminUser");
            if (cookie != null)
            {
                return View(cookie);
            }
            else
            {
                return RedirectToRoute(new { Controller = "AdminLogin", Action = "Index" });
            }
        }
       
       // [Description(No = 1, Name = "用户信息")]
        public ActionResult UserInfo()
        {

            Administrator juser = MemUserDataManager.GetMemSessionData<Administrator>(HttpContext, "AdminUser");
            return View(juser);
        }
        [AdminLoginStateRequiredAttribute]
        public ActionResult GameManage()
        {
            return View("GameList");
        }
        [AdminLoginStateRequiredAttribute]
        public ActionResult GameStragesManage()
        {
            return View("GameStragesList");
        }
        [AdminLoginStateRequiredAttribute]
        public ActionResult membershipManage()
        {
            return View("memberShipManage");
        }
        [AdminLoginStateRequiredAttribute]
        public ActionResult AdminManage()
        {
            return View("AdminManage");
        }
        [AdminLoginStateRequiredAttribute]
        public ActionResult CommentManage()
        {
            return View("CommentManageView");
        }
        [AdminLoginStateRequiredAttribute]
        public ActionResult GroupPermissionDispatch(int?id)
        {
            AdministratorManager adminManager = new AdministratorManager(DbContext);
            if (id == null)
            {
                return NotFound();
            }
            var _admin = adminManager.GetById((int)id);
            var types = DbContext.GroupTable.ToList();
            ViewBag.Groups = types.Select(r => new SelectListItem
            { Text = r.Name, Value = r.Id.ToString(), Selected = (r.Id == _admin.GroupId) });
            //获取权限数组
            var arr = _admin.sPermission.Split(',');
            int[] inumarr;
            if(arr !=null && !string.IsNullOrEmpty(_admin.sPermission))
            {
                inumarr = Array.ConvertAll<string, int>(arr, s => int.Parse(s));
            }
            else
            {
                inumarr = new int[1];
            }
            var permissions = from ps in DbContext.PermissionTable
                        where (inumarr.Contains(ps.Id))
                        select ps;
            ViewBag.myPermissions = permissions.ToList();
            return View("GroupAdminDispatchView",_admin);
        }
        //BillManage
        [AdminLoginStateRequiredAttribute]
        public ActionResult BillManage()
        {
            return View("BillManageView");
        }
        [AdminLoginStateRequiredAttribute]
        public ActionResult GameItemModify(int ItemId)
        {
            if(ItemId <=0)
                return RedirectToRoute(new { Controller = "ManagerMain", Action = "GameManage" });
            GameListManager GamelistManager = new GameListManager(DbContext);
            var query = GamelistManager.GetDbSet().Where(r => r.ItemID == ItemId).FirstOrDefault();
            if (query != null)
            {
                IRepository<GameType> _noteTypeRepository;
                _noteTypeRepository = new GameTypeRepository(DbContext);
                var types = _noteTypeRepository.List();
                ViewBag.GameTypes = types.Select(r => new SelectListItem { Text = r.Name, Value = r.GameId.ToString() });
                return View("GameItem",query);
            }
            else
            {
                return RedirectToRoute(new { Controller = "ManagerMain", Action = "GameManage" });
            }
        }
        [AdminLoginStateRequiredAttribute]
        public ActionResult AddNews()
        {
            IRepository<NewsModel> _noteRepository;
            IRepository<GameType> _noteTypeRepository;
            _noteRepository = new NewsesRepository(DbContext);
            _noteTypeRepository = new GameTypeRepository(DbContext);
            var types = _noteTypeRepository.List();
            NewsModel n = new NewsModel { Title = "请输入" };
            ViewBag.Types = types.Select(r => new SelectListItem { Text = r.Name, Value = r.GameId.ToString() });
            return View("AddNews",n);
        }
        [AdminLoginStateRequiredAttribute]
        public ActionResult NewGameItem()
        {
            IRepository<GameType> _noteTypeRepository;
            _noteTypeRepository = new GameTypeRepository(DbContext);
            var types = _noteTypeRepository.List();
            ViewBag.GameTypes = types.Select(r => new SelectListItem { Text = r.Name, Value = r.GameId.ToString() });
            return View("NewGameItem");
        }
        [AdminLoginStateRequiredAttribute]
        public ActionResult NewGameStrage()
        {
            IRepository<GameType> _noteTypeRepository;
            _noteTypeRepository = new GameTypeRepository(DbContext);
            var types = _noteTypeRepository.List();
            ViewBag.GameTypes = types.Select(r => new SelectListItem { Text = r.Name, Value = r.GameId.ToString() });
            return View("NewGameStrage");
        }
        [HttpPost]
        [AdminLoginStateRequiredAttribute]
        // [Description(No = 12, Name = "上传头像", isGet = false)]
        public async Task<JsonResult> UploadFile()
        {
            LoginMessage msg = new LoginMessage();
            msg.msg = "未知错误";
            msg.SuccessCode = "-1000";
            Administrator loginUser = MemUserDataManager.GetMemSessionData<Administrator>(HttpContext, "AdminUser");
            
            var files = Request.Form.Files;

            string error = string.Empty;
            string res = string.Empty;
             long filelen=files[0].Length;
            //~/UploadFiles/Icon/UserName/
            string fileroot = string.Format("~/UploadFiles/Icon/{0}/", loginUser.Account);
            string filePath = _env.WebRootPath+(fileroot) ;
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            //获取文件信息：防止改名字的文件上传
            string fileName = files[0].FileName;
           // loginUser.Icon = fileroot + fileName;

            try
            {
                using (var stream = new FileStream(Path.Combine(filePath, fileName), FileMode.Create))
                {
                    await files[0].CopyToAsync(stream);
                }
                    ;// files[0].Save(Path.Combine(filePath, fileName));
            }
            catch (Exception e)
            {
                msg.msg = "保存文件失败" + e.Message;
                return Json(msg);
            }
            FileUploadHelper.FileExtension[] fe = { FileUploadHelper.FileExtension.JPG,
                    FileUploadHelper.FileExtension.PNG,
                    FileUploadHelper.FileExtension.GIF };
            if (!FileUploadHelper.CheckTrueFileName(files[0].FileName, fe
                ))
            {
                msg.msg = "非法的文件格式";
                return Json(msg);
            }

            IRepository<Administrator> memshipMgr = new AdministratorManager(DbContext);
           // loginUser.Icon = string.Format("../UploadFiles/Icon/{0}/{1}", loginUser.Account, fileName);
            memshipMgr.Update(loginUser);
            MemUserDataManager.UpdateSessionData(HttpContext, "AdminUser", loginUser);
           // msg.msg = loginUser.Icon;
                msg.SuccessCode = "0";
            return Json(msg);
        }
        /////////////////////////////////////////////////
        [HttpPost]
        [AdminLoginStateRequiredAttribute]
        public async Task<JsonResult> GetGameList(int page = 1, int rows = 10, int type = 1, string name = "")
        {
            page = page > 0 ? page : 1;
            GameListManager GamelistManager = new GameListManager(DbContext);
            var query = new List<GameModel>();
            if (type >= 0)
            {

                if (type == 0)
                {
                    query = GamelistManager.List();
                }
                else
                {
                    query = GamelistManager.GetDbSet().Where(r => r.Gametype == type).ToList();
                }


            }
            else
            {

                query = (from c in GamelistManager.GetDbSet()
                         where c.ItemName.Contains(name)
                         select c).ToList();

            }
            var count = query.Count();
            var pagecount = count % rows == 0 ? count / rows : count / rows + 1;
            var findItems = query.OrderByDescending(r => r.TopLevel)
                .Skip((page - 1) * rows)
                .Take(rows)
                .ToList();
            var notes = new Tuple<List<GameModel>, int>(findItems, pagecount);

            ViewBag.PageIndex = page;//当前页
            var tt = new { Total = notes.Item2, data = notes.Item1 };
            return Json(tt);

        }
        [HttpPost]//GameStrategies
        [AdminLoginStateRequiredAttribute]
        public JsonResult GetMemberships(int page = 1, int rows = 10, string name = "")
        {
            page = page > 0 ? page : 1;
            MemberShipManager membershipmgr = new MemberShipManager(DbContext);
            var query = new List<MemberShip>();
            if (string.IsNullOrEmpty(name))
            {
                query = membershipmgr.List();
            }
            else
            {
                query = (from c in membershipmgr.GetDbSet()
                         where c.UserName.Contains(name)
                         select c).ToList();

            }
            var count = query.Count();
            var pagecount = count % rows == 0 ? count / rows : count / rows + 1;
            var findItems = query.OrderByDescending(r => r.LastSignTime)
                .Skip((page - 1) * rows)
                .Take(rows)
                .ToList();
            var notes = new Tuple<List<MemberShip>, int>(findItems, pagecount);

            ViewBag.PageIndex = page;//当前页
            var tt = new { Total = notes.Item2, data = notes.Item1 };
            return Json(tt);

        }
        [HttpPost]
        [AdminLoginStateRequiredAttribute]
        public JsonResult GetGameStrategies(int page = 1, int rows = 10)
        {
            page = page > 0 ? page : 1;
            GameStrategiesRepository _noteRepository;
            _noteRepository = new GameStrategiesRepository(DbContext);
            var query = new List<GameStrategies>();
            query = _noteRepository.List();
            
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
        [HttpPost]
        [AdminLoginStateRequiredAttribute]
        public JsonResult DeleteMember(int uid,int page = 1, int rows = 10)
        {
            page = page > 0 ? page : 1;
            MemberShipManager membershipmgr = new MemberShipManager(DbContext);
            var query = new List<MemberShip>();
            if (uid != 0)
            {
                membershipmgr.Delete(uid);
            }
            query = membershipmgr.List();
            var count = query.Count();
            var pagecount = count % rows == 0 ? count / rows : count / rows + 1;
            var findItems = query.OrderByDescending(r => r.LastSignTime)
                .Skip((page - 1) * rows)
                .Take(rows)
                .ToList();
            var notes = new Tuple<List<MemberShip>, int>(findItems, pagecount);

            ViewBag.PageIndex = page;//当前页
            var tt = new { Total = notes.Item2, data = notes.Item1 };
            return Json(tt);

        }
        [HttpPost]
        [AdminLoginStateRequiredAttribute]
        public JsonResult DisableMember(int uid, int page = 1, int rows = 10, int type = 1)
        {
            page = page > 0 ? page : 1;
            MemberShipManager membershipmgr = new MemberShipManager(DbContext);
            var query = new List<MemberShip>();
            if (uid != 0)
            {
                MemberShip sh = membershipmgr.GetById(uid);
                if (sh != null)
                {
                    sh.nStatus = 0;
                    membershipmgr.Update(sh);
                    membershipmgr.SaveChanges();
                }
            }
            query = membershipmgr.List();
            var count = query.Count();
            var pagecount = count % rows == 0 ? count / rows : count / rows + 1;
            var findItems = query.OrderByDescending(r => r.LastSignTime)
                .Skip((page - 1) * rows)
                .Take(rows)
                .ToList();
            var notes = new Tuple<List<MemberShip>, int>(findItems, pagecount);

            ViewBag.PageIndex = page;//当前页
            var tt = new { Total = notes.Item2, data = notes.Item1 };
            return Json(tt);

        }
        //PageResetPassword
        [HttpPost]
        [AdminLoginStateRequiredAttribute]
        public JsonResult PageResetPassword(int uid, int page = 1, int rows = 10, int type = 1)
        {
            page = page > 0 ? page : 1;
            MemberShipManager membershipmgr = new MemberShipManager(DbContext);
            var query = new List<MemberShip>();
            if (uid != 0)
            {
                MemberShip sh = membershipmgr.GetById(uid);
                if (sh != null)
                {
                    string password_valid = string.Empty;
                    ValidateCode generater = new ValidateCode();
                    password_valid = generater.CreateValidateCode(12);
                    HttpContext.Session.SetString("ValidPassword_user_ehaiker", password_valid);
                    sh.Password=Security.Sha256(password_valid);
                    
                    membershipmgr.Update(sh);
                    membershipmgr.SaveChanges();
                    //给用户邮箱发邮件
                    string validcode = Security.Sha256(string.Format("{0}{1}{2}", sh.UserId,
                       sh.Password, DateTime.Now.ToLongTimeString()));
                    var noticestring =
                        string.Format("<h2>尊敬的{0},您好：</h2>您的新密码为{1}，请前往会员中心激活",
                        sh.UserName, password_valid);
                    SendMail.SendEmail(sh.Account, noticestring, "密码验证");
                }
            }
            var tt = new { Total = 1, data = "" };
            return Json(tt);

        }
       
        [HttpPost]
        [AdminLoginStateRequiredAttribute]
        public JsonResult GetchargeBills(int page = 1, int rows = 10)
        {
            page = page > 0 ? page : 1;
            var query = new List<PaybillApproveModel>();
            IRepository<PaybillApproveModel> _noteRepository = new PaybillApproveRepository(DbContext);

            query = _noteRepository.GetDbSet().Where(r=>r.PayState==0)?.ToList();
            try
            {
                var count = query.Count();
                var pagecount = count % rows == 0 ? count / rows : count / rows + 1;
                var findItems = query.OrderByDescending(r => r.CreateTime)
                    .Skip((page - 1) * rows)
                    .Take(rows)
                    .ToList();
                var notes = new Tuple<List<PaybillApproveModel>, int>(findItems, pagecount);

                ViewBag.PageIndex = page;//当前页
                var tt = new { Total = notes.Item2, data = notes.Item1 };
                return Json(tt);
            }
            catch
            {
                var tt = new { Total = 0, data = "" };
                return Json(tt);
            }
           
        }
        //PageBackBills
        [HttpPost]
        [AdminLoginStateRequiredAttribute]
        public JsonResult PageBackBills(int uid)
        {
            IRepository<PaybillApproveModel> _noteRepository = new PaybillApproveRepository(DbContext);
            if (uid != 0)
            {
                PaybillApproveModel sh = _noteRepository.GetById(uid);
                if (sh != null)
                {
                    sh.PayState = 3;
                    _noteRepository.Update(sh);
                    _noteRepository.SaveChanges();
                }
            }
            var tt = new { Total = 0, data =0 };
            return Json(tt);
        }
        //PayForBills
        [HttpPost]
        [AdminLoginStateRequiredAttribute]
        public JsonResult PayForBills(int uid)
        {
            IRepository<PaybillApproveModel> _noteRepository = new PaybillApproveRepository(DbContext);
            if (uid != 0)
            {
                PaybillApproveModel sh = _noteRepository.GetById(uid);
                if (sh != null)
                {
                    sh.PayState = 1;
                    _noteRepository.Update(sh);
                    _noteRepository.SaveChanges();
                }
            }
            var tt = new { Total = 0, data = 0 };
            return Json(tt);
        }
        //ValidPass
        //PageBackBills---未实现
       
        [AdminLoginStateRequiredAttribute]
        public JsonResult GameStragePass(int uid)
        {
            GameStrategiesRepository cmmtmgr = new GameStrategiesRepository(DbContext);
            if (uid != 0)
            {
                GameStrategies sh = cmmtmgr.GetById(uid);
                if (sh != null)
                {
                    sh.IsIdentified = 1;
                    cmmtmgr.Update(sh);
                    cmmtmgr.SaveChanges();
                }
            }
            var tt = new { Total = 0, data = 0 };
            return Json(tt);

        }
        //PayForBills---未实现
        [AdminLoginStateRequiredAttribute]
        public JsonResult GameStrageDel(int uid)
        {
            GameStrategiesRepository cmmtmgr = new GameStrategiesRepository(DbContext);
            if (uid != 0)
            {
                GameStrategies sh = cmmtmgr.GetById(uid);
                if (sh != null)
                {
                    cmmtmgr.Delete(uid);
                    cmmtmgr.SaveChanges();
                }
            }
            var tt = new { Total = 0, data = 0 };
            return Json(tt);
        }
        /// <summary>
        /// 获取描述图片
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AdminLoginStateRequiredAttribute]
        public JsonResult GetDescImgs()
        {
            //枚举图片文件
            string imgurl = _env.WebRootPath+("/public/games");
            var imgs = FileUploadHelper.FindImg(imgurl, "../public/games/");
            var tt = new { total = imgs.Count(), data = imgs.ToList() };
            return Json(tt); ;
        }

        [HttpPost]
        [AdminLoginStateRequiredAttribute]
        public JsonResult SaveGameItem(string Item_parameter)
        {
            GameModel gameItem = JsonHelper.DeserializeJsonToObject<GameModel>(Item_parameter);
            if(gameItem != null)
            {
                if(!string.IsNullOrEmpty(gameItem.gameDescription))
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

                GameListManager GamelistManager = new GameListManager(DbContext);
                GameModel sh = GamelistManager.GetById(gameItem.ItemID);
                if (sh != null)
                {
                    //赋值（更新内容）
                    sh.ItemName = gameItem.ItemName;
                    sh.supporter = gameItem.supporter;
                    sh.producer = gameItem.producer;
                    sh.grade = gameItem.grade;
                    sh.TopLevel = gameItem.TopLevel;
                    sh.resourcefrom = gameItem.resourcefrom;
                    sh.Keywords = gameItem.Keywords;
                    sh.ImgDescUri = gameItem.ImgDescUri;
                    sh.ImgHoverUri = gameItem.ImgHoverUri;
                    sh.targetUri = gameItem.targetUri;
                    sh.gameDescription = gameItem.gameDescription;
                    sh.Gametype = gameItem.Gametype;
                    GamelistManager.Update(sh);
                    GamelistManager.SaveChanges();
                    var t0 = new { code = 0, data = "更新成功" };
                    return Json(t0);
                }
            }
            var tt = new { code = 10000, data = "未知错误" };
            return Json(tt);
        }
        [HttpPost]
        [AdminLoginStateRequiredAttribute]
        public JsonResult AddNewGameItem(string Item_parameter)
        {
            GameModel gameItem = JsonHelper.DeserializeJsonToObject<GameModel>(Item_parameter);
            if (gameItem != null)
            {
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
                Administrator cookie = MemUserDataManager.GetMemSessionData<Administrator>(HttpContext, "AdminUser");
                
                GameListManager GamelistManager = new GameListManager(DbContext);
                //
                gameItem.MineTime = DateTime.Now;
                gameItem.StartTime = DateTime.Now;
                gameItem.EndTime = DateTime.Now.AddDays(1);
                //作者
                gameItem.Announcer = cookie.Account;
                gameItem.AuthorID = cookie.AdministratorID;
                gameItem.IsIdentified = 1;
                GamelistManager.Add(gameItem);
                GamelistManager.SaveChanges();
                var tt0 = new { code = 0, data = "添加成功" };
                return Json(tt0);
            }
            var tt = new { code = 10000, data = "未知错误" };
            return Json(tt);
        }
        [HttpPost]
        [AdminLoginStateRequiredAttribute]
        public JsonResult AddNewGameStrage(string Item_parameter)
        {
            GameStrategies gameItem = JsonHelper.DeserializeJsonToObject<GameStrategies>(Item_parameter);
            if (gameItem != null)
            {
                //防止脚本注入
                if(!string.IsNullOrEmpty(gameItem.Title))
                gameItem.Title = System.Text.RegularExpressions.Regex.Replace(gameItem.Title, "/(?!<(img|p|span).*?>)<.*?>/g", "");
                if(!string.IsNullOrEmpty(gameItem.Content))
                gameItem.Content = System.Text.RegularExpressions.Regex.Replace(gameItem.Content, "/(?!<(img|p|span).*?>)<.*?>/g", "");

                Administrator cookie = MemUserDataManager.GetMemSessionData<Administrator>(HttpContext, "AdminUser");

                GameStrategiesRepository GamelistManager = new GameStrategiesRepository(DbContext);
                //
                gameItem.CreateTime = DateTime.Now;
                gameItem.LastEditTime = DateTime.Now;
                gameItem.readers = 1;

                //作者
                gameItem.Author = cookie.Account;
                gameItem.AuthorID = cookie.AdministratorID;
                gameItem.IsIdentified = 1;
                GamelistManager.Add(gameItem);
                GamelistManager.SaveChanges();
                var tt0 = new { code = 0, data = "添加成功" };
                return Json(tt0);
            }
            var tt = new { code = 10000, data = "未知错误" };
            return Json(tt);
        }
        [HttpPost]
        [AdminLoginStateRequiredAttribute]
        public JsonResult GroupPermissionDispatch(string Item_parameter)
        {
           
            GameModel gameItem = JsonHelper.DeserializeJsonToObject<GameModel>(Item_parameter);
            var tt = new { total = 0, data = 0 };
            return Json(tt); 
        }
        [HttpPost]
        [AdminLoginStateRequired]
        public async Task<JsonResult> GetAPermissions(int? id)
        {
            var groupPermissionBinder = await DbContext.GroupBinderTable.FindAsync(id);
            if (groupPermissionBinder == null|| id==0)
            {
                var tt0 = new { total = 0, data = 0 };
                return Json(tt0);
            }
            var arr = groupPermissionBinder.OwnPermissions.Split(',');
            int[] inumarr;
            if (arr != null && !string.IsNullOrEmpty(groupPermissionBinder.OwnPermissions))
            {
                inumarr = Array.ConvertAll<string, int>(arr, s => int.Parse(s));
            }
            else
            {
                inumarr = new int[1];
            }
            var permissions = from ps in DbContext.PermissionTable
                              where (inumarr.Contains(ps.Id))
                              select ps;
           // ViewBag.myPermissions = permissions.ToList();
            var tt = new { total = 1, data = groupPermissionBinder.OwnPermissions,data1 = permissions.ToList() };
            return Json(tt);
        }

        [HttpPost]
        [AdminLoginStateRequiredAttribute]
        public JsonResult DeleteAdmin(int uid, int page = 1, int rows = 10)
        {
            page = page > 0 ? page : 1;
            AdministratorManager membershipmgr = new AdministratorManager(DbContext);
            var query = new List<Administrator>();
            if (uid != 0)
            {
                membershipmgr.Delete(uid);
            }
            query = membershipmgr.List();
            var count = query.Count();
            var pagecount = count % rows == 0 ? count / rows : count / rows + 1;
            var findItems = query.OrderByDescending(r => r.AdministratorID)
                .Skip((page - 1) * rows)
                .Take(rows)
                .ToList();
            var notes = new Tuple<List<Administrator>, int>(findItems, pagecount);

            ViewBag.PageIndex = page;//当前页
            var tt = new { Total = notes.Item2, data = notes.Item1 };
            return Json(tt);

        }
        [HttpPost]
        [AdminLoginStateRequiredAttribute]
        public JsonResult DisableAdmin(int uid, int page = 1, int rows = 10, int type = 1)
        {
            page = page > 0 ? page : 1;
            AdministratorManager membershipmgr = new AdministratorManager(DbContext);
            var query = new List<Administrator>();
            if (uid != 0)
            {
                Administrator sh = membershipmgr.GetById(uid);
                if (sh != null)
                {
                    //sh. = 0;
                    membershipmgr.Update(sh);
                    membershipmgr.SaveChanges();
                }
            }
            query = membershipmgr.List();
            var count = query.Count();
            var pagecount = count % rows == 0 ? count / rows : count / rows + 1;
            var findItems = query.OrderByDescending(r => r.CreateTime)
                .Skip((page - 1) * rows)
                .Take(rows)
                .ToList();
            var notes = new Tuple<List<Administrator>, int>(findItems, pagecount);

            ViewBag.PageIndex = page;//当前页
            var tt = new { Total = notes.Item2, data = notes.Item1 };
            return Json(tt);

        }
        [HttpPost]//GameStrategies
        [AdminLoginStateRequiredAttribute]
        public JsonResult GetAdmins(int page = 1, int rows = 10, string name = "")
        {
            page = page > 0 ? page : 1;
            AdministratorManager membershipmgr = new AdministratorManager(DbContext);
            var query = new List<Administrator>();
            if (string.IsNullOrEmpty(name))
            {
                query = membershipmgr.List();
            }
            else
            {
                query = (from c in membershipmgr.GetDbSet()
                         where c.Account.Contains(name)
                         select c).ToList();

            }
            var count = query.Count();
            var pagecount = count % rows == 0 ? count / rows : count / rows + 1;
            var findItems = query.OrderByDescending(r => r.LoginTime)
                .Skip((page - 1) * rows)
                .Take(rows)
                .ToList();
            var notes = new Tuple<List<Administrator>, int>(findItems, pagecount);

            ViewBag.PageIndex = page;//当前页
            var tt = new { Total = notes.Item2, data = notes.Item1 };
            return Json(tt);

        }

    }
}
