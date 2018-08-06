using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.DTO;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerModel, CustomerDTO>();
            CreateMap<CustomerDTO, CustomerModel>();
            CreateMap<MovieModel, MovieDTO>();
            CreateMap<MovieDTO, MovieModel>();
            CreateMap<MembershipType, MembershipTypeDTO>();
            //CreateMap<Generes, GenreDTO>();

        }
    }
}