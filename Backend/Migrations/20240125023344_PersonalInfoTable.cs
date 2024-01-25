using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Backend.Migrations
{
    public partial class PersonalInfoTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PayGradeId",
                table: "Employees",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonalInfoId",
                table: "Employees",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PayGrade",
                columns: table => new
                {
                    PayGradeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PayAmount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayGrade", x => x.PayGradeId);
                });

            migrationBuilder.CreateTable(
                name: "PersonalInfo",
                columns: table => new
                {
                    PersonalInfoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SSN = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: false),
                    RoutingNumber = table.Column<long>(type: "bigint", nullable: false),
                    AccountNumber = table.Column<long>(type: "bigint", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    HireDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalInfo", x => x.PersonalInfoId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PayGradeId",
                table: "Employees",
                column: "PayGradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PersonalInfoId",
                table: "Employees",
                column: "PersonalInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_PayGrade_PayGradeId",
                table: "Employees",
                column: "PayGradeId",
                principalTable: "PayGrade",
                principalColumn: "PayGradeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_PersonalInfo_PersonalInfoId",
                table: "Employees",
                column: "PersonalInfoId",
                principalTable: "PersonalInfo",
                principalColumn: "PersonalInfoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_PayGrade_PayGradeId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_PersonalInfo_PersonalInfoId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "PayGrade");

            migrationBuilder.DropTable(
                name: "PersonalInfo");

            migrationBuilder.DropIndex(
                name: "IX_Employees_PayGradeId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_PersonalInfoId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PayGradeId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PersonalInfoId",
                table: "Employees");
        }
    }
}
