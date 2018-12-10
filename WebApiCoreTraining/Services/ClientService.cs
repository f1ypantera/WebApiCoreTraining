using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCoreTraining.Controllers;
using WebApiCoreTraining.Models;


namespace WebApiCoreTraining.Services
{
    public class ClientService
    {
        private readonly IRepository<Client> repo;
        public ClientService(IRepository<Client> repo)
        {
            this.repo = repo;
        }

        public async Task AddClient(Client client)
        {
            client.DateTimeRegister = DateTime.Now;
            await repo.AddAsync(client);
        }
    }
}
