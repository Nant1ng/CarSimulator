using System.Text.Json;
using SimulatorLibrary.Models;
using SimulatorLibrary.Interfaces;

namespace SimulatorLibrary.Services
{
    public class DriverService : IDriverService
    {
        private readonly HttpClient _httpClient;

        public DriverService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<Driver> GetRandomDriver()
        {
            var response = await _httpClient.GetStringAsync("https://randomuser.me/api/");
            var jsonDoc = JsonDocument.Parse(response);
            var user = jsonDoc.RootElement.GetProperty("results")[0];

            var driver = new Driver
            {
                Title = user.GetProperty("name").GetProperty("title").GetString(),
                Name = $"{user.GetProperty("name").GetProperty("first").GetString()} {user.GetProperty("name").GetProperty("last").GetString()}",
                Gender = user.GetProperty("gender").GetString()
            };

            return driver;
        }
    }
}
