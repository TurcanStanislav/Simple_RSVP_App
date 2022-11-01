using Microsoft.EntityFrameworkCore;
using Simple_RSVP_App.Entities;

namespace Simple_RSVP_App.DbConnection
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
