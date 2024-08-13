using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using OT.Api.DataTransferObjects.Shop;
using OT.Api.Repositories;
using OT.Shared;

namespace OT.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly IShopRespository _shopRespository;

        public ShopController(IShopRespository shopRespository)
        {
            _shopRespository = shopRespository;
        }

        // GET: /api/shop
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetAllShopsDTO>>> GetAllShopsAsync()
        {
            var shops = await _shopRespository.GetAllShopsAsync();
            if (shops == null)
            {
                return Ok(new List<GetAllShopsDTO>());
            }

            return Ok(shops);
        }

        // GET: api/shop/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Shop>>> GetShopByIdAsync(int id)
        {
            var shop = await _shopRespository.GetShopByIdAsync(id);
            if (shop == null)
            {
                return NotFound("Shop not found in the database.");
            }

            return Ok(shop);
        }

        // POST: api/shop/createifnotexists
        [HttpPost("createifnotexists")]
        public async Task<IActionResult> CreateShopIfNotExists([FromBody] Shop shop)
        {
            var (isSuccess, message) = await _shopRespository.CreateShopIfNotExists(shop);
            if (isSuccess)
            {
                return Ok(new { Message = message });
            }
            return BadRequest(message);
        }

        // PUT: api/shop/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateShopAsync(int id, [FromBody] Shop shop)
        {
            if (id != shop.Id)
            {
                return BadRequest("Please check that ids are matching.");
            }
            try
            {
                await _shopRespository.UpdateShopAsync(shop);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _shopRespository.ExistsAsync(id))
                {
                    return NotFound("Shop not found in the database");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/shop/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShopAsync(int id)
        {
            var shop = await _shopRespository.GetShopByIdAsync(id);
            if (shop == null)
            {
                return NotFound("Shop not found in the database.");
            }

            await _shopRespository.RemoveShopAsync(id);
            return NoContent();
        }
    }
}
