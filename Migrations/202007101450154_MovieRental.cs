namespace VidlyLearn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieRental : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.MovieRentals",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateRented = c.DateTime(nullable: false),
                        DateReturned = c.DateTime(),
                        CustomerId = c.Int(nullable: false),
                        MovieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.MovieId);
          
            //RenameTable(name: "dbo.Rentals", newName: "MovieRentals");
            //RenameColumn(table: "dbo.MovieRentals", name: "Customer_Id", newName: "CustomerId");
            //RenameColumn(table: "dbo.MovieRentals", name: "Movie_Id", newName: "MovieId");
            //RenameIndex(table: "dbo.MovieRentals", name: "IX_Movie_Id", newName: "IX_MovieId");
            //RenameIndex(table: "dbo.MovieRentals", name: "IX_Customer_Id", newName: "IX_CustomerId");
        }
        
        public override void Down()
        {
          

            //RenameIndex(table: "dbo.MovieRentals", name: "IX_CustomerId", newName: "IX_Customer_Id");
            //RenameIndex(table: "dbo.MovieRentals", name: "IX_MovieId", newName: "IX_Movie_Id");
            //RenameColumn(table: "dbo.MovieRentals", name: "MovieId", newName: "Movie_Id");
            //RenameColumn(table: "dbo.MovieRentals", name: "CustomerId", newName: "Customer_Id");
            //RenameTable(name: "dbo.MovieRentals", newName: "Rentals");

            DropForeignKey("dbo.MovieRentals", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.MovieRentals", "CustomerId", "dbo.Customers");
            DropIndex("dbo.MovieRentals", new[] { "MovieId" });
            DropIndex("dbo.MovieRentals", new[] { "CustomerId" });
            DropTable("dbo.MovieRentals");
        }
    }
}
