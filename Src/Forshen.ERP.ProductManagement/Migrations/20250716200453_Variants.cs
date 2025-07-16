using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forshen.ERP.ProductManagement.Migrations
{
    /// <inheritdoc />
    public partial class Variants : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Variants");

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

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Variants",
                type: "nvarchar(254)",
                maxLength: 254,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Variants",
                table: "Variants",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Dimensions_ProductId",
                table: "Dimensions",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Dimensions_ProductId1",
                table: "Dimensions",
                column: "ProductId1");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dimensions_Variants_ProductId",
                table: "Dimensions");

            migrationBuilder.DropForeignKey(
                name: "FK_Dimensions_Variants_ProductId1",
                table: "Dimensions");

            migrationBuilder.DropIndex(
                name: "IX_Dimensions_ProductId",
                table: "Dimensions");

            migrationBuilder.DropIndex(
                name: "IX_Dimensions_ProductId1",
                table: "Dimensions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Variants",
                table: "Variants");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Dimensions");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "Dimensions");

            migrationBuilder.RenameTable(
                name: "Variants",
                newName: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(254)",
                oldMaxLength: 254);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");
        }
    }
}
