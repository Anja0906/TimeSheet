using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeSheet.Data.Migrations
{
    /// <inheritdoc />
    public partial class FinalIHope : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Employees_EmplyeeId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkingHours_Employees_EmplyeeId",
                table: "WorkingHours");

            migrationBuilder.AlterColumn<int>(
                name: "EmplyeeId",
                table: "WorkingHours",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Employees_EmplyeeId",
                table: "Projects",
                column: "EmplyeeId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingHours_Employees_EmplyeeId",
                table: "WorkingHours",
                column: "EmplyeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Employees_EmplyeeId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkingHours_Employees_EmplyeeId",
                table: "WorkingHours");

            migrationBuilder.AlterColumn<int>(
                name: "EmplyeeId",
                table: "WorkingHours",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Employees_EmplyeeId",
                table: "Projects",
                column: "EmplyeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingHours_Employees_EmplyeeId",
                table: "WorkingHours",
                column: "EmplyeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
