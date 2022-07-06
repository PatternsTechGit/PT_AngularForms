using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfilePicUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AccountStatus = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TransactionType = table.Column<int>(type: "int", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransactionAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AccountId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "ProfilePicUrl" },
                values: new object[] { "aa45e3c9-261d-41fe-a1b0-5b4dcf79cfd3", "rassmasood@hotmail.com", "Raas", "Masood", "https://res.cloudinary.com/demo/image/upload/w_400,h_400,c_crop,g_face,r_max/w_200/lady.jpg" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccountNumber", "AccountStatus", "AccountTitle", "CurrentBalance", "UserId" },
                values: new object[] { "37846734-172e-4149-8cec-6f43d1eb3f60", "0001-1001", 1, "Raas Masood", 3500m, "aa45e3c9-261d-41fe-a1b0-5b4dcf79cfd3" });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "AccountId", "TransactionAmount", "TransactionDate", "TransactionType" },
                values: new object[,]
                {
                    { "0c9ba805-a546-487f-87d0-4bce06628292", "37846734-172e-4149-8cec-6f43d1eb3f60", 200m, new DateTime(2021, 9, 29, 22, 50, 50, 551, DateTimeKind.Local).AddTicks(1371), 0 },
                    { "3022256e-1a91-432b-aae6-4d68259ec98c", "37846734-172e-4149-8cec-6f43d1eb3f60", -500m, new DateTime(2021, 8, 29, 22, 50, 50, 551, DateTimeKind.Local).AddTicks(1374), 1 },
                    { "4499291f-8723-4bc9-8b8c-2275aa22e4a8", "37846734-172e-4149-8cec-6f43d1eb3f60", 1000m, new DateTime(2020, 6, 29, 22, 50, 50, 551, DateTimeKind.Local).AddTicks(1310), 0 },
                    { "45e07350-eac2-43eb-9212-92e3ee6d6535", "37846734-172e-4149-8cec-6f43d1eb3f60", -300m, new DateTime(2021, 11, 29, 22, 50, 50, 551, DateTimeKind.Local).AddTicks(1364), 1 },
                    { "669d0a57-f8bf-4625-b762-10008d7c491e", "37846734-172e-4149-8cec-6f43d1eb3f60", -200m, new DateTime(2022, 2, 28, 22, 50, 50, 551, DateTimeKind.Local).AddTicks(1352), 1 },
                    { "67371025-7de6-406a-9929-e24cdc304082", "37846734-172e-4149-8cec-6f43d1eb3f60", 500m, new DateTime(2022, 3, 29, 22, 50, 50, 551, DateTimeKind.Local).AddTicks(1349), 0 },
                    { "75f8377d-8493-4063-94d7-bced031b3b9f", "37846734-172e-4149-8cec-6f43d1eb3f60", 900m, new DateTime(2021, 7, 29, 22, 50, 50, 551, DateTimeKind.Local).AddTicks(1376), 0 },
                    { "7ae4b617-14fe-4afa-89e3-69e92239a55e", "37846734-172e-4149-8cec-6f43d1eb3f60", 200m, new DateTime(2021, 12, 29, 22, 50, 50, 551, DateTimeKind.Local).AddTicks(1361), 0 },
                    { "7de5b896-7276-4fa7-b9a8-57b7b5ace775", "37846734-172e-4149-8cec-6f43d1eb3f60", -100m, new DateTime(2021, 10, 29, 22, 50, 50, 551, DateTimeKind.Local).AddTicks(1366), 1 },
                    { "86162ae8-2474-4191-93b4-ebffd274361d", "37846734-172e-4149-8cec-6f43d1eb3f60", 3000m, new DateTime(2022, 6, 28, 22, 50, 50, 551, DateTimeKind.Local).AddTicks(1269), 0 },
                    { "8d73f4eb-9376-43cf-b9c2-0ec8cc995310", "37846734-172e-4149-8cec-6f43d1eb3f60", -500m, new DateTime(2021, 6, 29, 22, 50, 50, 551, DateTimeKind.Local).AddTicks(1306), 1 },
                    { "a08ec8aa-3faf-46dd-9e5e-3d90effcf415", "37846734-172e-4149-8cec-6f43d1eb3f60", 500m, new DateTime(2022, 1, 29, 22, 50, 50, 551, DateTimeKind.Local).AddTicks(1355), 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_UserId",
                table: "Accounts",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AccountId",
                table: "Transactions",
                column: "AccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
