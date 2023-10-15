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

            migrationBuilder.DropIndex(
                name: "IX_Todos_CreatedBy",
                table: "Todos");

            migrationBuilder.DropIndex(
                name: "IX_Todos_LabelId",
                table: "Todos");

            migrationBuilder.DropIndex(
                name: "IX_Todos_ProjectId",
                table: "Todos");

            migrationBuilder.AlterColumn<string>(
                name: "IconPriority",
                table: "Todos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Birthday", "RegisteredAt" },
                values: new object[] { new DateTime(2023, 10, 15, 1, 39, 32, 289, DateTimeKind.Local).AddTicks(1096), new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Birthday", "RegisteredAt" },
                values: new object[] { new DateTime(2023, 10, 15, 1, 39, 32, 289, DateTimeKind.Local).AddTicks(1109), new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 10, 22, 1, 39, 32, 289, DateTimeKind.Local).AddTicks(1147), new DateTime(2023, 10, 15, 1, 39, 32, 289, DateTimeKind.Local).AddTicks(1147) });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 10, 22, 1, 39, 32, 289, DateTimeKind.Local).AddTicks(1152), new DateTime(2023, 10, 15, 1, 39, 32, 289, DateTimeKind.Local).AddTicks(1152) });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 10, 22, 1, 39, 32, 289, DateTimeKind.Local).AddTicks(1154), new DateTime(2023, 10, 15, 1, 39, 32, 289, DateTimeKind.Local).AddTicks(1154) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IconPriority",
                table: "Todos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Birthday", "RegisteredAt" },
                values: new object[] { new DateTime(2023, 10, 9, 19, 3, 45, 97, DateTimeKind.Local).AddTicks(216), new DateTime(2023, 10, 9, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Birthday", "RegisteredAt" },
                values: new object[] { new DateTime(2023, 10, 9, 19, 3, 45, 97, DateTimeKind.Local).AddTicks(233), new DateTime(2023, 10, 9, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 10, 16, 19, 3, 45, 97, DateTimeKind.Local).AddTicks(283), new DateTime(2023, 10, 9, 19, 3, 45, 97, DateTimeKind.Local).AddTicks(283) });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 10, 16, 19, 3, 45, 97, DateTimeKind.Local).AddTicks(287), new DateTime(2023, 10, 9, 19, 3, 45, 97, DateTimeKind.Local).AddTicks(287) });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 10, 16, 19, 3, 45, 97, DateTimeKind.Local).AddTicks(290), new DateTime(2023, 10, 9, 19, 3, 45, 97, DateTimeKind.Local).AddTicks(289) });

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
        }
    }
}
