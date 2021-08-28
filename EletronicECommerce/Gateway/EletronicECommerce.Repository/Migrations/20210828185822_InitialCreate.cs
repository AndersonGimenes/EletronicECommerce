using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EletronicECommerce.Repository.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    Code = table.Column<string>(type: "varchar(10)", nullable: false),
                    PurchasePrice = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    SalePrice = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<string>(type: "char(36)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(36)", nullable: false),
                    Email = table.Column<string>(type: "varchar(200)", nullable: false),
                    Password = table.Column<string>(type: "varchar(200)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_User", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
