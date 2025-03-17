using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeManagement.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class addedApprovalColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leaves_employees_EmployeeId",
                table: "Leaves");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Leaves",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApprovedBy",
                table: "Leaves",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d0b85c3e-4f68-4a8c-9c92-7aabc1234567"),
                column: "ConcurrencyStamp",
                value: "e5afa96b-d847-4269-987d-13429ad2cbb0");

            migrationBuilder.AddForeignKey(
                name: "FK_Leaves_employees_EmployeeId",
                table: "Leaves",
                column: "EmployeeId",
                principalTable: "employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leaves_employees_EmployeeId",
                table: "Leaves");

            migrationBuilder.DropColumn(
                name: "ApprovedBy",
                table: "Leaves");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Leaves",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d0b85c3e-4f68-4a8c-9c92-7aabc1234567"),
                column: "ConcurrencyStamp",
                value: "fde21dee-7db9-4448-92d6-bf50ed2aef0b");

            migrationBuilder.AddForeignKey(
                name: "FK_Leaves_employees_EmployeeId",
                table: "Leaves",
                column: "EmployeeId",
                principalTable: "employees",
                principalColumn: "Id");
        }
    }
}
