using EM.EntityFramework;
using EntityFramework.DynamicFilters;

namespace EM.Migrations.SeedData
{
    public class InitialDataBuilder
    {
        private readonly EMDbContext _context;

        public InitialDataBuilder(EMDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            _context.DisableAllFilters();

            new DefaultEditionsBuilder(_context).Build();
            new DefaultTenantRoleAndUserBuilder(_context).Build();
            new DefaultLanguagesBuilder(_context).Build();
        }
    }
}
