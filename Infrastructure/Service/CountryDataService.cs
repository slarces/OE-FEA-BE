using Flag_Explorer_App.Domain.Entities.Country;
using Flag_Explorer_App.Dtos.Country;
using Polly;
using System.Text.Json;

namespace Flag_Explorer_App.Infrastructure.Service
{
    public class CountryDataService(HttpClient httpClient)
    {
        private readonly HttpClient _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        private readonly string _jsonFilePath = "Data/countries.json";


        public async Task FetchAndStoreCountriesAsync()
        {
            var retryPolicy = 
                Policy.Handle<Exception>()
                .WaitAndRetryAsync(5,
                    retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),  // exponential backoff
                        (exception, timeSpan, retryCount, context) =>
                            {
                                Console.WriteLine($"Retry {retryCount} encountered an error: {exception.Message}. Waiting {timeSpan} before next retry.");
                            });

            var cts = new CancellationTokenSource(TimeSpan.FromSeconds(60));
            _httpClient.Timeout = TimeSpan.FromSeconds(60);

            var response = "";

            try
            {
                await retryPolicy.ExecuteAsync(async () =>
                {
                     response = await _httpClient.GetStringAsync("https://restcountries.com/v3.1/all", cts.Token);
                });
                
                Console.WriteLine(response);

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
