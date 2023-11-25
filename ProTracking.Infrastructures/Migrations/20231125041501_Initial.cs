using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProTracking.Infrastructures.Migrations
{
    public partial class Initial : Migration
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
                    ReportTo = table.Column<int>(type: "int", nullable: true),
                    Assignee = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    IconPriority = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todos", x => x.Id);
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
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegisteredAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastLoginAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<int>(type: "int", nullable: true),
                    GoogleId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoogleEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountTypeId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    IsBanking = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionHistory_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    { 2, "Normal", "Normal", "https://drive.google.com/file/d/10qMV7ydU1rCyhMaZdHTmzwQh6_vkFv4n/view?usp=sharing", "ZaloPay" },
                    { 3, "Standard", "Standard", "https://drive.google.com/file/d/1KhnoyG2OcJjR5isd44K4mMC6nXZs-VxE/view?usp=sharing", "ZaloPay" },
                    { 4, "Premium", "Premium", "https://drive.google.com/file/d/1lyhl-L9asLIx48XAws8F50pGrTvLSocX/view?usp=sharing", "ZaloPay" },
                    { 5, "Normal", "Normal", "https://drive.google.com/file/d/17gfyZEJWp-6ltJQazuAxj86nzxRoRmhM/view?usp=sharing", "TPBank" },
                    { 6, "Standard", "Standard", "https://drive.google.com/file/d/1bXRIqAG_qDv5VXlL4_Lr2EDqPa3nhVYI/view?usp=sharing", "TPBank" },
                    { 7, "Premium", "Premium", "https://drive.google.com/file/d/1V9ykNI_Rsm4bZWvMZ-rORTG9SPPjBB7l/view?usp=sharing", "TPBank" }
                });

            migrationBuilder.InsertData(
                table: "ProjectParticipants",
                columns: new[] { "Id", "CustomerId", "IsLeader", "ProjectId" },
                values: new object[] { 1, 2, true, 1 });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CreatedBy", "Description", "Status", "SubTitle", "Title" },
                values: new object[] { 1, 2, "A startup project helping user to manage projects", "Active", "ProTracking make your work easier", "ProTracking EXE201" });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "Assignee", "CreatedBy", "EndDate", "IconPriority", "LabelId", "Priority", "ProjectId", "ReportTo", "StartDate", "Status", "Title" },
                values: new object[,]
                {
                    { 1, 2, 2, new DateTime(2023, 12, 2, 11, 15, 1, 314, DateTimeKind.Local).AddTicks(2445), "", 1, 5, 1, null, new DateTime(2023, 11, 25, 11, 15, 1, 314, DateTimeKind.Local).AddTicks(2445), "In Progress", "Design UI/UX for application" },
                    { 2, 2, 2, new DateTime(2023, 12, 2, 11, 15, 1, 314, DateTimeKind.Local).AddTicks(2448), "", 2, 5, 1, null, new DateTime(2023, 11, 25, 11, 15, 1, 314, DateTimeKind.Local).AddTicks(2447), "Todo", "Builtd API for application" },
                    { 3, 2, 2, new DateTime(2023, 12, 2, 11, 15, 1, 314, DateTimeKind.Local).AddTicks(2450), "", 3, 5, 1, null, new DateTime(2023, 11, 25, 11, 15, 1, 314, DateTimeKind.Local).AddTicks(2450), "In Progress", "Integrated Chatbox to application" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "AccountTypeId", "Avatar", "Birthday", "Email", "EndDate", "FirstName", "GoogleEmail", "GoogleId", "LastLoginAt", "LastName", "Password", "Phone", "RegisteredAt", "Role", "StartDate", "Status", "Username" },
                values: new object[,]
                {
                    { 1, 3, null, new DateTime(2023, 11, 25, 11, 15, 1, 314, DateTimeKind.Local).AddTicks(2381), "protracking@gmail.com", null, "ProTracking", "protracking@gmail.com", null, null, "ProTracking", "toilaadmin", "08888888", new DateTime(2023, 11, 25, 0, 0, 0, 0, DateTimeKind.Local), 1, null, "Active", "ProTracking" },
                    { 2, 3, null, new DateTime(2023, 11, 25, 11, 15, 1, 314, DateTimeKind.Local).AddTicks(2392), "khoa@gmail.com", null, "Hoang", "khoa@gmail.com", null, null, "Khoa", "1234", "08888888", new DateTime(2023, 11, 25, 0, 0, 0, 0, DateTimeKind.Local), 1, null, "Active", "khoa" },
                    { 3, 1, null, new DateTime(2023, 11, 25, 11, 15, 1, 314, DateTimeKind.Local).AddTicks(2394), "hai@gmail.com", null, "Hoang", "hai@gmail.com", null, null, "Hai", "1234", "08888888", new DateTime(2023, 11, 25, 0, 0, 0, 0, DateTimeKind.Local), 1, null, "Active", "khoa" }
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
                table: "TransactionHistory",
                columns: new[] { "Id", "AccountTypeId", "Amount", "Content", "CustomerId", "EndDate", "IsActive", "IsBanking", "PaymentDate", "PaymentId", "StartDate" },
                values: new object[] { 1, 1, 0.0, null, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, new DateTime(2023, 11, 25, 11, 15, 1, 314, DateTimeKind.Local).AddTicks(9356), 1, new DateTime(2023, 11, 25, 11, 15, 1, 314, DateTimeKind.Local).AddTicks(9360) });

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
                name: "IX_TransactionHistory_CustomerId",
                table: "TransactionHistory",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChildTasks");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Labels");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "ProjectParticipants");

            migrationBuilder.DropTable(
                name: "TransactionHistory");

            migrationBuilder.DropTable(
                name: "Todos");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "AccountTypes");
        }
    }
}
