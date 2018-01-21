namespace SmartAgent.Model.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SmartAgent.Model.SmartAgentDbEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SmartAgent.Model.SmartAgentDbEntities context)
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
            Agent[] agents = { new Model.Agent() { FirstName = "Francois", LastName = "Ali", BirthDate = DateTime.Now },
                            new Model.Agent() { FirstName = "Toto", LastName = "Titi", BirthDate = DateTime.Now },
                            new Model.Agent() { FirstName = "Tata", LastName = "tutu", BirthDate = DateTime.Now },
                            new Model.Agent() { FirstName = "Laurent", LastName = "Lolo", BirthDate = DateTime.Now },
                            new Model.Agent() { FirstName = "Amandine", LastName = "toto", BirthDate = DateTime.Now },
                            new Model.Agent() { FirstName = "Maceo", LastName = "Plex", BirthDate = DateTime.Now }
            };

            context.Agents.AddOrUpdate(
                a => a.LastName,
                            agents

                );
            Model.Task[] tasks = {
                new Model.Task{ Author = agents[4], Label = "Reseaux"},
                new Model.Task{ Author = agents[1], Label = "climatisation"},
                new Model.Task{ Author = agents[2], Label = "Plomberie"},
    
             };
          
            context.Tasks.AddOrUpdate(
                t=>t.Label,
                tasks
                );
            context.SaveChanges();
        }
    }
}
