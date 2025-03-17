using Microsoft.EntityFrameworkCore.Migrations;

namespace SzkolenieTechniczne.Geo.Storage.Migrations
{
    public partial class CountrySeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            InsertCountrySector(migrationBuilder, "PL", "Polska", "Poland");
            InsertCountrySector(migrationBuilder, "RU", "Rosja", "Russia");
            InsertCountrySector(migrationBuilder, "IT", "Włochy", "Italy");
            InsertCountrySector(migrationBuilder, "SK", "Słowacja", "Slovakia");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }

        private void InsertCountrySector(MigrationBuilder migrationBuilder, string alpha3Code, string namePl, string nameEn)
        {
            Guid countryId = Guid.NewGuid();
            migrationBuilder.InsertData("Countries", schema: "Geo", columns: new[] { "Id", "Alpha3Code" },
                values: new object[] { countryId, alpha3Code });

            var columns = new[] { "Id", "CountryId", "LanguageCode", "Name" };
            migrationBuilder.InsertData("CountryTransaltions", schema: "Geo", columns: columns,
                values: new object[] { Guid.NewGuid(), countryId, "pl", namePl });
            migrationBuilder.InsertData("CountryTransaltions", schema: "Geo", columns: columns,
                values: new object[] { Guid.NewGuid(), countryId, "en", nameEn });
        }
    }
}
