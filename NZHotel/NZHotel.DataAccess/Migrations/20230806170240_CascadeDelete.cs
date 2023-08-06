using Microsoft.EntityFrameworkCore.Migrations;

namespace NZHotel.DataAccess.Migrations
{
    public partial class CascadeDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GuestInformation_Reservations_ReservationId",
                table: "GuestInformation");

            migrationBuilder.AddForeignKey(
                name: "FK_GuestInformation_Reservations_ReservationId",
                table: "GuestInformation",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GuestInformation_Reservations_ReservationId",
                table: "GuestInformation");

            migrationBuilder.AddForeignKey(
                name: "FK_GuestInformation_Reservations_ReservationId",
                table: "GuestInformation",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
