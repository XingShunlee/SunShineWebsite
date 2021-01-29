using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ehaiker;
using ehaiker.Models;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace ehaiker
{
    public class GameListManager : IRepository<GameModel>
    {
        private EhaikerContext context;
        public GameListManager(EhaikerContext _context)
        {
            context =_context;
            
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="admin">管理员实体</param>
        /// <returns></returns>
        public void Add(GameModel ImgItem)
        {

            if (HasAccounts(ImgItem.ItemName))
            {
                // _resp.Code = 0;
                // _resp.Message = "帐号已存在";
                return ;
            }
            else
            {
                context.GameLists.Add(ImgItem);
            }
        }
        public List<GameModel> List()
        {
            return context.GameLists.ToList();
        }
        public GameModel GetById(int id)
        {
            return context.GameLists.FirstOrDefault(r => r.ItemID == id);
        }
        public void Update(GameModel ImgItem)
        {
            context.Entry(ImgItem).State = EntityState.Modified;
        }
        public DbSet<GameModel> GetDbSet()
        {
            return context.GameLists;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="administratorID">主键</param>
        /// <returns></returns>
        public void Delete(int administratorID)
        {
            var _admin = GetById(administratorID);
            if (context.GameLists.Count() == 1)
            {
                return ;
            }
            else
            {
                context.GameLists.Remove(_admin);
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="administratorID">主键,主键</param>
        /// <returns></returns>
        public int DeleteArray(int[] administratorIDs)
        {

            if (context.GameLists.Count() <=0 )
            {
                return 0;
            }
            else
            {
                var idlist = administratorIDs;
                IQueryable<Object> queryEntity = context.GameLists.Where(r => idlist.Contains(r.ItemID));
                foreach (GameModel item in queryEntity)
                {
                    context.GameLists.Remove(item);
                }
                return context.SaveChanges();
            }
        }
        /// <summary>
        /// 查找
        /// </summary>
        /// <param name="accounts">帐号</param>
        /// <returns></returns>
        public GameModel Find(string account)
        {
            return context.GameLists.FirstOrDefault(a => a.ItemName == account);
        }

        /// <summary>
        /// 帐号是否存在
        /// </summary>
        /// <param name="accounts">帐号</param>
        /// <returns></returns>
        public bool HasAccounts(string accounts)
        {
            return context.GameLists.FirstOrDefault(a => a.ItemName.ToUpper() == accounts.ToUpper()) != null;
        }

        /// <summary>
        /// 更新登录信息
        /// </summary>
        /// <param name="administratorID">主键</param>
        /// <param name="ip">IP地址</param>
        /// <param name="time">时间</param>
        /// <returns></returns>
        public int UpadateLoginInfo(int administratorID, string ip, DateTime time)
        {
            var _admin = GetById(administratorID);
            if (_admin == null)
            {
                return 0;
            }
            else
            {
                Update(_admin);
                return SaveChanges();
            }
        }

       
        //根据用户页面大小，起始，返回相应的内容
        public Tuple<List<GameModel>, int> PageList(int pageindex, int pagesize)
        {
            var query = context.GameLists
                .AsQueryable();
            var count = query.Count();
            var pagecount = count % pagesize == 0 ? count / pagesize : count / pagesize + 1;
            var notes = query.OrderByDescending(r => r.TopLevel)
                .Skip((pageindex - 1) * pagesize)
                .Take(pagesize)
                .ToList();
            return new Tuple<List<GameModel>, int>(notes, count);
        }
        public int SaveChanges()
        {
           // try
            //{
                return context.SaveChanges();
           // }
            //catch (DbEntityValidationException exception)
            //{
            //    var errorMessages =
            //        exception.EntityValidationErrors
            //            .SelectMany(validationResult => validationResult.ValidationErrors)
            //            .Select(m => m.ErrorMessage);

            //    var fullErrorMessage = string.Join(", ", errorMessages);
            //    //记录日志
            //    //Log.Error(fullErrorMessage);
            //    var exceptionMessage = string.Concat(exception.Message, " 验证异常消息是：", fullErrorMessage);

            //    throw new DbEntityValidationException(exceptionMessage, exception.EntityValidationErrors);
            //}
        }
    }
   
}
/// <summary>
/// 管理员身份验证类
/// </summary>
//public class GameListAuthorizeAttribute : AuthorizeAttribute
//{
//    /// <summary>
//    /// 重写自定义授权检查
//    /// </summary>
//    /// <returns></returns>
//    protected override bool AuthorizeCore(HttpContextBase httpContext)
//    {
//        if (httpContext.Session["AdminUser"] == null) return false;
//        else return true;
//    }
//    /// <summary>
//    /// 重写未授权的 HTTP 请求处理
//    /// </summary>
//    protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
//    {
//        filterContext.Result = new RedirectResult("/AdminLogin/Index");
//    }
//}