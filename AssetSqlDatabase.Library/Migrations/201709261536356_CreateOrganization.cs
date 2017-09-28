namespace AssetSqlDatabase.Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateOrganization : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrganizationId = c.Int(nullable: false),
                        Name = c.String(),
                        ShortName = c.String(),
                        BranchCode = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organizations", t => t.OrganizationId, cascadeDelete: true)
                .Index(t => t.OrganizationId);
            
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ShortName = c.String(),
                        Location = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrganizationId = c.Int(nullable: false),
                        Name = c.String(),
                        ShortName = c.String(),
                        DepartmentCode = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organizations", t => t.OrganizationId, cascadeDelete: true)
                .Index(t => t.OrganizationId);
            
            CreateTable(
                "dbo.Designations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepartmentId = c.Int(nullable: false),
                        Name = c.String(),
                        ShortName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrganizationId = c.Int(nullable: false),
                        BranchId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        DesignationId = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        ContactNo = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        Image = c.Binary(),
                        Code = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branches", t => t.BranchId, cascadeDelete: false)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: false)
                .ForeignKey("dbo.Designations", t => t.DesignationId, cascadeDelete: false)
                .ForeignKey("dbo.Organizations", t => t.OrganizationId, cascadeDelete: false)
                .Index(t => t.OrganizationId)
                .Index(t => t.BranchId)
                .Index(t => t.DepartmentId)
                .Index(t => t.DesignationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "OrganizationId", "dbo.Organizations");
            DropForeignKey("dbo.Employees", "DesignationId", "dbo.Designations");
            DropForeignKey("dbo.Employees", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Employees", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.Designations", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Departments", "OrganizationId", "dbo.Organizations");
            DropForeignKey("dbo.Branches", "OrganizationId", "dbo.Organizations");
            DropIndex("dbo.Employees", new[] { "DesignationId" });
            DropIndex("dbo.Employees", new[] { "DepartmentId" });
            DropIndex("dbo.Employees", new[] { "BranchId" });
            DropIndex("dbo.Employees", new[] { "OrganizationId" });
            DropIndex("dbo.Designations", new[] { "DepartmentId" });
            DropIndex("dbo.Departments", new[] { "OrganizationId" });
            DropIndex("dbo.Branches", new[] { "OrganizationId" });
            DropTable("dbo.Employees");
            DropTable("dbo.Designations");
            DropTable("dbo.Departments");
            DropTable("dbo.Organizations");
            DropTable("dbo.Branches");
        }
    }
}
