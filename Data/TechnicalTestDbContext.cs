using Microsoft.EntityFrameworkCore;
using TechnicalTest.Models;

namespace TechnicalTest.Data
{
    public class TechnicalTestDbContext : DbContext
    {
        public TechnicalTestDbContext(DbContextOptions<TechnicalTestDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}
