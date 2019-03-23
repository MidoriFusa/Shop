namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Places",
                c => new
                    {
                        PlaceId = c.Int(nullable: false, identity: true),
                        PlaceName = c.String(nullable: false, maxLength: 4),
                    })
                .PrimaryKey(t => t.PlaceId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false, maxLength: 15),
                        Height = c.Double(nullable: false),
                        Width = c.Double(nullable: false),
                        Length = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "dbo.ProductPlaces",
                c => new
                    {
                        Product_ProductId = c.Int(nullable: false),
                        Place_PlaceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_ProductId, t.Place_PlaceId })
                .ForeignKey("dbo.Products", t => t.Product_ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Places", t => t.Place_PlaceId, cascadeDelete: true)
                .Index(t => t.Product_ProductId)
                .Index(t => t.Place_PlaceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductPlaces", "Place_PlaceId", "dbo.Places");
            DropForeignKey("dbo.ProductPlaces", "Product_ProductId", "dbo.Products");
            DropIndex("dbo.ProductPlaces", new[] { "Place_PlaceId" });
            DropIndex("dbo.ProductPlaces", new[] { "Product_ProductId" });
            DropTable("dbo.ProductPlaces");
            DropTable("dbo.Products");
            DropTable("dbo.Places");
        }
    }
}
