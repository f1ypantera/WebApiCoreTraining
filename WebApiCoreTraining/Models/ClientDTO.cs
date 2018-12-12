using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCoreTraining.Models
{
    public class ClientDTO
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
        public DateTime DateTimeRegister { get; set; }      
    }
}
