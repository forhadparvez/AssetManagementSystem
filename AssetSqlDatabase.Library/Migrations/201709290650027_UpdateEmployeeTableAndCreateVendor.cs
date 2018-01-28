namespace AssetSqlDatabase.Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEmployeeTableAndCreateVendor : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "DesignationId", "dbo.Designations");
            DropIndex("dbo.Employees", new[] { "DesignationId" });
            CreateTable(
                "dbo.Vendors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ShortName = c.String(),
                        Email = c.String(),
                        ContactNo = c.String(),
                        Address = c.String(),
                        Comments = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Employees", "Designation", c => c.String());
            DropColumn("dbo.Employees", "DesignationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "DesignationId", c => c.Int(nullable: false));
            DropColumn("dbo.Employees", "Designation");
            DropTable("dbo.Vendors");
            CreateIndex("dbo.Employees", "DesignationId");
            AddForeignKey("dbo.Employees", "DesignationId", "dbo.Designations", "Id", cascadeDelete: true);
        }
    }
}
