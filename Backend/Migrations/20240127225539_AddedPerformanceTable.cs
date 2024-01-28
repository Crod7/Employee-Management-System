using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    public partial class AddedPerformanceTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Performance_Employee_EmployeeId",
                table: "Performance");

            migrationBuilder.AddForeignKey(
                name: "FK_Performance_Employee_EmployeeId",
                table: "Performance",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Performance_Employee_EmployeeId",
                table: "Performance");

            migrationBuilder.AddForeignKey(
                name: "FK_Performance_Employee_EmployeeId",
                table: "Performance",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "EmployeeId");
        }
    }
}
