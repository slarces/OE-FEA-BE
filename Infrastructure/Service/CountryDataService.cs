using Flag_Explorer_App.Domain.Entities.Country;
using Flag_Explorer_App.Dtos.Country;
using System.Text.Json;

namespace Flag_Explorer_App.Infrastructure.Service
{
    public class CountryDataService(HttpClient httpClient)
    {
        private readonly HttpClient _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        private readonly string _jsonFilePath = "Data/countries.json";

        public async Task FetchAndStoreCountriesAsync()
        {
            try
            {
                var response = await _httpClient.GetStringAsync("https://restcountries.com/v3.1/all");

                var countries = JsonSerializer.Deserialize<List<CountryDto>>(response, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (countries == null || countries.Count == 0) return;

                var jsonData = JsonSerializer.Serialize(countries, new JsonSerializerOptions { WriteIndented = true });

                // Ensure the directory exists
                Directory.CreateDirectory("Data"); 

                await File.WriteAllTextAsync(_jsonFilePath, jsonData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching country data: {ex.Message}");
            }
        }
    }
}
