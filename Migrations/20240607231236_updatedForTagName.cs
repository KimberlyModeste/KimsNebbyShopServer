using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KimsNebbyShopServer.Migrations
{
    /// <inheritdoc />
    public partial class updatedForTagName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TagName",
                table: "TagConnectors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TagName",
                table: "TagConnectors");
        }
    }
}
