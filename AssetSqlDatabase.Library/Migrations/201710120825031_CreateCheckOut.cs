namespace AssetSqlDatabase.Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCheckOut : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CheckOuts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EntryDate = c.DateTime(nullable: false),
                        ReturnDate = c.DateTime(nullable: false),
                        Commants = c.String(),
                        AssetEntry_Id = c.Int(),
                        AssetLocation_Id = c.Int(),
                        Employee_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AssetEntries", t => t.AssetEntry_Id)
                .ForeignKey("dbo.AssetLocations", t => t.AssetLocation_Id)
                .ForeignKey("dbo.Employees", t => t.Employee_Id)
                .Index(t => t.AssetEntry_Id)
                .Index(t => t.AssetLocation_Id)
                .Index(t => t.Employee_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CheckOuts", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.CheckOuts", "AssetLocation_Id", "dbo.AssetLocations");
            DropForeignKey("dbo.CheckOuts", "AssetEntry_Id", "dbo.AssetEntries");
            DropIndex("dbo.CheckOuts", new[] { "Employee_Id" });
            DropIndex("dbo.CheckOuts", new[] { "AssetLocation_Id" });
            DropIndex("dbo.CheckOuts", new[] { "AssetEntry_Id" });
            DropTable("dbo.CheckOuts");
        }
    }
}
