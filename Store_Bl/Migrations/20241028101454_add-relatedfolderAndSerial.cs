using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store_Bl.Migrations
{
    /// <inheritdoc />
    public partial class addrelatedfolderAndSerial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RelatedFolder",
                table: "DeliveryForms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RelatedSerial",
                table: "DeliveryForms",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RelatedFolder",
                table: "DeliveryForms");

            migrationBuilder.DropColumn(
                name: "RelatedSerial",
                table: "DeliveryForms");
        }
    }
}
