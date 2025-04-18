using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store_Bl.Migrations
{
    /// <inheritdoc />
    public partial class addrelationdepartment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Medical_DepId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Medical_DepId",
                table: "Users",
                column: "Medical_DepId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_MedicalDepartments_Medical_DepId",
                table: "Users",
                column: "Medical_DepId",
                principalTable: "MedicalDepartments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_MedicalDepartments_Medical_DepId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_Medical_DepId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Medical_DepId",
                table: "Users");
        }
    }
}
