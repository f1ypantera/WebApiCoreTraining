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
           

     

    



    }

}