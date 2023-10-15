using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProTracking.Infrastructures.Migrations
{
    public partial class AddAccountTypeToCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Birthday",
                value: new DateTime(2023, 10, 9, 15, 3, 46, 324, DateTimeKind.Local).AddTicks(6100));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Birthday",
                value: new DateTime(2023, 10, 9, 15, 3, 46, 324, DateTimeKind.Local).AddTicks(6116));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                column: "Birthday",
                value: new DateTime(2023, 10, 9, 14, 41, 4, 384, DateTimeKind.Local).AddTicks(6329));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Birthday",
                value: new DateTime(2023, 10, 9, 14, 41, 4, 384, DateTimeKind.Local).AddTicks(6343));
        }
    }
}
