using AutoMapper;
using ControllerSystems.DeusCumpre.Application.DataTransferObjects;
using ControllerSystems.DeusCumpre.Domain.Entities;

namespace ControllerSystems.DeusCumpre.Application.AutoMapper
{
    public class ModelToApplicationMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ModelToApplicationMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<User, UserDto>();
            Mapper.CreateMap<Post, PostDto>();
        }
    }
}