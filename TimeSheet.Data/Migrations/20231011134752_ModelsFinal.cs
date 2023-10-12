using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeSheet.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModelsFinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkingHours_Employees_EmployeeId",
                table: "WorkingHours");

            migrationBuilder.DropIndex(
                name: "IX_WorkingHours_EmployeeId",
                table: "WorkingHours");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "WorkingHours");

            migrationBuilder.AddColumn<int>(
                name: "EmplyeeId",
                table: "WorkingHours",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkingHours_EmplyeeId",
                table: "WorkingHours",
                column: "EmplyeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingHours_Employees_EmplyeeId",
                table: "WorkingHours",
                column: "EmplyeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkingHours_Employees_EmplyeeId",
                table: "WorkingHours");

            migrationBuilder.DropIndex(
                name: "IX_WorkingHours_EmplyeeId",
                table: "WorkingHours");

            migrationBuilder.DropColumn(
                name: "EmplyeeId",
                table: "WorkingHours");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "WorkingHours",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_WorkingHours_EmployeeId",
                table: "WorkingHours",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingHours_Employees_EmployeeId",
                table: "WorkingHours",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
