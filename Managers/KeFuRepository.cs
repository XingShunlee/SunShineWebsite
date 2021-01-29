using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ehaiker.Models;
using System.Web.Http;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace ehaiker.Managers
{
    public class KeFuRepository : IRepository<KefuServiceStatus>
    {
        private EhaikerContext context;
        public KeFuRepository(EhaikerContext _context)
        {
            context = _context;
        }
        
        public void Add(KefuServiceStatus note)
        {
            context.kefu_StatusService.Add(note);
        }
        public KefuServiceStatus GetById(int id)
        {
            return context.kefu_StatusService.FirstOrDefault(r => r.kfUserId == id);
        }
        public List<KefuServiceStatus> List()
        {

            return context.kefu_StatusService.ToList();
        }
        public DbSet<KefuServiceStatus> GetDbSet()
        {
            return context.kefu_StatusService;
        }
        public void Update(KefuServiceStatus note)
        {
            context.Entry(note).State =EntityState.Modified;
           
        }
        public Tuple<List<KefuServiceStatus>, int> PageList(int pageindex, int pagesize)
        {
            var query = context.kefu_StatusService
                .AsQueryable();
            var count = query.Count();
            var pagecount = count % pagesize == 0 ? count / pagesize : count / pagesize + 1;
            var notes = query.OrderByDescending(r => r.isOnline)
                .Skip((pageindex - 1) * pagesize)
                .Take(pagesize)
                .ToList();
            return new Tuple<List<KefuServiceStatus>, int>(notes, count);
        }
        public void  Delete(int administratorID)
        {
            var _admin = GetById(administratorID);
            
                context.kefu_StatusService.Remove(_admin);
        }
        public KefuServiceStatus Find(string accounts)
        {
            return context.kefu_StatusService.FirstOrDefault(a => a.Account == accounts);
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