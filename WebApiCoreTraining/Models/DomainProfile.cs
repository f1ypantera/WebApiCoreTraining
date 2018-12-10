using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApiCoreTraining.Services;

namespace WebApiCoreTraining.Models
{
    public class DomainProfile :Profile
    {
        public DomainProfile()
        {
            CreateMap<Client, ClientDTO>().ReverseMap();
            CreateMap<Property, PropertyDetailedDTO>()
                .ForMember(dest => dest.ClientName, opt => opt.MapFrom(x => x.Client.Name));


            CreateMap<Property, PropertyAddDTO>().ReverseMap();


            CreateMap<PropertyDetailedDTO, Property>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
