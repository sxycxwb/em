namespace EM.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class AddSomeModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Inf_Station",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ZoneId = c.Guid(nullable: false),
                        StationTypeId = c.Guid(nullable: false),
                        StationName = c.String(nullable: false, unicode: false),
                        ProductionTime = c.DateTime(nullable: false, precision: 0),
                        OwnershipRatio = c.Int(nullable: false),
                        MachineNumber = c.Int(nullable: false),
                        MachineModel = c.String(unicode: false),
                        MachineCapacity = c.String(unicode: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(precision: 0),
                        LastModificationTime = c.DateTime(precision: 0),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Inf_Station_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Inf_StationType", t => t.StationTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Inf_Zone", t => t.ZoneId, cascadeDelete: true)
                .Index(t => t.ZoneId)
                .Index(t => t.StationTypeId);
            
            CreateTable(
                "dbo.Inf_StationType",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TypeName = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Inf_Zone",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ZoneName = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inf_Station", "ZoneId", "dbo.Inf_Zone");
            DropForeignKey("dbo.Inf_Station", "StationTypeId", "dbo.Inf_StationType");
            DropIndex("dbo.Inf_Station", new[] { "StationTypeId" });
            DropIndex("dbo.Inf_Station", new[] { "ZoneId" });
            DropTable("dbo.Inf_Zone");
            DropTable("dbo.Inf_StationType");
            DropTable("dbo.Inf_Station",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Inf_Station_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
