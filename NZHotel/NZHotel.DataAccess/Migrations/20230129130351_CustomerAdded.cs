using Microsoft.EntityFrameworkCore.Migrations;

namespace NZHotel.DataAccess.Migrations
{
    public partial class CustomerAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Rooms_RoomId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_RoomStatuses_RoomStatusId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_RoomId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ContactEmail",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ContactName",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ContactSurname",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "RoomStatusId",
                table: "Reservations",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_RoomStatusId",
                table: "Reservations",
                newName: "IX_Reservations_CustomerId");

            migrationBuilder.AddColumn<int>(
                name: "RoomStatusId",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ContactSurname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ContactEmail = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ContactPhone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    IsTurkish = table.Column<bool>(type: "bit", nullable: false),
                    TurkishIDNo = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    PassportNo = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Adress = table.Column<string>(type: "ntext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoomStatusId",
                table: "Rooms",
                column: "RoomStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Customer_CustomerId",
                table: "Reservations",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_RoomStatuses_RoomStatusId",
                table: "Rooms",
                column: "RoomStatusId",
                principalTable: "RoomStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Customer_CustomerId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_RoomStatuses_RoomStatusId",
                table: "Rooms");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_RoomStatusId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "RoomStatusId",
                table: "Rooms");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Reservations",
                newName: "RoomStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_CustomerId",
                table: "Reservations",
                newName: "IX_Reservations_RoomStatusId");

            migrationBuilder.AddColumn<string>(
                name: "ContactEmail",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactName",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactSurname",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Reservations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_RoomId",
                table: "Reservations",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Rooms_RoomId",
                table: "Reservations",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_RoomStatuses_RoomStatusId",
                table: "Reservations",
                column: "RoomStatusId",
                principalTable: "RoomStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
