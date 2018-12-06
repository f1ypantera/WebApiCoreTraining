using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApiCoreTraining.Models
{
    public class PeopleContext :DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Property> Properties { get; set; }
        public PeopleContext(DbContextOptions<PeopleContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Property>()
                .HasOne(p => p.Client)
                .WithMany(b => b.Properties)
                .HasForeignKey(p => p.ClientId)
                .HasConstraintName("ForeignKey_Properties_Client");
        }
    }
}
