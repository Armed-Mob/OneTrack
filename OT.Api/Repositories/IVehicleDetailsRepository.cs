using OT.Shared;

namespace OT.Api.Repositories
{
    public interface IVehicleDetailsRepository
    {
        Task<IEnumerable<VehicleDetails>> GetAllVehicleDetailsAsync();
        Task<VehicleDetails> GetVehicleDetailsByIdAsync(int id);
        Task AddVehicleDetailsAsync(VehicleDetails vehicleDetails);
        Task UpdateVehicleDetailsAsync(VehicleDetails vehicleDetails);
        Task DeleteVehicleDetailsAsync(int id);
    }
}
