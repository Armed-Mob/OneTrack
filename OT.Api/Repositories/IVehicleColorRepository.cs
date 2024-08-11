using OT.Api.DataTransferObjects.VehicleColor;
using OT.Shared;

namespace OT.Api.Repositories
{
    public interface IVehicleColorRepository : IBaseRepository
    {
        Task<IEnumerable<GetAllColorsResponseDTO>> GetAllVehicleColorsAsync();
        Task<VehicleColor> GetVehicleColorByIdAsync(int id);
        Task AddVehicleColorAsync(VehicleColor vehicleColor);
        Task RemoveVehicleColorAsync(int id);
        Task UpdateVehicleColorAsync(VehicleColor vehicleColor);
    }
}
