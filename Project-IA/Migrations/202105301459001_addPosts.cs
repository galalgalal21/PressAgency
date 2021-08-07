namespace Project_IA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPosts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        EditorName = c.String(),
                        ArticleTitle = c.String(),
                        ArticleBody = c.String(),
                        ArticleImage = c.String(),
                        PostCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.PostCategories", t => t.PostCategoryId, cascadeDelete: true)
                .Index(t => t.PostCategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "PostCategoryId", "dbo.PostCategories");
            DropIndex("dbo.Posts", new[] { "PostCategoryId" });
            DropTable("dbo.Posts");
        }
    }
}
