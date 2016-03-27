namespace EM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyEmployer : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Inf_Employer", "MachineCapacity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Inf_Employer", "MachineCapacity", c => c.String(unicode: false));
        }
    }
}
