
using ControllerSystems.DeusCumpre.Data.Entities;
using System.Data.Entity.ModelConfiguration;
namespace ControllerSystems.DeusCumpre.Data.EntityConfig
{
    public class TagConfiguration : EntityTypeConfiguration<Tag>
    {
        public TagConfiguration()
        {
            HasKey(e => new { e.PostId, e.Text });
        }
    }
}