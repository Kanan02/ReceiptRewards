using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReceiptRewards.Infrastructure.Migrations
{
    public partial class NonNullableapprovaldate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coupons");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovalDate",
                table: "Receipts",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ApprovalDate",
                table: "Receipts",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.CreateTable(
                name: "Coupons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ReceiptId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Prize10000azn = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Prize1000azn = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Prize100azn = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Prize2azn = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Coupons_Receipts_ReceiptId",
                        column: x => x.ReceiptId,
                        principalTable: "Receipts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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

            migrationBuilder.CreateIndex(
                name: "IX_Coupons_ReceiptId",
                table: "Coupons",
                column: "ReceiptId");
        }
    }
}
