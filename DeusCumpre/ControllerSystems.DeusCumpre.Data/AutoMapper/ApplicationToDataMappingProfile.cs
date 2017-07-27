using AutoMapper;
using ControllerSystems.DeusCumpre.Application.DataTransferObjects;
using ControllerSystems.DeusCumpre.Data.Entities;
using System.Collections.Generic;

namespace ControllerSystems.DeusCumpre.Data.AutoMapper
{
    public class ApplicationToDataMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ApplicationToDataMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<UserDto, User>();
            Mapper.CreateMap<string, Tag>().ConvertUsing<TagTypeConverter>();
            Mapper.CreateMap<PostDto, Post>();
        }
    }
}