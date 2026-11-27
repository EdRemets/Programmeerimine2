using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KooliProjekt.Application.Migrations
{
    /// <inheritdoc />
    public partial class AddClients : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Operations_Workers_workerid",
                table: "Operations");

            migrationBuilder.AlterColumn<int>(
                name: "workerid",
                table: "Operations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "clientid",
                table: "Cars",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    userName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    passwordHash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_clientid",
                table: "Cars",
                column: "clientid");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Clients_clientid",
                table: "Cars",
                column: "clientid",
                principalTable: "Clients",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Operations_Workers_workerid",
                table: "Operations",
                column: "workerid",
                principalTable: "Workers",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Clients_clientid",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Operations_Workers_workerid",
                table: "Operations");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Cars_clientid",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "clientid",
                table: "Cars");

            migrationBuilder.AlterColumn<int>(
                name: "workerid",
                table: "Operations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Operations_Workers_workerid",
                table: "Operations",
                column: "workerid",
                principalTable: "Workers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
