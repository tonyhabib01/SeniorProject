namespace GymApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWorkout : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Workouts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Body = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "Workout_Id", c => c.Int());
            CreateIndex("dbo.Users", "Workout_Id");
            AddForeignKey("dbo.Users", "Workout_Id", "dbo.Workouts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Workout_Id", "dbo.Workouts");
            DropIndex("dbo.Users", new[] { "Workout_Id" });
            DropColumn("dbo.Users", "Workout_Id");
            DropTable("dbo.Workouts");
        }
    }
}
