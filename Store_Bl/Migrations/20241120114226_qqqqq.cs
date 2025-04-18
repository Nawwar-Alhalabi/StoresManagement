using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store_Bl.Migrations
{
    /// <inheritdoc />
    public partial class qqqqq : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvoiceNumber",
                table: "DeliveryForms");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InvoiceNumber",
                table: "DeliveryForms",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
