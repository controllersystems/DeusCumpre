using AutoMapper;
using ControllerSystems.DeusCumpre.Application.DataTransferObjects;
using ControllerSystems.DeusCumpre.Domain.Entities;

namespace ControllerSystems.DeusCumpre.Application.AutoMapper
{
    public class ApplicationToModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ApplicationToModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<UserDto, User>();
            Mapper.CreateMap<PostDto, Post>();
        }
    }
}