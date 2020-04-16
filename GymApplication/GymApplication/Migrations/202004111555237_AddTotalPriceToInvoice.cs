namespace GymApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTotalPriceToInvoice : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Invoices", "TotalPrice", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Invoices", "TotalPrice", c => c.Int(nullable: false));
        }
    }
}
