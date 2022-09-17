using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MCV.Test.API.Migrations
{
    public partial class Intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    HiringDate = table.Column<DateTime>(nullable: false),
                    DepartmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Engineering" },
                    { 2, "IT" },
                    { 3, "CS" },
                    { 4, "AI" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "BirthDate", "DepartmentId", "HiringDate", "Name", "Title" },
                values: new object[] { 1, new DateTime(1998, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2020, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ahmed", "Software Engineer" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "BirthDate", "DepartmentId", "HiringDate", "Name", "Title" },
                values: new object[] { 2, new DateTime(1998, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2021, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mohamed", "Architect" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "BirthDate", "DepartmentId", "HiringDate", "Name", "Title" },
                values: new object[] { 3, new DateTime(1998, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2022, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sayed", "Doctor" });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
