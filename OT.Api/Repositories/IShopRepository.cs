using OT.Shared;

namespace OT.Api.Repositories
{
    public interface IShopRepository
    {
        Task<IEnumerable<Shop>> GetAllShopsAsync();
        Task<Shop> GetShopByIdAsync(int id);
        Task AddShopAsync(Shop shop);
        Task UpdateShopAsync(Shop shop);
        Task DeleteShopAsync(int id);
    }
}
