using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeSheet.Data.Migrations
{
    /// <inheritdoc />
    public partial class PassHash : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Employees",
                newName: "PasswordHash");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "Employees",
                newName: "Password");
        }
    }
}
