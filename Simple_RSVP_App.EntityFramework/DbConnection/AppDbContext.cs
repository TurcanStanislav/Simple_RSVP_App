using Microsoft.EntityFrameworkCore;
using Simple_RSVP_App.Domain.Entities;

namespace Simple_RSVP_App.EntityFramework.DbConnection
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
