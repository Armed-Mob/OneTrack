using Microsoft.EntityFrameworkCore;
using OT.Api.DataContext;
using OT.Shared;

namespace OT.Api.Repositories
{
    public class VehicleDetailsRepository : IVehicleDetailsRepository
    {
        private readonly OTApiSQLContext _context;

        public VehicleDetailsRepository(OTApiSQLContext context)
        {
            _context = context;
        }

        public async Task AddVehicleDetailsAsync(VehicleDetails vehicleDetails)
        {
            _context.VehicleDetails.Add(vehicleDetails);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteVehicleDetailsAsync(int id)
        {
            var vehicle = await GetVehicleDetailsByIdAsync(id);
            if (vehicle != null)
            {
                _context.VehicleDetails.Remove(vehicle);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<VehicleDetails>> GetAllVehicleDetailsAsync()
        {
            return await _context.VehicleDetails.ToListAsync();
        }

        public async Task<VehicleDetails> GetVehicleDetailsByIdAsync(int id)
        {
            if (id == 0)
            {
                return null;
            }
            var vehicle = await _context.VehicleDetails.SingleOrDefaultAsync(v => v.Id == id);
            if (vehicle == null)
            {
                return null;
            }
            return vehicle;
        }

        public async Task UpdateVehicleDetailsAsync(VehicleDetails vehicleDetails)
        {
            _context.VehicleDetails.Update(vehicleDetails);
            await _context.SaveChangesAsync();
        }
    }
}
