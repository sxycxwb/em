namespace EM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Inf_Station", "StationType_Id", c => c.Guid());
            AddColumn("dbo.Inf_Station", "StationZone_Id", c => c.Guid());
            CreateIndex("dbo.Inf_Station", "StationType_Id");
            CreateIndex("dbo.Inf_Station", "StationZone_Id");
            AddForeignKey("dbo.Inf_Station", "StationType_Id", "dbo.Inf_DictData", "Id");
            AddForeignKey("dbo.Inf_Station", "StationZone_Id", "dbo.Inf_DictData", "Id");
            DropColumn("dbo.Inf_Station", "ZoneId");
            DropColumn("dbo.Inf_Station", "StationTypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Inf_Station", "StationTypeId", c => c.Guid(nullable: false));
            AddColumn("dbo.Inf_Station", "ZoneId", c => c.Guid(nullable: false));
            DropForeignKey("dbo.Inf_Station", "StationZone_Id", "dbo.Inf_DictData");
            DropForeignKey("dbo.Inf_Station", "StationType_Id", "dbo.Inf_DictData");
            DropIndex("dbo.Inf_Station", new[] { "StationZone_Id" });
            DropIndex("dbo.Inf_Station", new[] { "StationType_Id" });
            DropColumn("dbo.Inf_Station", "StationZone_Id");
            DropColumn("dbo.Inf_Station", "StationType_Id");
        }
    }
}
