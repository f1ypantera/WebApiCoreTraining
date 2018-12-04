using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApiCoreTraining.Models
{
    public class PeopleContext :DbContext
    {
        public DbSet<Client> clients { get; set; }
        public DbSet<Property> properties { get; set; }

        public PeopleContext(DbContextOptions<PeopleContext> options):base(options) { }
    }
}
