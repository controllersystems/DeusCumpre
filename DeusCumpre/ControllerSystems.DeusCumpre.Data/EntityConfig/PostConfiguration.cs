
using ControllerSystems.DeusCumpre.Data.Entities;
using System.Data.Entity.ModelConfiguration;
namespace ControllerSystems.DeusCumpre.Data.EntityConfig
{
    public class PostConfiguration: EntityTypeConfiguration<Post>
    {
        public PostConfiguration()
        {
            HasKey(e => e.Id);

            Property(e => e.Title)
                .IsRequired();

            Property(e => e.Body)
                .IsRequired();

            Property(e => e.Body)
                .HasMaxLength(600);
        }
    }
}