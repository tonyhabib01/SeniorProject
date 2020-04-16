namespace GymApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIdToInvoiceItems : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.InvoiceItems");
            AddColumn("dbo.InvoiceItems", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.InvoiceItems", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.InvoiceItems");
            DropColumn("dbo.InvoiceItems", "Id");
            AddPrimaryKey("dbo.InvoiceItems", new[] { "InvoiceId", "ItemId" });
        }
    }
}
