namespace Project_IA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nobody : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserViewModels",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        username = c.String(),
                        Email = c.String(),
                        userType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserViewModels");
        }
    }
}
