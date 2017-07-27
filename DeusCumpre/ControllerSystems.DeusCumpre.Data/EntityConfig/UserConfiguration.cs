
using ControllerSystems.DeusCumpre.Data.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ControllerSystems.DeusCumpre.Data.EntityConfig
{
    public class UserConfiguration: EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            HasKey(e => e.Id);

            Property(e => e.Login)
                .IsRequired();

            Property(e => e.Password)
                .IsRequired();
        }
    }
}