using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace OT.Api.DataTransferObjects.VehicleColor
{
    public class GetAllColorsResponseDTO
    {
        [Display(Name = "Database Id")]
        public int Id { get; set; }
        [Display(Name = "Color Name")]
        public string ColorName { get; set; } = string.Empty;
        [Display(Name = "Hex Value")]
        public string? HexValue { get; set; }
    }
}
