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

        private readonly static List<Client> clients = new List<Client>();

        private readonly static List<Property> properties = new List<Property>();

  
        [HttpPost]
        [Route("AddClient")]
        public ActionResult AddClient([FromBody]Client client)
        {
            int lastId = 1;
                                           
            var generateTime = DateTime.Now;

            client.ClientId = lastId;
            
            client.DateTimeRegister = generateTime;
            clients.Add(client);          
            return Ok();
        }
        [HttpGet]
        [Route("GetClient")]
        public ActionResult GetClient(int id)
        {
            var result = clients.FirstOrDefault(u=>u.ClientId == id);

            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet]
        [Route("GetAllClient")]
        public ActionResult GetAllClient()
        {
            var result = clients.ToList();
            return Ok(result);
            
        }

        [HttpPost]
        [Route("AddProperty")]
        public ActionResult AddProperty([FromBody]Property property)
        {

            properties.Add(property);

            return Ok();
        }
        [HttpGet]
        [Route("GetProperty")]
        public ActionResult GetProperty(int id)
        {
            var result = properties.FirstOrDefault(u => u.Id == id);

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
            var result = properties.ToList();
            return Ok(result);

        }
        [HttpGet]
        [Route("GetPropertyByClientId")]
        public ActionResult GetPropertyByClientId(int id)
        {
            var result = properties.Where(p => p.ClientId == id);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }








    }

}