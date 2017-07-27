
using AutoMapper;
using ControllerSystems.DeusCumpre.Application.AutoMapper;
namespace ControllerSystems.DeusCumpre.Data.AutoMapper
{
    public class AutoMapperDataConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<ApplicationToDataMappingProfile>();
                x.AddProfile<DataToApplicationMappingProfile>();

                x.AddProfile<ApplicationToModelMappingProfile>();
                x.AddProfile<ModelToApplicationMappingProfile>();
            });
        }
    }
}
