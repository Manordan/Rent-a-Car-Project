namespace CarSite.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CityId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 20),
                        Address = c.String(nullable: false, maxLength: 40),
                        Longitude = c.Int(nullable: false),
                        Latitude = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        CarModelId = c.Int(nullable: false),
                        CurrentKilometers = c.Int(nullable: false),
                        YearOfManufacture = c.Int(nullable: false),
                        Transmission = c.Int(nullable: false),
                        Picture = c.String(),
                        IsRightForRent = c.Boolean(nullable: false),
                        IsAvailableForRent = c.Boolean(nullable: false),
                        BranchId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branches", t => t.BranchId, cascadeDelete: true)
                .ForeignKey("dbo.CarModels", t => t.CarModelId, cascadeDelete: true)
                .Index(t => t.CarModelId)
                .Index(t => t.BranchId);
            
            CreateTable(
                "dbo.CarModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CarManufacturerId = c.Int(nullable: false),
                        Model = c.String(nullable: false, maxLength: 20),
                        DailyCost = c.Int(nullable: false),
                        DailyCostDelay = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CarManufacturers", t => t.CarManufacturerId)
                .Index(t => t.CarManufacturerId);
            
            CreateTable(
                "dbo.CarManufacturers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 9),
                        CarId = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndtDate = c.DateTime(nullable: false),
                        ReturnDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Cars", t => t.CarId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.CarId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 9),
                        FirstName = c.String(nullable: false, maxLength: 20),
                        LastName = c.String(nullable: false, maxLength: 20),
                        UserName = c.String(nullable: false, maxLength: 12),
                        Password = c.String(nullable: false, maxLength: 12),
                        DateOfBirth = c.DateTime(),
                        Gender = c.Int(nullable: false),
                        Email = c.String(nullable: false),
                        Picture = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Authorization = c.String(maxLength: 20),
                        UserId = c.String(nullable: false, maxLength: 9),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Branches", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Rents", "CarId", "dbo.Cars");
            DropForeignKey("dbo.Roles", "UserId", "dbo.Users");
            DropForeignKey("dbo.Rents", "UserId", "dbo.Users");
            DropForeignKey("dbo.Cars", "CarModelId", "dbo.CarModels");
            DropForeignKey("dbo.CarModels", "CarManufacturerId", "dbo.CarManufacturers");
            DropForeignKey("dbo.Cars", "BranchId", "dbo.Branches");
            DropIndex("dbo.Roles", new[] { "UserId" });
            DropIndex("dbo.Rents", new[] { "CarId" });
            DropIndex("dbo.Rents", new[] { "UserId" });
            DropIndex("dbo.CarModels", new[] { "CarManufacturerId" });
            DropIndex("dbo.Cars", new[] { "BranchId" });
            DropIndex("dbo.Cars", new[] { "CarModelId" });
            DropIndex("dbo.Branches", new[] { "CityId" });
            DropTable("dbo.Cities");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.Rents");
            DropTable("dbo.CarManufacturers");
            DropTable("dbo.CarModels");
            DropTable("dbo.Cars");
            DropTable("dbo.Branches");
        }
    }
}
