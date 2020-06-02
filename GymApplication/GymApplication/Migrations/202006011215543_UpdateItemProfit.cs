namespace GymApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateItemProfit : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Items", "Profit");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Items", "Profit", c => c.Double(nullable: false));
        }
    }
}
