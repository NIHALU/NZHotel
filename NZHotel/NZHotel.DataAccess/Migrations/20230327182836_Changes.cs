using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NZHotel.DataAccess.Migrations
{
    public partial class Changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guests_Genders_GenderId",
                table: "Guests");

            migrationBuilder.DropForeignKey(
                name: "FK_Guests_GuestTypes_GuestTypeId",
                table: "Guests");

            migrationBuilder.RenameColumn(
                name: "Definiton",
                table: "GuestTypes",
                newName: "Definition");

            migrationBuilder.RenameColumn(
                name: "Definiton",
                table: "Genders",
                newName: "Definition");

            migrationBuilder.AlterColumn<int>(
                name: "GuestTypeId",
                table: "Guests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GenderId",
                table: "Guests",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "GuestInformation",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_Genders_GenderId",
                table: "Guests",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_GuestTypes_GuestTypeId",
                table: "Guests",
                column: "GuestTypeId",
                principalTable: "GuestTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guests_Genders_GenderId",
                table: "Guests");

            migrationBuilder.DropForeignKey(
                name: "FK_Guests_GuestTypes_GuestTypeId",
                table: "Guests");

            migrationBuilder.RenameColumn(
                name: "Definition",
                table: "GuestTypes",
                newName: "Definiton");

            migrationBuilder.RenameColumn(
                name: "Definition",
                table: "Genders",
                newName: "Definiton");

            migrationBuilder.AlterColumn<int>(
                name: "GuestTypeId",
                table: "Guests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "GenderId",
                table: "Guests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "GuestInformation",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_Genders_GenderId",
                table: "Guests",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_GuestTypes_GuestTypeId",
                table: "Guests",
                column: "GuestTypeId",
                principalTable: "GuestTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
