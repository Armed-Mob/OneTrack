using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OT.Api.DataTransferObjects.ShopClient;
using OT.Api.Repositories;
using OT.Shared;

namespace OT.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IShopClientRepository _clientRepository;

        public ClientController(IShopClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        // GET: api/client
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetAllClientsDTO>>> GetAllClientsAsync()
        {
            var clients = await _clientRepository.GetShopClientsAsync();
            if (clients == null)
            {
                return Ok(new List<GetAllClientsDTO>());
            }

            return Ok(clients);
        }

        // GET: api/client/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ShopClient>>> GetClientByIdAsync(int id)
        {
            var client = await _clientRepository.GetShopClientByIdAsync(id);
            if (client == null)
            {
                return NotFound("Client not found in the database.");
            }

            return Ok(client);
        }

        // POST: api/client/createifnotexists
        [HttpPost("createifnotexists")]
        public async Task<IActionResult> CreateClientIfNotExists([FromBody] CreateShopClientDTO dto)
        {
            var (isSuccess, message) = await _clientRepository.CreateClientIfNotExists(dto);
            if (isSuccess)
            {
                return Ok(new { Message = message });
            }

            return BadRequest(message);
        }

        // PUT: api/client/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClientAsync(int id, [FromBody] ShopClient client)
        {
            if (id != client.Id)
            {
                return BadRequest("Please check that the ids are matching.");
            }

            try
            {
                await _clientRepository.UpdateShopClientAsync(client);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _clientRepository.ExistsAsync(id))
                {
                    return NotFound("Client not found in the database");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/client/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClientAsync(int id)
        {
            var client = await _clientRepository.GetShopClientByIdAsync(id);
            if (client == null)
            {
                return NotFound("Client not found in the database.");
            }

            await _clientRepository.DeleteShopClientAsync(id);
            return NoContent();
        }
    }
}
