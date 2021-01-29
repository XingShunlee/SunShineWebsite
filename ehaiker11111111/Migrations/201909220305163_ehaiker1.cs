namespace ehaiker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ehaiker1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GameModels", "gameDescription", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.GameModels", "gameDescription");
        }
    }
}
