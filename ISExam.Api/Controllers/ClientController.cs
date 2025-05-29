using ISExam.Service.DTOs;
using ISExam.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ISExam.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService service;

        public ClientController(IClientService service)
        {
            this.service = service;
        }

        [HttpGet]
        public List<ClientDTO> Get()
        {
            var Clients = service.GetClients();

            return Clients;
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var Client = service.GetClient(id);
            if (Client == null)
                return NotFound();
            return Ok(Client);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ClientDTO Client)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var existingClient = service.GetClient(Client.Id);

            if (existingClient != null)
                return Conflict($"Client with id {Client.Id} already exists.");

            var newClient = service.AddClient(Client);

            return Created($"Client with id {newClient.Id} created successfully", newClient);
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] ClientDTO Client)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
            var existingClient = service.GetClient(id);
            if (existingClient == null)
                return NotFound();
            Client.Id = id;
            var updatedClient = service.UpdateClient(Client);
            return Ok(updatedClient);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = service.DeleteClient(id);

            if (result == false)
                return NotFound($"Client with id {id} not found.");

            return Ok($"Client with id {id} deleted successfully.");
        }
    }
}
