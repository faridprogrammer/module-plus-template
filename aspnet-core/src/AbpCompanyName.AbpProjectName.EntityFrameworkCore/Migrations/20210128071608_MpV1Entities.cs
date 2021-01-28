using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AbpCompanyName.AbpProjectName.Migrations
{
    public partial class MpV1Entities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Logs",
                newName: "MpLogs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MpLogs",
                table: "MpLogs",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "MpCountries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PhoneCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MpCountries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MpTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerId = table.Column<long>(type: "bigint", nullable: false),
                    CreditAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DebitAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Reason = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ReferenceEntityId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MpTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MpTransactions_AbpUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MpStateProvinces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PhoneCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MpStateProvinces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MpStateProvinces_MpCountries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "MpCountries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MpCities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PhoneCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    StateProvinceId = table.Column<int>(type: "int", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MpCities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MpCities_MpCountries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "MpCountries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MpCities_MpStateProvinces_StateProvinceId",
                        column: x => x.StateProvinceId,
                        principalTable: "MpStateProvinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MpAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    StateProvinceId = table.Column<int>(type: "int", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    AddressLine1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AddressLine2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PostalZipCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Phone1 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Phone2 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Phone3 = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Latitude = table.Column<long>(type: "bigint", nullable: true),
                    Longitude = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MpAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MpAddresses_MpCities_CityId",
                        column: x => x.CityId,
                        principalTable: "MpCities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MpAddresses_MpCountries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "MpCountries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MpAddresses_MpStateProvinces_StateProvinceId",
                        column: x => x.StateProvinceId,
                        principalTable: "MpStateProvinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MpInvoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<long>(type: "bigint", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MpInvoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MpInvoices_AbpUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MpInvoices_MpAddresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "MpAddresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MpInvoiceItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceId1 = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MpInvoiceItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MpInvoiceItems_MpInvoices_InvoiceId1",
                        column: x => x.InvoiceId1,
                        principalTable: "MpInvoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MpPayments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OwnerId = table.Column<long>(type: "bigint", nullable: false),
                    ReferenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InvoiceId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MpPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MpPayments_AbpUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MpPayments_MpInvoices_InvoiceId1",
                        column: x => x.InvoiceId1,
                        principalTable: "MpInvoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MpAddresses_CityId",
                table: "MpAddresses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_MpAddresses_CountryId",
                table: "MpAddresses",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_MpAddresses_StateProvinceId",
                table: "MpAddresses",
                column: "StateProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_MpCities_CountryId",
                table: "MpCities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_MpCities_StateProvinceId",
                table: "MpCities",
                column: "StateProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_MpInvoiceItems_InvoiceId1",
                table: "MpInvoiceItems",
                column: "InvoiceId1");

            migrationBuilder.CreateIndex(
                name: "IX_MpInvoices_AddressId",
                table: "MpInvoices",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_MpInvoices_CustomerId",
                table: "MpInvoices",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_MpPayments_InvoiceId1",
                table: "MpPayments",
                column: "InvoiceId1");

            migrationBuilder.CreateIndex(
                name: "IX_MpPayments_OwnerId",
                table: "MpPayments",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_MpStateProvinces_CountryId",
                table: "MpStateProvinces",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_MpTransactions_OwnerId",
                table: "MpTransactions",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MpInvoiceItems");

            migrationBuilder.DropTable(
                name: "MpPayments");

            migrationBuilder.DropTable(
                name: "MpTransactions");

            migrationBuilder.DropTable(
                name: "MpInvoices");

            migrationBuilder.DropTable(
                name: "MpAddresses");

            migrationBuilder.DropTable(
                name: "MpCities");

            migrationBuilder.DropTable(
                name: "MpStateProvinces");

            migrationBuilder.DropTable(
                name: "MpCountries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MpLogs",
                table: "MpLogs");

            migrationBuilder.RenameTable(
                name: "MpLogs",
                newName: "Logs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Logs",
                table: "Logs",
                column: "Id");
        }
    }
}
