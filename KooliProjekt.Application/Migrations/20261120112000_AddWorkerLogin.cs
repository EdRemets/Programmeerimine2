using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KooliProjekt.Application.Migrations
{
    /// <inheritdoc />
    public partial class AddWorkerLogin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "passwordHash",
                table: "Workers",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "userName",
                table: "Workers",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Workers_userName",
                table: "Workers",
                column: "userName",
                unique: true,
                filter: "[userName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Workers_userName",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "passwordHash",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "userName",
                table: "Workers");
        }
    }
}
