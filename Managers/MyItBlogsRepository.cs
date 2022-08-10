using ehaiker;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ehaikerv202010.Models
{
    public class MyItBlogsManager 
    {
        private EhaikerContext context;
        public MyItBlogsManager(EhaikerContext _context)
        {
            context = _context;

        }

        public void Add(MyItBlogModel ImgItem)
        {
            if (!isHasRecord(ImgItem.BlogID, ImgItem.UserGuid))
                context.GetView<MyItBlogModel>().Add(ImgItem);
        }
        public List<MyItBlogModel> List()
        {
            return context.GetView<MyItBlogModel>()?.ToList();
        }
        public MyItBlogModel GetById(int id)
        {
            return context.GetView<MyItBlogModel>().FirstOrDefault(r => r.IndexID == id);
        }
        public void Update(MyItBlogModel ImgItem)
        {
            context.Entry(ImgItem).State = EntityState.Modified;
        }
        public DbSet<MyItBlogModel> GetDbSet()
        {
            return context.GetView<MyItBlogModel>();
        }

        public void Delete(int keyID)
        {
            var _admin = GetById(keyID);
            if (_admin != null)
            {
                context.GetView<MyItBlogModel>().Remove(_admin);
            }
        }
        public void SafeDelete(int keyID, string userguid)
        {
            var _admin = GetById(keyID);
            if (_admin != null && _admin.UserGuid.ToUpper() == userguid.ToUpper())
            {
                context.GetView<MyItBlogModel>().Remove(_admin);
            }
        }
        public int DeleteArray(int[] keyIDs)
        {

            if (context.GetView<MyItBlogModel>().Count() <= 0)
            {
                return 0;
            }
            else
            {
                var idlist = keyIDs;
                IQueryable<Object> queryEntity = context.GetView<MyItBlogModel>().Where(r => idlist.Contains(r.IndexID));
                foreach (MyItBlogModel item in queryEntity)
                {
                    context.GetView<MyItBlogModel>().Remove(item);
                }
                return context.SaveChanges();
            }
        }

        public bool isHasRecord(int gameid, string userguid)
        {
            return context.GetView<MyItBlogModel>().FirstOrDefault(a => a.BlogID == gameid && a.UserGuid.ToUpper() == userguid.ToUpper()) != null;
        }

        //根据用户页面大小，起始，返回相应的内容
        public Tuple<List<MyItBlogModel>, int> PageList(int pageindex, int pagesize)
        {
            var query = context.GetView<MyItBlogModel>()
                .AsQueryable();
            var count = query.Count();
            var pagecount = count % pagesize == 0 ? count / pagesize : count / pagesize + 1;
            var notes = query.OrderByDescending(r => r.BlogID)
                .Skip((pageindex - 1) * pagesize)
                .Take(pagesize)
                .ToList();
            return new Tuple<List<MyItBlogModel>, int>(notes, count);
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
