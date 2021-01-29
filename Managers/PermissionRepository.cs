using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Remoting.Messaging;
using ehaiker.Models;
using System.Data.Entity.Validation;
using ehaiker.Auth;
using System.Data;

namespace ehaiker.Managers
{
    public class PermissionRepository: IRepository<Permission>
    {
        private EhaikerContext context;
     public PermissionRepository()
        {
            context = CallContext.GetData("DBEHaiker") as EhaikerContext;
            if (context == null)
            {
                context = new EhaikerContext();

                CallContext.SetData("DBEHaiker", context);
            }
        }
        
        public void Add(Permission note)
        {
            context.permissions.Add(note);
            
        }
        public Permission GetById(int id)
        {
            return context.permissions.FirstOrDefault(r => r.Id == id);
        }
        public List<Permission> List()
        {

            return context.permissions.ToList();
        }
        public System.Data.Entity.DbSet<Permission> GetDbSet()
        {
            return context.permissions;
        }
        public void Update(Permission note)
        {
            context.Entry(note).State = System.Data.Entity.EntityState.Modified;
        }
        public Tuple<List<Permission>, int> PageList(int pageindex, int pagesize)
        {
            var query = context.permissions
                .AsQueryable();
            var count = query.Count();
            var pagecount = count % pagesize == 0 ? count / pagesize : count / pagesize + 1;
            var notes = query.OrderByDescending(r => r.Id)
                .Skip((pageindex - 1) * pagesize)
                .Take(pagesize)
                .ToList();
            return new Tuple<List<Permission>, int>(notes, pagecount);
        }
        public Tuple<List<Permission>, int> PageList(int pageindex, int pagesize,int groupID)
        {
            var query = context.permissions.Where(x=>x.Id==groupID)
                .AsQueryable();
            var count = query.Count();
            var pagecount = count % pagesize == 0 ? count / pagesize : count / pagesize + 1;
            var notes = query.OrderByDescending(r => r.Id)
                .Skip((pageindex - 1) * pagesize)
                .Take(pagesize)
                .ToList();
            return new Tuple<List<Permission>, int>(notes, count);
        }
        public void Delete(int ID)
        {
            var _admin = GetById(ID);
          
                context.permissions.Remove(_admin);
         }
        public int SaveChanges()
        {
            try
            {
                return context.SaveChanges();
            }
            catch (DbEntityValidationException exception)
            {
                var errorMessages =
                    exception.EntityValidationErrors
                        .SelectMany(validationResult => validationResult.ValidationErrors)
                        .Select(m => m.ErrorMessage);

                var fullErrorMessage = string.Join(", ", errorMessages);
                //记录日志
                //Log.Error(fullErrorMessage);
                var exceptionMessage = string.Concat(exception.Message, " 验证异常消息是：", fullErrorMessage);

                throw new DbEntityValidationException(exceptionMessage, exception.EntityValidationErrors);
            }
        }
    }
}