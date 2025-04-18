using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store_Bl.Migrations
{
    /// <inheritdoc />
    public partial class addNewRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "departmentOrderFormId",
                table: "DeliveryForms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryForms_departmentOrderFormId",
                table: "DeliveryForms",
                column: "departmentOrderFormId",
                unique: false);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryForms_DepartmentOrderForms_departmentOrderFormId",
                table: "DeliveryForms",
                column: "departmentOrderFormId",
                principalTable: "DepartmentOrderForms",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
