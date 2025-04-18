using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store_Bl.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Itemspurchased_PurchaseOrderForms_PurchaseOrderFormId",
                table: "Itemspurchased");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Itemspurchased",
                table: "Itemspurchased");

            migrationBuilder.RenameTable(
                name: "Itemspurchased",
                newName: "ItemsPurchased");

            migrationBuilder.RenameIndex(
                name: "IX_Itemspurchased_PurchaseOrderFormId",
                table: "ItemsPurchased",
                newName: "IX_ItemsPurchased_PurchaseOrderFormId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemsPurchased",
                table: "ItemsPurchased",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemsPurchased_PurchaseOrderForms_PurchaseOrderFormId",
                table: "ItemsPurchased",
                column: "PurchaseOrderFormId",
                principalTable: "PurchaseOrderForms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemsPurchased_PurchaseOrderForms_PurchaseOrderFormId",
                table: "ItemsPurchased");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemsPurchased",
                table: "ItemsPurchased");

            migrationBuilder.RenameTable(
                name: "ItemsPurchased",
                newName: "Itemspurchased");

            migrationBuilder.RenameIndex(
                name: "IX_ItemsPurchased_PurchaseOrderFormId",
                table: "Itemspurchased",
                newName: "IX_Itemspurchased_PurchaseOrderFormId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Itemspurchased",
                table: "Itemspurchased",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Itemspurchased_PurchaseOrderForms_PurchaseOrderFormId",
                table: "Itemspurchased",
                column: "PurchaseOrderFormId",
                principalTable: "PurchaseOrderForms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
