using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeManagement.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class addedEmployeeandLeavesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a0f85c3e-4f68-4a8c-9c92-7aabc1234567"));

            migrationBuilder.RenameColumn(
                name: "FatherName",
                table: "employees",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Designation",
                table: "employees",
                newName: "Email");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "employees",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateOnly>(
                name: "JoiningDate",
                table: "employees",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "employees",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId1",
                table: "employees",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Leaves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LeaveType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leaves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Leaves_employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d0b85c3e-4f68-4a8c-9c92-7aabc1234567"),
                column: "ConcurrencyStamp",
                value: "801b126f-1c8f-44ca-bdda-f0a48d81ed59");

            migrationBuilder.CreateIndex(
                name: "IX_employees_UserId1",
                table: "employees",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Leaves_EmployeeId",
                table: "Leaves",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_employees_AspNetUsers_UserId1",
                table: "employees",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employees_AspNetUsers_UserId1",
                table: "employees");

            migrationBuilder.DropTable(
                name: "Leaves");

            migrationBuilder.DropIndex(
                name: "IX_employees_UserId1",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "JoiningDate",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "employees");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "employees",
                newName: "FatherName");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "employees",
                newName: "Designation");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "employees",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d0b85c3e-4f68-4a8c-9c92-7aabc1234567"),
                column: "ConcurrencyStamp",
                value: "041c7219-432e-4df6-afbf-bdf21ac51e8c");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Department", "Designation", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Pin", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("a0f85c3e-4f68-4a8c-9c92-7aabc1234567"), 0, "74a03c15-cc24-4df8-bde1-904abe13c257", null, null, "admin@gmail.com", true, null, null, false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEHePA6bxEiGh4aoCf4rEOSKyQujy2QkRXlD8sqAdyIlTr798TODq0BGz2uD0+IpLeg==", null, false, null, "43ef8181-c6f8-4de5-bb78-7de032eaec0b", false, false, "admin" });
        }
    }
}
