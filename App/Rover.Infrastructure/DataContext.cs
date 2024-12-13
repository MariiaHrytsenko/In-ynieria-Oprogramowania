using Rover.Domain;
using Microsoft.EntityFrameworkCore;

namespace Rover.Infrastructure
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
