using ehaiker.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ehaiker.Managers
{
    public class KeFuChatRecordRepository : IRepository<ChatRecord>
    {
        private EhaikerContext context;
        public KeFuChatRecordRepository(EhaikerContext _context)
        {
            context = _context;

        }
        public void Add(ChatRecord note)
        {
            context.chatRecords.Add(note);

        }
        public ChatRecord GetById(int id)
        {
            return context.chatRecords.FirstOrDefault(r => r.kfUserId == id);
        }
        public List<ChatRecord> List()
        {

            return context.chatRecords.ToList();
        }
        public DbSet<ChatRecord> GetDbSet()
        {
            return context.chatRecords;
        }
        public void Update(ChatRecord note)
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
        public Tuple<List<ChatRecord>, int> PageList(int pageindex, int pagesize)
        {
            var query = context.chatRecords
                .AsQueryable();
            var count = query.Count();
            var pagecount = count % pagesize == 0 ? count / pagesize : count / pagesize + 1;
            var notes = query.OrderByDescending(r => r.RecordId)
                .Skip((pageindex - 1) * pagesize)
                .Take(pagesize)
                .ToList();
            return new Tuple<List<ChatRecord>, int>(notes, count);
        }
        public void Delete(int administratorID)
        {
            var _admin = GetById(administratorID);
            context.chatRecords.Remove(_admin);
        }
        public int Deletebat(int cumstomerId)
        {
            var cums = context.chatRecords.Where(r => r.customerId == cumstomerId);
            foreach (var t in cums)
            {
                context.chatRecords.Remove(t);
            }
            return SaveChanges();
        }
    }
}