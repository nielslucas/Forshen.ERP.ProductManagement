using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forshen.ERP.ProductManagement.Migrations
{
    /// <inheritdoc />
    public partial class relationsForProductDimensions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dimensions_Products_ProductId",
                table: "Dimensions");

            migrationBuilder.DropForeignKey(
                name: "FK_Dimensions_Products_ProductId1",
                table: "Dimensions");

            migrationBuilder.DropIndex(
                name: "IX_Dimensions_ProductId",
                table: "Dimensions");

            migrationBuilder.DropIndex(
                name: "IX_Dimensions_ProductId1",
                table: "Dimensions");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Dimensions");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "Dimensions");

            migrationBuilder.CreateTable(
                name: "ProductDimensions",
                columns: table => new
                {
                    DimensionsId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDimensions", x => new { x.DimensionsId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_ProductDimensions_Dimensions_DimensionsId",
                        column: x => x.DimensionsId,
                        principalTable: "Dimensions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductDimensions_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductDimensions_ProductsId",
                table: "ProductDimensions",
                column: "ProductsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductDimensions");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Dimensions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId1",
                table: "Dimensions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dimensions_ProductId",
                table: "Dimensions",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Dimensions_ProductId1",
                table: "Dimensions",
                column: "ProductId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Dimensions_Products_ProductId",
                table: "Dimensions",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dimensions_Products_ProductId1",
                table: "Dimensions",
                column: "ProductId1",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
