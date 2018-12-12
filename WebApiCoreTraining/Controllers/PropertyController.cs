using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiCoreTraining.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApiCoreTraining.Services;


namespace WebApiCoreTraining.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IRepository<Property> propertyRepository;
        private readonly IMapper mapper;
        private readonly PeopleContext peopleContext;

        public PropertyController(IRepository<Property> propertyRepository, IMapper mapper, PeopleContext peopleContext)
        {
            this.propertyRepository = propertyRepository;
            this.mapper = mapper;
            this.peopleContext = peopleContext;
        }

        [HttpPost]
        [Route("AddProperty")]
        public async Task<ActionResult> AddProperty([FromBody] PropertyAddDTO propertyAddDTO)
        {
            if (ModelState.IsValid)
            {
                var property = mapper.Map<Property>(propertyAddDTO);
                await propertyRepository.AddAsync(property);
            }

            return Ok("Has been added");
        }
        [HttpGet]
        [Route("GetProperty")]
        public async Task<ActionResult> GetProperty(int id)
        {
            var property = await peopleContext.Set<Property>().Include(x => x.Client).FirstAsync(x => x.Id == id);
            var result = mapper.Map<PropertyDetailedDTO>(property);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet]
        [Route("GetAllProperty")]
        public ActionResult GetAllProperty()
        {
            var clientName = peopleContext.Set<Property>().Include(x => x.Client).ToList();
            var result = mapper.Map<IList<PropertyDetailedDTO>>(clientName);
            return Ok(result);
        }
        [HttpGet]
        [Route("RemoveProperty")]
        public async Task<ActionResult> RemoveProperty(int id)
        {
            await propertyRepository.RemoveAsync(id);
            return Ok("Has been deleted");
        }
        [HttpGet]
        [Route("GetPropertyByClientId")]
        public ActionResult GetPropertyByClientId(int id)
        {

            var property = peopleContext.Set<Property>().Include(x => x.Client).Where(x => x.ClientId == id);
            var result = mapper.Map<IList<PropertyDetailedDTO>>(property);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

    }
}