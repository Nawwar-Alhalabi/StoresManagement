using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store_Bl.Migrations
{
    /// <inheritdoc />
    public partial class EditstatusOfPurchaseOrderAndAddAccountant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountantApproval",
                table: "PurchaseOrderForms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ManagerApproval",
                table: "PurchaseOrderForms",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountantApproval",
                table: "PurchaseOrderForms");

            migrationBuilder.DropColumn(
                name: "ManagerApproval",
                table: "PurchaseOrderForms");
        }
    }
}
