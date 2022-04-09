using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Amart.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Login = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    TotalAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Created", "Name", "OrderId", "Price", "Updated" },
                values: new object[,]
                {
                    { new Guid("3b7bb906-4d07-4e3b-9590-a08341e3e34b"), new DateTime(2022, 4, 9, 13, 13, 1, 164, DateTimeKind.Local).AddTicks(9480), "IPhone 13S", null, 250m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8dbacb5f-371d-4d35-bd41-65967bce80ce"), new DateTime(2022, 4, 9, 13, 13, 1, 165, DateTimeKind.Local).AddTicks(321), "Acer Aspire", null, 1250m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5c5ffe31-0b04-4ed1-8ca6-b059e5157ba3"), new DateTime(2022, 4, 9, 13, 13, 1, 165, DateTimeKind.Local).AddTicks(330), "Samsung S20", null, 1600m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1cc3694a-8686-47db-95c1-f25a93583daf"), new DateTime(2022, 4, 9, 13, 13, 1, 165, DateTimeKind.Local).AddTicks(333), "Coca cola", null, 250m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("31d14f0c-4d4b-4e78-acb0-f750eb4a5321"), new DateTime(2022, 4, 9, 13, 13, 1, 165, DateTimeKind.Local).AddTicks(336), "Ball", null, 20m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d9f09c1b-9cc2-4e90-9c6a-0be8edda9015"), new DateTime(2022, 4, 9, 13, 13, 1, 165, DateTimeKind.Local).AddTicks(339), "Monitor", null, 630m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3deafeda-f483-47f1-8b4d-18f97c30d07d"), new DateTime(2022, 4, 9, 13, 13, 1, 165, DateTimeKind.Local).AddTicks(342), "Book", null, 450m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Created", "Login", "Password", "Updated" },
                values: new object[] { new Guid("b7158e4d-a47c-41c8-8a94-48992d11da07"), new DateTime(2022, 4, 9, 13, 13, 1, 162, DateTimeKind.Local).AddTicks(1928), "Admin", "12345678", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_OrderId",
                table: "Products",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
