using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReceiptRewards.Infrastructure.Migrations
{
    public partial class Renamedapprovaldate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ApprovedDate",
                table: "Receipts",
                newName: "ApprovalDate");

            migrationBuilder.UpdateData(
                table: "Presents",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 3, 13, 55, 39, 883, DateTimeKind.Local).AddTicks(782));

            migrationBuilder.UpdateData(
                table: "Presents",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 3, 13, 55, 39, 883, DateTimeKind.Local).AddTicks(783));

            migrationBuilder.UpdateData(
                table: "Presents",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 3, 13, 55, 39, 883, DateTimeKind.Local).AddTicks(784));

            migrationBuilder.UpdateData(
                table: "Presents",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 3, 13, 55, 39, 883, DateTimeKind.Local).AddTicks(785));

            migrationBuilder.UpdateData(
                table: "Presents",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 3, 13, 55, 39, 883, DateTimeKind.Local).AddTicks(786));

            migrationBuilder.UpdateData(
                table: "Presents",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 3, 13, 55, 39, 883, DateTimeKind.Local).AddTicks(786));

            migrationBuilder.UpdateData(
                table: "Presents",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 3, 13, 55, 39, 883, DateTimeKind.Local).AddTicks(787));

            migrationBuilder.UpdateData(
                table: "Presents",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 3, 13, 55, 39, 883, DateTimeKind.Local).AddTicks(787));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CreatedAt", "RegisterDate" },
                values: new object[] { new DateTime(2024, 6, 3, 13, 55, 39, 883, DateTimeKind.Local).AddTicks(696), new DateTime(2024, 6, 3, 13, 55, 39, 883, DateTimeKind.Local).AddTicks(683) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ApprovalDate",
                table: "Receipts",
                newName: "ApprovedDate");

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
    }
}
