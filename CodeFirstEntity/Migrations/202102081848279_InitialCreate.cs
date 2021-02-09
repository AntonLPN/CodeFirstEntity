namespace CodeFirstEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 20),
                        LastName = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameBook = c.String(),
                        ClientsId = c.Int(nullable: false),
                        AuthorsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Authors", t => t.AuthorsId, cascadeDelete: true)
                .Index(t => t.AuthorsId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "AuthorsId", "dbo.Authors");
            DropIndex("dbo.Books", new[] { "AuthorsId" });
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
        }
    }
}
