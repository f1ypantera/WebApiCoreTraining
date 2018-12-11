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

      
        [SetUp]
        public void Setup()
        {
           


        }

        [Test]
        //[TestSource]
        //[TestCaseSource]
        public async Task Can_Add_Client()
        {
            //arrange
            var mock = new Mock<IRepository<Client>>();
            var clientService = new ClientService(mock.Object);

            var client = new Client { Name = "Test" };
                      
            // act
            await clientService.AddClient(client);

            // assert
            // mock.Verify(c => c.AddAsync(It.IsAny<Client>()), Times.Once());
            mock.Verify(c => c.AddAsync(It.Is<Client>(s=>s.Name == "Test")),Times.Once());
           // Assert.AreEqual("Test", client.Name);
           // Assert.IsTrue(client.DateTimeRegister != default(DateTime));
        }

        [Test]
        public void Can_Get_AllClient()
        {
            //arrange
            var mock = new Mock<IRepository<Client>>();
            var client = new List<Client> {
                new Client { Name = "Test" },
                new Client { Name = "Test2" },
            };
            var clientService = new ClientService(mock.Object);

            

            //act
            clientService.GetAllClient();

            // assert
            mock.Verify(c => c.GetAll());
            Assert.IsNotEmpty(client);
          
        }
               
    }
}