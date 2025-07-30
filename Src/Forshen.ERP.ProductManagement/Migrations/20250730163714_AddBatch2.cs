using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forshen.ERP.ProductManagement.Migrations
{
    /// <inheritdoc />
    public partial class AddBatch2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batch_DimensionValues_DimensionValueId",
                table: "Batch");

            migrationBuilder.DropIndex(
                name: "IX_Batch_DimensionValueId",
                table: "Batch");

            migrationBuilder.DropColumn(
                name: "DimensionValueId",
                table: "Batch");

            migrationBuilder.AddColumn<int>(
                name: "BatchId",
                table: "DimensionValues",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DimensionValues_BatchId",
                table: "DimensionValues",
                column: "BatchId",
                unique: true,
                filter: "[BatchId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_DimensionValues_Batch_BatchId",
                table: "DimensionValues",
                column: "BatchId",
                principalTable: "Batch",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DimensionValues_Batch_BatchId",
                table: "DimensionValues");

            migrationBuilder.DropIndex(
                name: "IX_DimensionValues_BatchId",
                table: "DimensionValues");

            migrationBuilder.DropColumn(
                name: "BatchId",
                table: "DimensionValues");

            migrationBuilder.AddColumn<int>(
                name: "DimensionValueId",
                table: "Batch",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Batch_DimensionValueId",
                table: "Batch",
                column: "DimensionValueId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Batch_DimensionValues_DimensionValueId",
                table: "Batch",
                column: "DimensionValueId",
                principalTable: "DimensionValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
