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
                    creation_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "now()"),
                    row_guid = table.Column<Guid>(type: "uuid", nullable: true, defaultValueSql: "uuid_generate_v4()"),
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
                    row_guid = table.Column<Guid>(type: "uuid", nullable: true, defaultValueSql: "uuid_generate_v4()"),
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
                    row_guid = table.Column<Guid>(type: "uuid", nullable: true, defaultValueSql: "uuid_generate_v4()"),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_choice_group", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "survey_answer",
                schema: "survey",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    creation_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "now()"),
                    row_guid = table.Column<Guid>(type: "uuid", nullable: true, defaultValueSql: "uuid_generate_v4()"),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_survey_answer", x => x.id);
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
                    creation_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "now()"),
                    branch_id = table.Column<Guid>(type: "uuid", nullable: true),
                    row_guid = table.Column<Guid>(type: "uuid", nullable: true, defaultValueSql: "uuid_generate_v4()"),
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
                    row_guid = table.Column<Guid>(type: "uuid", nullable: true, defaultValueSql: "uuid_generate_v4()"),
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

            migrationBuilder.CreateTable(
                name: "survey",
                schema: "survey",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    status = table.Column<byte>(type: "smallint", nullable: false),
                    title = table.Column<string>(type: "varchar(100)", nullable: true),
                    body = table.Column<string>(type: "varchar(1000)", nullable: true),
                    image = table.Column<byte[]>(type: "bytea", nullable: false),
                    creation_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "now()"),
                    choice_group_id = table.Column<Guid>(type: "uuid", nullable: false),
                    branch_id = table.Column<Guid>(type: "uuid", nullable: true),
                    row_guid = table.Column<Guid>(type: "uuid", nullable: true, defaultValueSql: "uuid_generate_v4()"),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_survey", x => x.id);
                    table.ForeignKey(
                        name: "FK_survey_branch_branch_id",
                        column: x => x.branch_id,
                        principalSchema: "user",
                        principalTable: "branch",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_survey_choice_group_choice_group_id",
                        column: x => x.choice_group_id,
                        principalSchema: "survey",
                        principalTable: "choice_group",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "survey_answer_choice",
                schema: "survey",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    survey_answer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    choice_id = table.Column<Guid>(type: "uuid", nullable: false),
                    coordinates = table.Column<string>(type: "varchar", nullable: false),
                    drawing_type = table.Column<byte>(type: "smallint", nullable: false),
                    row_guid = table.Column<Guid>(type: "uuid", nullable: true, defaultValueSql: "uuid_generate_v4()"),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_survey_answer_choice", x => x.id);
                    table.ForeignKey(
                        name: "FK_survey_answer_choice_choice_choice_id",
                        column: x => x.choice_id,
                        principalSchema: "survey",
                        principalTable: "choice",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_survey_answer_choice_survey_answer_survey_answer_id",
                        column: x => x.survey_answer_id,
                        principalSchema: "survey",
                        principalTable: "survey_answer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "survey_branch",
                schema: "survey",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    survey_id = table.Column<Guid>(type: "uuid", nullable: false),
                    branch_id = table.Column<Guid>(type: "uuid", nullable: false),
                    row_guid = table.Column<Guid>(type: "uuid", nullable: true, defaultValueSql: "uuid_generate_v4()"),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_survey_branch", x => x.id);
                    table.ForeignKey(
                        name: "FK_survey_branch_branch_branch_id",
                        column: x => x.branch_id,
                        principalSchema: "user",
                        principalTable: "branch",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_survey_branch_survey_survey_id",
                        column: x => x.survey_id,
                        principalSchema: "survey",
                        principalTable: "survey",
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

            migrationBuilder.CreateIndex(
                name: "IX_survey_branch_id",
                schema: "survey",
                table: "survey",
                column: "branch_id");

            migrationBuilder.CreateIndex(
                name: "IX_survey_choice_group_id",
                schema: "survey",
                table: "survey",
                column: "choice_group_id");

            migrationBuilder.CreateIndex(
                name: "IX_survey_answer_choice_choice_id",
                schema: "survey",
                table: "survey_answer_choice",
                column: "choice_id");

            migrationBuilder.CreateIndex(
                name: "IX_survey_answer_choice_survey_answer_id",
                schema: "survey",
                table: "survey_answer_choice",
                column: "survey_answer_id");

            migrationBuilder.CreateIndex(
                name: "IX_survey_branch_branch_id",
                schema: "survey",
                table: "survey_branch",
                column: "branch_id");

            migrationBuilder.CreateIndex(
                name: "IX_survey_branch_survey_id",
                schema: "survey",
                table: "survey_branch",
                column: "survey_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "administrator_password",
                schema: "user");

            migrationBuilder.DropTable(
                name: "doctor",
                schema: "user");

            migrationBuilder.DropTable(
                name: "survey_answer_choice",
                schema: "survey");

            migrationBuilder.DropTable(
                name: "survey_branch",
                schema: "survey");

            migrationBuilder.DropTable(
                name: "administrator",
                schema: "user");

            migrationBuilder.DropTable(
                name: "choice",
                schema: "survey");

            migrationBuilder.DropTable(
                name: "survey_answer",
                schema: "survey");

            migrationBuilder.DropTable(
                name: "survey",
                schema: "survey");

            migrationBuilder.DropTable(
                name: "branch",
                schema: "user");

            migrationBuilder.DropTable(
                name: "choice_group",
                schema: "survey");
        }
    }
}
