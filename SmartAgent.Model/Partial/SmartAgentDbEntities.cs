namespace SmartAgent.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public partial class SmartAgentDbEntities : DbContext
    {
       
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Agent>().ToTable("Personne");

            modelBuilder.Entity<Agent>().Property(a => a.LastName).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<Agent>().Property(a => a.FirstName).IsRequired();

        }


    }
}
