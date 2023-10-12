using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeSheet.Data.Migrations
{
    /// <inheritdoc />
    public partial class Finals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryWorkingHour");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "WorkingHours",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "WorkingHours",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_WorkingHours_CategoryId",
                table: "WorkingHours",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingHours_Categories_CategoryId",
                table: "WorkingHours",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkingHours_Categories_CategoryId",
                table: "WorkingHours");

            migrationBuilder.DropIndex(
                name: "IX_WorkingHours_CategoryId",
                table: "WorkingHours");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "WorkingHours");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "WorkingHours");

            migrationBuilder.CreateTable(
                name: "CategoryWorkingHour",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    WorkingHourId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryWorkingHour", x => new { x.CategoriesId, x.WorkingHourId });
                    table.ForeignKey(
                        name: "FK_CategoryWorkingHour_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryWorkingHour_WorkingHours_WorkingHourId",
                        column: x => x.WorkingHourId,
                        principalTable: "WorkingHours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryWorkingHour_WorkingHourId",
                table: "CategoryWorkingHour",
                column: "WorkingHourId");
        }
    }
}
