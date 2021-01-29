namespace ehaiker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GameStrategies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 1024),
                        Content = c.String(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        LastEditTime = c.DateTime(nullable: false),
                        GameId = c.Int(nullable: false),
                        Author = c.String(),
                        ReferAthor = c.String(),
                        Rank = c.Int(nullable: false),
                        toplevel = c.Int(nullable: false),
                        readers = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GameTypes",
                c => new
                    {
                        GameId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.GameId);
            
            CreateTable(
                "dbo.Administrators",
                c => new
                    {
                        AdministratorID = c.Int(nullable: false, identity: true),
                        Account = c.String(nullable: false, maxLength: 30),
                        Password = c.String(nullable: false, maxLength: 256),
                        LoginIP = c.String(),
                        LoginTime = c.DateTime(),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AdministratorID);
            
            CreateTable(
                "dbo.MemberShips",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Account = c.String(nullable: false, maxLength: 30),
                        Password = c.String(nullable: false, maxLength: 256),
                        LoginIP = c.String(),
                        LoginTime = c.DateTime(),
                        CreateTime = c.DateTime(nullable: false),
                        VIPLevel = c.Int(nullable: false),
                        Icon = c.String(),
                        UserName = c.String(),
                        MobilePhone = c.String(maxLength: 11),
                        SignCount = c.Int(nullable: false),
                        LastSignTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.GameItemModels",
                c => new
                    {
                        ItemID = c.Int(nullable: false, identity: true),
                        ItemName = c.String(),
                        ImgDescUri = c.String(),
                        ImgHoverUri = c.String(),
                        hrefUri = c.String(),
                        Ftag_chji = c.String(),
                        Ftag_fu = c.String(),
                        Ftag_xshi = c.String(),
                        TopLevel = c.Int(nullable: false),
                        jiangli = c.String(),
                        fanli = c.String(),
                        Gametype = c.Int(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ItemID);
            
            CreateTable(
                "dbo.HotItemModels",
                c => new
                    {
                        ItemID = c.Int(nullable: false, identity: true),
                        ItemName = c.String(),
                        ImgDescUri = c.String(),
                        ImgHoverUri = c.String(),
                        hrefUri = c.String(),
                        Ftag_chji = c.String(),
                        Ftag_fu = c.String(),
                        Ftag_xshi = c.String(),
                        TopLevel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ItemID);
            
            CreateTable(
                "dbo.SupplierModels",
                c => new
                    {
                        ItemID = c.Int(nullable: false, identity: true),
                        ItemName = c.String(),
                        ImgDescUri = c.String(),
                        ImgHoverUri = c.String(),
                        hrefUri = c.String(),
                    })
                .PrimaryKey(t => t.ItemID);
            
            CreateTable(
                "dbo.NewsModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 1024),
                        Content = c.String(nullable: false),
                        ReleaseTime = c.DateTime(nullable: false),
                        LastEditTime = c.DateTime(nullable: false),
                        NewsTypeId = c.Int(nullable: false),
                        Announcer = c.String(),
                        ReferAthor = c.String(),
                        Rank = c.Int(nullable: false),
                        toplevel = c.Int(nullable: false),
                        readers = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MemberShipInfomations",
                c => new
                    {
                        IndexId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        UMoney = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TMoney = c.Decimal(nullable: false, precision: 18, scale: 2),
                        isValid = c.Boolean(nullable: false),
                        isMailValid = c.Boolean(nullable: false),
                        isIdentityValid = c.Boolean(nullable: false),
                        IdentityCard = c.String(),
                    })
                .PrimaryKey(t => t.IndexId);
            
            CreateTable(
                "dbo.PaybillModels",
                c => new
                    {
                        PayBillID = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        PayForWhat = c.String(),
                        PayType = c.Int(nullable: false),
                        PayIdentity = c.String(),
                        PayState = c.Int(nullable: false),
                        PayValue = c.Int(nullable: false),
                        PayForDateTime = c.DateTime(nullable: false),
                        PayDeleteMask = c.Boolean(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PayBillID);
            
            CreateTable(
                "dbo.PaybillApproveModels",
                c => new
                    {
                        PayBillApproveID = c.Int(nullable: false, identity: true),
                        PayBillID = c.Int(nullable: false),
                        ApproveForWhat = c.String(),
                        PayType = c.Int(nullable: false),
                        PayState = c.Int(nullable: false),
                        PayForDateTime = c.DateTime(nullable: false),
                        ApproveDeleteMask = c.Boolean(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PayBillApproveID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PaybillApproveModels");
            DropTable("dbo.PaybillModels");
            DropTable("dbo.MemberShipInfomations");
            DropTable("dbo.NewsModels");
            DropTable("dbo.SupplierModels");
            DropTable("dbo.HotItemModels");
            DropTable("dbo.GameItemModels");
            DropTable("dbo.MemberShips");
            DropTable("dbo.Administrators");
            DropTable("dbo.GameTypes");
            DropTable("dbo.GameStrategies");
        }
    }
}
