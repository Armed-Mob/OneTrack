using OT.Shared;

namespace OT.Api.Repositories
{
    public interface IShopClientRepository
    {
        Task<IEnumerable<ShopClient>> GetShopClientsAsync();
        Task<ShopClient> GetShopClientByIdAsync(int id);
        Task AddShopClientAsync(ShopClient shopClient);
        Task UpdateShopClientAsync(ShopClient shopClient);
        Task DeleteShopClientAsync(int id);
    }
}
