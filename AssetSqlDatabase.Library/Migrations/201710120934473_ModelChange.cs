namespace AssetSqlDatabase.Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CheckOuts", "ReturnDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CheckOuts", "ReturnDate", c => c.DateTime(nullable: false));
        }
    }
}
