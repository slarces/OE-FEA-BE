using Flag_Explorer_App.Domain.Entities.Country;
using Flag_Explorer_App.Dtos.Country;
using Flag_Explorer_App.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Security.AccessControl;
using System.Text.Json;
using System.Threading.Tasks;

namespace Flag_Explorer_App.Infrastructure.Seeders
{
    public static class CountryMetadataSeeder
    {
        private static bool _seeded = false;

        private static readonly string _jsonFilePath = "Data/countries.json";

        private static List<CountryDetail> countryDetails = [];

        private static List<CountryLocation> countryLocation = [];

        private static List<CountryFlag> countryFlags = [];

        private static List<Maps> countryMaps = [];

        public static void SeedCountries(this ModelBuilder modelBuilder)
        {
            if (_seeded) return;
            _seeded = true;

            // Get data from JSON file
            List<CountryDto> countries = GetCountries();

            if (countries.Count != 0)
            {
                CreateSeedModelData(countries);

                modelBuilder.Entity<CountryDetail>().HasData(countryDetails);

                modelBuilder.Entity<CountryLocation>().HasData(countryLocation);

                modelBuilder.Entity<Maps>().HasData(countryMaps);

                modelBuilder.Entity<CountryFlag>().HasData(countryFlags);
            }
        }

        private static void CreateSeedModelData(List<CountryDto> countries)
        {
            countries.ForEach(country => {

                var countryDetailId = StaticGuid.GenerateDeterministicGuid(country.Cca3);

                countryDetails.Add(
                        new()
                        {
                            Id = StaticGuid.GenerateDeterministicGuid(country.Cca3),
                            CommonName = country.Name.Common,
                            OfficialName = country.Name.Official,
                            Alpha2Code = country.Cca2,
                            Alpha3Code = country.Cca3,
                            Population = country.Population,
                        }
                    );

                var countryId = StaticGuid.GenerateDeterministicGuid($"{country.Cca3}" + $"{country.Ccn3}");

                countryLocation.Add(
                    new()
                    {
                        Id = countryId,
                        CountryDetailId = countryDetailId,
                        Region = country.Region,
                        SubRegion = country.Subregion,
                        Capital = country.Capital
                    });

                countryMaps.Add(
                    new()
                    {
                        Id = StaticGuid.GenerateDeterministicGuid($"{country.Cca3}" + $"{country.Area}"),
                        CountryLocationId = countryId,
                        OpenStreetMaps = country.Maps.OpenStreetMaps,
                        GoogleMaps = country.Maps.GoogleMaps,
                    });

                var countryFlagId = StaticGuid.GenerateDeterministicGuid($"{country.Cca3}" + $"{country.Flag}" + $"{country.Cca2}");

                countryFlags.Add(
                    new()
                    {
                        Id = countryFlagId,
                        CountryDetailId = countryDetailId,
                        Svg = country.Flags.Svg,
                        Png = country.Flags.Png,
                        FlagCode = country.Flag
                    });
            });
        }

        private static List<CountryDto> GetCountries()
        {
            // Ensure the file exists
            if (!File.Exists(_jsonFilePath)) return [];

            var jsonData = File.ReadAllText(_jsonFilePath);

            var countries = JsonSerializer.Deserialize<List<CountryDto>>(jsonData, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return countries ?? [];
        }
    }
}
