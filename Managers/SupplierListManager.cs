using ehaiker.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ehaiker
{
    public class SupplierListManager : IRepository<SupplierModel>
    {
        private EhaikerContext context;
        public SupplierListManager(EhaikerContext _context)
        {
            context = _context;
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="admin">管理员实体</param>
        /// <returns></returns>
        public void Add(SupplierModel ImgItem)
        {

            if (HasAccounts(ImgItem.ItemName))
            {
                // _resp.Code = 0;
                // _resp.Message = "帐号已存在";
                return;
            }
            else
            {
                context.SupplierItems.Add(ImgItem);
            }
        }
        public List<SupplierModel> List()
        {
            return context.SupplierItems.ToList();
        }
        public SupplierModel GetById(int id)
        {
            return context.SupplierItems.FirstOrDefault(r => r.ItemID == id);
        }
        public void Update(SupplierModel ImgItem)
        {
            context.Entry(ImgItem).State = EntityState.Modified;
        }
        public DbSet<SupplierModel> GetDbSet()
        {
            return context.SupplierItems;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="administratorID">主键</param>
        /// <returns></returns>
        public void Delete(int administratorID)
        {
            var _admin = GetById(administratorID);
            if (context.SupplierItems.Count() == 1)
            {
                return;
            }
            else
            {
                context.SupplierItems.Remove(_admin);

            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="administratorID">主键,主键</param>
        /// <returns></returns>
        public int DeleteArray(int[] administratorIDs)
        {

            if (context.SupplierItems.Count() <= 0)
            {
                return 0;
            }
            else
            {
                var idlist = administratorIDs;
                IQueryable<Object> queryEntity = context.SupplierItems.Where(r => idlist.Contains(r.ItemID));
                foreach (SupplierModel item in queryEntity)
                {
                    context.SupplierItems.Remove(item);
                }
                return context.SaveChanges();
            }
        }
        /// <summary>
        /// 查找
        /// </summary>
        /// <param name="accounts">帐号</param>
        /// <returns></returns>
        public SupplierModel Find(string account)
        {
            return context.SupplierItems.FirstOrDefault(a => a.ItemName == account);
        }

        /// <summary>
        /// 帐号是否存在
        /// </summary>
        /// <param name="accounts">帐号</param>
        /// <returns></returns>
        public bool HasAccounts(string accounts)
        {
            return context.SupplierItems.FirstOrDefault(a => a.ItemName.ToUpper() == accounts.ToUpper()) != null;
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
                //  _admin.LoginIP = ip;
                //  _admin.LoginTime = time;
                Update(_admin);
                return SaveChanges();
            }
        }
        public int SaveChanges()
        {
            // try
            {
                return context.SaveChanges();
            }
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
        public Tuple<List<SupplierModel>, int> PageList(int pageindex, int pagesize)
        {
            var query = context.SupplierItems
                .AsQueryable();
            var count = query.Count();
            var pagecount = count % pagesize == 0 ? count / pagesize : count / pagesize + 1;
            var notes = query.OrderByDescending(r => r.ItemID)
                .Skip((pageindex - 1) * pagesize)
                .Take(pagesize)
                .ToList();
            return new Tuple<List<SupplierModel>, int>(notes, count);
        }
    }

}
