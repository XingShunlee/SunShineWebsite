namespace ehaiker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ehaiker : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GameModels",
                c => new
                    {
                        ItemID = c.Int(nullable: false, identity: true),
                        ItemName = c.String(),
                        ImgDescUri = c.String(),
                        ImgHoverUri = c.String(),
                        targetUri = c.String(),
                        supporter = c.String(),
                        producer = c.String(),
                        resourcefrom = c.String(),
                        MineTime = c.DateTime(nullable: false),
                        TopLevel = c.Int(nullable: false),
                        grade = c.Single(nullable: false),
                        Gametype = c.Int(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ItemID);
            
            DropTable("dbo.GameItemModels");
            DropTable("dbo.HotItemModels");
        }
        
        public override void Down()
        {
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
            
            DropTable("dbo.GameModels");
        }
    }
}
