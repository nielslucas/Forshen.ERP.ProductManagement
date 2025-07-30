using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forshen.ERP.ProductManagement.Migrations
{
    /// <inheritdoc />
    public partial class VariantName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Variants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Variants");
        }
    }
}
