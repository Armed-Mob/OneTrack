using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OT.Api.DataTransferObjects.VehicleColor;
using OT.Api.Repositories;
using OT.Shared;

namespace OT.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleColorController : ControllerBase
    {
        private readonly IVehicleColorRepository _vehicleColorRepository;

        public VehicleColorController(IVehicleColorRepository vehicleColorRepository)
        {
            _vehicleColorRepository = vehicleColorRepository;
        }

        // GET: api/vehiclecolor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetAllColorsResponseDTO>>> GetAllVehicleColorsAsync()
        {
            var colors = await _vehicleColorRepository.GetAllVehicleColorsAsync();
            if (colors == null)
            {
                return Ok(new List<GetAllColorsResponseDTO>());
            }

            return Ok(colors);
        }

        // GET: api/vehiclecolor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<VehicleColor>>> GetVehicleColorByIdAsync(int id)
        {
            var color = await _vehicleColorRepository.GetVehicleColorByIdAsync(id);
            if (color == null)
            {
                return NotFound("Vehicle Color not found in the database.");
            }

            return Ok(color);
        }

        // POST: api/vehiclecolor/createifnotexists
        [HttpPost("createifnotexists")]
        public async Task<IActionResult> CreateColorIfNotExists([FromBody] VehicleColor color)
        {
            var (isSuccess, message) = await _vehicleColorRepository.CreateColorIfNotExists(color);
            if (isSuccess)
            {
                return Ok(new { Message = message });
            }
            return BadRequest(message);
        }

        // PUT: api/vehiclecolor/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicleColorAsync(int id, VehicleColor vehicleColor)
        {
            if (id != vehicleColor.Id)
            {
                return BadRequest("Please check that the ids are matching.");
            }

            try
            {
                await _vehicleColorRepository.UpdateVehicleColorAsync(vehicleColor);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _vehicleColorRepository.ExistsAsync(id))
                {
                    return NotFound("Vehicle Color not found in the database.");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/vehiclecolor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicleColorAsync(int id)
        {
            var color = await _vehicleColorRepository.GetVehicleColorByIdAsync(id);
            if (color == null)
            {
                return NotFound("Vehicle Color not found in the database");
            }

            await _vehicleColorRepository.RemoveVehicleColorAsync(id);
            return NoContent();
        }
    }
}
