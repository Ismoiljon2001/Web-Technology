using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using WAD_CW_11064.Models;
using WAD_CW_11064.Repositories;

namespace WAD_CW_11064.Controllers
{
    public class ClientController : ControllerBase
    {
        [Route("api/[controller]")]
        [ApiController]
        public class CLientController : ControllerBase
        {
            private readonly IClientRepository _clientRepository;
            public CLientController(IClientRepository clientRepository)
            {
                _clientRepository = clientRepository;
            }
            // GET: api/Clients
            [HttpGet]
            public IActionResult GetClients()
            {
                var clients = _clientRepository.GetClients();
                return new OkObjectResult(clients);
                //return new string[] { "value1", "value2" };
            }
            // GET: api/Client/5
            [HttpGet, Route("{ClientId}", Name = "GetC")]
            public IActionResult Get(int ClientId)
            {
                var client = _clientRepository.GetClientById(ClientId);
                return new OkObjectResult(client);
                //return "value";
            }

            // POST: api/Client
            [HttpPost]
            public IActionResult Post([FromBody] Client client)
            {
                using (var scope = new TransactionScope())
                {
                    _clientRepository.InsertClient(client);
                    scope.Complete();
                    return CreatedAtAction(nameof(Get), new { id = client.OrderId }, client);
                }
            }
            // PUT: api/Client/5
            [HttpPut("{ClientId}")]
            public IActionResult Put([FromBody] Client client)
            {
                if (client != null)
                {
                    using (var scope = new TransactionScope())
                    {
                        _clientRepository.UpdateClient(client);
                        scope.Complete();
                        return new OkResult();
                    }
                }
                return new NoContentResult();
            }
            // DELETE: api/ApiWithActions/5
            [HttpDelete("{ClientId}")]
            public IActionResult Delete(int ClientId)
            {
                _clientRepository.DeleteClient(ClientId);
                return new OkResult();
            }

        }
    }
}       
