using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace WebApiCoreTraining.Models
{
    public class DomainProfile :Profile
    {
        public DomainProfile()
        {
            CreateMap<Client, ClientDTO>().ReverseMap();
            CreateMap<Property, PropertyDTO>()
                .ForMember(dest => dest.ClientName, opt => opt.MapFrom(x => x.Client.Name));
           //CreateMap<PropertyDTO, Property>()
           //    .ForAllMembers(opt => opt.Condition(src => src != null));
        }
    }
}
