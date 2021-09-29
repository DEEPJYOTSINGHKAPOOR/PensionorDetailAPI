using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PensionorDetailAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PensionerDetail",
                columns: table => new
                {
                    AadhaarNo = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    DOB = table.Column<DateTime>(type: "date", nullable: true),
                    PAN = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    Salary = table.Column<double>(type: "float", nullable: true),
                    Allowance = table.Column<double>(type: "float", nullable: true),
                    BankType = table.Column<int>(type: "int", nullable: true),
                    BankName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    BankAccountNo = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    PensionType = table.Column<int>(type: "int", nullable: true),
                    Password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Pensione__6F3B29F7307713C9", x => x.AadhaarNo);
                });

            migrationBuilder.CreateTable(
                name: "PensionTransaction",
                columns: table => new
                {
                    TransactionNum = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PAN = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    AadhaarNo = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: true),
                    PensionAmount = table.Column<double>(type: "float", nullable: true),
                    BankType = table.Column<int>(type: "int", nullable: true),
                    BankName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    BankAccountNo = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    PensionType = table.Column<int>(type: "int", nullable: true),
                    TransactionDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PensionT__829367DA2E88EE74", x => x.TransactionNum);
                    table.ForeignKey(
                        name: "FK__PensionTr__Aadha__398D8EEE",
                        column: x => x.AadhaarNo,
                        principalTable: "PensionerDetail",
                        principalColumn: "AadhaarNo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PensionTransaction_AadhaarNo",
                table: "PensionTransaction",
                column: "AadhaarNo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PensionTransaction");

            migrationBuilder.DropTable(
                name: "PensionerDetail");
        }
    }
}
