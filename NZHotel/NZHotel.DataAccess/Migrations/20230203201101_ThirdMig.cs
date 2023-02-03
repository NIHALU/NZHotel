using Microsoft.EntityFrameworkCore.Migrations;

namespace NZHotel.DataAccess.Migrations
{
    public partial class ThirdMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_RoomStatuses_RoomStatusId",
                table: "Rooms");

            migrationBuilder.AlterColumn<int>(
                name: "RoomStatusId",
                table: "Rooms",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "BedInfo",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoomName",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasJakuzi",
                table: "RoomDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasSafeDepositBox",
                table: "RoomDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasWashingMashine",
                table: "RoomDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_RoomStatuses_RoomStatusId",
                table: "Rooms",
                column: "RoomStatusId",
                principalTable: "RoomStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_RoomStatuses_RoomStatusId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "BedInfo",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "RoomName",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "HasJakuzi",
                table: "RoomDetails");

            migrationBuilder.DropColumn(
                name: "HasSafeDepositBox",
                table: "RoomDetails");

            migrationBuilder.DropColumn(
                name: "HasWashingMashine",
                table: "RoomDetails");

            migrationBuilder.AlterColumn<int>(
                name: "RoomStatusId",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_RoomStatuses_RoomStatusId",
                table: "Rooms",
                column: "RoomStatusId",
                principalTable: "RoomStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
