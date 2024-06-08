using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KimsNebbyShopServer.Migrations
{
    /// <inheritdoc />
    public partial class updatedTCWith : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TagConnectors_Items_ItemId",
                table: "TagConnectors");

            migrationBuilder.DropForeignKey(
                name: "FK_TagConnectors_Tags_TagId",
                table: "TagConnectors");

            migrationBuilder.AlterColumn<int>(
                name: "TagId",
                table: "TagConnectors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "TagConnectors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_TagConnectors_Items_ItemId",
                table: "TagConnectors",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TagConnectors_Tags_TagId",
                table: "TagConnectors",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TagConnectors_Items_ItemId",
                table: "TagConnectors");

            migrationBuilder.DropForeignKey(
                name: "FK_TagConnectors_Tags_TagId",
                table: "TagConnectors");

            migrationBuilder.AlterColumn<int>(
                name: "TagId",
                table: "TagConnectors",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "TagConnectors",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TagConnectors_Items_ItemId",
                table: "TagConnectors",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TagConnectors_Tags_TagId",
                table: "TagConnectors",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
