using ehaiker.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ehaiker.Managers
{
    public class GameCommentManager: IRepository<CommentModel>
    {
        private EhaikerContext context;
        public GameCommentManager(EhaikerContext _context)
        {
            context = _context;
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="admin">管理员实体</param>
        /// <returns></returns>
        public void Add(CommentModel ImgItem)
        {

            if (HasAccounts(ImgItem.GameName))
            {
                // _resp.Code = 0;
                // _resp.Message = "帐号已存在";
                return;
            }
            else
            {
                context.CommentTable.Add(ImgItem);
            }
        }
        public List<CommentModel> List()
        {
            return context.CommentTable.ToList();
        }
        public CommentModel GetById(int gameStrateid)
        {
            return context.CommentTable.FirstOrDefault(r => r.GameStrateID == gameStrateid);
        }
        public CommentModel GetBycommentId(int commentid)
        {
            return context.CommentTable.FirstOrDefault(r => r.CommentID == commentid);
        }
        public void Update(CommentModel ImgItem)
        {
            context.Entry(ImgItem).State = EntityState.Modified;
        }
        public DbSet<CommentModel> GetDbSet()
        {
            return context.CommentTable;
        }
       
        public void Delete(int GamecommentID)
        {
            var _admin = GetBycommentId(GamecommentID);
             context.CommentTable.Remove(_admin);
            
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="administratorID">主键,主键</param>
        /// <returns></returns>
        public int DeleteArray(int[] commentIDs)
        {

            if (context.CommentTable.Count() <= 0)
            {
                return 0;
            }
            else
            {
                var idlist = commentIDs;
                IQueryable<Object> queryEntity = context.CommentTable.Where(r => idlist.Contains(r.CommentID));
                foreach (CommentModel item in queryEntity)
                {
                    context.CommentTable.Remove(item);
                }
                return context.SaveChanges();
            }
        }
        /// <summary>
        /// 查找
        /// </summary>
        /// <param name="accounts">帐号</param>
        /// <returns></returns>
        public CommentModel Find(string gamename)
        {
            return context.CommentTable.FirstOrDefault(a => a.GameName == gamename);
        }

        /// <summary>
        /// 帐号是否存在
        /// </summary>
        /// <param name="accounts">帐号</param>
        /// <returns></returns>
        public bool HasAccounts(string gamename)
        {
            return context.CommentTable.FirstOrDefault(a => a.GameName.ToUpper() == gamename.ToUpper()) != null;
        }

        /// <summary>
       


        //根据用户页面大小，起始，返回相应的内容
        public Tuple<List<CommentModel>, int> PageList(int pageindex, int pagesize)
        {
            var query = context.CommentTable
                .AsQueryable();
            var count = query.Count();
            var pagecount = count % pagesize == 0 ? count / pagesize : count / pagesize + 1;
            var notes = query.OrderByDescending(r => r.CreateTime)
                .Skip((pageindex - 1) * pagesize)
                .Take(pagesize)
                .ToList();
            return new Tuple<List<CommentModel>, int>(notes, count);
        }
        public int SaveChanges()
        {
           // try
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