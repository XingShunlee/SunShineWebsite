using FormAuth.Models;
using FormAuth.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Configuration;
using ehaiker.Auth;

namespace FormAuth.DBServer
{
    public class UserServer 
    {
        protected string ConnStr;
        public UserServer(string connStr)
        {
            ConnStr = ConfigurationManager.ConnectionStrings[connStr].ConnectionString;
        }

      
        public Role GetRoleById(int roleId)
        {
            Role role = new Role();
            role.PList = new List<Permission>();
            string sql = string.Empty;
            int rId = 0;
            string roleName = string.Empty;
            sql = @"select r.Id rId,r.Name rName,p.Id pId,p.ControllerNo pCId,p.Controller Controller,p.ControllerName ConCnName,p.ActionNo pAId,p.ActionName pAName,p.ActionName ActCnName 
                    from  [dbo].[role] r  
                        left join[dbo].[RolePermission] rp on r.Id = rp.RoleId
                        left join[dbo].[Permission] p on rp.PerId = p.Id where r.id=@roleId";
            using (var conn = new SqlConnection(ConnStr))
            {
                using (var comm = new SqlCommand(sql, conn))
                {
                    comm.Parameters.AddWithValue("@roleId", roleId);
                    conn.Open();
                    using (var r = comm.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            rId = r["rId"];
                            roleName =r["rName"];
                            role.PList.Add(new Permission
                            {
                                Id = r["pId"],
                                ControllerNo = r["pCId"],
                                ControllerName =r["pCName"],
                                ActionNo = r["pAId"],
                                ActionName =r["pAName"],
                                Controller = r["Controller"],
                                Action = r["Action"]
                            });
                        }
                        role.Id = rId;
                        role.Name = roleName;
                    }
                }
            }
            return role;
        }
        public IList<User> GetAllUser()
        {
            string sql = string.Empty;
            IList<User> uList = new List<User>();
            sql = "select * from user where 1=1 ;";
            using (var conn = new SqlConnection(ConnStr))
            {
                using (var comm = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    using (var r = comm.ExecuteReader())
                    {
                        uList.Add(new User
                        {
                            Id = DBConvert.ToInt(r["id"]),
                            Name = DBConvert.ToString(r["name"]),
                            RoleId = DBConvert.ToInt(r["roleId"])
                        });
                    }
                }
            }
            return uList;
        }

        public IList<Role> GetAllRole()
        {
            string sql = string.Empty;
            IList<Role> uList = new List<Role>();
            sql = "select * from role where 1=1 ;";
            using (var conn = new SqlConnection(ConnStr))
            {
                using (var comm = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    using (var r = comm.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            uList.Add(new Role
                            {
                                Id = DBConvert.ToInt(r["id"]),
                                Name = DBConvert.ToString(r["name"]),
                                CnName = DBConvert.ToString(r["cnName"])
                            });
                        }
                    }
                }
            }
            return uList;
        }

        public IList<Permission> GetAllPermission()
        {
            string sql = string.Empty;
            IList<Permission> uList = new List<Permission>();
            sql = "select * from Permission where 1=1 ;";
            using (var conn = new SqlConnection(ConnStr))
            {
                using (var comm = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    using (var r = comm.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            uList.Add(new Permission
                            {
                                Id = DBConvert.ToInt(r["Id"]),
                                CId = DBConvert.ToInt(r["CId"]),
                                CName = DBConvert.ToString(r["CName"]),
                                AId = DBConvert.ToInt(r["AId"]),
                                AName = DBConvert.ToString(r["AName"]),
                                ConCnName = DBConvert.ToString(r["ConCnName"]),
                                ActCnName = DBConvert.ToString(r["ActCnName"])
                            });
                        }
                    }
                }
            }
            return uList;
        }

        public bool UpdateRolePer(Role role)
        {
            bool result = false;
            string sql = string.Empty;

            using (var conn = new SqlConnection(ConnStr))
            {
                SqlTransaction sT = null;
                try
                {
                    sql = "delete from rolePermission where 1=1 and roleId=@roleIdValue ";
                    conn.Open();
                    sT = conn.BeginTransaction();
                    using (var comm = new SqlCommand(sql, conn))
                    {
                        comm.ExecuteNonQuery();
                    }
                    StringBuilder sb = new StringBuilder();
                    foreach (var item in role.PList)
                    {
                        sql = "insert into rolePermission (roleId,perId) values(" + role.Id.ToString() + "," + item.Id.ToString() + "); ";
                        sb.Append(sql);
                    }

                    using (var comm = new SqlCommand(sb.ToString(), conn))
                    {
                        if (comm.ExecuteNonQuery() > 0)
                            result = true;
                        else
                            result = false;
                    }
                }
                catch (Exception ex)
                {
                    sT.Rollback();
                    result = false;
                }
            }
            return result;
        }

    }
}