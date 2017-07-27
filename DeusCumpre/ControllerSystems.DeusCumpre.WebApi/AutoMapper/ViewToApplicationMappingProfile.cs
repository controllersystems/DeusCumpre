
using AutoMapper;
using ControllerSystems.DeusCumpre.Application.DataTransferObjects;
using ControllerSystems.DeusCumpre.WebApi.ViewModels;

namespace ControllerSystems.DeusCumpre.WebApi.AutoMapper
{
    public class ViewToApplicationMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewToApplicationMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<UserViewModel, UserDto>();
            Mapper.CreateMap<PostViewModel, PostDto>();
        }
    }
}