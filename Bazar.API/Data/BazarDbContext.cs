using Microsoft.EntityFrameworkCore;
using Bazar.API.Models;


namespace Bazar.API.Data
{
    public class BazarDbContext : DbContext
    {
        public BazarDbContext(DbContextOptions<BazarDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
