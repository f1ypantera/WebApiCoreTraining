using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApiCoreTraining.Models;


namespace WebApiCoreTraining.Models
{
    public class Client
    {   
        
        public int ClientId { get; set; }
        public string Name { get; set; }
        public DateTime DateTimeRegister { get; set; }
        public List<Property> Properties { get; set; }

       
    }
}
