using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IoTAPI.Migrations
{
    /// <inheritdoc />
    public partial class Correcao2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Ativo",
                table: "User",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Ativo",
                table: "Produto",
                type: "integer",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<int>(
                name: "Ativo",
                table: "CatSub",
                type: "integer",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "User");

            migrationBuilder.AlterColumn<bool>(
                name: "Ativo",
                table: "Produto",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<bool>(
                name: "Ativo",
                table: "CatSub",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }
    }
}
