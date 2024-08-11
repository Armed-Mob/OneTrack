using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using OT.Api.DataContext;
using OT.Shared;

namespace OT.Api.Repositories
{
    public class ShopRepository : IShopRepository
    {
        private readonly OTApiSQLContext _context;

        public ShopRepository(OTApiSQLContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Shop>> GetAllShopsAsync()
        {
            return await _context.Shops.ToListAsync();
        }

        public async Task<Shop> GetShopByIdAsync(int id)
        {
            if (id == 0)
            {
                return null;
            }
            var shop = await _context.Shops.SingleOrDefaultAsync(s => s.Id == id);
            if (shop == null)
            {
                return null;
            }
            return shop;
        }

        public async Task AddShopAsync(Shop shop)
        {
            _context.Shops.Add(shop);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateShopAsync(Shop shop)
        {
            _context.Shops.Update(shop);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteShopAsync(int id)
        {
            var shop = await GetShopByIdAsync(id);
            if (shop != null)
            {
                _context.Shops.Remove(shop);
                await _context.SaveChangesAsync();
            }
        }
    }
}
