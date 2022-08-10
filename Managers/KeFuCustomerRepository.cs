using ehaiker.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ehaiker.Managers
{
    public class KeFuCustomerRepository : IRepository<Customer>
    {
        private EhaikerContext context;
        public KeFuCustomerRepository(EhaikerContext _context)
        {
            context = _context;

        }
        public void Add(Customer note)
        {
            context.kefu_customers.Add(note);
        }
        public Customer GetById(int id)
        {
            return context.kefu_customers.AsNoTracking().FirstOrDefault(r => r.customerId == id);
        }
        public List<Customer> List()
        {

            return context.kefu_customers.ToList();
        }
        public DbSet<Customer> GetDbSet()
        {
            return context.kefu_customers;
        }
        public void Update(Customer note)
        {
            context.Entry(note).State = EntityState.Modified;
        }
        public Tuple<List<Customer>, int> PageList(int pageindex, int pagesize)
        {
            var query = context.kefu_customers
                .AsQueryable();
            var count = query.Count();
            var pagecount = count % pagesize == 0 ? count / pagesize : count / pagesize + 1;
            var notes = query.OrderByDescending(r => r.customerId)
                .Skip((pageindex - 1) * pagesize)
                .Take(pagesize)
                .ToList();
            return new Tuple<List<Customer>, int>(notes, count);
        }
        public void Delete(int administratorID)
        {
            var _admin = GetById(administratorID);
            context.kefu_customers.Remove(_admin);
        }
        public int Deletebat(int cumstomerId)
        {
            var cums = context.kefu_customers.Where(r => r.customerId == cumstomerId).ToList();
            foreach (var t in cums)
            {
                context.kefu_customers.Remove(t);
            }
            return SaveChanges();
        }
        public int SaveChanges()
        {
            //try
            //{
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