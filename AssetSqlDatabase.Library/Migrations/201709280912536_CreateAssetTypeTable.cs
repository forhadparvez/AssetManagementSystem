namespace AssetSqlDatabase.Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateAssetTypeTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssetTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ShortName = c.String(),
                        Code = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AssetTypes");
        }
    }
}
