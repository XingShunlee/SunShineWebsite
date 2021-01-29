using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using ehaiker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ehaiker
{
    public class PaybillApproveRepository: IRepository<PaybillApproveModel>
    {
        private EhaikerContext context;
        public PaybillApproveRepository(EhaikerContext _context)
        {
            context = _context;
        }
        [HttpPost]
        public void Add(PaybillApproveModel note)
        {
            context.PayBillApproveModels.Add(note);
            
        }
        public PaybillApproveModel GetById(int id)
        {
            return context.PayBillApproveModels.FirstOrDefault(r => r.PayBillID == id);
        }
        public List<PaybillApproveModel> List()
        {

            return context.PayBillApproveModels.ToList();
        }
        public DbSet<PaybillApproveModel> GetDbSet()
        {
            return context.PayBillApproveModels;
        }
        public void Update(PaybillApproveModel note)
        {
            context.Entry(note).State = EntityState.Modified;
        }
        public Tuple<List<PaybillApproveModel>, int> PageList(int pageindex, int pagesize)
        {
            var query = context.PayBillApproveModels
                .AsQueryable();
            var count = query.Count();
            var pagecount = count % pagesize == 0 ? count / pagesize : count / pagesize + 1;
            var notes = query.OrderByDescending(r => r.CreateTime)
                .Skip((pageindex - 1) * pagesize)
                .Take(pagesize)
                .ToList();
            return new Tuple<List<PaybillApproveModel>, int>(notes, count);
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
                context.PayBillApproveModels.Remove(_admin);
               
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

    }
}
