    using FrontToBacktask2.Models;
using Microsoft.EntityFrameworkCore;

namespace FrontToBacktask2.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options)
        {
            
        }

        public DbSet<AboutIntroComponent> AboutIntroComponents { get; set; }
        public DbSet<ContactCreating> ContactCreatings { get; set; }
        public DbSet<ContactTypes> ContactTypes { get; set; }
        public DbSet<WorkCategory> WorkCategories { get; set; }
        public DbSet<Work> Works { get; set; }
        public DbSet<ServiceComponent> ServiceComponents { get; set; }
        public DbSet<FeaturedWork> FeaturedWorks { get; set; }
    }
}
