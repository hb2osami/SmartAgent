using SmartAgent.Model.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgent.Model.Partial
{
    internal class MyDatabaseInitializer : AutoMigrateDatabaseInitializer<SmartAgentDbEntities, Configuration>
    {
        public MyDatabaseInitializer() : base()
        {

        }
    }
    internal abstract class AutoMigrateDatabaseInitializer<TContext, TConfiguration> : IDatabaseInitializer<TContext>
        where TContext : DbContext
        where TConfiguration : DbMigrationsConfiguration<TContext>, new()
    {
        private readonly DbMigrationsConfiguration _configuration;
        public AutoMigrateDatabaseInitializer()
        {
            _configuration = new TConfiguration();
        }
        public AutoMigrateDatabaseInitializer(string connectionStringName)
        {
            System.Diagnostics.Contracts.Contract.Requires(!string.IsNullOrEmpty(connectionStringName), "connectionStringName");
            _configuration = new TConfiguration
            {
                TargetDatabase = new DbConnectionInfo(connectionStringName)
            };
        }
        void IDatabaseInitializer<TContext>.InitializeDatabase(TContext context)
        {
            System.Diagnostics.Contracts.Contract.Requires(context != null, "context");

            Console.WriteLine("Initializing Database");
            bool dbExists = context.Database.Exists();
            bool compatible;
            try
            {
                compatible = context.Database.CompatibleWithModel(throwIfNoMetadata: true);
            }
            catch (Exception e)
            {
                Console.WriteLine("The database is not not compatible : " + e.Message);
                compatible = false;
            }
            var migrator = new DbMigrator(_configuration);
            if (migrator.GetPendingMigrations().Any())
            {
                Console.WriteLine("There are some pending migrations : " + migrator.GetPendingMigrations().Count());
                var pendingMigrations = migrator.GetPendingMigrations();
                //run migrations
                foreach (string mig in pendingMigrations)
                {
                    Console.WriteLine("Updating Migration:" + mig);
                    //execute the migration
                    migrator.Update(mig);
                    Console.WriteLine("Updated Migration:" + mig);
                }
                Console.WriteLine("Migrations successfully performed");
            }
        }
    }
}
