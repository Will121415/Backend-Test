using System.Linq;
using System.Collections.Generic;
using back_end.models;
using BLL;
using DAL;
using Entity;
using Microsoft.AspNetCore.Mvc;

namespace back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController: ControllerBase
    {
        private readonly ClientService _clientService;
        public ClientController(TestContext testContext)
        {
            _clientService = new ClientService(testContext);
        }
         [HttpPost]
        public ActionResult<ClientViewModel> Save(ClientInputModel clientInput)
        {
            Client client = MapClient(clientInput);
            var response = _clientService.Save(client);

            if(response.Object == null) return BadRequest(response.Message);

            return Ok(response.Object);
        }
        private Client MapClient(ClientInputModel clientInput)
        {
            Client client = new Client();

            client.Indentification = clientInput.Indentification;
            client.Name = clientInput.Name;
            client.LastName = clientInput.LastName;
            client.Phone = clientInput.Phone;
            client.Address = clientInput.Address;
            client.Neighborhood = clientInput.Neighborhood;
            client.City = clientInput.City;
            return client;
        }
        [HttpGet]
        public ActionResult<IEnumerable<ClientViewModel>> AllClients()
        {
            var response = _clientService.AllClients();

            if(response.Objects == null) return BadRequest(response.Message);
             
            var clients = response.Objects.Select(c => new ClientViewModel(c));

            return Ok(clients);
        }
        
        [HttpGet("{identification}")]
        public ActionResult<ClientViewModel> SearchById(string identification)
        {
            var response =  _clientService.FindById(identification);

            if(response.Object == null) return NotFound("Cliente no encontrado!");
            var client = new ClientViewModel(response.Object);
            return Ok(client);
        }

        [HttpPut] 
        public ActionResult<ClientViewModel> Modify(ClientInputModel clientInput)
        {
            Client client = MapClient(clientInput);
            var response =  _clientService.Modify(client);

            if (response.Error) return BadRequest(response.Message);

            return Ok(response.Object);
        }
    }
}