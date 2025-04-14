using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SzkolenieTechniczne.Company.Storage.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Company");

            migrationBuilder.EnsureSchema(
                name: "Dictionaries");

            migrationBuilder.CreateTable(
                name: "Companies",
                schema: "Company",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    PhoneDirectional = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    NIP = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    REGON = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactTypes",
                schema: "Dictionaries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                schema: "Dictionaries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Alpha3Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    ExternalSourceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExternalId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastSynchronizedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobPositions",
                schema: "Company",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    WorkingHours = table.Column<short>(type: "smallint", nullable: true),
                    GrossSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WorkingWeekHours = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobPositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobPositions_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "Company",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactTypeTranslations",
                schema: "Dictionaries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContactTypeId = table.Column<long>(type: "bigint", nullable: false),
                    ContactTypeId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactTypeTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactTypeTranslations_ContactTypes_ContactTypeId1",
                        column: x => x.ContactTypeId1,
                        principalSchema: "Dictionaries",
                        principalTable: "ContactTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyAddresses",
                schema: "Company",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Post = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Province = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    District = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Community = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    City = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Street = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    FlatNumber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    HouseNumber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyAddresses_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "Company",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyAddresses_Countries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "Dictionaries",
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CountryTranslations",
                schema: "Dictionaries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CountryTranslations_Countries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "Dictionaries",
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobPositionTranslations",
                schema: "Company",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobPositionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Responsibilities = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobPositionTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobPositionTranslations_JobPositions_JobPositionId",
                        column: x => x.JobPositionId,
                        principalSchema: "Company",
                        principalTable: "JobPositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyAddresses_CompanyId",
                schema: "Company",
                table: "CompanyAddresses",
                column: "CompanyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CompanyAddresses_CountryId",
                schema: "Company",
                table: "CompanyAddresses",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactTypeTranslations_ContactTypeId1",
                schema: "Dictionaries",
                table: "ContactTypeTranslations",
                column: "ContactTypeId1");

            migrationBuilder.CreateIndex(
                name: "IX_ContactTypeTranslations_LanguageCode",
                schema: "Dictionaries",
                table: "ContactTypeTranslations",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_ContactTypeTranslations_Name",
                schema: "Dictionaries",
                table: "ContactTypeTranslations",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_CountryTranslations_CountryId",
                schema: "Dictionaries",
                table: "CountryTranslations",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryTranslations_LanguageCode",
                schema: "Dictionaries",
                table: "CountryTranslations",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_JobPositions_CompanyId",
                schema: "Company",
                table: "JobPositions",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_JobPositionTranslations_JobPositionId",
                schema: "Company",
                table: "JobPositionTranslations",
                column: "JobPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_JobPositionTranslations_LanguageCode",
                schema: "Company",
                table: "JobPositionTranslations",
                column: "LanguageCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyAddresses",
                schema: "Company");

            migrationBuilder.DropTable(
                name: "ContactTypeTranslations",
                schema: "Dictionaries");

            migrationBuilder.DropTable(
                name: "CountryTranslations",
                schema: "Dictionaries");

            migrationBuilder.DropTable(
                name: "JobPositionTranslations",
                schema: "Company");

            migrationBuilder.DropTable(
                name: "ContactTypes",
                schema: "Dictionaries");

            migrationBuilder.DropTable(
                name: "Countries",
                schema: "Dictionaries");

            migrationBuilder.DropTable(
                name: "JobPositions",
                schema: "Company");

            migrationBuilder.DropTable(
                name: "Companies",
                schema: "Company");
        }
    }
}
