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
using WebApiCoreTraining.Services;
using AutoMapper;

namespace WebApiCoreTraining
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            string con = "Data Source=KBP1-LHP-F76802\\SQLEXPRESS;Initial Catalog=usersdbstore;Trusted_Connection=True;MultipleActiveResultSets=true";
            services.AddDbContext<PeopleContext>(options => options.UseSqlServer(con));
            services.AddScoped<IRepository<Client>,Repository<Client>>();
            services.AddScoped<IRepository<Property>, Repository<Property>>();
            services.AddScoped<ClientService>();
            services.AddAutoMapper();
            services.AddRouting();
            services.AddMvc();

        }       
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var routeBuilder = new RouteBuilder(app);
            routeBuilder.MapRoute("{api}/{controller}/{action}", async context =>
            {
                context.Response.ContentType = "text/html; charset=utf-8";
                await context.Response.WriteAsync("двухсегментный запрос");
            });
            routeBuilder.MapRoute("{api}/{controller}/{action}/{id}",
                async context => {
                    context.Response.ContentType = "text/html; charset=utf-8";
                    await context.Response.WriteAsync("трехсегментный запрос");
                });
            app.UseMvc();           
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
