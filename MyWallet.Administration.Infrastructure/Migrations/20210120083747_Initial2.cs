using Microsoft.EntityFrameworkCore.Migrations;

namespace MyWallet.Administration.Infrastructure.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RowVersion",
                schema: "user",
                table: "administrator_password",
                newName: "row_version");

            migrationBuilder.RenameColumn(
                name: "RowVersion",
                schema: "user",
                table: "administrator",
                newName: "row_version");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "row_version",
                schema: "user",
                table: "administrator_password",
                newName: "RowVersion");

            migrationBuilder.RenameColumn(
                name: "row_version",
                schema: "user",
                table: "administrator",
                newName: "RowVersion");
        }
    }
}
