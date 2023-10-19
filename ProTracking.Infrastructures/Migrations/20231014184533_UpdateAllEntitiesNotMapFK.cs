using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProTracking.Infrastructures.Migrations
{
    public partial class UpdateAllEntitiesNotMapFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChildTasks_Todos_TodoId",
                table: "ChildTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Todos_TodoId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Labels_Projects_ProjectId",
                table: "Labels");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectParticipants_Customers_CustomerId",
                table: "ProjectParticipants");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectParticipants_Projects_ProjectId",
                table: "ProjectParticipants");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionHistory_Customers_CustomerId",
                table: "TransactionHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionHistory_Payments_PaymentId",
                table: "TransactionHistory");

            migrationBuilder.DropIndex(
                name: "IX_TransactionHistory_CustomerId",
                table: "TransactionHistory");

            migrationBuilder.DropIndex(
                name: "IX_TransactionHistory_PaymentId",
                table: "TransactionHistory");

            migrationBuilder.DropIndex(
                name: "IX_ProjectParticipants_CustomerId",
                table: "ProjectParticipants");

            migrationBuilder.DropIndex(
                name: "IX_ProjectParticipants_ProjectId",
                table: "ProjectParticipants");

            migrationBuilder.DropIndex(
                name: "IX_Labels_ProjectId",
                table: "Labels");

            migrationBuilder.DropIndex(
                name: "IX_Comments_TodoId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_ChildTasks_TodoId",
                table: "ChildTasks");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Birthday",
                value: new DateTime(2023, 10, 15, 1, 45, 32, 736, DateTimeKind.Local).AddTicks(4694));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Birthday",
                value: new DateTime(2023, 10, 15, 1, 45, 32, 736, DateTimeKind.Local).AddTicks(4711));

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 10, 22, 1, 45, 32, 736, DateTimeKind.Local).AddTicks(4760), new DateTime(2023, 10, 15, 1, 45, 32, 736, DateTimeKind.Local).AddTicks(4759) });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 10, 22, 1, 45, 32, 736, DateTimeKind.Local).AddTicks(4768), new DateTime(2023, 10, 15, 1, 45, 32, 736, DateTimeKind.Local).AddTicks(4768) });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 10, 22, 1, 45, 32, 736, DateTimeKind.Local).AddTicks(4770), new DateTime(2023, 10, 15, 1, 45, 32, 736, DateTimeKind.Local).AddTicks(4769) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Birthday",
                value: new DateTime(2023, 10, 15, 1, 39, 32, 289, DateTimeKind.Local).AddTicks(1096));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Birthday",
                value: new DateTime(2023, 10, 15, 1, 39, 32, 289, DateTimeKind.Local).AddTicks(1109));

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

            migrationBuilder.CreateIndex(
                name: "IX_TransactionHistory_CustomerId",
                table: "TransactionHistory",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionHistory_PaymentId",
                table: "TransactionHistory",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectParticipants_CustomerId",
                table: "ProjectParticipants",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectParticipants_ProjectId",
                table: "ProjectParticipants",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Labels_ProjectId",
                table: "Labels",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_TodoId",
                table: "Comments",
                column: "TodoId");

            migrationBuilder.CreateIndex(
                name: "IX_ChildTasks_TodoId",
                table: "ChildTasks",
                column: "TodoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChildTasks_Todos_TodoId",
                table: "ChildTasks",
                column: "TodoId",
                principalTable: "Todos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Todos_TodoId",
                table: "Comments",
                column: "TodoId",
                principalTable: "Todos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Labels_Projects_ProjectId",
                table: "Labels",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectParticipants_Customers_CustomerId",
                table: "ProjectParticipants",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectParticipants_Projects_ProjectId",
                table: "ProjectParticipants",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionHistory_Customers_CustomerId",
                table: "TransactionHistory",
                column: "CustomerId",
                principalTable: "Customers",
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
