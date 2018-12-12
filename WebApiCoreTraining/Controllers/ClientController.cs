using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiCoreTraining.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApiCoreTraining.Services;



namespace WebApiCoreTraining.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IRepository<Client> clientRepository;
        private readonly IMapper mapper;
        private readonly ClientService clientService;

        public ClientController(IRepository<Client> clientRepository, IMapper mapper, ClientService clientService)
        {
            this.clientRepository = clientRepository;
            this.mapper = mapper;            
            this.clientService = clientService;
         
            
        }

        [HttpPost]
        [Route("AddClient")]
        public async Task<ActionResult> AddClient([FromBody] ClientDTO clientDTO )
        {
            if(ModelState.IsValid)
            {
            
                var client = mapper.Map<Client>(clientDTO);
                await clientService.AddClient(client);
            }
     
            return Ok("Has been Added");
        }
        [HttpGet]
        [Route("GetClient")]
        public async Task<ActionResult> GetClient(int id)
        {

            var client = await clientRepository.GetAsync(id);          
            var result  = mapper.Map<ClientDTO>(client);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet]
        [Route("GetAllClient")]
        public ActionResult GetAllClient()
        {        
            var result = mapper.Map<IList<ClientDTO>>(clientService.GetAllClient());  
            
            return Ok(result);
        }
        [HttpGet]
        [Route("RemoveClient")]
        public async Task<ActionResult> RemoveClient(int id)
        {                   
            await clientRepository.RemoveAsync(id);
            return Ok("Has been Deleted");
        }
  
    }

}