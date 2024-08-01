using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReceiptRewards.Infrastructure.Migrations
{
    public partial class AddedOperatorToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Operator",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Operator",
                table: "Users");
        }
    }
}
