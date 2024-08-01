using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReceiptRewards.Infrastructure.Migrations
{
    public partial class Removednotefromreceipt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Note",
                table: "Receipts");

            migrationBuilder.UpdateData(
                table: "Presents",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 31, 13, 57, 58, 753, DateTimeKind.Local).AddTicks(6759));

            migrationBuilder.UpdateData(
                table: "Presents",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 31, 13, 57, 58, 753, DateTimeKind.Local).AddTicks(6761));

            migrationBuilder.UpdateData(
                table: "Presents",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 31, 13, 57, 58, 753, DateTimeKind.Local).AddTicks(6761));

            migrationBuilder.UpdateData(
                table: "Presents",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 31, 13, 57, 58, 753, DateTimeKind.Local).AddTicks(6762));

            migrationBuilder.UpdateData(
                table: "Presents",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 31, 13, 57, 58, 753, DateTimeKind.Local).AddTicks(6763));

            migrationBuilder.UpdateData(
                table: "Presents",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 31, 13, 57, 58, 753, DateTimeKind.Local).AddTicks(6763));

            migrationBuilder.UpdateData(
                table: "Presents",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 31, 13, 57, 58, 753, DateTimeKind.Local).AddTicks(6764));

            migrationBuilder.UpdateData(
                table: "Presents",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 31, 13, 57, 58, 753, DateTimeKind.Local).AddTicks(6764));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CreatedAt", "RegisterDate" },
                values: new object[] { new DateTime(2024, 5, 31, 13, 57, 58, 753, DateTimeKind.Local).AddTicks(6653), new DateTime(2024, 5, 31, 13, 57, 58, 753, DateTimeKind.Local).AddTicks(6636) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Receipts",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Presents",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 30, 11, 5, 5, 241, DateTimeKind.Local).AddTicks(6518));

            migrationBuilder.UpdateData(
                table: "Presents",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 30, 11, 5, 5, 241, DateTimeKind.Local).AddTicks(6521));

            migrationBuilder.UpdateData(
                table: "Presents",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 30, 11, 5, 5, 241, DateTimeKind.Local).AddTicks(6523));

            migrationBuilder.UpdateData(
                table: "Presents",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 30, 11, 5, 5, 241, DateTimeKind.Local).AddTicks(6523));

            migrationBuilder.UpdateData(
                table: "Presents",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 30, 11, 5, 5, 241, DateTimeKind.Local).AddTicks(6524));

            migrationBuilder.UpdateData(
                table: "Presents",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 30, 11, 5, 5, 241, DateTimeKind.Local).AddTicks(6526));

            migrationBuilder.UpdateData(
                table: "Presents",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 30, 11, 5, 5, 241, DateTimeKind.Local).AddTicks(6527));

            migrationBuilder.UpdateData(
                table: "Presents",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 5, 30, 11, 5, 5, 241, DateTimeKind.Local).AddTicks(6527));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CreatedAt", "RegisterDate" },
                values: new object[] { new DateTime(2024, 5, 30, 11, 5, 5, 241, DateTimeKind.Local).AddTicks(6365), new DateTime(2024, 5, 30, 11, 5, 5, 241, DateTimeKind.Local).AddTicks(6352) });
        }
    }
}
