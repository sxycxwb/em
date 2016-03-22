using System.Linq;
using Abp.Application.Editions;
using EM.Editions;
using EM.EntityFramework;

namespace EM.Migrations.SeedData
{
    public class DefaultEditionsBuilder
    {
        private readonly EMDbContext _context;

        public DefaultEditionsBuilder(EMDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            CreateEditions();
        }

        private void CreateEditions()
        {
            var defaultEdition = _context.Editions.FirstOrDefault(e => e.Name == EditionManager.DefaultEditionName);
            if (defaultEdition == null)
            {
                defaultEdition = new Edition { Name = EditionManager.DefaultEditionName, DisplayName = EditionManager.DefaultEditionName };
                _context.Editions.Add(defaultEdition);
                _context.SaveChanges();

                //TODO: Add desired features to the standard edition, if wanted!
            }   
        }
    }
}