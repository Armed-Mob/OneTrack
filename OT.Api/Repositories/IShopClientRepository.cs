using OT.Api.DataTransferObjects.ShopClient;
using OT.Shared;

namespace OT.Api.Repositories
{
    public interface IShopClientRepository : IBaseRepository
    {
        Task<IEnumerable<GetAllClientsDTO>> GetShopClientsAsync();
        Task<ShopClient> GetShopClientByIdAsync(int id);
        Task AddShopClientAsync(CreateShopClientDTO dto);
        Task UpdateShopClientAsync(ShopClient shopClient);
        Task DeleteShopClientAsync(int id);
        Task<(bool isSuccess, string message)> CreateClientIfNotExists(CreateShopClientDTO dto);
    }
}
