using Flag_Explorer_App.Domain.Entities.Country;
using Flag_Explorer_App.Dtos.Country;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Security.AccessControl;
using System.Text.Json;
using System.Threading.Tasks;

namespace Flag_Explorer_App.Infrastructure.Seeders
{
    public static class CountryMetadataSeeder
    {
        private static readonly string _jsonFilePath = "Data/countries.json";

        private static List<CountryLocation> countryLocation = [];

        private static List<CountryFlag> countryFlags = [];

        public static void SeedCountries(this ModelBuilder modelBuilder)
        {
            // Get data from JSON file
            List<CountryDto> countries = GetCountries();

            // DB Model
            List<CountryDetail> countryDetails = [];

            if (countries.Count != 0)
            {
                countries.ForEach(country => {
                    countryDetails.Add(
                        new() 
                        {
                            Id = Guid.NewGuid(),
                            CommonName = country.Name.Common,
                            OfficialName = country.Name.Official,
                            Alpha2Code = country.Cca2,
                            Alpha3Code = country.Cca3,
                            Population = country.Population,
                        }
                    );
                });

                modelBuilder.Entity<CountryDetail>().HasData(countryDetails);

                SeedCountryLocations(countryDetails, countries);

                modelBuilder.Entity<CountryLocation>().HasData(countryLocation);

                SeedCountryFlags(countryDetails, countries);

                modelBuilder.Entity<CountryFlag>().HasData(countryFlags);
            }
        }

        
        private static void SeedCountryLocations(List<CountryDetail> countryDetail, List<CountryDto> countries)
        {
            countries.ForEach(country => {
                var newId = Guid.NewGuid();

                countryLocation.Add(
                    new()
                    {
                        Id = newId,
                        CountryDetailId = countryDetail.Find(c => c.Alpha2Code == country.Cca2)!.Id,
                        Region = country.Region,
                        SubRegion = country.Subregion,
                        Capital = country.Capital,
                        MapAddresses = new()
                        {
                            Id = Guid.NewGuid(),
                            CountryLocationId = newId,
                            OpenStreetMaps = country.Maps.OpenStreetMaps,
                            GoogleMaps = country.Maps.GoogleMaps,
                        }
   
                    });
            });  
        }

        private static void SeedCountryFlags(List<CountryDetail> countryDetail, List<CountryDto> countries)
        {
            countries.ForEach(country => {
                var newId = Guid.NewGuid();

                countryFlags.Add(
                    new()
                    {
                        Id = newId,
                        CountryDetailId = countryDetail.Find(c => c.Alpha2Code == country.Cca2)!.Id,
                        Svg = country.Flags.Svg,
                        Png = country.Flags.Png,
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
