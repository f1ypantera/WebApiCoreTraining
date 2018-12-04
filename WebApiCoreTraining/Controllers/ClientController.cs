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
 
        private readonly PeopleContext db;
       

        public ClientController(PeopleContext peopleContext)
        {
            db = peopleContext;
        }

        [HttpPost]
        [Route("AddClient")]
        public ActionResult AddClient([FromBody]Client client)
        {


                db.Add(client);
                db.SaveChanges();
                
        
                 
            return Ok();
        }
        [HttpGet]
        [Route("GetClient")]
        public ActionResult GetClient(int id)
        {
            var result = db.Clients.FirstOrDefault(u=>u.ClientId == id);

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
            var result = db.Clients.ToList();
            return Ok(result);
            
        }

        [HttpPost]
        [Route("AddProperty")]
        public ActionResult AddProperty([FromBody]Property property)
        {

            db.Add(property);
            db.SaveChanges();

            return Ok();
        }
        [HttpGet]
        [Route("GetProperty")]
        public ActionResult GetProperty(int id)
        {
            var result = db.Properties.FirstOrDefault(u => u.Id == id);

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
            var result = db.Properties.ToList();
            return Ok(result);

        }
        [HttpGet]
        [Route("GetPropertyByClientId")]
        public ActionResult GetPropertyByClientId(int id)
        {
            var result = db.Properties.Where(p => p.ClientId == id).Select(u => new
            {
                u.Name,
                u.Adress,
                ClientName = db.Clients.FirstOrDefault(c => c.ClientId == u.ClientId).Name,

            });
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }








    }

}