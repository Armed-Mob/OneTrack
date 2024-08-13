using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OT.Shared
{
    public class VehicleDetails
    {
        public int Id { get; set; }
        public string Make { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string Year { get; set; } = string.Empty;
        public string? Trim { get; set; } = string.Empty;
        public string? Doors { get; set; } = string.Empty;
        public string? Gvwr { get; set; } = string.Empty;
        public int? ColorId { get; set; }
        public string? Series { get; set; } = string.Empty;
        public string? DriveType { get; set; } = string.Empty;
        public string? EngineModel { get; set; } = string.Empty;
        public string? Turbo { get; set; } = string.Empty;
        public string? CabType { get; set; } = string.Empty;
        public string? FuelTypePrimary { get; set; } = string.Empty;
        public string? DisplacementL { get; set; } = string.Empty;

        public int ShopClientId { get; set; }
        public virtual ShopClient ShopClient { get; set; }
    }
}
