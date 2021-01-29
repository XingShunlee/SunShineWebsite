using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using ehaiker.Models;
using Microsoft.EntityFrameworkCore;
using ehaikerv202010.Models;

namespace ehaiker
{
    public class NewsesRepository: IRepository<NewsModel>
    {
        private EhaikerContext context;
        public NewsesRepository(EhaikerContext _context)
        {
            context = _context;
        }
        
        public void Add(NewsModel note)
        {
            context.WebNewses.Add(note);
            
        }
        public NewsModel GetById(int id)
        {
            return context.WebNewses.FirstOrDefault(r => r.Id == id);
        }
        public List<NewsModel> List()
        {

            return context.WebNewses.ToList();
        }
        public DbSet<NewsModel> GetDbSet()
        {
            return context.WebNewses;
        }
        public void Update(NewsModel note)
        {
            context.Entry(note).State = EntityState.Modified;
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
        public Tuple<List<NewsModel>, int> PageList(int pageindex, int pagesize)
        {
            var query = context.WebNewses
                .AsQueryable();
            var count = query.Count();
            var pagecount = count % pagesize == 0 ? count / pagesize : count / pagesize + 1;
            var notes = query.OrderByDescending(r => r.LastEditTime)
                .Skip((pageindex - 1) * pagesize)
                .Take(pagesize)
                .ToList();
            return new Tuple<List<NewsModel>, int>(notes, pagecount);
        }
        public void Delete(int administratorID)
        {
            var _admin = GetById(administratorID);
            if (context.GameStrategs.Count() == 1)
            {
                return ;
            }
            else
            {
                context.WebNewses.Remove(_admin);
               
            }
        }

    }
}
