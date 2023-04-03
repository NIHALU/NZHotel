using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NZHotel.DataAccess.Migrations
{
    public partial class AddedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.DropColumn(
                name: "EmployeeDetailId",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "ShiftId",
                table: "Employees",
                newName: "EmployeeFileId");

            migrationBuilder.CreateTable(
                name: "EmployeeFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HourlyWage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MonthlyWage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DailyWage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OvertimeWage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DailyWorkingHour = table.Column<int>(type: "int", nullable: true),
                    MonthlyWorkingDay = table.Column<int>(type: "int", nullable: true),
                    OvertimeNumber = table.Column<int>(type: "int", nullable: true),
                    OffDay = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkingTypeId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeFiles_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeFiles_WorkingTypes_WorkingTypeId",
                        column: x => x.WorkingTypeId,
                        principalTable: "WorkingTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeFiles_EmployeeId",
                table: "EmployeeFiles",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeFiles_WorkingTypeId",
                table: "EmployeeFiles",
                column: "WorkingTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeFiles");

            migrationBuilder.RenameColumn(
                name: "EmployeeFileId",
                table: "Employees",
                newName: "ShiftId");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeDetailId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EmployeeDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    DailyWage = table.Column<decimal>(type: "decimal(8,2)", nullable: true),
                    DailyWorkingHour = table.Column<int>(type: "int", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    HourlyWage = table.Column<decimal>(type: "decimal(8,2)", nullable: true),
                    MonthlyWage = table.Column<decimal>(type: "decimal(8,2)", nullable: true),
                    MonthlyWorkingDay = table.Column<int>(type: "int", nullable: true),
                    OffDay = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OvertimeNumber = table.Column<int>(type: "int", nullable: true),
                    OvertimeWage = table.Column<decimal>(type: "decimal(8,2)", nullable: true),
                    Salary = table.Column<decimal>(type: "decimal(8,2)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WorkingTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeDetails_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeDetails_WorkingTypes_WorkingTypeId",
                        column: x => x.WorkingTypeId,
                        principalTable: "WorkingTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shifts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Evening = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Morning = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Noon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shifts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shifts_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDetails_EmployeeId",
                table: "EmployeeDetails",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDetails_WorkingTypeId",
                table: "EmployeeDetails",
                column: "WorkingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_EmployeeId",
                table: "Shifts",
                column: "EmployeeId",
                unique: true);
        }
    }
}
