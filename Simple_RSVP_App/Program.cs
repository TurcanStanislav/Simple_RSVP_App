using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Simple_RSVP_App.DbConnection;
using Simple_RSVP_App.Extensions;

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