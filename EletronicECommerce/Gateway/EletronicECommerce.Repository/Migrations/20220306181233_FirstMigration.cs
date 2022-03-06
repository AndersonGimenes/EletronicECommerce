using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace EletronicECommerce.Repository.Migrations
{
    public partial class FirstMigration : Migration
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
                name: "User",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(36)", nullable: false),
                    Email = table.Column<string>(type: "varchar(200)", nullable: false),
                    Password = table.Column<string>(type: "varchar(200)", nullable: false),
                    Role = table.Column<string>(type: "varchar(20)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    Code = table.Column<string>(type: "varchar(10)", nullable: false),
                    SalePrice = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    CategoryId = table.Column<string>(type: "char(36)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_Product", x => x.Id);
                    table.ForeignKey(
                        name: "Fk_Category_Product",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(36)", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(50)", nullable: false),
                    Surname = table.Column<string>(type: "varchar(200)", nullable: false),
                    DocumentNumber = table.Column<string>(type: "varchar(14)", nullable: false),
                    DocumentType = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "char(36)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_User", x => x.Id);
                    table.ForeignKey(
                        name: "Fk_User_Costumer",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(36)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    StatusOrder = table.Column<string>(type: "varchar(20)", nullable: false),
                    TypePayment = table.Column<string>(type: "varchar(20)", nullable: false),
                    UserId = table.Column<string>(type: "char(36)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_Order", x => x.Id);
                    table.ForeignKey(
                        name: "Fk_Order_User",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductStock",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    PurchasePrice = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<string>(type: "char(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_Stock", x => x.Id);
                    table.ForeignKey(
                        name: "Fk_Product_Stock",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Street = table.Column<string>(type: "varchar(500)", nullable: false),
                    Number = table.Column<string>(type: "varchar(10)", nullable: true, defaultValue: "S/N"),
                    Neighborhood = table.Column<string>(type: "varchar(50)", nullable: false),
                    City = table.Column<string>(type: "varchar(100)", nullable: false),
                    State = table.Column<string>(type: "varchar(2)", nullable: false),
                    Country = table.Column<string>(type: "varchar(50)", nullable: false),
                    AddressType = table.Column<string>(type: "varchar(20)", nullable: false),
                    CustomerId = table.Column<string>(type: "char(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_Address", x => x.Id);
                    table.ForeignKey(
                        name: "Fk_Customer_Address",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderProduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<string>(type: "char(36)", nullable: false),
                    OrderId = table.Column<string>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_OrderProduct", x => x.Id);
                    table.ForeignKey(
                        name: "Fk_Order_Product",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Fk_Product_Order",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_CustomerId",
                table: "Address",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_UserId",
                table: "Customer",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserId",
                table: "Order",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_OrderId",
                table: "OrderProduct",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_ProductId",
                table: "OrderProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductStock_ProductId",
                table: "ProductStock",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "OrderProduct");

            migrationBuilder.DropTable(
                name: "ProductStock");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
