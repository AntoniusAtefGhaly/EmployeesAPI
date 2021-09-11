using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeesAPI.Migrations
{
    public partial class taxsedit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeTaxs",
                table: "EmployeeTaxs");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "EmployeeTaxs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeTaxs",
                table: "EmployeeTaxs",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeTaxs",
                table: "EmployeeTaxs");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EmployeeTaxs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeTaxs",
                table: "EmployeeTaxs",
                column: "Tax");
        }
    }
}
