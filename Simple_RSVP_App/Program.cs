using Mapster;
using MapsterMapper;
using Simple_RSVP_App.Extensions;
using Simple_RSVP_App.Repository.Interfaces;
using Simple_RSVP_App.Repository.Repositories.UserRepo;

namespace Simple_RSVP_App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContextService()
                            .AddControllersWithViews()
                            .AddRazorRuntimeCompilation();

            builder.Services.AddTransient<IMapper, Mapper>();
            builder.Services.AddTransient<IUserRepo, UserRepo>();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Users}/{action=Index}/{id?}"
            );

            app.Run();
        }
    }
}