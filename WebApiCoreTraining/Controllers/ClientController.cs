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
    [Route("api/Client")]
    
    public class ClientController : ControllerBase
    {
        private readonly WebApiContext _webApiContext;

        public ClientController (WebApiContext webApiContext)
        {
            _webApiContext = webApiContext;
            if (_webApiContext.Clients.Count() == 0)
            {
                _webApiContext.Clients.Add(new Client { Name = "Peter", DateTimeRegister = DateTime.Now });
                _webApiContext.Clients.Add(new Client { Name = "Mark", DateTimeRegister = DateTime.Now });
                _webApiContext.SaveChanges();
            }
        }

        public 
        {
            return _webApiContext.Clients.ToList();
        }
            
       
    }
}