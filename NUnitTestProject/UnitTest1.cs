using System;
using WebApiCoreTraining.Models;
using WebApiCoreTraining.Controllers;
using WebApiCoreTraining.Services;
using System.Linq;
using NUnit.Framework;
using Moq;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tests
{
    public class Tests
    {
        [Test]
        public async Task Can_Add_Client()
        {
            // arrange
            var client = new Client { Name = "Test" };
            var mock = new Mock<IRepository<Client>>();
            
            var clientService = new ClientService(mock.Object);

            // act
            await clientService.AddClient(client);

            // assert
            mock.Verify(c => c.AddAsync(It.IsAny<Client>()), Times.Once());
            Assert.AreEqual("Test",client.Name);
            Assert.IsTrue(client.DateTimeRegister != default(DateTime));
        }
       
        [SetUp]
        public void Setup()
        {

           //var mock = new Mock<IRepository<Client>>();
           // var mock2 = new Mock<IRepository<Property>>();
           // var mock3 = new Mock<IMapper>();
           // var mock4 = new Mock<PeopleContext>();
           // var mock5 = new Mock<ClientService>();
           // mock.Setup(repo => repo.GetAll()).Returns(AddClientTest);
           

           // var controller = new ClientController(mock.Object, mock2.Object, mock3.Object, mock4.Object, mock5.Object);

            

        }

        [Test]
        public void Test()
        {

           


            Assert.Pass();
          
        }
    }
}