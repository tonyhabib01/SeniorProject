namespace GymApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProfitInvoice : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Invoices", "Profit");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Invoices", "Profit", c => c.Double(nullable: false));
        }
    }
}
