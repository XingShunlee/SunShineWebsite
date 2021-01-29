namespace ehaiker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KefuServiceStatus3 : DbMigration
    {
        public override void Up()
        {
           
        }
        
        public override void Down()
        {
            DropTable("dbo.KefuServiceStatus");
        }
    }
}
