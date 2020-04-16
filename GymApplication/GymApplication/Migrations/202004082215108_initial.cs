namespace GymApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Day = c.String(),
                        StartTime = c.String(),
                        EndTime = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.InvoiceItems",
                c => new
                    {
                        InvoiceId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.InvoiceId, t.ItemId })
                .ForeignKey("dbo.Invoices", t => t.InvoiceId, cascadeDelete: true)
                .ForeignKey("dbo.Items", t => t.ItemId, cascadeDelete: true)
                .Index(t => t.InvoiceId)
                .Index(t => t.ItemId);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InvoiceDateTime = c.DateTime(),
                        TotalPrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Barcode = c.String(),
                        RetailPrice = c.Double(nullable: false),
                        ActualPrice = c.Double(nullable: false),
                        StockNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MembershipName = c.String(),
                        MembershipFees = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImagePath = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        EmailAddress = c.String(),
                        Address = c.String(),
                        PhoneNumber = c.String(),
                        EmergencyNumber = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        RoleId = c.Int(nullable: false),
                        MembershipTypeId = c.Int(nullable: false),
                        RegistrationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MembershipTypes", t => t.MembershipTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.MembershipTypeId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ItemInvoices",
                c => new
                    {
                        Item_Id = c.Int(nullable: false),
                        Invoice_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Item_Id, t.Invoice_Id })
                .ForeignKey("dbo.Items", t => t.Item_Id, cascadeDelete: true)
                .ForeignKey("dbo.Invoices", t => t.Invoice_Id, cascadeDelete: true)
                .Index(t => t.Item_Id)
                .Index(t => t.Invoice_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Users", "MembershipTypeId", "dbo.MembershipTypes");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.InvoiceItems", "ItemId", "dbo.Items");
            DropForeignKey("dbo.InvoiceItems", "InvoiceId", "dbo.Invoices");
            DropForeignKey("dbo.ItemInvoices", "Invoice_Id", "dbo.Invoices");
            DropForeignKey("dbo.ItemInvoices", "Item_Id", "dbo.Items");
            DropIndex("dbo.ItemInvoices", new[] { "Invoice_Id" });
            DropIndex("dbo.ItemInvoices", new[] { "Item_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Users", new[] { "MembershipTypeId" });
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.InvoiceItems", new[] { "ItemId" });
            DropIndex("dbo.InvoiceItems", new[] { "InvoiceId" });
            DropTable("dbo.ItemInvoices");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Users");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Roles");
            DropTable("dbo.MembershipTypes");
            DropTable("dbo.Items");
            DropTable("dbo.Invoices");
            DropTable("dbo.InvoiceItems");
            DropTable("dbo.Classes");
        }
    }
}
