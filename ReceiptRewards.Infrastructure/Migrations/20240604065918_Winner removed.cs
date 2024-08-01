using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReceiptRewards.Infrastructure.Migrations
{
    public partial class Winnerremoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Winners");

            migrationBuilder.UpdateData(
                table: "Presents",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 4, 10, 59, 17, 703, DateTimeKind.Local).AddTicks(788));

            migrationBuilder.UpdateData(
                table: "Presents",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 4, 10, 59, 17, 703, DateTimeKind.Local).AddTicks(789));

            migrationBuilder.UpdateData(
                table: "Presents",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 4, 10, 59, 17, 703, DateTimeKind.Local).AddTicks(790));

            migrationBuilder.UpdateData(
                table: "Presents",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 4, 10, 59, 17, 703, DateTimeKind.Local).AddTicks(791));

            migrationBuilder.UpdateData(
                table: "Presents",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 4, 10, 59, 17, 703, DateTimeKind.Local).AddTicks(791));

            migrationBuilder.UpdateData(
                table: "Presents",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 4, 10, 59, 17, 703, DateTimeKind.Local).AddTicks(792));

            migrationBuilder.UpdateData(
                table: "Presents",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 4, 10, 59, 17, 703, DateTimeKind.Local).AddTicks(793));

            migrationBuilder.UpdateData(
                table: "Presents",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 4, 10, 59, 17, 703, DateTimeKind.Local).AddTicks(793));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CreatedAt", "RegisterDate" },
                values: new object[] { new DateTime(2024, 6, 4, 10, 59, 17, 703, DateTimeKind.Local).AddTicks(687), new DateTime(2024, 6, 4, 10, 59, 17, 703, DateTimeKind.Local).AddTicks(676) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Winners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CheckAddDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CouponCode = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Msisdn = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PrizeType = table.Column<int>(type: "int", nullable: false),
                    Surname = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WinDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Winners", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Presents",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 4, 10, 37, 35, 554, DateTimeKind.Local).AddTicks(4908));

            migrationBuilder.UpdateData(
                table: "Presents",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 4, 10, 37, 35, 554, DateTimeKind.Local).AddTicks(4910));

            migrationBuilder.UpdateData(
                table: "Presents",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 4, 10, 37, 35, 554, DateTimeKind.Local).AddTicks(4911));

            migrationBuilder.UpdateData(
                table: "Presents",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 4, 10, 37, 35, 554, DateTimeKind.Local).AddTicks(4912));

            migrationBuilder.UpdateData(
                table: "Presents",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 4, 10, 37, 35, 554, DateTimeKind.Local).AddTicks(4912));

            migrationBuilder.UpdateData(
                table: "Presents",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 4, 10, 37, 35, 554, DateTimeKind.Local).AddTicks(4913));

            migrationBuilder.UpdateData(
                table: "Presents",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 4, 10, 37, 35, 554, DateTimeKind.Local).AddTicks(4913));

            migrationBuilder.UpdateData(
                table: "Presents",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 4, 10, 37, 35, 554, DateTimeKind.Local).AddTicks(4914));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CreatedAt", "RegisterDate" },
                values: new object[] { new DateTime(2024, 6, 4, 10, 37, 35, 554, DateTimeKind.Local).AddTicks(4808), new DateTime(2024, 6, 4, 10, 37, 35, 554, DateTimeKind.Local).AddTicks(4791) });
        }
    }
}
