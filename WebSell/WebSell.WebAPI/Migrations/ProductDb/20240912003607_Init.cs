using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSell.WebAPI.Migrations.ProductDb
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "prod");

            migrationBuilder.CreateTable(
                name: "ProdCategory",
                schema: "prod",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProdProduct",
                schema: "prod",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdProduct", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProdProductCategory",
                schema: "prod",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdProductCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProdProductCategory_ProdCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "prod",
                        principalTable: "ProdCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdProductCategory_ProdProduct_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "prod",
                        principalTable: "ProdProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProdProductCategory_CategoryId",
                schema: "prod",
                table: "ProdProductCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdProductCategory_ProductId",
                schema: "prod",
                table: "ProdProductCategory",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProdProductCategory",
                schema: "prod");

            migrationBuilder.DropTable(
                name: "ProdCategory",
                schema: "prod");

            migrationBuilder.DropTable(
                name: "ProdProduct",
                schema: "prod");
        }
    }
}
