using Microsoft.EntityFrameworkCore.Migrations;

namespace NZHotel.DataAccess.Migrations
{
    public partial class AddedShiftTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OffDay",
                table: "Shifts");

            migrationBuilder.AddColumn<string>(
                name: "OffDay",
                table: "EmployeeDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OffDay",
                table: "EmployeeDetails");

            migrationBuilder.AddColumn<string>(
                name: "OffDay",
                table: "Shifts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
