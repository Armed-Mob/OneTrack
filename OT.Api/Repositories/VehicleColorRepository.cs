using Microsoft.EntityFrameworkCore;
using OT.Api.DataContext;
using OT.Api.DataTransferObjects.VehicleColor;
using OT.Shared;

namespace OT.Api.Repositories
{
    public class VehicleColorRepository : IVehicleColorRepository
    {
        private readonly OTApiSQLContext _context;

        public VehicleColorRepository(OTApiSQLContext context)
        {
            _context = context;
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
        
    }
}
