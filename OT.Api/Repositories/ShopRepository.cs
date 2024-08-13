using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using OT.Api.DataContext;
using OT.Api.DataTransferObjects.Shop;
using OT.Shared;

namespace OT.Api.Repositories
{
    public class ShopRepository : IShopRespository
    {
        private readonly OTApiSQLContext _context;
        private readonly ILogger<ShopRepository> _logger;

        public ShopRepository(OTApiSQLContext context, ILogger<ShopRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task CreateShopAsync(Shop shop)
        {
            _context.Shops.Add(shop);
            await _context.SaveChangesAsync();
        }

        public async Task<(bool isSuccess, string message)> CreateShopIfNotExists(Shop shop)
        {
            try
            {
                var exists = await _context.Shops.AnyAsync(s =>
                    s.ShopName.ToLower() == shop.ShopName.ToLower());
                if (exists)
                {
                    return (false, "Shop already exists.");
                }

                _context.Shops.Add(shop);
                await _context.SaveChangesAsync();
                return (true, "Shop created successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating shop with name {ShopName}", shop.ShopName);
                return (false, "Failed to create shop due to server error");
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Shops.AnyAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<GetAllShopsDTO>> GetAllShopsAsync()
        {
            var shops = await _context.Shops
                .Select(s => new GetAllShopsDTO
                {
                    Id = s.Id,
                    ShopOwnerFirstName = s.ShopOwnerFirstName,
                    ShopOwnerLastName = s.ShopOwnerLastName,
                    ShopName = s.ShopName,
                    ShopOwner = s.ShopOwner,
                    ShopOwnerEmail = s.ShopOwnerEmail,
                    ShopOwnerPhone = s.ShopOwnerPhone,
                    ShopEmail = s.ShopEmail,
                    ShopPhone = s.ShopPhone,
                })
                .OrderBy(s => s.ShopOwnerFirstName)
                .OrderBy(s => s.ShopOwnerLastName)
                .ToListAsync();

            return shops;
        }

        public async Task<Shop> GetShopByIdAsync(int id)
        {
            if (id == 0)
            { return null; }

            var shop = await _context.Shops.FirstOrDefaultAsync(s => s.Id == id);
            if (shop == null)
            { return null; }

            return shop;
        }

        public async Task RemoveShopAsync(int id)
        {
            var shop = await GetShopByIdAsync(id);

            if (shop != null)
            {
                _context.Shops.Remove(shop);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateShopAsync(Shop shop)
        {
            _context.Shops.Update(shop);
            await _context.SaveChangesAsync();
        }
    }
}
