namespace AssetSqlDatabase.Library.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AssetEntryAdditionalTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attchments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AssetEntryId = c.Int(nullable: false),
                        File = c.Binary(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AssetEntries", t => t.AssetEntryId, cascadeDelete: false)
                .Index(t => t.AssetEntryId);

            CreateTable(
                "dbo.Finances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AssetEntryId = c.Int(nullable: false),
                        VendorId = c.Int(nullable: false),
                        ParchasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ParchaseOrderNo = c.String(),
                        PurchaseDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AssetEntries", t => t.AssetEntryId, cascadeDelete: false)
                .ForeignKey("dbo.Vendors", t => t.VendorId, cascadeDelete: false)
                .Index(t => t.AssetEntryId)
                .Index(t => t.VendorId);

            CreateTable(
                "dbo.Notes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AssetEntryId = c.Int(nullable: false),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AssetEntries", t => t.AssetEntryId, cascadeDelete: false)
                .Index(t => t.AssetEntryId);

            CreateTable(
                "dbo.ServiceOrRepairings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AssetEntryId = c.Int(nullable: false),
                        Description = c.String(),
                        ServiceDate = c.DateTime(),
                        ServiceingCostDecimal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PartsCostDecimal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxDecimal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ServiceBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AssetEntries", t => t.AssetEntryId, cascadeDelete: false)
                .Index(t => t.AssetEntryId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.ServiceOrRepairings", "AssetEntryId", "dbo.AssetEntries");
            DropForeignKey("dbo.Notes", "AssetEntryId", "dbo.AssetEntries");
            DropForeignKey("dbo.Finances", "VendorId", "dbo.Vendors");
            DropForeignKey("dbo.Finances", "AssetEntryId", "dbo.AssetEntries");
            DropForeignKey("dbo.Attchments", "AssetEntryId", "dbo.AssetEntries");
            DropIndex("dbo.ServiceOrRepairings", new[] { "AssetEntryId" });
            DropIndex("dbo.Notes", new[] { "AssetEntryId" });
            DropIndex("dbo.Finances", new[] { "VendorId" });
            DropIndex("dbo.Finances", new[] { "AssetEntryId" });
            DropIndex("dbo.Attchments", new[] { "AssetEntryId" });
            DropTable("dbo.ServiceOrRepairings");
            DropTable("dbo.Notes");
            DropTable("dbo.Finances");
            DropTable("dbo.Attchments");
        }
    }
}
