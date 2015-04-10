namespace BikeStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class products : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    SKU = c.Long(nullable: false),
                    Name = c.String(nullable: false),
                    Category = c.String(nullable: false),
                    Price = c.Decimal(nullable: false),
                    ManufacturerId = c.String(nullable: false),
                    BrandName = c.String(nullable: false),
                    LongDescription = c.String(nullable: false, maxLength:4096),
                    ShortDescription = c.String(nullable: false, maxLength:4096),
                    SubCategory = c.String(nullable: true),
                    ProductGroup = c.String(nullable: true),
                    ThumbURL = c.String(nullable: false),
                    ImageURL = c.String(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.SKU);
        }
        
        public override void Down()
        {
            DropTable("dbo.Products");
        }
    }
}
