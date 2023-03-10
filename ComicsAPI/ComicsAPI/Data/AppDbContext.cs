using ComicsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ComicsAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Comic> Comics { get; set; }
        public DbSet<ComicPhotos> ComicsPhotos { get; set; }
    }
}
