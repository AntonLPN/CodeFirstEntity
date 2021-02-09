namespace CodeFirstEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 20),
                        LastName = c.String(maxLength: 20),
                        Dept = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Books", "Client_Id", c => c.Int());
            AlterColumn("dbo.Books", "NameBook", c => c.String(maxLength: 20));
            CreateIndex("dbo.Books", "Client_Id");
            AddForeignKey("dbo.Books", "Client_Id", "dbo.Clients", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "Client_Id", "dbo.Clients");
            DropIndex("dbo.Books", new[] { "Client_Id" });
            AlterColumn("dbo.Books", "NameBook", c => c.String());
            DropColumn("dbo.Books", "Client_Id");
            DropTable("dbo.Clients");
        }
    }
}
