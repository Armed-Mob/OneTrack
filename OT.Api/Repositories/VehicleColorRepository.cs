using Microsoft.EntityFrameworkCore;
using OT.Api.DataContext;
using OT.Api.DataTransferObjects.VehicleColor;
using OT.Shared;

namespace OT.Api.Repositories
{
    public class VehicleColorRepository : IVehicleColorRepository
    {
        private readonly OTApiSQLContext _context;
        private readonly ILogger<VehicleColorRepository> _logger;

        public VehicleColorRepository(OTApiSQLContext context, ILogger<VehicleColorRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<GetAllColorsResponseDTO>> GetAllVehicleColorsAsync()
        {
            var colors = await _context.VehicleColors
                .Select(c => new GetAllColorsResponseDTO
                {
                    Id = c.Id,
                    ColorName = c.ColorName,
                    HexValue = c.HexValue
                })
                .OrderByDescending(c => c.ColorName)
                .ToListAsync();

            return colors;
        }

        public async Task<VehicleColor> GetVehicleColorByIdAsync(int id)
        {
            if (id == 0)
            {
                return null;
            }
            var color = await _context.VehicleColors.FirstOrDefaultAsync(c => c.Id == id);
            if (color == null)
            {
                return null;
            }

            return color;
        }

        public async Task AddVehicleColorAsync(VehicleColor vehicleColor)
        {
            _context.VehicleColors.Add(vehicleColor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateVehicleColorAsync(VehicleColor vehicleColor)
        {
            _context.VehicleColors.Update(vehicleColor);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveVehicleColorAsync(int id)
        {
            var color = await GetVehicleColorByIdAsync(id);
            if (color != null)
            {
                _context.VehicleColors.Remove(color);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.VehicleColors.AnyAsync(c => c.Id == id);
        }

        public async Task<(bool isSuccess, string message)> CreateColorIfNotExists(VehicleColor color)
        {
            try
            {
                var exists = await _context.VehicleColors.AnyAsync(c =>
                    c.ColorName.ToLower() == color.ColorName.ToLower() ||
                    c.HexValue.ToLower() == color.ColorName.ToLower());

                if (exists)
                {
                    return (false, "Color already exists.");
                }

                _context.VehicleColors.Add(color);
                await _context.SaveChangesAsync();
                return (true, "Color created successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error createing color with name {ColorName}", color.ColorName);
                return (false, "Failed to create color due to server error.");
            }
        }
    }
}
