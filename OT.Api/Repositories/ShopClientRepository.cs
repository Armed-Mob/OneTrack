using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using OT.Api.DataContext;
using OT.Api.DataTransferObjects.ShopClient;
using OT.Shared;

namespace OT.Api.Repositories
{
    public class ShopClientRepository : IShopClientRepository
    {
        private readonly OTApiSQLContext _context;
        private readonly ILogger<ShopClientRepository> _logger;

        public ShopClientRepository(OTApiSQLContext context, ILogger<ShopClientRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task AddShopClientAsync(CreateShopClientDTO dto)
        {
            var client = new ShopClient
            {
                Id = dto.Id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                ClientEmail = dto.Email,
                ClientPhone = dto.Phone,
                ShopId = dto.ShopId,
            };

            _context.ShopClients.Add(client);
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

        public async Task<IEnumerable<GetAllClientsDTO>> GetShopClientsAsync()
        {
            var clients = await _context.ShopClients
                .Include(c => c.Shop)
                .Where(c => c.Shop.Id == c.ShopId)
                .Select(sc => new GetAllClientsDTO
                {
                    Id = sc.Id,
                    FirstName = sc.FirstName,
                    LastName = sc.LastName,
                    ClientPhone = sc.ClientPhone,
                    ClientEmail = sc.ClientEmail,
                    ShopId = sc.ShopId,
                })                
                .OrderBy(sc => sc.FirstName)
                .OrderBy(sc => sc.LastName)
                .ToListAsync();

            return clients;
        }

        public async Task UpdateShopClientAsync(ShopClient shopClient)
        {
            _context.ShopClients.Update(shopClient);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.ShopClients.AnyAsync(sc => sc.Id == id);
        }

        public async Task<(bool isSuccess, string message)> CreateClientIfNotExists(CreateShopClientDTO dto)
        {
            try
            {
                var exists = await _context.ShopClients.AnyAsync(sc =>
                    sc.FirstName.ToLower() == dto.FirstName.ToLower() &&
                    sc.LastName.ToLower() == dto.LastName.ToLower());
                if (exists)
                {
                    return (false, "Client already exists.");
                }               

                var client = new ShopClient
                {
                    Id = dto.Id,
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    ClientEmail = dto.Email,
                    ClientPhone = dto.Phone,
                    ShopId = dto.ShopId                
                };
                _context.ShopClients.Add(client);
                await _context.SaveChangesAsync();
                return (true, "Client created successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating client with name {ClientFirstName} {ClientLastName}", dto.FirstName, dto.LastName);
                return (false, "Failed to create client due to server error.");
            }
        }
    }
}
