using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store_Bl.Migrations
{
    /// <inheritdoc />
    public partial class removerelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryForms_DepartmentOrderForms_departmentOrderFormId",
                table: "DeliveryForms");


            migrationBuilder.DropIndex(
                name: "IX_DeliveryForms_departmentOrderFormId",
                table: "DeliveryForms");

           

            migrationBuilder.DropColumn(
                name: "departmentOrderFormId",
                table: "DeliveryForms");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PurchaseOrderFormId",
                table: "ReceiptForms",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "departmentOrderFormId",
                table: "DeliveryForms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptForms_PurchaseOrderFormId",
                table: "ReceiptForms",
                column: "PurchaseOrderFormId",
                unique: true,
                filter: "[PurchaseOrderFormId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryForms_departmentOrderFormId",
                table: "DeliveryForms",
                column: "departmentOrderFormId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryForms_DepartmentOrderForms_departmentOrderFormId",
                table: "DeliveryForms",
                column: "departmentOrderFormId",
                principalTable: "DepartmentOrderForms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptForms_PurchaseOrderForms_PurchaseOrderFormId",
                table: "ReceiptForms",
                column: "PurchaseOrderFormId",
                principalTable: "PurchaseOrderForms",
                principalColumn: "Id");
        }
    }
}
