using AutoMapper;
using Models.DtoModels;
using Models.Entities;
using Models.ServiceModels.Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            CreateMap<Newsletter, SubscribeNewsletterModel>();
            CreateMap<SubscribeNewsletterModel, Newsletter>();
        }
    }
}
