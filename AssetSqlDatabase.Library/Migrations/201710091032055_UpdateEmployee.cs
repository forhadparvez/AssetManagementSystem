namespace AssetSqlDatabase.Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEmployee : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Employees", new[] { "DepartmentId" });
            AddColumn("dbo.Employees", "Department", c => c.String());
            DropColumn("dbo.Employees", "DepartmentId");
            DropColumn("dbo.Employees", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Image", c => c.Binary());
            AddColumn("dbo.Employees", "DepartmentId", c => c.Int(nullable: false));
            DropColumn("dbo.Employees", "Department");
            CreateIndex("dbo.Employees", "DepartmentId");
            AddForeignKey("dbo.Employees", "DepartmentId", "dbo.Departments", "Id", cascadeDelete: true);
        }
    }
}
