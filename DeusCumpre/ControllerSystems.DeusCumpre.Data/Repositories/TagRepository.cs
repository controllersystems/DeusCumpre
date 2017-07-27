
using ControllerSystems.DeusCumpre.Application.DataTransferObjects;
using ControllerSystems.DeusCumpre.Application.Interfaces.Repositories;
using ControllerSystems.DeusCumpre.Data.Context;
using ControllerSystems.DeusCumpre.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ControllerSystems.DeusCumpre.Data.Repositories
{
    public class TagRepository : RepositoryBase<TagDto, Tag>, ITagRepository
    {
        public List<TagDto> GetAllDistinct()
        {
            using (DeusCumpreContext db = new DeusCumpreContext())
            {
                return Convert(db.Tag.Distinct().ToList());
            }
        }
    }
}
