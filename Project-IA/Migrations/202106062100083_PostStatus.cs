namespace Project_IA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PostStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "PostStatus", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "PostStatus");
        }
    }
}
