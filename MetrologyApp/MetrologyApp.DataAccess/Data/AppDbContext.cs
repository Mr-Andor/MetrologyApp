using MetrologyApp.Models;
using Microsoft.EntityFrameworkCore;

namespace MetrologyApp.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<NominalPoint> NominalPoints { get; set; }
        public DbSet<ActualPoint> ActualPoints { get; set; }
        public DbSet<Result> Results { get; set; }
    }
}
