using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forshen.ERP.ProductManagement.Migrations
{
    /// <inheritdoc />
    public partial class ChangesForBatch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MainVariant",
                table: "Variants",
                newName: "IsMainVariant");

            migrationBuilder.AddColumn<int>(
                name: "MainVariantId",
                table: "Variants",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BatchId",
                table: "DimensionValues",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Dimensions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Batch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductionDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ExpireDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batch", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Variants_MainVariantId",
                table: "Variants",
                column: "MainVariantId");

            migrationBuilder.CreateIndex(
                name: "IX_DimensionValues_BatchId",
                table: "DimensionValues",
                column: "BatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_DimensionValues_Batch_BatchId",
                table: "DimensionValues",
                column: "BatchId",
                principalTable: "Batch",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Variants_Variants_MainVariantId",
                table: "Variants",
                column: "MainVariantId",
                principalTable: "Variants",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DimensionValues_Batch_BatchId",
                table: "DimensionValues");

            migrationBuilder.DropForeignKey(
                name: "FK_Variants_Variants_MainVariantId",
                table: "Variants");

            migrationBuilder.DropTable(
                name: "Batch");

            migrationBuilder.DropIndex(
                name: "IX_Variants_MainVariantId",
                table: "Variants");

            migrationBuilder.DropIndex(
                name: "IX_DimensionValues_BatchId",
                table: "DimensionValues");

            migrationBuilder.DropColumn(
                name: "MainVariantId",
                table: "Variants");

            migrationBuilder.DropColumn(
                name: "BatchId",
                table: "DimensionValues");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Dimensions");

            migrationBuilder.RenameColumn(
                name: "IsMainVariant",
                table: "Variants",
                newName: "MainVariant");
        }
    }
}
