using Microsoft.EntityFrameworkCore.Migrations;

namespace NZHotel.DataAccess.Migrations
{
    public partial class sixthMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Reservations",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValueSql: "true");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Reservations",
                type: "bit",
                nullable: false,
                defaultValueSql: "true",
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
