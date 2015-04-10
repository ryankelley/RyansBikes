namespace BikeStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SKU = c.Long(nullable: false),
                        Name = c.String(),
                        Category = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ManufacturerId = c.String(),
                        BrandName = c.String(),
                        LongDescription = c.String(),
                        ShortDescription = c.String(),
                        SubCategory = c.String(),
                        ProductGroup = c.String(),
                        ThumbURL = c.String(),
                        ImageURL = c.String(),
                        SalesPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Products");
        }
    }
}
