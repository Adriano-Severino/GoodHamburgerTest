using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GoodHamburger.Api.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sandwich",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Userid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sandwich", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Extra",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SandwichId = table.Column<long>(type: "bigint", nullable: true),
                    Userid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Extra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Extra_Sandwich_SandwichId",
                        column: x => x.SandwichId,
                        principalTable: "Sandwich",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Userid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SandwichId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedido_Sandwich_SandwichId",
                        column: x => x.SandwichId,
                        principalTable: "Sandwich",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Extra",
                columns: new[] { "Id", "Name", "Price", "SandwichId", "Userid" },
                values: new object[,]
                {
                    { 1L, "Fries", 2.00m, null, new Guid("206d0fcc-ea9a-4164-9c38-c48b18451e1e") },
                    { 2L, "SoftDrink", 2.50m, null, new Guid("206d0fcc-ea9a-4164-9c38-c48b18451e1e") }
                });

            migrationBuilder.InsertData(
                table: "Sandwich",
                columns: new[] { "Id", "Name", "Price", "Userid" },
                values: new object[,]
                {
                    { 1L, "XBurger", 5.00m, new Guid("206d0fcc-ea9a-4164-9c38-c48b18451e1e") },
                    { 2L, "XEgg", 4.50m, new Guid("206d0fcc-ea9a-4164-9c38-c48b18451e1e") },
                    { 3L, "XBacon", 7.00m, new Guid("206d0fcc-ea9a-4164-9c38-c48b18451e1e") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Extra_SandwichId",
                table: "Extra",
                column: "SandwichId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_SandwichId",
                table: "Pedido",
                column: "SandwichId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Extra");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "Sandwich");
        }
    }
}
