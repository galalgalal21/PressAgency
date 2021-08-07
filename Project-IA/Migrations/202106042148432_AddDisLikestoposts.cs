namespace Project_IA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDisLikestoposts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "DisLikesCounter", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "DisLikesCounter");
        }
    }
}
