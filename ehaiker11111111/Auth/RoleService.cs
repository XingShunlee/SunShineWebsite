using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Remoting.Messaging;
using System.Data.Entity.Validation;
using System.Data;

namespace ehaiker.Auth
{
    public class RoleService
    {
         private EhaikerContext context;
         public RoleService()
        {
            context = CallContext.GetData("DBEHaiker") as EhaikerContext;
            if (context == null)
            {
                context = new EhaikerContext();

                CallContext.SetData("DBEHaiker", context);
            }
        }
        /// <summary>
        /// 将Persion存入数据库
        /// </summary>
        /// <param name="actionNo"></param>
        /// <param name="controllerNo"></param>
        /// <param name="actionName"></param>
        /// <param name="controllerName"></param>
        /// <param name="controller"></param>
        /// <param name="action"></param>
         public void CreatePermissions(int actionNo, int controllerNo, string actionName, string controllerName, string controller, string action, bool _isGet, bool bShowInManagerBar)
        {
            Permission miss = new Permission
            {
                Action =action,
            ActionNo = actionNo,
            ControllerNo =controllerNo,
            Controller =controller,
            ControllerName =controllerName,
            ActionName =actionName,
            isGet=_isGet,
            ShowInManagerBar = bShowInManagerBar
            };
            context.permissions.Add(miss);
            try
            {
                context.SaveChanges();
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
        /// <summary>
        /// 获取所有已经定义的权限列表
        /// </summary>
        /// <returns></returns>
         public Tuple<List<Permission>, int> GetPermissionPageList(int page, int rows)
        {
            var query = context.permissions.AsEnumerable();
            var count = query.Count();
            var pagecount = count % rows == 0 ? count / rows : count / rows + 1;
            var notes = query.OrderByDescending(r => r.Id)
                .Skip((page - 1) * rows)
                .Take(rows)
                .ToList();
            return new Tuple<List<Permission>, int>(notes, count);
        }
        public List<Permission> GetPermissions()
        {
            var query = context.permissions.AsEnumerable();
           
            return query.OrderBy(r => r.ControllerNo).ToList();
        }
        ///获取所有可以分配的组资源
        ///
        public IList<RolePermissionBinder> GetCanAssignGroup(int myGroupId)
        {
            return context.RoleBinderTable.Where(r=>r.Id>myGroupId).ToList();
        }
        public IList<RolePermissionBinder> GetAllGroup()
        {
            return context.RoleBinderTable.ToList();
        }
        /// <summary>
        /// 增加新角色
        /// </summary>
        /// <param name="roleInfo"></param>
        /// <returns></returns>
        public int AddRole(RolePermissionBinder roleInfo)
        {
            context.RoleBinderTable.Add(roleInfo);
            context.SaveChanges();
            var _admin = context.RoleBinderTable.FirstOrDefault(a => a.Name == roleInfo.Name);
            return _admin.Id;
        }
        public int saveRolePermission(int RoleId, string ids)
        {
            try
            {
                var admin = context.RoleBinderTable.Where(r => r.Id == RoleId).ToList();
                if (admin[0] != null)
                {
                    admin[0].Permissions = ids;
                    context.Entry(admin[0]).State = System.Data.Entity.EntityState.Modified;
                    return context.SaveChanges();
                }
                return 0;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        ///由组ID获取权限
        public Tuple<List<Permission>, int> GetGroupPermissionPageList(int page, int rows, int groupId)
        {
            try
            {
                var rp = context.RoleBinderTable.Where(r => r.Id == groupId).AsEnumerable().ToList();
                var arr = rp[0].Permissions.Split(',');
                int[] inumarr;
                inumarr = Array.ConvertAll<string, int>(arr, s => int.Parse(s));
                var query = from ps in context.permissions
                            where (inumarr.Contains(ps.Id))
                            select ps;
                var count = query.Count();
                var pagecount = count % rows == 0 ? count /rows : count / rows + 1;
                var notes = query.OrderByDescending(r => r.Id)
                    .Skip((page - 1) * rows)
                    .Take(rows)
                    .ToList();
                return new Tuple<List<Permission>, int>(notes, count);
            }
            catch (Exception e)
            {
                return new Tuple<List<Permission>, int>(new List<Permission>(),0);
            }
        }
         public List<Permission> GetGroupPermissions( int groupId)
         {
             try
             {
                 var rp = context.RoleBinderTable.Where(r => r.Id == groupId).AsEnumerable().ToList();
                 var arr = rp[0].Permissions.Split(',');
                 int[] inumarr;
                 inumarr = Array.ConvertAll<string, int>(arr, s => int.Parse(s));
                 var query = from ps in context.permissions
                             where (inumarr.Contains(ps.Id))
                             select ps;
                
                 return query.OrderBy(r => r.ControllerNo).ToList();
             }
             catch (Exception e)
             {
                 return new List<Permission>();
             }
         }
        //获取个人权限
         public List<Permission> GetPermissionById(int privatePermissionId)
         {
             try
             {
                 var rp = context.MemShips.Where(r => r.UserId == privatePermissionId).AsEnumerable().ToList();
                 var arr = rp[0].sPermission.Split(',');
                 int[] inumarr;
                 inumarr = Array.ConvertAll<string, int>(arr, s => int.Parse(s));
                 var query = from ps in context.permissions
                             where (inumarr.Contains(ps.Id))
                             select ps;
                 ;
                 return query .ToList() as List<Permission>;
             }
             catch (Exception e)
             {
                 return new List<Permission>();
             }
         }
        //获取管理员、客服等工作人员权限【现在会员与网站工作人员是分开的，但是权限认证是统一的】
         public List<Permission> GetSitePermission(int privatePermissionId)
         {
             try
             {
                 var rp = context.Admin.Where(r => r.AdministratorID == privatePermissionId).AsEnumerable().ToList();
                 var arr = rp[0].sPermission.Split(',');
                 int[] inumarr;
                 inumarr = Array.ConvertAll<string, int>(arr, s => int.Parse(s));
                 var query = from ps in context.permissions
                             where (inumarr.Contains(ps.Id))
                             select ps;
                 ;
                 return query.ToList() as List<Permission>;
             }
             catch (Exception e)
             {
                 return new List<Permission>();
             }
         }
        public int saveSitePermission(int userId,string ids)
        {
            try{
                var admin = context.Admin.Where(r=>r.AdministratorID == userId).ToList();
                if(admin[0] != null)
                {
                    admin[0].sPermission=ids;
                    context.Entry(admin[0]).State = System.Data.Entity.EntityState.Modified;
                    return context.SaveChanges();
                }
                return 0;
            }catch(Exception e)
            {
                return 0;
            }
        }
         public List<Administrator> GetSitePerson(int GroupId)
         {
             try
             {
                 return context.Admin.Where(r => r.GroupId > GroupId).ToList().Select(r=>new Administrator{AdministratorID =r.AdministratorID,Account=r.Account}).ToList();
                 
             }
             catch (Exception e)
             {
                 return new List<Administrator>();
             }
         }
        
        //获取格式化的菜单
         public List<MenuItem> GetFormatMenu(List<Permission> permissions)
         {
             List<MenuItem> ls = new List<MenuItem>();
             var a =
             permissions.Where(x => x.isGet == true).GroupBy(x => x.ControllerNo).Select(x => x.First()).ToArray();//获取非重复项
             foreach (var b in a)
             {
                 MenuItem it = new MenuItem();
                 it.MenuString = b.ControllerName;
                 it.items = permissions.Where(x => x.ControllerNo == b.ControllerNo).ToList();
                 ls.Add(it);
             }
             return ls;
         }
        //获取管理员菜单
         public List<MenuItem> GetFormatMgrMenu(List<Permission> permissions)
         {
             List<MenuItem> ls = new List<MenuItem>();
             var a =
             permissions.Where(x=>x.ShowInManagerBar==true).GroupBy(x => x.ControllerNo).Select(x => x.First()).ToArray();//获取非重复项
             foreach (var b in a)
             {
                 MenuItem it = new MenuItem();
                 it.MenuString = b.ControllerName;
                 it.items = permissions.Where(x => x.ControllerNo == b.ControllerNo &&x.ShowInManagerBar==true ).ToList();
                 ls.Add(it);
             }
             return ls;
         }
    }
}