namespace Project_IA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCategoryTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PostCategories",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ArticleTitle = c.String(nullable: false),
                        ArticleType = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PostCategories");
        }
    }
}
