using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication6.Migrations
{
    public partial class forImagePathADD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "spOrderID",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    OrderNo = table.Column<string>(nullable: true),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    CustomerId = table.Column<int>(nullable: true),
                    CustomerName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "spOrderIDWiseDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Qty = table.Column<double>(nullable: false),
                    UnitPrice = table.Column<double>(nullable: false),
                    DiscountPercentage = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "spOrderID");

            migrationBuilder.DropTable(
                name: "spOrderIDWiseDetails");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Products");
        }
    }
}
