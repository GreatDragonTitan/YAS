using Microsoft.EntityFrameworkCore;
using YAS.Models.Records;

namespace YAS.Models.Repositories
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<PostRecord> Posts { get; set; }
        public DbSet<AutoServiceRecord> AutoServices { get; set; }
    }
}