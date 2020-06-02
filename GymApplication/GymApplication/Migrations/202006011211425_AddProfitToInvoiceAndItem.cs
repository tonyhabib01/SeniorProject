namespace GymApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProfitToInvoiceAndItem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoices", "Profit", c => c.Double(nullable: false));
            AddColumn("dbo.Items", "Profit", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "Profit");
            DropColumn("dbo.Invoices", "Profit");
        }
    }
}
