using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogApi.Migrations
{
    /// <inheritdoc />
    public partial class AddNewColumnAndType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Bloggers",
                type: "varchar(30)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Bloggers",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Bloggers",
                type: "longtext",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Bloggers");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Bloggers",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(30)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Bloggers",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
