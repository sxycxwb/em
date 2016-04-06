namespace EM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSome : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Inf_Station", "StationName", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Inf_Station", "StationName", c => c.String(nullable: false, unicode: false));
        }
    }
}
