using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store_Bl.Migrations
{
    /// <inheritdoc />
    public partial class addforigenkeytoreceiptForms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PurchaseOrderFormId",
                table: "ReceiptForms",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptForms_PurchaseOrderFormId",
                table: "ReceiptForms",
                column: "PurchaseOrderFormId",
                unique: true,
                filter: "[PurchaseOrderFormId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptForms_PurchaseOrderForms_PurchaseOrderFormId",
                table: "ReceiptForms",
                column: "PurchaseOrderFormId",
                principalTable: "PurchaseOrderForms",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptForms_PurchaseOrderForms_PurchaseOrderFormId",
                table: "ReceiptForms");

            migrationBuilder.DropIndex(
                name: "IX_ReceiptForms_PurchaseOrderFormId",
                table: "ReceiptForms");

            migrationBuilder.DropColumn(
                name: "PurchaseOrderFormId",
                table: "ReceiptForms");
        }
    }
}
