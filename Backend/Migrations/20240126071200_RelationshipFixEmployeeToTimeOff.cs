using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    public partial class RelationshipFixEmployeeToTimeOff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_PayGrade_PayGradeId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_PersonalInfo_PersonalInfoId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Role_RoleId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Schedule_ScheduleId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Performance_Employees_EmployeeId",
                table: "Performance");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeOffRequest_Employees_EmployeeId",
                table: "TimeOffRequest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Employee");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_ScheduleId",
                table: "Employee",
                newName: "IX_Employee_ScheduleId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_RoleId",
                table: "Employee",
                newName: "IX_Employee_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_PersonalInfoId",
                table: "Employee",
                newName: "IX_Employee_PersonalInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_PayGradeId",
                table: "Employee",
                newName: "IX_Employee_PayGradeId");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "TimeOffRequest",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Performance",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                table: "Employee",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_PayGrade_PayGradeId",
                table: "Employee",
                column: "PayGradeId",
                principalTable: "PayGrade",
                principalColumn: "PayGradeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_PersonalInfo_PersonalInfoId",
                table: "Employee",
                column: "PersonalInfoId",
                principalTable: "PersonalInfo",
                principalColumn: "PersonalInfoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Role_RoleId",
                table: "Employee",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Schedule_ScheduleId",
                table: "Employee",
                column: "ScheduleId",
                principalTable: "Schedule",
                principalColumn: "ScheduleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Performance_Employee_EmployeeId",
                table: "Performance",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeOffRequest_Employee_EmployeeId",
                table: "TimeOffRequest",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_PayGrade_PayGradeId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_PersonalInfo_PersonalInfoId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Role_RoleId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Schedule_ScheduleId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Performance_Employee_EmployeeId",
                table: "Performance");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeOffRequest_Employee_EmployeeId",
                table: "TimeOffRequest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee",
                table: "Employee");

            migrationBuilder.RenameTable(
                name: "Employee",
                newName: "Employees");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_ScheduleId",
                table: "Employees",
                newName: "IX_Employees_ScheduleId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_RoleId",
                table: "Employees",
                newName: "IX_Employees_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_PersonalInfoId",
                table: "Employees",
                newName: "IX_Employees_PersonalInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_PayGradeId",
                table: "Employees",
                newName: "IX_Employees_PayGradeId");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "TimeOffRequest",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Performance",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "EmployeeId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Role_RoleId",
                table: "Employees",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Schedule_ScheduleId",
                table: "Employees",
                column: "ScheduleId",
                principalTable: "Schedule",
                principalColumn: "ScheduleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Performance_Employees_EmployeeId",
                table: "Performance",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeOffRequest_Employees_EmployeeId",
                table: "TimeOffRequest",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
