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
            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                schema: "prod",
                table: "ProdProduct",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "prod",
                table: "ProdProduct",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                schema: "prod",
                table: "ProdProduct",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "prod",
                table: "ProdProduct");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "prod",
                table: "ProdProduct");

            migrationBuilder.DropColumn(
                name: "Price",
                schema: "prod",
                table: "ProdProduct");
        }
    }
}
