using ehaiker;
using ehaiker.Auth;
using ehaikerv202010.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ehaikerv202010.helpers
{
    public class permissionHelper
    {
        public static void InitPermissionOnce(EhaikerContext _cont)
        {
            Assembly.GetEntryAssembly()
        .GetTypes()
        .AsEnumerable()
        .Where(type => typeof(Controller).IsAssignableFrom(type))
        .ToList()
        .ForEach(d =>
        {
            var memberactions = d.GetMethods(BindingFlags.DeclaredOnly|BindingFlags.Public|
                BindingFlags.Instance|BindingFlags.NonPublic);
           
            foreach (var item in memberactions) //get all the memberfuctions
            {
                //get customer properties
                var customAttributes = item.GetCustomAttributes<PermissionControlAttribute>();
                
                foreach (var attr in customAttributes)
                {
                    Permission ps = new Permission();
                    ps.Controller = d.Name;
                    ps.Action = item.Name;
                    ps.ChineseActionName = attr.ChineseActionName;
                    ps.Description = attr.Description;
                    ps.GlobalNo = attr.GlobalNo;
                    ps.isGet = attr.isGet;
                    ps.ShowInManagerBar = attr.ShowInManagerBar;
                    ps.VisitLevel = attr.VisitLevel;
                    _cont.PermissionTable.Add(ps);
                }
                
            }
        });
            _cont.SaveChanges(); 
        }
    }
}
