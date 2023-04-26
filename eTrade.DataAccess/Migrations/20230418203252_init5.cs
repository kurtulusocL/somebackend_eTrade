using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eTrade.DataAccess.Migrations
{
    public partial class init5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Files",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId1",
                table: "Files",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Files_ProductId1",
                table: "Files",
                column: "ProductId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Products_ProductId1",
                table: "Files",
                column: "ProductId1",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Products_ProductId1",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_ProductId1",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "Files");
        }
    }
}
