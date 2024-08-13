
using OT.Api.DataTransferObjects.Shop;
using OT.Shared;

namespace OT.Api.Repositories
{
    public interface IShopRespository : IBaseRepository
    {
        Task<IEnumerable<GetAllShopsDTO>> GetAllShopsAsync();
        Task<Shop> GetShopByIdAsync(int id);
        Task CreateShopAsync(Shop shop);
        Task RemoveShopAsync(int id);
        Task UpdateShopAsync(Shop shop);
        Task<(bool isSuccess, string message)> CreateShopIfNotExists(Shop shop);
    }
}
