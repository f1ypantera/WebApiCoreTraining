using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApiCoreTraining.Models
{
    public class WebApiContext :DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Property> Properties { get; set; }

        public WebApiContext(DbContextOptions<WebApiContext> options) : base(options) { }
    }
}
