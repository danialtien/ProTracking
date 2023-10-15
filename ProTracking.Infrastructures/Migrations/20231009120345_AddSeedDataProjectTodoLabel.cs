using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProTracking.Infrastructures.Migrations
{
    public partial class AddSeedDataProjectTodoLabel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Birthday",
                value: new DateTime(2023, 10, 9, 19, 3, 45, 97, DateTimeKind.Local).AddTicks(216));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Birthday",
                value: new DateTime(2023, 10, 9, 19, 3, 45, 97, DateTimeKind.Local).AddTicks(233));

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CreatedBy", "Description", "Status", "SubTitle", "Title" },
                values: new object[] { 1, 1, "A startup project helping user to manage projects", "Active", "ProTracking make your work easier", "ProTracking EXE201" });

            migrationBuilder.InsertData(
                table: "Labels",
                columns: new[] { "Id", "ProjectId", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Frontend" },
                    { 2, 1, "Backend" },
                    { 3, 1, "AI" },
                    { 4, 1, "Marketing" }
                });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "Assignee", "CreatedBy", "EndDate", "IconPriority", "LabelId", "Priority", "ProjectId", "ReportTo", "StartDate", "Status", "Title" },
                values: new object[] { 1, 1, 1, new DateTime(2023, 10, 16, 19, 3, 45, 97, DateTimeKind.Local).AddTicks(283), "", 1, 5, 1, 0, new DateTime(2023, 10, 9, 19, 3, 45, 97, DateTimeKind.Local).AddTicks(283), "In Progress", "Design UI/UX for application" });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "Assignee", "CreatedBy", "EndDate", "IconPriority", "LabelId", "Priority", "ProjectId", "ReportTo", "StartDate", "Status", "Title" },
                values: new object[] { 2, 1, 1, new DateTime(2023, 10, 16, 19, 3, 45, 97, DateTimeKind.Local).AddTicks(287), "", 2, 5, 1, 0, new DateTime(2023, 10, 9, 19, 3, 45, 97, DateTimeKind.Local).AddTicks(287), "Todo", "Builtd API for application" });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "Assignee", "CreatedBy", "EndDate", "IconPriority", "LabelId", "Priority", "ProjectId", "ReportTo", "StartDate", "Status", "Title" },
                values: new object[] { 3, 1, 1, new DateTime(2023, 10, 16, 19, 3, 45, 97, DateTimeKind.Local).AddTicks(290), "", 3, 5, 1, 0, new DateTime(2023, 10, 9, 19, 3, 45, 97, DateTimeKind.Local).AddTicks(289), "In Progress", "Integrated Chatbox to application" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Labels",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Labels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Labels",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Labels",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1);

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
        }
    }
}
