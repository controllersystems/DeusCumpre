
using ControllerSystems.DeusCumpre.Application.DataTransferObjects;
using System.Collections.Generic;

namespace ControllerSystems.DeusCumpre.Application.Interfaces.Repositories
{
    public interface ITagRepository : IRepositoryBase<TagDto>
    {
        List<TagDto> GetAllDistinct();
    }
}