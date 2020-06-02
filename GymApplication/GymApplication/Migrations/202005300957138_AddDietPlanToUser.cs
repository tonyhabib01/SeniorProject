namespace GymApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDietPlanToUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DietPlans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Body = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "DietPlan_Id", c => c.Int());
            CreateIndex("dbo.Users", "DietPlan_Id");
            AddForeignKey("dbo.Users", "DietPlan_Id", "dbo.DietPlans", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "DietPlan_Id", "dbo.DietPlans");
            DropIndex("dbo.Users", new[] { "DietPlan_Id" });
            DropColumn("dbo.Users", "DietPlan_Id");
            DropTable("dbo.DietPlans");
        }
    }
}
