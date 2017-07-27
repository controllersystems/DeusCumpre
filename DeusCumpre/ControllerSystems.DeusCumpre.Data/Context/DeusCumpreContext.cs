using ControllerSystems.DeusCumpre.Data.Entities;
using ControllerSystems.DeusCumpre.Data.EntityConfig;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ControllerSystems.DeusCumpre.Data.Context
{
    public class DeusCumpreContext: DbContext
    {
        public DeusCumpreContext()
            : base("DeusCumpreContext")
        {
            Database.SetInitializer<DeusCumpreContext>(new CreateDatabaseIfNotExists<DeusCumpreContext>());
        }

        public DbSet<User> User { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<Tag> Tag { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<DateTime>()
                .Configure(c => c.HasColumnType("datetime2"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new PostConfiguration());
            modelBuilder.Configurations.Add(new TagConfiguration());
        }
    }
}