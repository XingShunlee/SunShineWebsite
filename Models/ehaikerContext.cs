using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ehaikerv202010.Models;
using Microsoft.EntityFrameworkCore;
using ehaiker.Models;
using ehaiker.Auth;
using ehaikerv202010.helpers;

namespace ehaiker
{
    public class EhaikerContext : DbContext
    {
        public EhaikerContext(DbContextOptions<EhaikerContext> options)
            : base(options)
        {
           
            if (Database.EnsureCreated())
            {
                //增加默认类型和管理员
                AdministratorManager adminManager = new AdministratorManager(this);
                Administrator loginViewModel = new Administrator();
                loginViewModel.Account = "Admin";
                loginViewModel.Password = Security.Sha256("www.ehaiker.com");
                loginViewModel.CreateTime = DateTime.Now;
                var _response = adminManager.Find(loginViewModel.Account);
                if (_response == null)
                {
                    adminManager.Add(loginViewModel);
                    adminManager.SaveChanges();
                }
                //
                GameTypeRepository GametypeMgr = new GameTypeRepository(this);
                GameType gamemedia = new GameType();
                gamemedia.Name = "WEB";
                GametypeMgr.Add(gamemedia);
                GametypeMgr.SaveChanges();
                //
                gamemedia = null;
                gamemedia = new GameType();
                gamemedia.Name = "APP";
                GametypeMgr.Add(gamemedia);
                GametypeMgr.SaveChanges();
                //
                gamemedia = null;
                gamemedia = new GameType();
                gamemedia.Name = "PC";
                GametypeMgr.Add(gamemedia);
                GametypeMgr.SaveChanges();
                //auto generator the permissions from actions for the first time
                permissionHelper.InitPermissionOnce(this);

            }
           
        }
        //每个DbSet代表一张表
        public DbSet<GameStrategies> GameStrategs { set; get; }//游戏攻略
        public DbSet<GameType> GameTypes { set; get; }//游戏类型
        public DbSet<Administrator> Admin { set; get; }
        public DbSet<MemberShip> MemShips { set; get; }//会员表
        public DbSet<GameModel> GameLists { set; get; }//游戏项目表
        public DbSet<SupplierModel> SupplierItems { set; get; }//供应商表
        public DbSet<NewsModel> WebNewses { set; get; }//网站新闻
        public DbSet<MemberShipInfomation> MemberShipInfomation { set; get; }
        public DbSet<PaybillModel> PayBillModels { set; get; }//账单
        public DbSet<PaybillApproveModel> PayBillApproveModels { set; get; }//账单
        //
        public DbSet<KefuServiceStatus> kefu_StatusService { set; get; }//客服
        public DbSet<Customer> kefu_customers { set; get; }//客服用户
        public DbSet<ChatRecord> chatRecords { set; get; }//信息记录
        //权限表
        public DbSet<Permission> PermissionTable { set; get; }
        public DbSet<Role> RoleTable { set; get; }//角色表
        public DbSet<RolePermissionBinder> RoleBinderTable { set; get; }//角色权限绑定表
        public DbSet<Group> GroupTable { set; get; }//角色表
        public DbSet<GroupPermissionBinder> GroupBinderTable { set; get; }//组权限绑定表
        //評論表
        public DbSet<CommentModel> CommentTable { set; get; }
        public DbSet<MyGameLibs> MyGames { set; get; }
        public DbSet<MyGameStrage> MyGameStrages { set; get; }
        public DbSet<T> GetView<T>() where T:class
        {
            switch(typeof(T).Name)
            {
                case "GameStrategies":
                    return GameStrategs as DbSet<T>;
                case "GameType":
                    return GameTypes as DbSet<T>;
                case "Administrator":
                    return Admin as DbSet<T>;
                case "MemberShip":
                    return MemShips as DbSet<T>;
                case "GameModel":
                    return GameLists as DbSet<T>;
                case "SupplierModel":
                    return SupplierItems as DbSet<T>;
                case "NewsModel":
                    return WebNewses as DbSet<T>;
                case "MemberShipInfomation":
                    return MemberShipInfomation as DbSet<T>;
                case "PaybillModel":
                    return PayBillModels as DbSet<T>;
                case "PaybillApproveModel":
                    return PayBillApproveModels as DbSet<T>;
                case "KefuServiceStatus":
                    return kefu_StatusService as DbSet<T>;
                case "Customer":
                    return kefu_customers as DbSet<T>;
                case "ChatRecord":
                    return chatRecords as DbSet<T>;
                case "CommentModel":
                    return CommentTable as DbSet<T>;
                case "MyGameLibs":
                    return MyGames as DbSet<T>;
                case "MyGameStrage":
                    return MyGameStrages as DbSet<T>;
                case "Permission":
                    return PermissionTable as DbSet<T>;
                case "RolePermissionBinder":
                    return RoleBinderTable as DbSet<T>;
                case "Role":
                    return RoleTable as DbSet<T>;
                case "GroupPermissionBinder":
                    return RoleBinderTable as DbSet<T>;
                case "Group":
                    return GroupTable as DbSet<T>;
                default:
                    return null;
            }
            }
    }
   
   
}