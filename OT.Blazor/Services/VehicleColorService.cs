using OT.Shared;
using System.Drawing;
using System.Net.Http.Json;

namespace OT.Blazor.Services
{
    public class VehicleColorService
    {
        private readonly HttpClient _httpClient;

        public VehicleColorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<VehicleColor>> GetVehicleColorsAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<VehicleColor>>("api/vehiclecolor");
            return response ?? Enumerable.Empty<VehicleColor>().ToList();
        }

        public async Task<VehicleColor> GetVehicleColorByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<VehicleColor>($"api/vehiclecolor/{id}");
        }

        public async Task AddVehicleColor(VehicleColor color)
        {
            await _httpClient.PostAsJsonAsync("api/vehiclecolor", color);
        }

        public async Task UpdateVehicleColor(VehicleColor color)
        {
            await _httpClient.PutAsJsonAsync($"api/vehiclecolor/{color.Id}", color);
        }

        public async Task<bool> DeleteVehicleColor(int id)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.DeleteAsync($"/api/vehiclecolor/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex) 
            {
                // TODO: Log the exception or handle it accordingly
                Console.WriteLine($"Error deleting vehicle color: {ex.Message}");
                return false;
            }            
        }
    }
}
