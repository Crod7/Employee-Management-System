using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    public partial class AddedCascadeToEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_PersonalInfo_PersonalInfoId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Schedule_ScheduleId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeOffRequest_Employee_EmployeeId",
                table: "TimeOffRequest");

            migrationBuilder.AlterColumn<int>(
                name: "ScheduleId",
                table: "Employee",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "PersonalInfoId",
                table: "Employee",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_PersonalInfo_PersonalInfoId",
                table: "Employee",
                column: "PersonalInfoId",
                principalTable: "PersonalInfo",
                principalColumn: "PersonalInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Schedule_ScheduleId",
                table: "Employee",
                column: "ScheduleId",
                principalTable: "Schedule",
                principalColumn: "ScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeOffRequest_Employee_EmployeeId",
                table: "TimeOffRequest",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_PersonalInfo_PersonalInfoId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Schedule_ScheduleId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeOffRequest_Employee_EmployeeId",
                table: "TimeOffRequest");

            migrationBuilder.AlterColumn<int>(
                name: "ScheduleId",
                table: "Employee",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PersonalInfoId",
                table: "Employee",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_PersonalInfo_PersonalInfoId",
                table: "Employee",
                column: "PersonalInfoId",
                principalTable: "PersonalInfo",
                principalColumn: "PersonalInfoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Schedule_ScheduleId",
                table: "Employee",
                column: "ScheduleId",
                principalTable: "Schedule",
                principalColumn: "ScheduleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeOffRequest_Employee_EmployeeId",
                table: "TimeOffRequest",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "EmployeeId");
        }
    }
}
