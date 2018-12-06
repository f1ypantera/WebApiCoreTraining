using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiCoreTraining.Models;


namespace WebApiCoreTraining.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    

    public class ClientController : ControllerBase

    {
        private readonly IRepository<Client> _clientRepository;
        private readonly IRepository<Property> _propertyRepository;
        


        public ClientController(IRepository<Client> clientRepository, IRepository<Property>  propertyRepository)
        {
            _clientRepository = clientRepository;
            _propertyRepository = propertyRepository;

        }

        [HttpPost]
        [Route("AddClient")]
        public async Task<ActionResult> AddClient([FromBody] Client client)
        {
            client.DateTimeRegister = DateTime.Now;
            await _clientRepository.AddAsync(client); 
            
            
            
            return Ok("Has been Added");
        }
        [HttpGet]
        [Route("GetClient")]
        public async Task<ActionResult> GetClient(int id)
        {
            var result =  await _clientRepository.GetAsync(id);
           
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet]
        [Route("GetAllClient")]
        public  ActionResult GetAllClient()
        {
            var result =_clientRepository.GetAll();
            return Ok(result);
            
        }
        [HttpGet]
        [Route("RemoveClient")]
        public async Task<ActionResult> RemoveClient(int id)
        {
            await _clientRepository.RemoveAsync(id);
            return Ok("Has been Deleted");
        }
        //[HttpGet]
        //[Route("GetPropertyByClientId")]
        //public ActionResult GetPropertyByClientId(int id)
        //{


        //    var result = db.Properties.Where(p => p.ClientId == id).Select(u => new
        //    {
        //        u.Name,
        //        u.Adress,
        //        ClientName = db.Clients.FirstOrDefault(c => c.ClientId == u.ClientId).Name,

        //    });
        //    if (result == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(result);
        //}



        [HttpPost]
        [Route("AddProperty")]
        public async Task<ActionResult> AddProperty([FromBody] Property property)
        {
            
            await  _propertyRepository.AddAsync(property);
            return Ok("Has been added");
        }
        [HttpGet]
        [Route("GetProperty")]
        public async Task<ActionResult> GetProperty(int id)
        {
            var result = await _propertyRepository.GetAsync(id);
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
            var result = _propertyRepository.GetAll();
            return Ok(result);

        }
        [HttpGet]
        [Route("RemoveProperty")]
        public async Task<ActionResult> RemoveProperty(int id)
        {
           await  _propertyRepository.RemoveAsync(id);
            return Ok("Has been deleted");
        }






    }

}