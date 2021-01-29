namespace ehaiker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CommentModels",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        GameID = c.Int(nullable: false),
                        GameName = c.String(),
                        UserName = c.String(),
                        UserId = c.String(),
                        comment = c.String(),
                        CreateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.CommentID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CommentModels");
        }
    }
}
