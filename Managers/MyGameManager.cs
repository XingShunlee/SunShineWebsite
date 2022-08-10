using ehaiker.Models;
using ehaikerv202010.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ehaiker
{
    public class MyGameManager : IRepository<MyGameLibs>
    {
        private EhaikerContext context;
        public MyGameManager(EhaikerContext _context)
        {
            context = _context;

        }

        public void Add(MyGameLibs ImgItem)
        {

            if (!isHasRecord(ImgItem.GameID, ImgItem.UserGuid))
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
            return context.GetView<MyGameLibs>().FirstOrDefault(r => r.IndexID == id);
        }
        public MyGameLibs GetIdByUserId(int gameid, string userguid)
        {
            return context.GetView<MyGameLibs>().FirstOrDefault(r => r.GameID == gameid && r.UserGuid.ToUpper() == userguid.ToUpper());
        }
        public void Update(MyGameLibs ImgItem)
        {
            context.Entry(ImgItem).State = EntityState.Modified;
        }
        public DbSet<MyGameLibs> GetDbSet()
        {
            return context.GetView<MyGameLibs>();
        }

        public void Delete(int keyID)
        {
            var _admin = GetById(keyID);
            if (_admin != null)
            {
                context.GetView<MyGameLibs>().Remove(_admin);
            }
        }
        public void SafeDelete(int gameID, string userguid)
        {
            var _admin = GetIdByUserId(gameID, userguid);
            if (_admin != null)
            {
                context.GetView<MyGameLibs>().Remove(_admin);
            }
        }
        public int DeleteArray(int[] keyIDs)
        {

            if (context.GetView<MyGameLibs>().Count() <= 0)
            {
                return 0;
            }
            else
            {
                var idlist = keyIDs;
                IQueryable<Object> queryEntity = context.GetView<MyGameStrage>().Where(r => idlist.Contains(r.IndexID));
                foreach (MyGameLibs item in queryEntity)
                {
                    context.GetView<MyGameLibs>().Remove(item);
                }
                return context.SaveChanges();
            }
        }
        public bool isHasRecord(int gameid, string userguid)
        {
            return context.GetView<MyGameLibs>().FirstOrDefault(a => a.GameID == gameid && a.UserGuid.ToUpper() == userguid.ToUpper()) != null;
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
