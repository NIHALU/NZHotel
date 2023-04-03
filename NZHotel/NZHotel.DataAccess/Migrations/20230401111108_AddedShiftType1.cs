using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NZHotel.DataAccess.Migrations
{
    public partial class AddedShiftType1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Regular",
                table: "Shifts");

            migrationBuilder.RenameColumn(
                name: "ShiftType",
                table: "EmployeeDetails",
                newName: "WorkingTypeId");

            migrationBuilder.CreateTable(
                name: "WorkingTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Definition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDetails_WorkingTypeId",
                table: "EmployeeDetails",
                column: "WorkingTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDetails_WorkingTypes_WorkingTypeId",
                table: "EmployeeDetails",
                column: "WorkingTypeId",
                principalTable: "WorkingTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDetails_WorkingTypes_WorkingTypeId",
                table: "EmployeeDetails");

            migrationBuilder.DropTable(
                name: "WorkingTypes");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeDetails_WorkingTypeId",
                table: "EmployeeDetails");

            migrationBuilder.RenameColumn(
                name: "WorkingTypeId",
                table: "EmployeeDetails",
                newName: "ShiftType");

            migrationBuilder.AddColumn<string>(
                name: "Regular",
                table: "Shifts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
