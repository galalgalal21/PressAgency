namespace Project_IA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ay7aga : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "PostCategory_id", "dbo.PostCategories");
            DropIndex("dbo.Posts", new[] { "PostCategory_id" });
            DropTable("dbo.PostCategories");
            DropTable("dbo.Posts");
        }
        
        public override void Down()
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
                        PostCategoryId = c.String(),
                        PostCategory_id = c.Int(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.PostCategories",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ArticleTitle = c.String(nullable: false),
                        ArticleType = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateIndex("dbo.Posts", "PostCategory_id");
            AddForeignKey("dbo.Posts", "PostCategory_id", "dbo.PostCategories", "id");
        }
    }
}
