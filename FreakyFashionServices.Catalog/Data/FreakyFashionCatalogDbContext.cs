using Microsoft.EntityFrameworkCore;

namespace FreakyFashionServices.Catalog.Data
{
    public class FreakyFashionCatalogDbContext : DbContext
    {
        public FreakyFashionCatalogDbContext(DbContextOptions<FreakyFashionCatalogDbContext> options)
            : base(options) 
        { }
    }
}
