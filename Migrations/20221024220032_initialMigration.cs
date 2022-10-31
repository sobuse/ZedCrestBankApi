using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZedCrestBankApi.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transcations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TranscationUniqueReference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranscationAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TranscationStatus = table.Column<int>(type: "int", nullable: false),
                    TranscationSourceAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranscationDestinationAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionParticulars = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranscationType = table.Column<int>(type: "int", nullable: false),
                    TranscationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transcations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wallets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WalletName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentWalletBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WalletType = table.Column<int>(type: "int", nullable: false),
                    AccountNumberGenerator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PinSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateLastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallets", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transcations");

            migrationBuilder.DropTable(
                name: "Wallets");
        }
    }
}
