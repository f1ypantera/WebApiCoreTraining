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
        [Key]
        public int Id { get; set; }      
        public int ClientId { get; set; }
        public Client Client { get; set; }      
        public string Name { get; set; }
        public string Adress { get; set; }

    }
}
