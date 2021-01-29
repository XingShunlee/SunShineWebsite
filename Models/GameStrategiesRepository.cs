using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using ehaiker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ehaikerv202010.Models;

namespace ehaiker
{
    public class GameStrategiesRepository: IRepository<GameStrategies>
    {
        private EhaikerContext context;
        public GameStrategiesRepository(EhaikerContext _context)
        {
            context = _context;
        }

       
        [HttpPost]
        public void Add(GameStrategies note)
        {
            context.GameStrategs.Add(note);
           
        }
        public GameStrategies GetById(int id)
        {
            return context.GameStrategs.FirstOrDefault(r => r.Id == id);
        }
        public List<GameStrategies> List()
        {

            return context.GameStrategs.ToList();
        }
        public DbSet<GameStrategies> GetDbSet()
        {
            return context.GameStrategs;
        }
        public void Update(GameStrategies note)
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
        public Tuple<List<GameStrategies>, int> PageList(int pageindex, int pagesize)
        {
            var query = context.GameStrategs
                .AsQueryable();
            var count = query.Count();
            var pagecount = count % pagesize == 0 ? count / pagesize : count / pagesize + 1;
            var notes = query.OrderByDescending(r => r.CreateTime)
                .Skip((pageindex - 1) * pagesize)
                .Take(pagesize)
                .ToList();
            return new Tuple<List<GameStrategies>, int>(notes, pagecount);
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
                context.GameStrategs.Remove(_admin);
            }
        }

    }
}
