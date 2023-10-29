using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProTracking.Infrastructures.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Birthday", "RegisteredAt" },
                values: new object[] { new DateTime(2023, 10, 29, 10, 31, 19, 527, DateTimeKind.Local).AddTicks(9003), new DateTime(2023, 10, 29, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Birthday", "RegisteredAt" },
                values: new object[] { new DateTime(2023, 10, 29, 10, 31, 19, 527, DateTimeKind.Local).AddTicks(9023), new DateTime(2023, 10, 29, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 11, 5, 10, 31, 19, 527, DateTimeKind.Local).AddTicks(9077), new DateTime(2023, 10, 29, 10, 31, 19, 527, DateTimeKind.Local).AddTicks(9076) });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 11, 5, 10, 31, 19, 527, DateTimeKind.Local).AddTicks(9086), new DateTime(2023, 10, 29, 10, 31, 19, 527, DateTimeKind.Local).AddTicks(9085) });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 11, 5, 10, 31, 19, 527, DateTimeKind.Local).AddTicks(9088), new DateTime(2023, 10, 29, 10, 31, 19, 527, DateTimeKind.Local).AddTicks(9087) });

            migrationBuilder.UpdateData(
                table: "TransactionHistory",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PaymentDate", "StartDate" },
                values: new object[] { new DateTime(2023, 10, 29, 10, 31, 19, 528, DateTimeKind.Local).AddTicks(2005), new DateTime(2023, 10, 29, 10, 31, 19, 528, DateTimeKind.Local).AddTicks(2008) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
