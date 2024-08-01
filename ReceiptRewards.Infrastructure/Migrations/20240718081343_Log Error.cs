using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReceiptRewards.Infrastructure.Migrations
{
    public partial class LogError : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ErrorLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LogType = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrorLogs", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Presents",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 18, 12, 13, 43, 326, DateTimeKind.Local).AddTicks(6102));

            migrationBuilder.UpdateData(
                table: "Presents",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 18, 12, 13, 43, 326, DateTimeKind.Local).AddTicks(6106));

            migrationBuilder.UpdateData(
                table: "Presents",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 18, 12, 13, 43, 326, DateTimeKind.Local).AddTicks(6108));

            migrationBuilder.UpdateData(
                table: "Presents",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 18, 12, 13, 43, 326, DateTimeKind.Local).AddTicks(6109));

            migrationBuilder.UpdateData(
                table: "Presents",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 18, 12, 13, 43, 326, DateTimeKind.Local).AddTicks(6111));

            migrationBuilder.UpdateData(
                table: "Presents",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 18, 12, 13, 43, 326, DateTimeKind.Local).AddTicks(6112));

            migrationBuilder.UpdateData(
                table: "Presents",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 18, 12, 13, 43, 326, DateTimeKind.Local).AddTicks(6114));

            migrationBuilder.UpdateData(
                table: "Presents",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 18, 12, 13, 43, 326, DateTimeKind.Local).AddTicks(6115));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CreatedAt", "RegisterDate" },
                values: new object[] { new DateTime(2024, 7, 18, 12, 13, 43, 326, DateTimeKind.Local).AddTicks(5877), new DateTime(2024, 7, 18, 12, 13, 43, 326, DateTimeKind.Local).AddTicks(5850) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ErrorLogs");

            migrationBuilder.UpdateData(
                table: "Presents",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 1, 11, 52, 57, 518, DateTimeKind.Local).AddTicks(5777));

            migrationBuilder.UpdateData(
                table: "Presents",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 1, 11, 52, 57, 518, DateTimeKind.Local).AddTicks(5779));

            migrationBuilder.UpdateData(
                table: "Presents",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 1, 11, 52, 57, 518, DateTimeKind.Local).AddTicks(5779));

            migrationBuilder.UpdateData(
                table: "Presents",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 1, 11, 52, 57, 518, DateTimeKind.Local).AddTicks(5780));

            migrationBuilder.UpdateData(
                table: "Presents",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 1, 11, 52, 57, 518, DateTimeKind.Local).AddTicks(5781));

            migrationBuilder.UpdateData(
                table: "Presents",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 1, 11, 52, 57, 518, DateTimeKind.Local).AddTicks(5782));

            migrationBuilder.UpdateData(
                table: "Presents",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 1, 11, 52, 57, 518, DateTimeKind.Local).AddTicks(5782));

            migrationBuilder.UpdateData(
                table: "Presents",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 7, 1, 11, 52, 57, 518, DateTimeKind.Local).AddTicks(5783));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CreatedAt", "RegisterDate" },
                values: new object[] { new DateTime(2024, 7, 1, 11, 52, 57, 518, DateTimeKind.Local).AddTicks(5605), new DateTime(2024, 7, 1, 11, 52, 57, 518, DateTimeKind.Local).AddTicks(5593) });
        }
    }
}
