using Microsoft.EntityFrameworkCore.Migrations;

namespace PensionorDetailAPI.Migrations
{
    public partial class AddedOnDeleteCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__PensionTr__Aadha__398D8EEE",
                table: "PensionTransaction");

            migrationBuilder.AddForeignKey(
                name: "FK__PensionTr__Aadha__398D8EEE",
                table: "PensionTransaction",
                column: "AadhaarNo",
                principalTable: "PensionerDetail",
                principalColumn: "AadhaarNo",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__PensionTr__Aadha__398D8EEE",
                table: "PensionTransaction");

            migrationBuilder.AddForeignKey(
                name: "FK__PensionTr__Aadha__398D8EEE",
                table: "PensionTransaction",
                column: "AadhaarNo",
                principalTable: "PensionerDetail",
                principalColumn: "AadhaarNo",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
