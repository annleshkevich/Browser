using Microsoft.EntityFrameworkCore;
using SearchEngine.Model.DatabaseModels;

namespace SearchEngine.Model
{
    public class BrowserContext : DbContext
    {
        public BrowserContext(DbContextOptions<BrowserContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Browser> Browsers { get; set; } = null!;
    }
}
