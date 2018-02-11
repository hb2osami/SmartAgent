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
            Agent[] agents = { new Model.Agent() { FirstName = "Francois", LastName = "dumeige", Company ="ass" ,Job ="technicien",BirthDate = DateTime.Now },
                            new Model.Agent() { FirstName = "Eric", LastName = "dupont", Company ="a2II" ,Job ="technicien de surface", BirthDate = DateTime.Now },
                            new Model.Agent() { FirstName = "Nastia", LastName = "pellet", Company ="cst" ,Job ="ingénieur", BirthDate = DateTime.Now },
                            new Model.Agent() { FirstName = "Laurent", LastName = "Brod",  Company ="alp" ,Job ="plombier",BirthDate = DateTime.Now },
                            new Model.Agent() { FirstName = "Amandine", LastName = "Lee", Company ="cst" ,Job ="technicien reseau", BirthDate = DateTime.Now },
                            new Model.Agent() { FirstName = "Maceo", LastName = "Plex",  Company ="tpa" ,Job ="technicien cablage", BirthDate = DateTime.Now }
            };



            Model.Task[] tasks = {
                new Model.Task{ Author = agents[4], Label = "Reseaux", Location="rennes",Priority="high"},
                new Model.Task{ Author = agents[1], Label = "climatisation", Location="Caen",Priority="low"},
                new Model.Task{ Author = agents[2], Label = "Plomberie" ,Location="Paris",Priority="Medium"},

             };

            context.Agents.AddOrUpdate(
                a => a.LastName,
                            agents

                );          
            context.Tasks.AddOrUpdate(
                t=>t.Label,
                tasks
                );
            context.SaveChanges();
        }
    }
}
