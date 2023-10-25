using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProTracking.Infrastructures.Migrations
{
    public partial class UpdateSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Index = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QRCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccessKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrivateKey = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegisteredAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastLoginAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<int>(type: "int", nullable: true),
                    GoogleId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoogleEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OAuthToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OAuthExpiry = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccountTypeId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_AccountTypes_AccountTypeId",
                        column: x => x.AccountTypeId,
                        principalTable: "AccountTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Labels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Labels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Labels_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectParticipants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    IsLeader = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectParticipants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectParticipants_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectParticipants_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    AccountTypeId = table.Column<int>(type: "int", nullable: false),
                    PaymentId = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionHistory_AccountTypes_AccountTypeId",
                        column: x => x.AccountTypeId,
                        principalTable: "AccountTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransactionHistory_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransactionHistory_Payments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Todos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    LabelId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReportTo = table.Column<int>(type: "int", nullable: false),
                    Assignee = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    IconPriority = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Todos_Customers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Todos_Labels_LabelId",
                        column: x => x.LabelId,
                        principalTable: "Labels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Todos_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChildTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TodoId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChildTasks_Todos_TodoId",
                        column: x => x.TodoId,
                        principalTable: "Todos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TodoId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReplyToId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Comments_ReplyToId",
                        column: x => x.ReplyToId,
                        principalTable: "Comments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Todos_TodoId",
                        column: x => x.TodoId,
                        principalTable: "Todos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AccountTypes",
                columns: new[] { "Id", "Description", "Index", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "Free account", 0, 0.0, "Free" },
                    { 2, "Standard account", 1, 20.0, "Standard" },
                    { 3, "Premium account", 2, 30.0, "Premium" },
                    { 4, "Enterprise account", 3, 40.0, "Enterprise" }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "AccessKey", "PrivateKey", "QRCode", "Title" },
                values: new object[,]
                {
                    { 1, "Free", "Free", "Free", "Free" },
                    { 2, "AceessKey", "Privatekey", "dfsdalfdfa", "ZaloPay" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CreatedBy", "Description", "Status", "SubTitle", "Title" },
                values: new object[] { 1, 1, "A startup project helping user to manage projects", "Active", "ProTracking make your work easier", "ProTracking EXE201" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "AccountTypeId", "Avatar", "Birthday", "Email", "EndDate", "FirstName", "GoogleEmail", "GoogleId", "LastLoginAt", "LastName", "OAuthExpiry", "OAuthToken", "Password", "Phone", "RegisteredAt", "Role", "StartDate", "Status", "Username" },
                values: new object[,]
                {
                    { 1, 1, null, new DateTime(2023, 10, 22, 13, 1, 10, 230, DateTimeKind.Local).AddTicks(6474), "khoa@gmail.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hoang", "khoa@gmail.com", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Khoa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "1234", "08888888", new DateTime(2023, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "khoa" },
                    { 2, 1, null, new DateTime(2023, 10, 22, 13, 1, 10, 230, DateTimeKind.Local).AddTicks(6486), "hai@gmail.com", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hoang", "hai@gmail.com", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hai", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "1234", "08888888", new DateTime(2023, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active", "khoa" }
                });

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
                table: "ProjectParticipants",
                columns: new[] { "Id", "CustomerId", "IsLeader", "ProjectId" },
                values: new object[] { 1, 1, true, 1 });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "Assignee", "CreatedBy", "EndDate", "IconPriority", "LabelId", "Priority", "ProjectId", "ReportTo", "StartDate", "Status", "Title" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2023, 10, 29, 13, 1, 10, 230, DateTimeKind.Local).AddTicks(6544), "", 1, 5, 1, 0, new DateTime(2023, 10, 22, 13, 1, 10, 230, DateTimeKind.Local).AddTicks(6543), "In Progress", "Design UI/UX for application" },
                    { 2, 1, 1, new DateTime(2023, 10, 29, 13, 1, 10, 230, DateTimeKind.Local).AddTicks(6549), "", 2, 5, 1, 0, new DateTime(2023, 10, 22, 13, 1, 10, 230, DateTimeKind.Local).AddTicks(6549), "Todo", "Builtd API for application" },
                    { 3, 1, 1, new DateTime(2023, 10, 29, 13, 1, 10, 230, DateTimeKind.Local).AddTicks(6551), "", 3, 5, 1, 0, new DateTime(2023, 10, 22, 13, 1, 10, 230, DateTimeKind.Local).AddTicks(6551), "In Progress", "Integrated Chatbox to application" }
                });

            migrationBuilder.InsertData(
                table: "TransactionHistory",
                columns: new[] { "Id", "AccountTypeId", "Amount", "Content", "CustomerId", "PaymentDate", "PaymentId", "StartDate" },
                values: new object[] { 1, 1, 0.0, null, 1, new DateTime(2023, 10, 22, 13, 1, 10, 230, DateTimeKind.Local).AddTicks(9910), 1, new DateTime(2023, 10, 22, 13, 1, 10, 230, DateTimeKind.Local).AddTicks(9913) });

            migrationBuilder.CreateIndex(
                name: "IX_ChildTasks_TodoId",
                table: "ChildTasks",
                column: "TodoId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ReplyToId",
                table: "Comments",
                column: "ReplyToId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_TodoId",
                table: "Comments",
                column: "TodoId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AccountTypeId",
                table: "Customers",
                column: "AccountTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Labels_ProjectId",
                table: "Labels",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectParticipants_CustomerId",
                table: "ProjectParticipants",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectParticipants_ProjectId",
                table: "ProjectParticipants",
                column: "ProjectId");

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

            migrationBuilder.CreateIndex(
                name: "IX_TransactionHistory_AccountTypeId",
                table: "TransactionHistory",
                column: "AccountTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionHistory_CustomerId",
                table: "TransactionHistory",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionHistory_PaymentId",
                table: "TransactionHistory",
                column: "PaymentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChildTasks");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "ProjectParticipants");

            migrationBuilder.DropTable(
                name: "TransactionHistory");

            migrationBuilder.DropTable(
                name: "Todos");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Labels");

            migrationBuilder.DropTable(
                name: "AccountTypes");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
