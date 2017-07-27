
using AutoMapper;
using ControllerSystems.DeusCumpre.Data.Entities;
using System.Collections.Generic;
namespace ControllerSystems.DeusCumpre.Data.AutoMapper
{
    public class TagTypeConverter : ITypeConverter<string, Tag>
    {
        public Tag Convert(ResolutionContext context)
        {
            return new Tag()
            {
                Text = System.Convert.ToString(context.SourceValue)
            };
        }
    }
}