using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Backend.Migrations
{
    public partial class AddedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Employees",
                newName: "TimeOffRequestId");

            migrationBuilder.AlterColumn<int>(
                name: "TimeOffRequestId",
                table: "Employees",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Employees",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "PerformanceId",
                table: "Employees",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ScheduleId",
                table: "Employees",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "EmployeeId");

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    ScheduleId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MondayStart = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MondayEnd = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TuesdayStart = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TuesdayEnd = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    WednesdayStart = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    WednesdayEnd = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ThursdayStart = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ThursdayEnd = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FridayStart = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FridayEnd = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SaturdayStart = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SaturdayEnd = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SundayStart = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SundayEnd = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.ScheduleId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ScheduleId",
                table: "Employees",
                column: "ScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Schedule_ScheduleId",
                table: "Employees",
                column: "ScheduleId",
                principalTable: "Schedule",
                principalColumn: "ScheduleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Schedule_ScheduleId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ScheduleId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PerformanceId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ScheduleId",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "TimeOffRequestId",
                table: "Employees",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Employees",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Id");
        }
    }
}
