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
        private readonly IRepository<Property> propertyRepository;
        private readonly IMapper mapper;
        private readonly PeopleContext peopleContext;
        private readonly ClientService clientService;

        public ClientController(IRepository<Client> clientRepository, IRepository<Property> propertyRepository, IMapper mapper, PeopleContext peopleContext, ClientService clientService)
        {
            this.clientRepository = clientRepository;
            this.propertyRepository = propertyRepository;
            this.mapper = mapper;
            this.peopleContext = peopleContext;
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
            var result = mapper.Map<IList<ClientDTO>>(clientRepository.GetAll());        
            return Ok(result);
        }
        [HttpGet]
        [Route("RemoveClient")]
        public async Task<ActionResult> RemoveClient(int id)
        {                   
            await clientRepository.RemoveAsync(id);
            return Ok("Has been Deleted");
        }
    

        [HttpPost]
        [Route("AddProperty")]
        public async Task<ActionResult> AddProperty([FromBody] PropertyAddDTO propertyAddDTO )
        {
            if (ModelState.IsValid)
            {
                var property = mapper.Map<Property>(propertyAddDTO);
                await propertyRepository.AddAsync(property);
            }
           
            return Ok("Has been added");
        }
        [HttpGet]
        [Route("GetProperty")]
        public async Task<ActionResult> GetProperty(int id)
        {
            var property = await peopleContext.Set<Property>().Include(x => x.Client).FirstAsync(x=> x.Id == id);        
            var result = mapper.Map<PropertyDetailedDTO>(property);         
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet]
        [Route("GetAllProperty")]
        public ActionResult GetAllProperty()
        {
            var clientName = peopleContext.Set<Property>().Include(x => x.Client).ToList();
            var result = mapper.Map<IList<PropertyDetailedDTO>>(clientName);                   
            return Ok(result);
        }
        [HttpGet]
        [Route("RemoveProperty")]
        public async Task<ActionResult> RemoveProperty(int id)
        {
            await propertyRepository.RemoveAsync(id);
            return Ok("Has been deleted");
        }
        [HttpGet]
        [Route("GetPropertyByClientId")]
        public ActionResult GetPropertyByClientId(int id)
        {        

            var property =  peopleContext.Set<Property>().Include(x => x.Client).Where(x => x.ClientId == id);
            var result = mapper.Map<IList<PropertyDetailedDTO>>(property);       
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }

}