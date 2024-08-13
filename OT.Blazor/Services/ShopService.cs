using OT.Shared;
using System.Net.Http.Json;

namespace OT.Blazor.Services
{
    public class ShopService
    {
        private readonly HttpClient _httpClient;

        public ShopService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Shop>> GetShopsAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<Shop>>("api/shop");
            return response ?? Enumerable.Empty<Shop>().ToList();
        }

        public async Task<Shop> GetShopByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Shop>($"api/shop/{id}");
        }

        public async Task<(bool isSuccess, string message)> CreateShopIfNotExists(Shop shop)
        {
            var response = await _httpClient.PostAsJsonAsync("api/shop/createifnotexists", shop);
            if (response.IsSuccessStatusCode)
            {
                return (true, "Color created successfully.");
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                return (false, errorMessage);
            }

            return (false, "Failed to create shop due to server error. Please contact your System Administrator.");
        }

        public async Task<HttpResponseMessage> UpdateShop(Shop shop)
        {
            return await _httpClient.PutAsJsonAsync($"api/shop/{shop.Id}", shop);
        }

        public async Task<bool> DeleteShop(int id)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.DeleteAsync($"api/shop/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleteing shop: {ex.Message}");
                return false;
            }
        }

    }
}
