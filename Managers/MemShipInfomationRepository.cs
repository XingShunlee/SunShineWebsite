using ehaiker.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ehaiker
{
    public class MemberShipInfomationRepository : IRepository<MemberShipInfomation>
    {
        private EhaikerContext context;
        public MemberShipInfomationRepository(EhaikerContext _context)
        {
            context = _context;
        }
        public void Add(MemberShipInfomation note)
        {
            context.MemberShipInfomation.Add(note);

        }
        public MemberShipInfomation GetById(int indexId)
        {
            return context.MemberShipInfomation.FirstOrDefault(r => r.IndexId == indexId);
        }
        public MemberShipInfomation GetByUserId(string userguid)
        {
            return context.MemberShipInfomation.FirstOrDefault(r => r.UserGuid == userguid);
        }
        public List<MemberShipInfomation> List()
        {
            return context.MemberShipInfomation.ToList();
        }
        public DbSet<MemberShipInfomation> GetDbSet()
        {
            return context.MemberShipInfomation;
        }
        public void Update(MemberShipInfomation note)
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
        public Tuple<List<MemberShipInfomation>, int> PageList(int pageindex, int pagesize)
        {
            var query = context.MemberShipInfomation
                .AsQueryable();
            var count = query.Count();
            var pagecount = count % pagesize == 0 ? count / pagesize : count / pagesize + 1;
            var notes = query.OrderByDescending(r => r.IndexId)
                .Skip((pageindex - 1) * pagesize)
                .Take(pagesize)
                .ToList();
            return new Tuple<List<MemberShipInfomation>, int>(notes, count);
        }
        public void Delete(int administratorID)
        {
            var _admin = GetById(administratorID);
            if (_admin != null)
            {
                context.MemberShipInfomation.Remove(_admin);
            }
        }

    }
}
