using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ehaiker;
using ehaiker.Models;
using System.Data;
using Microsoft.EntityFrameworkCore;
using ehaikerv202010.Models;

namespace ehaiker
{
    public class MyGameManager: IRepository<MyGameLibs>
    {
        private EhaikerContext context;
        public MyGameManager(EhaikerContext _context)
        {
            context =_context;
            
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="admin">管理员实体</param>
        /// <returns></returns>
        public void Add(MyGameLibs ImgItem)
        {

            if (HasAccounts(ImgItem.ItemName))
            {
                // _resp.Code = 0;
                // _resp.Message = "帐号已存在";
                return ;
            }
            else
            {
                context.GetView<MyGameLibs>().Add(ImgItem);
            }
        }
        public List<MyGameLibs> List()
        {
            return context.GetView<MyGameLibs>()?.ToList();
        }
        public MyGameLibs GetById(int id)
        {
            return context.GetView<MyGameLibs>().FirstOrDefault(r => r.GameID == id);
        }
        public void Update(MyGameLibs ImgItem)
        {
            context.Entry(ImgItem).State = EntityState.Modified;
        }
        public DbSet<MyGameLibs> GetDbSet()
        {
            return context.GetView<MyGameLibs>();
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
                context.GetView<MyGameLibs>().Remove(_admin);
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="administratorID">主键,主键</param>
        /// <returns></returns>
        public int DeleteArray(int[] administratorIDs)
        {

            if (context.GetView<MyGameLibs>().Count() <=0 )
            {
                return 0;
            }
            else
            {
                var idlist = administratorIDs;
                IQueryable<Object> queryEntity = context.GetView<MyGameLibs>().Where(r => idlist.Contains(r.GameID));
                foreach (MyGameLibs item in queryEntity)
                {
                    context.GetView<MyGameLibs>().Remove(item);
                }
                return context.SaveChanges();
            }
        }
        /// <summary>
        /// 查找
        /// </summary>
        /// <param name="accounts">帐号</param>
        /// <returns></returns>
        public MyGameLibs Find(string account)
        {
            return context.GetView<MyGameLibs>().FirstOrDefault(a => a.ItemName == account);
        }

        /// <summary>
        /// 帐号是否存在
        /// </summary>
        /// <param name="accounts">帐号</param>
        /// <returns></returns>
        public bool HasAccounts(string accounts)
        {
            return context.GetView<MyGameLibs>().FirstOrDefault(a => a.ItemName.ToUpper() == accounts.ToUpper()) != null;
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
        public Tuple<List<MyGameLibs>, int> PageList(int pageindex, int pagesize)
        {
            var query = context.GetView<MyGameLibs>()
                .AsQueryable();
            var count = query.Count();
            var pagecount = count % pagesize == 0 ? count / pagesize : count / pagesize + 1;
            var notes = query.OrderByDescending(r => r.GameID)
                .Skip((pageindex - 1) * pagesize)
                .Take(pagesize)
                .ToList();
            return new Tuple<List<MyGameLibs>, int>(notes, count);
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
