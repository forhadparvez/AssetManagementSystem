namespace AssetSqlDatabase.Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateManufacturerAndModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssetManufacurers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AssetGroupId = c.Int(nullable: false),
                        Name = c.String(),
                        ShortName = c.String(),
                        Code = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AssetGroups", t => t.AssetGroupId, cascadeDelete: false)
                .Index(t => t.AssetGroupId);
            
            CreateTable(
                "dbo.AssetModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AssetGroupId = c.Int(nullable: false),
                        AssetManufacurerId = c.Int(nullable: false),
                        Name = c.String(),
                        ShortName = c.String(),
                        Code = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AssetGroups", t => t.AssetGroupId, cascadeDelete: false)
                .ForeignKey("dbo.AssetManufacurers", t => t.AssetManufacurerId, cascadeDelete: false)
                .Index(t => t.AssetGroupId)
                .Index(t => t.AssetManufacurerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AssetModels", "AssetManufacurerId", "dbo.AssetManufacurers");
            DropForeignKey("dbo.AssetModels", "AssetGroupId", "dbo.AssetGroups");
            DropForeignKey("dbo.AssetManufacurers", "AssetGroupId", "dbo.AssetGroups");
            DropIndex("dbo.AssetModels", new[] { "AssetManufacurerId" });
            DropIndex("dbo.AssetModels", new[] { "AssetGroupId" });
            DropIndex("dbo.AssetManufacurers", new[] { "AssetGroupId" });
            DropTable("dbo.AssetModels");
            DropTable("dbo.AssetManufacurers");
        }
    }
}
