using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Turquoise.Administration.Infrastructure.SQL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "user");

            migrationBuilder.EnsureSchema(
                name: "survey");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "administrator",
                schema: "user",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "varchar(20)", nullable: false),
                    surname = table.Column<string>(type: "varchar(20)", nullable: false),
                    full_name = table.Column<string>(type: "text", nullable: true),
                    creationAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    row_guid = table.Column<Guid>(type: "uuid", nullable: true),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_administrator", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "branch",
                schema: "user",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "varchar(20)", nullable: false),
                    code = table.Column<string>(type: "varchar(3)", nullable: false),
                    row_guid = table.Column<Guid>(type: "uuid", nullable: true),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_branch", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "choice_group",
                schema: "survey",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "varchar(20)", nullable: false),
                    code = table.Column<string>(type: "varchar(3)", nullable: false),
                    row_guid = table.Column<Guid>(type: "uuid", nullable: true),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_choice_group", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "administrator_password",
                schema: "user",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    hash = table.Column<byte[]>(type: "bytea", nullable: false),
                    salt = table.Column<byte[]>(type: "bytea", nullable: false),
                    row_guid = table.Column<Guid>(type: "uuid", nullable: true, defaultValueSql: "uuid_generate_v4()")
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

            migrationBuilder.CreateTable(
                name: "doctor",
                schema: "user",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "varchar(20)", nullable: false),
                    surname = table.Column<string>(type: "varchar(20)", nullable: false),
                    full_name = table.Column<string>(type: "text", nullable: true),
                    creationAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    branch_id = table.Column<Guid>(type: "uuid", nullable: true),
                    row_guid = table.Column<Guid>(type: "uuid", nullable: true),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doctor", x => x.id);
                    table.ForeignKey(
                        name: "FK_doctor_branch_branch_id",
                        column: x => x.branch_id,
                        principalSchema: "user",
                        principalTable: "branch",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "choice",
                schema: "survey",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "varchar(20)", nullable: false),
                    code = table.Column<string>(type: "varchar(3)", nullable: false),
                    number = table.Column<long>(type: "bigint", nullable: false),
                    color = table.Column<string>(type: "varchar(6)", nullable: false),
                    description = table.Column<string>(type: "varchar", nullable: true),
                    choice_group_id = table.Column<Guid>(type: "uuid", nullable: false),
                    row_guid = table.Column<Guid>(type: "uuid", nullable: true),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_choice", x => x.id);
                    table.ForeignKey(
                        name: "FK_choice_choice_group_choice_group_id",
                        column: x => x.choice_group_id,
                        principalSchema: "survey",
                        principalTable: "choice_group",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_choice_choice_group_id",
                schema: "survey",
                table: "choice",
                column: "choice_group_id");

            migrationBuilder.CreateIndex(
                name: "IX_doctor_branch_id",
                schema: "user",
                table: "doctor",
                column: "branch_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "administrator_password",
                schema: "user");

            migrationBuilder.DropTable(
                name: "choice",
                schema: "survey");

            migrationBuilder.DropTable(
                name: "doctor",
                schema: "user");

            migrationBuilder.DropTable(
                name: "administrator",
                schema: "user");

            migrationBuilder.DropTable(
                name: "choice_group",
                schema: "survey");

            migrationBuilder.DropTable(
                name: "branch",
                schema: "user");
        }
    }
}
