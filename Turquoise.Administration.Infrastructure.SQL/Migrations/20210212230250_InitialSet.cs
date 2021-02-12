using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Turquoise.Administration.Infrastructure.SQL.Migrations
{
    public partial class InitialSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "doctor_id",
                schema: "survey",
                table: "survey_answer",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_survey_answer_doctor_id",
                schema: "survey",
                table: "survey_answer",
                column: "doctor_id");

            migrationBuilder.AddForeignKey(
                name: "FK_survey_answer_doctor_doctor_id",
                schema: "survey",
                table: "survey_answer",
                column: "doctor_id",
                principalSchema: "user",
                principalTable: "doctor",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_survey_answer_doctor_doctor_id",
                schema: "survey",
                table: "survey_answer");

            migrationBuilder.DropIndex(
                name: "IX_survey_answer_doctor_id",
                schema: "survey",
                table: "survey_answer");

            migrationBuilder.DropColumn(
                name: "doctor_id",
                schema: "survey",
                table: "survey_answer");
        }
    }
}
