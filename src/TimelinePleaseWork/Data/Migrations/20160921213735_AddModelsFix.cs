using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TimelinePleaseWork.Data.Migrations
{
    public partial class AddModelsFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_InventoryItems_InventoryItemId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_InventoryItemId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "InventoryItemId",
                table: "Items");

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "InventoryItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItems_ItemId",
                table: "InventoryItems",
                column: "ItemId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItems_Items_ItemId",
                table: "InventoryItems",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItems_Items_ItemId",
                table: "InventoryItems");

            migrationBuilder.DropIndex(
                name: "IX_InventoryItems_ItemId",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "InventoryItems");

            migrationBuilder.AddColumn<int>(
                name: "InventoryItemId",
                table: "Items",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Items_InventoryItemId",
                table: "Items",
                column: "InventoryItemId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_InventoryItems_InventoryItemId",
                table: "Items",
                column: "InventoryItemId",
                principalTable: "InventoryItems",
                principalColumn: "InventoryItemId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
