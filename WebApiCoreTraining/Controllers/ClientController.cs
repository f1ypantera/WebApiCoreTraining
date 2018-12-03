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
        private readonly WebApiContext _webApiContext;

        public ClientController(WebApiContext webApiContext)
        {
            _webApiContext = webApiContext;
            if (_webApiContext.Clients.Count() == 0)
            {
                _webApiContext.Clients.Add(new Client { Name = "Peter", DateTimeRegister = DateTime.Now });
                _webApiContext.Clients.Add(new Client { Name = "Mark", DateTimeRegister = DateTime.Now });


                _webApiContext.SaveChanges();
            }
            if (_webApiContext.Properties.Count() == 0)
            {
        
                _webApiContext.Properties.Add(new Property { ClientId = 1, NameProperty = "BigHouse", AdressProperty = "Boryspil" });
                _webApiContext.Properties.Add(new Property { ClientId = 2, NameProperty = "3roomFlat", AdressProperty = "Kyiv" });
                _webApiContext.Properties.Add(new Property { ClientId = 2, NameProperty = "2roomFlat", AdressProperty = "Lviv" });

                _webApiContext.SaveChanges();
            }


        }
        [HttpGet]
        public IEnumerable<Property> GetProperty()
        {

            return _webApiContext.Properties.ToList();

        }

        //[HttpGet]
        //public ActionResult<List<Client>> GetAll()
        //{
        //    return _webApiContext.Clients.ToList();
        //}

        //[HttpGet("{ClientId}")]
        //public ActionResult<Client> GetById(int ClientId)
        //{
        //    var item = _webApiContext.Clients.Find(ClientId);
        //    if (item == null)
        //    {
        //        return NotFound();
        //    }
        //    return item;
        //}



    



    }

}