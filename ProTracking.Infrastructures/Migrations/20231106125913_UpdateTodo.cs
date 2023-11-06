using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProTracking.Infrastructures.Migrations
{
    public partial class UpdateTodo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todos_Customers_CreatedBy",
                table: "Todos");

            migrationBuilder.DropForeignKey(
                name: "FK_Todos_Labels_LabelId",
                table: "Todos");

            migrationBuilder.DropForeignKey(
                name: "FK_Todos_Projects_ProjectId",
                table: "Todos");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionHistory_AccountTypes_AccountTypeId",
                table: "TransactionHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionHistory_Payments_PaymentId",
                table: "TransactionHistory");

            migrationBuilder.DropIndex(
                name: "IX_TransactionHistory_AccountTypeId",
                table: "TransactionHistory");

            migrationBuilder.DropIndex(
                name: "IX_TransactionHistory_PaymentId",
                table: "TransactionHistory");

            migrationBuilder.DropIndex(
                name: "IX_Todos_CreatedBy",
                table: "Todos");

            migrationBuilder.DropIndex(
                name: "IX_Todos_LabelId",
                table: "Todos");

            migrationBuilder.DropIndex(
                name: "IX_Todos_ProjectId",
                table: "Todos");

            migrationBuilder.AlterColumn<int>(
                name: "ReportTo",
                table: "Todos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Priority",
                table: "Todos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Birthday", "RegisteredAt" },
                values: new object[] { new DateTime(2023, 11, 6, 19, 59, 11, 172, DateTimeKind.Local).AddTicks(5296), new DateTime(2023, 11, 6, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Birthday", "RegisteredAt" },
                values: new object[] { new DateTime(2023, 11, 6, 19, 59, 11, 172, DateTimeKind.Local).AddTicks(5331), new DateTime(2023, 11, 6, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AccessKey", "PrivateKey", "QRCode" },
                values: new object[] { "Normal", "Normal", "https://drive.google.com/file/d/10qMV7ydU1rCyhMaZdHTmzwQh6_vkFv4n/view?usp=sharing" });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "AccessKey", "PrivateKey", "QRCode", "Title" },
                values: new object[,]
                {
                    { 3, "Standard", "Standard", "https://drive.google.com/file/d/1KhnoyG2OcJjR5isd44K4mMC6nXZs-VxE/view?usp=sharing", "ZaloPay" },
                    { 4, "Premium", "Premium", "https://drive.google.com/file/d/1lyhl-L9asLIx48XAws8F50pGrTvLSocX/view?usp=sharing", "ZaloPay" },
                    { 5, "Normal", "Normal", "https://drive.google.com/file/d/17gfyZEJWp-6ltJQazuAxj86nzxRoRmhM/view?usp=sharing", "TPBank" },
                    { 6, "Standard", "Standard", "https://drive.google.com/file/d/1bXRIqAG_qDv5VXlL4_Lr2EDqPa3nhVYI/view?usp=sharing", "TPBank" },
                    { 7, "Premium", "Premium", "https://drive.google.com/file/d/1V9ykNI_Rsm4bZWvMZ-rORTG9SPPjBB7l/view?usp=sharing", "TPBank" }
                });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "ReportTo", "StartDate" },
                values: new object[] { new DateTime(2023, 11, 13, 19, 59, 11, 172, DateTimeKind.Local).AddTicks(5532), null, new DateTime(2023, 11, 6, 19, 59, 11, 172, DateTimeKind.Local).AddTicks(5530) });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "ReportTo", "StartDate" },
                values: new object[] { new DateTime(2023, 11, 13, 19, 59, 11, 172, DateTimeKind.Local).AddTicks(5548), null, new DateTime(2023, 11, 6, 19, 59, 11, 172, DateTimeKind.Local).AddTicks(5546) });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "ReportTo", "StartDate" },
                values: new object[] { new DateTime(2023, 11, 13, 19, 59, 11, 172, DateTimeKind.Local).AddTicks(5555), null, new DateTime(2023, 11, 6, 19, 59, 11, 172, DateTimeKind.Local).AddTicks(5553) });

            migrationBuilder.UpdateData(
                table: "TransactionHistory",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PaymentDate", "StartDate" },
                values: new object[] { new DateTime(2023, 11, 6, 19, 59, 11, 176, DateTimeKind.Local).AddTicks(1218), new DateTime(2023, 11, 6, 19, 59, 11, 176, DateTimeKind.Local).AddTicks(1231) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.AlterColumn<int>(
                name: "ReportTo",
                table: "Todos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Priority",
                table: "Todos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Birthday", "RegisteredAt" },
                values: new object[] { new DateTime(2023, 11, 2, 19, 8, 29, 267, DateTimeKind.Local).AddTicks(983), new DateTime(2023, 11, 2, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Birthday", "RegisteredAt" },
                values: new object[] { new DateTime(2023, 11, 2, 19, 8, 29, 267, DateTimeKind.Local).AddTicks(1000), new DateTime(2023, 11, 2, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AccessKey", "PrivateKey", "QRCode" },
                values: new object[] { "AceessKey", "Privatekey", "dfsdalfdfa" });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "ReportTo", "StartDate" },
                values: new object[] { new DateTime(2023, 11, 9, 19, 8, 29, 267, DateTimeKind.Local).AddTicks(1106), 0, new DateTime(2023, 11, 2, 19, 8, 29, 267, DateTimeKind.Local).AddTicks(1106) });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "ReportTo", "StartDate" },
                values: new object[] { new DateTime(2023, 11, 9, 19, 8, 29, 267, DateTimeKind.Local).AddTicks(1113), 0, new DateTime(2023, 11, 2, 19, 8, 29, 267, DateTimeKind.Local).AddTicks(1113) });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "ReportTo", "StartDate" },
                values: new object[] { new DateTime(2023, 11, 9, 19, 8, 29, 267, DateTimeKind.Local).AddTicks(1115), 0, new DateTime(2023, 11, 2, 19, 8, 29, 267, DateTimeKind.Local).AddTicks(1115) });

            migrationBuilder.UpdateData(
                table: "TransactionHistory",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PaymentDate", "StartDate" },
                values: new object[] { new DateTime(2023, 11, 2, 19, 8, 29, 267, DateTimeKind.Local).AddTicks(4308), new DateTime(2023, 11, 2, 19, 8, 29, 267, DateTimeKind.Local).AddTicks(4311) });

            migrationBuilder.CreateIndex(
                name: "IX_TransactionHistory_AccountTypeId",
                table: "TransactionHistory",
                column: "AccountTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionHistory_PaymentId",
                table: "TransactionHistory",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Todos_CreatedBy",
                table: "Todos",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Todos_LabelId",
                table: "Todos",
                column: "LabelId");

            migrationBuilder.CreateIndex(
                name: "IX_Todos_ProjectId",
                table: "Todos",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Todos_Customers_CreatedBy",
                table: "Todos",
                column: "CreatedBy",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Todos_Labels_LabelId",
                table: "Todos",
                column: "LabelId",
                principalTable: "Labels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Todos_Projects_ProjectId",
                table: "Todos",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionHistory_AccountTypes_AccountTypeId",
                table: "TransactionHistory",
                column: "AccountTypeId",
                principalTable: "AccountTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionHistory_Payments_PaymentId",
                table: "TransactionHistory",
                column: "PaymentId",
                principalTable: "Payments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
