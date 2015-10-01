
using AutoMapper;
using ControllerSystems.DeusCumpre.Application.DataTransferObjects;
using ControllerSystems.DeusCumpre.WebApi.ViewModels;

namespace ControllerSystems.DeusCumpre.WebApi.AutoMapper
{
    public class ApplicationToViewMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ApplicationToViewMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<UserDto, UserViewModel>();
            Mapper.CreateMap<PostDto, PostViewModel>();
        }
    }
}