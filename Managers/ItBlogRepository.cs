using ehaiker.Models;
using ehaikerv202010.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ehaiker
{
    public class ItBlogRepository
    {
        private EhaikerContext context;
        public ItBlogRepository(EhaikerContext _context)
        {
            context = _context;
        }


        [HttpPost]
        public void Add(ItBlogModel note)
        {
            context.ItBlogSets.Add(note);

        }
        public ItBlogModel GetById(int id)
        {
            return context.ItBlogSets.FirstOrDefault(r => r.Id == id);
        }
        public List<ItBlogModel> List()
        {

            return context.ItBlogSets.ToList();
        }
        public DbSet<ItBlogModel> GetDbSet()
        {
            return context.ItBlogSets;
        }
        public void Update(ItBlogModel note)
        {
            context.Entry(note).State = EntityState.Modified;
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
        public Tuple<List<ItBlogModel>, int> PageList(int pageindex, int pagesize)
        {
            var query = context.ItBlogSets
                .AsQueryable();
            var count = query.Count();
            var pagecount = count % pagesize == 0 ? count / pagesize : count / pagesize + 1;
            var notes = query.OrderByDescending(r => r.CreateTime)
                .Skip((pageindex - 1) * pagesize)
                .Take(pagesize)
                .ToList();
            return new Tuple<List<ItBlogModel>, int>(notes, pagecount);
        }
        public void Delete(int ID)
        {
            var _admin = GetById(ID);
            if (context.ItBlogSets.Count() < 1)
            {
                return;
            }
            else
            {
                context.ItBlogSets.Remove(_admin);
            }
        }

    }
}
