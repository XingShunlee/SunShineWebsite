using ehaiker.Models;
using ehaikerv202010.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ehaiker
{
    public class MyGameStragesManager : IRepository<MyGameStrage>
    {
        private EhaikerContext context;
        public MyGameStragesManager(EhaikerContext _context)
        {
            context = _context;

        }

        public void Add(MyGameStrage ImgItem)
        {
            if (!isHasRecord(ImgItem.GameID, ImgItem.UserGuid))
                context.GetView<MyGameStrage>().Add(ImgItem);
        }
        public List<MyGameStrage> List()
        {
            return context.GetView<MyGameStrage>()?.ToList();
        }
        public MyGameStrage GetById(int id)
        {
            return context.GetView<MyGameStrage>().FirstOrDefault(r => r.IndexID == id);
        }
        public void Update(MyGameStrage ImgItem)
        {
            context.Entry(ImgItem).State = EntityState.Modified;
        }
        public DbSet<MyGameStrage> GetDbSet()
        {
            return context.GetView<MyGameStrage>();
        }

        public void Delete(int keyID)
        {
            var _admin = GetById(keyID);
            if (_admin != null)
            {
                context.GetView<MyGameStrage>().Remove(_admin);
            }
        }
        public void SafeDelete(int keyID, string userguid)
        {
            var _admin = GetById(keyID);
            if (_admin != null && _admin.UserGuid.ToUpper() == userguid.ToUpper())
            {
                context.GetView<MyGameStrage>().Remove(_admin);
            }
        }
        public int DeleteArray(int[] keyIDs)
        {

            if (context.GetView<MyGameStrage>().Count() <= 0)
            {
                return 0;
            }
            else
            {
                var idlist = keyIDs;
                IQueryable<Object> queryEntity = context.GetView<MyGameStrage>().Where(r => idlist.Contains(r.IndexID));
                foreach (MyGameStrage item in queryEntity)
                {
                    context.GetView<MyGameStrage>().Remove(item);
                }
                return context.SaveChanges();
            }
        }

        public bool isHasRecord(int gameid, string userguid)
        {
            return context.GetView<MyGameStrage>().FirstOrDefault(a => a.GameID == gameid && a.UserGuid.ToUpper() == userguid.ToUpper()) != null;
        }

        //根据用户页面大小，起始，返回相应的内容
        public Tuple<List<MyGameStrage>, int> PageList(int pageindex, int pagesize)
        {
            var query = context.GetView<MyGameStrage>()
                .AsQueryable();
            var count = query.Count();
            var pagecount = count % pagesize == 0 ? count / pagesize : count / pagesize + 1;
            var notes = query.OrderByDescending(r => r.GameID)
                .Skip((pageindex - 1) * pagesize)
                .Take(pagesize)
                .ToList();
            return new Tuple<List<MyGameStrage>, int>(notes, count);
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
