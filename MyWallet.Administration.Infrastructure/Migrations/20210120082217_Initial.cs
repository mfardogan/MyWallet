using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyWallet.Administration.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "user");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "administrator",
                schema: "user",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    name = table.Column<string>(type: "text", nullable: false),
                    surname = table.Column<string>(type: "text", nullable: false),
                    fullName = table.Column<string>(type: "text", nullable: true),
                    creationAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    RowGuid = table.Column<Guid>(type: "uuid", nullable: true, defaultValueSql: "uuid_generate_v4()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_administrator", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "administrator_password",
                schema: "user",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    hash = table.Column<byte[]>(type: "bytea", nullable: false),
                    salt = table.Column<byte[]>(type: "bytea", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    RowGuid = table.Column<Guid>(type: "uuid", nullable: true, defaultValueSql: "uuid_generate_v4()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_administrator_password", x => x.id);
                    table.ForeignKey(
                        name: "FK_administrator_password_administrator_id",
                        column: x => x.id,
                        principalSchema: "user",
                        principalTable: "administrator",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "administrator_password",
                schema: "user");

            migrationBuilder.DropTable(
                name: "administrator",
                schema: "user");
        }
    }
}
