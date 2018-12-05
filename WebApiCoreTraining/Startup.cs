using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WebApiCoreTraining.Models;




namespace WebApiCoreTraining
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string con = "Data Source=KBP1-LHP-F76802\\SQLEXPRESS;Initial Catalog=usersdbstore;Trusted_Connection=True;MultipleActiveResultSets=true";
            services.AddDbContext<PeopleContext>(options => options.UseSqlServer(con));

            services.AddScoped<IRepository<Client>,Repository<Client>>();
            services.AddScoped<IRepository<Property>, Repository<Property>>();



            services.AddRouting();
            services.AddMvc();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

          
        }
        private async Task Handle(HttpContext context)
        {
            await context.Response.WriteAsync("Hello ASP.NET Core!");
        }
    }
}
