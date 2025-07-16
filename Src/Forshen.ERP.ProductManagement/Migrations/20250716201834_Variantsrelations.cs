using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forshen.ERP.ProductManagement.Migrations
{
    /// <inheritdoc />
    public partial class Variantsrelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dimensions_Variants_ProductId",
                table: "Dimensions");

            migrationBuilder.DropForeignKey(
                name: "FK_Dimensions_Variants_ProductId1",
                table: "Dimensions");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Variants");

            migrationBuilder.AddColumn<bool>(
                name: "MainVariant",
                table: "Variants",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Variants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VariantDimensionValue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VariantId = table.Column<int>(type: "int", nullable: false),
                    DimensionValueId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VariantDimensionValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VariantDimensionValue_DimensionValues_DimensionValueId",
                        column: x => x.DimensionValueId,
                        principalTable: "DimensionValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VariantDimensionValue_Variants_VariantId",
                        column: x => x.VariantId,
                        principalTable: "Variants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Variants_ProductId",
                table: "Variants",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_VariantDimensionValue_DimensionValueId",
                table: "VariantDimensionValue",
                column: "DimensionValueId");

            migrationBuilder.CreateIndex(
                name: "IX_VariantDimensionValue_VariantId",
                table: "VariantDimensionValue",
                column: "VariantId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Variants_Products_ProductId",
                table: "Variants",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dimensions_Products_ProductId",
                table: "Dimensions");

            migrationBuilder.DropForeignKey(
                name: "FK_Dimensions_Products_ProductId1",
                table: "Dimensions");

            migrationBuilder.DropForeignKey(
                name: "FK_Variants_Products_ProductId",
                table: "Variants");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "VariantDimensionValue");

            migrationBuilder.DropIndex(
                name: "IX_Variants_ProductId",
                table: "Variants");

            migrationBuilder.DropColumn(
                name: "MainVariant",
                table: "Variants");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Variants");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Variants",
                type: "nvarchar(254)",
                maxLength: 254,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Dimensions_Variants_ProductId",
                table: "Dimensions",
                column: "ProductId",
                principalTable: "Variants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dimensions_Variants_ProductId1",
                table: "Dimensions",
                column: "ProductId1",
                principalTable: "Variants",
                principalColumn: "Id");
        }
    }
}
