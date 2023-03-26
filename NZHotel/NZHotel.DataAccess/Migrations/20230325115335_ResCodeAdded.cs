using Microsoft.EntityFrameworkCore.Migrations;

namespace NZHotel.DataAccess.Migrations
{
    public partial class ResCodeAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReservationCode",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReservationCode",
                table: "Reservations");
        }
    }
}
