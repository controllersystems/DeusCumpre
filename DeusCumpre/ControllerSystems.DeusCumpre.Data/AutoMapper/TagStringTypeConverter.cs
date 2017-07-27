
using AutoMapper;
using ControllerSystems.DeusCumpre.Data.Entities;
namespace ControllerSystems.DeusCumpre.Data.AutoMapper
{
    public class TagStringTypeConverter : ITypeConverter<Tag, string>
    {
        public string Convert(ResolutionContext context)
        {
            return ((Tag)context.SourceValue).Text;
        }
    }
}