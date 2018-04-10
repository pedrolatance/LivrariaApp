namespace Livraria.Infraestructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.author",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.book",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 200),
                        ISBN = c.String(nullable: false, maxLength: 12),
                        StorageQty = c.Int(nullable: false),
                        Author_Id = c.Int(nullable: false),
                        Category_Id = c.Int(nullable: false),
                        Publisher_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.author", t => t.Author_Id, cascadeDelete: true)
                .ForeignKey("dbo.category", t => t.Category_Id, cascadeDelete: true)
                .ForeignKey("dbo.publisher", t => t.Publisher_Id, cascadeDelete: true)
                .Index(t => t.ISBN, unique: true)
                .Index(t => t.Author_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.Publisher_Id);
            
            CreateTable(
                "dbo.category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.publisher",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.book", "Publisher_Id", "dbo.publisher");
            DropForeignKey("dbo.book", "Category_Id", "dbo.category");
            DropForeignKey("dbo.book", "Author_Id", "dbo.author");
            DropIndex("dbo.book", new[] { "Publisher_Id" });
            DropIndex("dbo.book", new[] { "Category_Id" });
            DropIndex("dbo.book", new[] { "Author_Id" });
            DropIndex("dbo.book", new[] { "ISBN" });
            DropTable("dbo.publisher");
            DropTable("dbo.category");
            DropTable("dbo.book");
            DropTable("dbo.author");
        }
    }
}
