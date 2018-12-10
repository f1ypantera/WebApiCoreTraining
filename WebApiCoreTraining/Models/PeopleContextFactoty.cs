using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebApiCoreTraining.Models
{
    public class BloggingContextFactory : IDesignTimeDbContextFactory<PeopleContext>
    {
        public PeopleContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PeopleContext>();
            optionsBuilder.UseSqlServer("Data Source=KBP1-LHP-F76802\\SQLEXPRESS;Initial Catalog=usersdbstore;Trusted_Connection=True;MultipleActiveResultSets=true");
            return new PeopleContext(optionsBuilder.Options);
        }
    }
}
