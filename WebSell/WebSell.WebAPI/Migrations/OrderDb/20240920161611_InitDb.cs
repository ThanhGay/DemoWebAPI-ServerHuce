using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSell.WebAPI.Migrations.OrderDb
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ord");

            migrationBuilder.CreateTable(
                name: "OrdCart",
                schema: "ord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdCart", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrdOrder",
                schema: "ord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdOrder", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrdOrderDetail",
                schema: "ord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdOrderDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdOrderDetail_OrdOrder_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "ord",
                        principalTable: "OrdOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrdOrderDetail_OrderId",
                schema: "ord",
                table: "OrdOrderDetail",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdCart",
                schema: "ord");

            migrationBuilder.DropTable(
                name: "OrdOrderDetail",
                schema: "ord");

            migrationBuilder.DropTable(
                name: "OrdOrder",
                schema: "ord");
        }
    }
}
