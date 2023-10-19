using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProTracking.Infrastructures.Migrations
{
    public partial class AddTodoToProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_AccountTypes_AccountTypeId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_AccountTypeId",
                table: "Customers");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Birthday", "RegisteredAt" },
                values: new object[] { new DateTime(2023, 10, 9, 14, 41, 4, 384, DateTimeKind.Local).AddTicks(6329), new DateTime(2023, 10, 9, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Birthday", "RegisteredAt" },
                values: new object[] { new DateTime(2023, 10, 9, 14, 41, 4, 384, DateTimeKind.Local).AddTicks(6343), new DateTime(2023, 10, 9, 0, 0, 0, 0, DateTimeKind.Local) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Birthday", "RegisteredAt" },
                values: new object[] { new DateTime(2023, 9, 26, 9, 56, 10, 877, DateTimeKind.Local).AddTicks(3175), new DateTime(2023, 9, 26, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Birthday", "RegisteredAt" },
                values: new object[] { new DateTime(2023, 9, 26, 9, 56, 10, 877, DateTimeKind.Local).AddTicks(3191), new DateTime(2023, 9, 26, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AccountTypeId",
                table: "Customers",
                column: "AccountTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_AccountTypes_AccountTypeId",
                table: "Customers",
                column: "AccountTypeId",
                principalTable: "AccountTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
