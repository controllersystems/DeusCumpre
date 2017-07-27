using ControllerSystems.DeusCumpre.Data.Entities;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Collections.Generic;

namespace ControllerSystems.DeusCumpre.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ControllerSystems.DeusCumpre.Data.Context.DeusCumpreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ControllerSystems.DeusCumpre.Data.Context.DeusCumpreContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            User user = new User()
            {
                IsAdmin = true,
                Login = "admin",
                Password = "123"
            };

            //context.User.AddOrUpdate(u => u.Login,
            //    user);

            Post post = new Post()
            {
                Title = "Bem vindo!",
                User = user,
                Body = "Sejam bem vindos ao blog Deus Cumpre." + Environment.NewLine + "Este blog tem por objetivo apresentar o Deus que está descrito na bíblia sagrada, suas características e como se relacionar com ele.",
                CreationDate = DateTime.Now
            };

            context.Post.AddOrUpdate(p => p.Title,
                post);

            context.Tag.AddOrUpdate(p => new { p.Text, p.PostId },
                new Tag { Text = "Deus", Post = post },
                new Tag { Text = "Bíblia", Post = post },
                new Tag { Text = "Deus vivo", Post = post });
        }
    }
}