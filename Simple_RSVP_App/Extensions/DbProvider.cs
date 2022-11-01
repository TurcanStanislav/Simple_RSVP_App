using Microsoft.EntityFrameworkCore;
using Simple_RSVP_App.DbConnection;

namespace Simple_RSVP_App.Extensions
{
    public static class DbProvider
    {
        public static IServiceCollection AddDbContextService(this IServiceCollection serviceCollection)
        {
            var provider = serviceCollection.BuildServiceProvider();
            var configuration = provider.GetRequiredService<IConfiguration>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            serviceCollection.AddDbContext<AppDbContext>(context => context.UseSqlServer(connectionString));

            return serviceCollection;
        }
    }
}
