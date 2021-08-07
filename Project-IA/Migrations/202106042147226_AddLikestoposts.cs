namespace Project_IA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLikestoposts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "LikesCounter", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "LikesCounter");
        }
    }
}
