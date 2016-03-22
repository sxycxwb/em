using System.Data.Entity.Migrations;
using EM.Migrations.SeedData;

namespace EM.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<EM.EntityFramework.EMDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "EMDB";
        }

        protected override void Seed(EM.EntityFramework.EMDbContext context)
        {
            new InitialDataBuilder(context).Build();
        }
    }
}
