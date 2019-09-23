namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addprodcutField : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Category_categoryId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "Category_categoryId" });
            RenameColumn(table: "dbo.Products", name: "Category_categoryId", newName: "CategoryId");
            AlterColumn("dbo.Products", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "CategoryId");
            AddForeignKey("dbo.Products", "CategoryId", "dbo.Categories", "categoryId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CategoryId" });
            AlterColumn("dbo.Products", "CategoryId", c => c.Int());
            RenameColumn(table: "dbo.Products", name: "CategoryId", newName: "Category_categoryId");
            CreateIndex("dbo.Products", "Category_categoryId");
            AddForeignKey("dbo.Products", "Category_categoryId", "dbo.Categories", "categoryId");
        }
    }
}
