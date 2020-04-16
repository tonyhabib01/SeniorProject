namespace GymApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InvoiceItemsModelFix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.InvoiceItems", "InvoiceId", "dbo.Invoices");
            DropForeignKey("dbo.InvoiceItems", "ItemId", "dbo.Items");
            DropIndex("dbo.InvoiceItems", new[] { "InvoiceId" });
            DropIndex("dbo.InvoiceItems", new[] { "ItemId" });
            RenameColumn(table: "dbo.InvoiceItems", name: "InvoiceId", newName: "Invoice_Id");
            RenameColumn(table: "dbo.InvoiceItems", name: "ItemId", newName: "Item_Id");
            AlterColumn("dbo.InvoiceItems", "Invoice_Id", c => c.Int());
            AlterColumn("dbo.InvoiceItems", "Item_Id", c => c.Int());
            CreateIndex("dbo.InvoiceItems", "Invoice_Id");
            CreateIndex("dbo.InvoiceItems", "Item_Id");
            AddForeignKey("dbo.InvoiceItems", "Invoice_Id", "dbo.Invoices", "Id");
            AddForeignKey("dbo.InvoiceItems", "Item_Id", "dbo.Items", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InvoiceItems", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.InvoiceItems", "Invoice_Id", "dbo.Invoices");
            DropIndex("dbo.InvoiceItems", new[] { "Item_Id" });
            DropIndex("dbo.InvoiceItems", new[] { "Invoice_Id" });
            AlterColumn("dbo.InvoiceItems", "Item_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.InvoiceItems", "Invoice_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.InvoiceItems", name: "Item_Id", newName: "ItemId");
            RenameColumn(table: "dbo.InvoiceItems", name: "Invoice_Id", newName: "InvoiceId");
            CreateIndex("dbo.InvoiceItems", "ItemId");
            CreateIndex("dbo.InvoiceItems", "InvoiceId");
            AddForeignKey("dbo.InvoiceItems", "ItemId", "dbo.Items", "Id", cascadeDelete: true);
            AddForeignKey("dbo.InvoiceItems", "InvoiceId", "dbo.Invoices", "Id", cascadeDelete: true);
        }
    }
}
