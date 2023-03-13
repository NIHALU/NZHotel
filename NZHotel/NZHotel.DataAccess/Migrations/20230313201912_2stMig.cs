using Microsoft.EntityFrameworkCore.Migrations;

namespace NZHotel.DataAccess.Migrations
{
    public partial class _2stMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_CleaningStatuses_CleaningStatusId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "GeneralStatus",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "GeneralStatus",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "GeneralStatus",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "GeneralStatus",
                table: "Customers");

            migrationBuilder.AlterColumn<int>(
                name: "CleaningStatusId",
                table: "Rooms",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Reservations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Employees",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Departments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Customers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_CleaningStatuses_CleaningStatusId",
                table: "Rooms",
                column: "CleaningStatusId",
                principalTable: "CleaningStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_CleaningStatuses_CleaningStatusId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Customers");

            migrationBuilder.AlterColumn<int>(
                name: "CleaningStatusId",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GeneralStatus",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GeneralStatus",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GeneralStatus",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GeneralStatus",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_CleaningStatuses_CleaningStatusId",
                table: "Rooms",
                column: "CleaningStatusId",
                principalTable: "CleaningStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
