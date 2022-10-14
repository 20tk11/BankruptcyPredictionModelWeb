using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Users;
using AutoMapper;
using Domain;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        protected MappingProfiles()
        {
            CreateMap<User, User>();
            CreateMap<Company, Company>();
            CreateMap<User, UserDto>();
        }
    }
}