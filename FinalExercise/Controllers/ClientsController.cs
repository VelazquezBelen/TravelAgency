using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FinalExercise.Domain.Models;
using FinalExercise.Domain.Interfaces;
using AutoMapper;
using FinalExercise.DTOs;
using FinalExercise.Services;

namespace FinalExercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly CosmosDbClientService _cosmosDbClientService;
        private readonly CosmosDbConfigurationService _cosmosDbConfigurationService;

        public ClientsController(IUnitOfWork unitOfWork, IMapper mapper, CosmosDbClientService cosmosDbClientService, CosmosDbConfigurationService cosmosDbConfigurationService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cosmosDbClientService = cosmosDbClientService;
            _cosmosDbConfigurationService = cosmosDbConfigurationService;
        }

        // GET: api/Clients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClient() => Ok(await _unitOfWork.Client.GetAll());


        // GET: api/Clients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClient(int id)
        {
            var client = await _unitOfWork.Client.Get(id);

            if (client == null)
            {
                return NotFound();
            }

            return client;
        }

        // PUT: api/Clients/5
        [HttpPut("{id}")]
        public IActionResult PutClient(int id, Client client)
        {
            if (id != client.ClientId)
            {
                return BadRequest();
            }

            if (!_unitOfWork.Client.Any(id))
            {
                return NotFound();
            }
            _unitOfWork.Client.Update(_mapper.Map<Client>(client));
            _unitOfWork.Complete();
            return Ok("Client Updated");
        }

        // POST: api/Clients
        [HttpPost]
        public IActionResult PostClient(ClientPostDTO client)
        {
            var result = _unitOfWork.Client.Add(_mapper.Map<Client>(client));
            _unitOfWork.Complete();
            if (result is not null)
                return Ok("Client Created");
            else
                return BadRequest("Error in Creating the Client");

        }

        // DELETE: api/Clients/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteClient(int id)
        {
            var client = await _unitOfWork.Client.Get(id);
            if (client == null)
            {
                return NotFound();
            }
            _unitOfWork.Client.Delete(client);
            _unitOfWork.Complete();
            return Ok("Client Deleted");
        }

        /* Cosmos DB */

        ///// GET: api/Clients/v2
        [HttpGet("v2")]
        public async Task<ActionResult<IEnumerable<CosmosClientModel>>> GetClientsV2()
        {
            return Ok(await _cosmosDbClientService.Get("SELECT * FROM c"));
        }

        // GET: api/Clients/v2/guid/5
        [HttpGet("v2/guid/{id}")]
        public async Task<ActionResult<IEnumerable<CosmosClientModel>>> GetClientGuidV2(string id)
        {
            var client = await _cosmosDbClientService.GetById(id);
            if (client == null)
                return NotFound();
            else
                return Ok(client);
        }

        // GET: api/Clients/v2/5
        [HttpGet("v2/{id}")]
        public async Task<ActionResult<IEnumerable<CosmosClientModelDTO>>> GetClientV2(int id)
        {
            var client = await _cosmosDbClientService.GetFirst("SELECT * FROM c WHERE c.clientId = " + id);
            if (client == null)
                return NotFound();
            else
                return Ok(_mapper.Map<CosmosClientModelDTO>(client));
        }

        // POST: api/Clients/v2
        [HttpPost("v2")]
        public async Task<IActionResult> PostClientV2(CosmosClientModelPostPutDTO client)
        {
            var newClient = _mapper.Map<CosmosClientModel>(client);
            var counter = await _cosmosDbConfigurationService.GetFirst("SELECT * FROM c");
            if (counter == null)
            {
                string newId = System.Guid.NewGuid().ToString();
                await _cosmosDbConfigurationService.Add(new Configuration() { Id = newId, Counter = 0 }, newId);
                newClient.ClientId = 0;
            }
            else
            {
                counter.Counter++;
                newClient.ClientId = counter.Counter;
                await _cosmosDbConfigurationService.Update(counter.Id, counter);
            }

            newClient.ClientGUID = System.Guid.NewGuid().ToString();
            await _cosmosDbClientService.Add(newClient, newClient.ClientGUID);
            return Ok("Client created successfully");
        }

        // PUT: api/Clients/v2/guid/5
        [HttpPut("v2/guid/{id}")]
        public async Task<ActionResult> PutClientGuidV2([Bind("Id,ClientId,Description")] CosmosClientModelPostPutDTO client, string id)
        {
            var cosmosClient = await _cosmosDbClientService.GetById(id);
            if (cosmosClient == null) { return NotFound(); }

            cosmosClient.Description = client.Description;

            await _cosmosDbClientService.Update(cosmosClient.ClientGUID, cosmosClient);
            return Ok("Client updated successfully");
        }

        // PUT: api/Clients/v2/5
        [HttpPut("v2/{id}")]
        public async Task<ActionResult> PutClientV2(CosmosClientModelPostPutDTO client, int id)
        {
            var cosmosClient = await _cosmosDbClientService.GetFirst("SELECT * FROM c WHERE c.clientId = " + id);
            if (cosmosClient == null)
                return NotFound();

            cosmosClient.Description = client.Description;
            await _cosmosDbClientService.Update(cosmosClient.ClientGUID, cosmosClient);
            return Ok("Client updated successfully");
        }

        // DELETE: api/Clients/v2/guid/5
        [HttpDelete("v2/guid/{id}")]
        public async Task<ActionResult> DeleteClientV2([Bind("Id")] string id)
        {
            var cosmosClient = await _cosmosDbClientService.GetById(id);
            if (cosmosClient == null) { return NotFound(); }

            await _cosmosDbClientService.Delete(id);
            return Ok("Client deleted successfully");
        }

        // DELETE: api/Clients/v2/5
        [HttpDelete("v2/{id}")]
        public async Task<ActionResult> DeleteClientV2([Bind("ClientId")] int id)
        {
            var client = await _cosmosDbClientService.GetFirst("SELECT * FROM c WHERE c.clientId = " + id);
            if (client == null)
                return NotFound();
            await _cosmosDbClientService.Delete(client.ClientGUID);
            return Ok("Client deleted successfully");
        }

        // GET: api/Clients/v2
        [HttpGet("v2/GetClientsByDescription")]
        public async Task<ActionResult<IEnumerable<CosmosClientModel>>> GetClientsByDescriptionV2(string description)
        {
            return Ok(await _cosmosDbClientService.Get("SELECT * FROM c WHERE c.description = " + "\"" + description + "\""));
        }        
    }
}
