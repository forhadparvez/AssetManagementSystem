namespace AssetSqlDatabase.Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCheckOutModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CheckOuts", "AssetEntry_Id", "dbo.AssetEntries");
            DropForeignKey("dbo.CheckOuts", "AssetLocation_Id", "dbo.AssetLocations");
            DropForeignKey("dbo.CheckOuts", "Employee_Id", "dbo.Employees");
            DropIndex("dbo.CheckOuts", new[] { "AssetEntry_Id" });
            DropIndex("dbo.CheckOuts", new[] { "AssetLocation_Id" });
            DropIndex("dbo.CheckOuts", new[] { "Employee_Id" });
            AddColumn("dbo.CheckOuts", "Employee", c => c.Int(nullable: false));
            AddColumn("dbo.CheckOuts", "AssetLocation", c => c.Int(nullable: false));
            AddColumn("dbo.CheckOuts", "AssetEntry", c => c.Int(nullable: false));
            DropColumn("dbo.CheckOuts", "AssetEntry_Id");
            DropColumn("dbo.CheckOuts", "AssetLocation_Id");
            DropColumn("dbo.CheckOuts", "Employee_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CheckOuts", "Employee_Id", c => c.Int());
            AddColumn("dbo.CheckOuts", "AssetLocation_Id", c => c.Int());
            AddColumn("dbo.CheckOuts", "AssetEntry_Id", c => c.Int());
            DropColumn("dbo.CheckOuts", "AssetEntry");
            DropColumn("dbo.CheckOuts", "AssetLocation");
            DropColumn("dbo.CheckOuts", "Employee");
            CreateIndex("dbo.CheckOuts", "Employee_Id");
            CreateIndex("dbo.CheckOuts", "AssetLocation_Id");
            CreateIndex("dbo.CheckOuts", "AssetEntry_Id");
            AddForeignKey("dbo.CheckOuts", "Employee_Id", "dbo.Employees", "Id");
            AddForeignKey("dbo.CheckOuts", "AssetLocation_Id", "dbo.AssetLocations", "Id");
            AddForeignKey("dbo.CheckOuts", "AssetEntry_Id", "dbo.AssetEntries", "Id");
        }
    }
}
