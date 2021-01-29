namespace ehaiker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KefuServiceStatus : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.serviceUsers",
                c => new
                {
                    kfUserId = c.Int(nullable: false, identity: true),
                    Account = c.String(nullable: false, maxLength: 30),
                    UserName = c.String(),
                    Password = c.String(nullable: false, maxLength: 256),
                    isOnline = c.Boolean(nullable: false),
                    CurrentPeople = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.kfUserId);

           

           
        }
        
        public override void Down()
        {
        }
    }
}
