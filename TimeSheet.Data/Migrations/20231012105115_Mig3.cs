using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeSheet.Data.Migrations
{
    /// <inheritdoc />
    public partial class Mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Employees_LeaderId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkingHours_Employees_EmplyeeId",
                table: "WorkingHours");

            migrationBuilder.AddColumn<int>(
                name: "EmplyeeId",
                table: "Projects",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_EmplyeeId",
                table: "Projects",
                column: "EmplyeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Employees_EmplyeeId",
                table: "Projects",
                column: "EmplyeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Employees_LeaderId",
                table: "Projects",
                column: "LeaderId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingHours_Employees_EmplyeeId",
                table: "WorkingHours",
                column: "EmplyeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Employees_EmplyeeId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Employees_LeaderId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkingHours_Employees_EmplyeeId",
                table: "WorkingHours");

            migrationBuilder.DropIndex(
                name: "IX_Projects_EmplyeeId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "EmplyeeId",
                table: "Projects");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Employees_LeaderId",
                table: "Projects",
                column: "LeaderId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingHours_Employees_EmplyeeId",
                table: "WorkingHours",
                column: "EmplyeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }
    }
}
