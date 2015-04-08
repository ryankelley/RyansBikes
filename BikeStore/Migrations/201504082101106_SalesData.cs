namespace BikeStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SalesData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegionId = c.Int(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Regions", t => t.RegionId)
                .Index(t => t.RegionId);
            
            CreateTable(
                "dbo.Regions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        SalesDirectorId = c.Int(),
                        SalesTarget = c.Decimal(nullable: false, storeType: "money"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.SalesDirectorId)
                .Index(t => t.SalesDirectorId);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegionId = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, storeType: "money"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Regions", t => t.RegionId, cascadeDelete: true)
                .Index(t => t.RegionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "RegionId", "dbo.Regions");
            DropForeignKey("dbo.Regions", "SalesDirectorId", "dbo.Employees");
            DropForeignKey("dbo.Sales", "RegionId", "dbo.Regions");
            DropIndex("dbo.Sales", new[] { "RegionId" });
            DropIndex("dbo.Regions", new[] { "SalesDirectorId" });
            DropIndex("dbo.Employees", new[] { "RegionId" });
            DropTable("dbo.Sales");
            DropTable("dbo.Regions");
            DropTable("dbo.Employees");
        }
    }
}
