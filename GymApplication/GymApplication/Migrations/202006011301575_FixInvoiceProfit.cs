namespace GymApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixInvoiceProfit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoices", "Profit", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Invoices", "Profit");
        }
    }
}
