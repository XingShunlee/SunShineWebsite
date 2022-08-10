using ehaiker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ehaiker
{
    public class PaybillRepository : IRepository<PaybillModel>
    {
        private EhaikerContext context;
        public PaybillRepository(EhaikerContext _context)
        {
            context = _context;
        }
        [HttpPost]
        public void Add(PaybillModel note)
        {
            context.PayBillModels.Add(note);

        }
        public PaybillModel GetById(int id)
        {
            return context.PayBillModels.FirstOrDefault(r => r.PayBillID == id);
        }
        public List<PaybillModel> List()
        {

            return context.PayBillModels.ToList();
        }
        public DbSet<PaybillModel> GetDbSet()
        {
            return context.PayBillModels;
        }
        public void Update(PaybillModel note)
        {
            context.Entry(note).State = EntityState.Modified;
        }
        public Tuple<List<PaybillModel>, int> PageList(int pageindex, int pagesize)
        {
            var query = context.PayBillModels
                .AsQueryable();
            var count = query.Count();
            var pagecount = count % pagesize == 0 ? count / pagesize : count / pagesize + 1;
            var notes = query.OrderByDescending(r => r.CreateTime)
                .Skip((pageindex - 1) * pagesize)
                .Take(pagesize)
                .ToList();
            return new Tuple<List<PaybillModel>, int>(notes, count);
        }
        public void Delete(int administratorID)
        {
            var _admin = GetById(administratorID);
            if (context.GameStrategs.Count() == 1)
            {
                return;
            }
            else
            {
                context.PayBillModels.Remove(_admin);

            }
        }
        public int SaveChanges()
        {
            //try
            // {
            return context.SaveChanges();
            //}
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
