using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ehaiker.Models
{
    //泛型数据库操作
    interface IRepository<T> where T : class, new()
    {
        T GetById(int id);
        List<T> List();
        void Add(T info);
        void Update(T note);
        void Delete(int ID);
        int SaveChanges();
        DbSet<T> GetDbSet();
        Tuple<List<T>, int> PageList(int pageindex, int pagesize);

    }
}
