using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApiCoreTraining.Models
{
    public class Property
    {
        
        public int PropertyID { get; set; }
       
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public string NameProperty { get; set; }
        public string AdressProperty { get; set; }

    }
}
