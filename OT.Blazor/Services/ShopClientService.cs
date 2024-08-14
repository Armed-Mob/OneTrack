using OT.Shared;
using System.Net.Http.Json;

namespace OT.Blazor.Services
{
    public class ShopClientService
    {
        private readonly HttpClient _httpClient;

        public ShopClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ShopClient>> GetAllShopClientsAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<ShopClient>>("api/client");
            return response ?? Enumerable.Empty<ShopClient>().ToList();
        }

        public async Task<ShopClient> GetShopClientByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<ShopClient>($"api/client/{id}");
        }

        public async Task<(bool isSuccess, string message)> CreateClientIfNotExists(ShopClient client)
        {
            var response = await _httpClient.PostAsJsonAsync("api/client/createifnotexists", client);
            if (response.IsSuccessStatusCode)
            {
                return (true, "Client created successfully.");
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                return (false, errorMessage);
            }

            return (false, "Failed to create client due to server error. Please contact your System Administrator.");
        }

        public async Task<HttpResponseMessage> UpdateClient(ShopClient client)
        {
            return await _httpClient.PutAsJsonAsync($"api/client/{client.Id}", client);
        }

        public async Task<bool> DeleteClient(int id)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.DeleteAsync($"/api/client/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting client: {ex.Message}");
                return false;
            }
        }
    }
}
