using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NZHotel.DataAccess.Migrations
{
    public partial class SecondMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRepairing",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "ReparingBeginDate",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "ReparingFinishDate",
                table: "Rooms");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRepairing",
                table: "Rooms",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReparingBeginDate",
                table: "Rooms",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReparingFinishDate",
                table: "Rooms",
                type: "datetime2",
                nullable: true);
        }
    }
}
