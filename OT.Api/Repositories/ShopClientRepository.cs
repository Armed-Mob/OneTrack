using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using OT.Api.DataContext;
using OT.Shared;

namespace OT.Api.Repositories
{
    public class ShopClientRepository : IShopClientRepository
    {
        private readonly OTApiSQLContext _context;

        public ShopClientRepository(OTApiSQLContext context)
        {
            _context = context;
        }

        public async Task AddShopClientAsync(ShopClient shopClient)
        {
            _context.ShopClients.Add(shopClient);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteShopClientAsync(int id)
        {
            var shopClient = await GetShopClientByIdAsync(id);
            if (shopClient != null)
            {
                _context.ShopClients.Update(shopClient);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ShopClient> GetShopClientByIdAsync(int id)
        {
            if (id == 0)
            {
                return null;
            }
            var client = await _context.ShopClients.FirstOrDefaultAsync(c => c.Id == id);   
            if (client == null)
            {
                return null;
            }
            return client;
        }

        public async Task<IEnumerable<ShopClient>> GetShopClientsAsync()
        {
            return await _context.ShopClients.ToListAsync();
        }

        public async Task UpdateShopClientAsync(ShopClient shopClient)
        {
            _context.ShopClients.Update(shopClient);
            await _context.SaveChangesAsync();
        }
    }
}
