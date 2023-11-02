using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProTracking.Infrastructures.Migrations
{
    public partial class SecondInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBanking",
                table: "TransactionHistory",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Birthday", "RegisteredAt" },
                values: new object[] { new DateTime(2023, 10, 29, 12, 17, 11, 569, DateTimeKind.Local).AddTicks(5323), new DateTime(2023, 10, 29, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Birthday", "RegisteredAt" },
                values: new object[] { new DateTime(2023, 10, 29, 12, 17, 11, 569, DateTimeKind.Local).AddTicks(5335), new DateTime(2023, 10, 29, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 11, 5, 12, 17, 11, 569, DateTimeKind.Local).AddTicks(5383), new DateTime(2023, 10, 29, 12, 17, 11, 569, DateTimeKind.Local).AddTicks(5382) });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 11, 5, 12, 17, 11, 569, DateTimeKind.Local).AddTicks(5387), new DateTime(2023, 10, 29, 12, 17, 11, 569, DateTimeKind.Local).AddTicks(5387) });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 11, 5, 12, 17, 11, 569, DateTimeKind.Local).AddTicks(5389), new DateTime(2023, 10, 29, 12, 17, 11, 569, DateTimeKind.Local).AddTicks(5388) });

            migrationBuilder.UpdateData(
                table: "TransactionHistory",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PaymentDate", "StartDate" },
                values: new object[] { new DateTime(2023, 10, 29, 12, 17, 11, 569, DateTimeKind.Local).AddTicks(8290), new DateTime(2023, 10, 29, 12, 17, 11, 569, DateTimeKind.Local).AddTicks(8293) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBanking",
                table: "TransactionHistory");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Birthday", "RegisteredAt" },
                values: new object[] { new DateTime(2023, 10, 28, 8, 31, 32, 990, DateTimeKind.Local).AddTicks(1460), new DateTime(2023, 10, 28, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Birthday", "RegisteredAt" },
                values: new object[] { new DateTime(2023, 10, 28, 8, 31, 32, 990, DateTimeKind.Local).AddTicks(1475), new DateTime(2023, 10, 28, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 11, 4, 8, 31, 32, 990, DateTimeKind.Local).AddTicks(1524), new DateTime(2023, 10, 28, 8, 31, 32, 990, DateTimeKind.Local).AddTicks(1524) });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 11, 4, 8, 31, 32, 990, DateTimeKind.Local).AddTicks(1530), new DateTime(2023, 10, 28, 8, 31, 32, 990, DateTimeKind.Local).AddTicks(1529) });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 11, 4, 8, 31, 32, 990, DateTimeKind.Local).AddTicks(1531), new DateTime(2023, 10, 28, 8, 31, 32, 990, DateTimeKind.Local).AddTicks(1531) });

            migrationBuilder.UpdateData(
                table: "TransactionHistory",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PaymentDate", "StartDate" },
                values: new object[] { new DateTime(2023, 10, 28, 8, 31, 32, 990, DateTimeKind.Local).AddTicks(4864), new DateTime(2023, 10, 28, 8, 31, 32, 990, DateTimeKind.Local).AddTicks(4867) });
        }
    }
}
