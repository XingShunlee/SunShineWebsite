using ehaiker.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ehaiker
{
    public class MemberShipManager : IRepository<MemberShip>
    {
        private EhaikerContext context;
        public MemberShipManager(EhaikerContext _context)
        {
            context = _context;
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="admin">管理员实体</param>
        /// <returns></returns>
        public void Add(MemberShip user)
        {

            if (HasAccounts(user.Account))
            {
                // _resp.Code = 0;
                // _resp.Message = "帐号已存在";
                return;
            }
            else
            {
                context.MemShips.Add(user);

            }
        }
        public List<MemberShip> List()
        {
            return context.MemShips.ToList();
        }
        public DbSet<MemberShip> GetDbSet()
        {
            return context.MemShips;
        }
        public MemberShip GetById(int id)
        {
            return context.MemShips.FirstOrDefault(r => r.UserId == id);
        }
        public void Update(MemberShip note)
        {
            context.Entry(note).State = EntityState.Modified;
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="administratorID">主键</param>
        /// <param name="password">新密码【密文】</param>
        /// <returns></returns>
        public int ChangePassword(int administratorID, string password)
        {
            var _admin = GetById(administratorID);
            if (_admin == null)
            {
                return 0;
                // _resp.Message = "该主键的管理员不存在";
            }
            else
            {
                _admin.Password = password;
                Update(_admin);
                return SaveChanges();
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="administratorID">主键</param>
        /// <returns></returns>
        public void Delete(int administratorID)
        {
            var _admin = GetById(administratorID);
            if (context.MemShips.Count() == 1)
            {
                return;
            }
            else
            {
                context.MemShips.Remove(_admin);

            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="administratorID">主键,主键</param>
        /// <returns></returns>
        public int DeleteArray(int[] administratorIDs)
        {

            if (context.MemShips.Count() <= 0)
            {
                return 0;
            }
            else
            {
                var idlist = administratorIDs;
                IQueryable<Object> queryEntity = context.MemShips.Where(r => idlist.Contains(r.UserId));
                foreach (MemberShip item in queryEntity)
                {
                    context.MemShips.Remove(item);
                }
                return context.SaveChanges();
            }
        }
        public int SaveChanges()
        {
            //try
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
        /// <summary>
        /// 查找
        /// </summary>
        /// <param name="accounts">帐号</param>
        /// <returns></returns>
        public MemberShip Find(string account)
        {
            return context.MemShips.FirstOrDefault(a => a.Account == account);
        }

        /// <summary>
        /// 帐号是否存在
        /// </summary>
        /// <param name="accounts">帐号</param>
        /// <returns></returns>
        public bool HasAccounts(string accounts)
        {
            return context.MemShips.FirstOrDefault(a => a.Account.ToUpper() == accounts.ToUpper()) != null;
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

        /// <summary>
        /// 验证
        /// </summary>
        /// <param name="accounts">帐号</param>
        /// <param name="password">密码【密文】</param>
        /// <returns>Code:1-成功;2-帐号不存在;3-密码错误</returns>
        public int Verify(string accounts, string password)
        {
            var _admin = context.MemShips.FirstOrDefault(a => a.Account == accounts);
            if (_admin == null)
            {
                return 2;
                // _resp.Message = "帐号为:【" + accounts + "】的不存在";
            }
            else if (_admin.Password == password)
            {
                return 1;
                // _resp.Message = "验证通过";
            }
            else
            {
                return 3;
                // _resp.Message = "帐号密码错误";
            }
        }
        //根据用户页面大小，起始，返回相应的内容
        public Tuple<List<MemberShip>, int> PageList(int pageindex, int pagesize)
        {
            var query = context.MemShips
                .AsQueryable();
            var count = query.Count();
            var pagecount = count % pagesize == 0 ? count / pagesize : count / pagesize + 1;
            var notes = query.OrderByDescending(r => r.Password)
                .Skip((pageindex - 1) * pagesize)
                .Take(pagesize)
                .ToList();
            return new Tuple<List<MemberShip>, int>(notes, count);
        }
    }

}
