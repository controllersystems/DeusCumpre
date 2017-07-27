using AutoMapper;
using ControllerSystems.DeusCumpre.Application.DataTransferObjects;
using ControllerSystems.DeusCumpre.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControllerSystems.DeusCumpre.Data.AutoMapper
{
    public class DataToApplicationMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DataToApplicationMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<User, UserDto>();
            Mapper.CreateMap<Post, PostDto>();
            Mapper.CreateMap<Tag, TagDto>();
            Mapper.CreateMap<Tag, string>().ConvertUsing<TagStringTypeConverter>();
        }
    }
}