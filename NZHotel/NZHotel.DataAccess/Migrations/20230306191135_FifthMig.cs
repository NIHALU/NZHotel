using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NZHotel.DataAccess.Migrations
{
    public partial class FifthMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GuestDetail");

            migrationBuilder.RenameColumn(
                name: "ReservationOptions",
                table: "Reservations",
                newName: "ReservationOptionId");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Reservations",
                type: "bit",
                nullable: false,
                defaultValueSql: "true",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<DateTime>(
                name: "PaymentDeadline",
                table: "Reservations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TurkishIDNo",
                table: "Customers",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<string>(
                name: "PassportNo",
                table: "Customers",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Customers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "GuestReservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuestId = table.Column<int>(type: "int", nullable: false),
                    ReservationId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestReservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GuestReservations_Guests_GuestId",
                        column: x => x.GuestId,
                        principalTable: "Guests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GuestReservations_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReservationOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Definition = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationOptions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ReservationOptionId",
                table: "Reservations",
                column: "ReservationOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_GuestReservations_GuestId_ReservationId",
                table: "GuestReservations",
                columns: new[] { "GuestId", "ReservationId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GuestReservations_ReservationId",
                table: "GuestReservations",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_ReservationOptions_ReservationOptionId",
                table: "Reservations",
                column: "ReservationOptionId",
                principalTable: "ReservationOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_ReservationOptions_ReservationOptionId",
                table: "Reservations");

            migrationBuilder.DropTable(
                name: "GuestReservations");

            migrationBuilder.DropTable(
                name: "ReservationOptions");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_ReservationOptionId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "PaymentDeadline",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "ReservationOptionId",
                table: "Reservations",
                newName: "ReservationOptions");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Reservations",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValueSql: "true");

            migrationBuilder.AlterColumn<string>(
                name: "TurkishIDNo",
                table: "Customers",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PassportNo",
                table: "Customers",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Customers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.CreateTable(
                name: "GuestDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GuestTypeId = table.Column<int>(type: "int", nullable: true),
                    IdentityNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsTurkish = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassportNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReservationId = table.Column<int>(type: "int", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GuestDetail_GuestTypes_GuestTypeId",
                        column: x => x.GuestTypeId,
                        principalTable: "GuestTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GuestDetail_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GuestDetail_GuestTypeId",
                table: "GuestDetail",
                column: "GuestTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GuestDetail_ReservationId",
                table: "GuestDetail",
                column: "ReservationId");
        }
    }
}
