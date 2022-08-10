using ehaiker.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ehaiker
{
    public class GameTypeRepository : IRepository<GameType>
    {
        private EhaikerContext context;
        public GameTypeRepository(EhaikerContext _context)
        {
            context = _context;

        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="admin">管理员实体</param>
        /// <returns></returns>
        public void Add(GameType ImgItem)
        {

            if (HasAccounts(ImgItem.Name))
            {
                // _resp.Code = 0;
                // _resp.Message = "帐号已存在";
                return;
            }
            else
            {
                context.GameTypes.Add(ImgItem);
            }
        }
        public List<GameType> List()
        {
            return context.GameTypes.ToList();
        }
        public GameType GetById(int id)
        {
            return context.GameTypes.FirstOrDefault(r => r.GameId == id);
        }
        public void Update(GameType ImgItem)
        {
            context.Entry(ImgItem).State = EntityState.Modified;
        }
        public DbSet<GameType> GetDbSet()
        {
            return context.GameTypes;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="administratorID">主键</param>
        /// <returns></returns>
        public void Delete(int administratorID)
        {
            var _admin = GetById(administratorID);
            if (context.GameTypes.Count() == 1)
            {
                return;
            }
            else
            {
                context.GameTypes.Remove(_admin);

            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="administratorID">主键,主键</param>
        /// <returns></returns>
        public int DeleteArray(int[] administratorIDs)
        {

            if (context.GameTypes.Count() <= 0)
            {
                return 0;
            }
            else
            {
                var idlist = administratorIDs;
                IQueryable<Object> queryEntity = context.GameLists.Where(r => idlist.Contains(r.ItemID));
                foreach (GameType item in queryEntity)
                {
                    context.GameTypes.Remove(item);
                }
                return context.SaveChanges();
            }
        }
        /// <summary>
        /// 查找
        /// </summary>
        /// <param name="accounts">帐号</param>
        /// <returns></returns>
        public GameType Find(string account)
        {
            return context.GameTypes.FirstOrDefault(a => a.Name == account);
        }

        /// <summary>
        /// 帐号是否存在
        /// </summary>
        /// <param name="accounts">帐号</param>
        /// <returns></returns>
        public bool HasAccounts(string accounts)
        {
            return context.GameTypes.FirstOrDefault(a => a.Name.ToUpper() == accounts.ToUpper()) != null;
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
        public int SaveChanges()
        {
            // try
            // {
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
        //根据用户页面大小，起始，返回相应的内容
        public Tuple<List<GameType>, int> PageList(int pageindex, int pagesize)
        {
            var query = context.GameTypes
                .AsQueryable();
            var count = query.Count();
            var pagecount = count % pagesize == 0 ? count / pagesize : count / pagesize + 1;
            var notes = query.OrderByDescending(r => r.GameId)
                .Skip((pageindex - 1) * pagesize)
                .Take(pagesize)
                .ToList();
            return new Tuple<List<GameType>, int>(notes, count);
        }
    }
}
