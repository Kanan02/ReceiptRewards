using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReceiptRewards.Infrastructure.Migrations
{
    public partial class AddedPresentSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Presents",
                columns: new[] { "Id", "CreatedAt", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 30, 11, 5, 5, 241, DateTimeKind.Local).AddTicks(6518), "TESS çanta", 1500, 200 },
                    { 2, new DateTime(2024, 5, 30, 11, 5, 5, 241, DateTimeKind.Local).AddTicks(6521), "TESS fincan", 2000, 200 },
                    { 3, new DateTime(2024, 5, 30, 11, 5, 5, 241, DateTimeKind.Local).AddTicks(6523), "TESS T-Shirt", 2200, 200 },
                    { 4, new DateTime(2024, 5, 30, 11, 5, 5, 241, DateTimeKind.Local).AddTicks(6523), "TESS hədiyyə dəsti", 3500, 200 },
                    { 5, new DateTime(2024, 5, 30, 11, 5, 5, 241, DateTimeKind.Local).AddTicks(6524), "TESS uçuş yastğı", 4500, 200 },
                    { 6, new DateTime(2024, 5, 30, 11, 5, 5, 241, DateTimeKind.Local).AddTicks(6526), "TESS bel çanatası", 6500, 200 },
                    { 7, new DateTime(2024, 5, 30, 11, 5, 5, 241, DateTimeKind.Local).AddTicks(6527), "TESS idman çantası", 7000, 200 },
                    { 8, new DateTime(2024, 5, 30, 11, 5, 5, 241, DateTimeKind.Local).AddTicks(6527), "TESS gödəkçə", 8000, 200 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CreatedAt", "RegisterDate" },
                values: new object[] { new DateTime(2024, 5, 30, 11, 5, 5, 241, DateTimeKind.Local).AddTicks(6365), new DateTime(2024, 5, 30, 11, 5, 5, 241, DateTimeKind.Local).AddTicks(6352) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Presents",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Presents",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Presents",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Presents",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Presents",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Presents",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Presents",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Presents",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CreatedAt", "RegisterDate" },
                values: new object[] { new DateTime(2024, 5, 29, 18, 11, 36, 905, DateTimeKind.Local).AddTicks(2241), new DateTime(2024, 5, 29, 18, 11, 36, 905, DateTimeKind.Local).AddTicks(2227) });
        }
    }
}
