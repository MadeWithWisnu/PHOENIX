using Microsoft.AspNetCore.Authentication.Cookies;
using PhoenixDataAccess;
using PhoenixWeb.Configurations;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        IServiceCollection services = builder.Services;//1
        builder.Services.AddControllersWithViews(); //1
        services.AddBusinessService();
        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(option =>
            {
                option.Cookie.Name = "AuthCookie";
                option.LoginPath = "/login";
                option.ExpireTimeSpan = TimeSpan.FromMinutes(20);
                option.AccessDeniedPath = "/access-denied";
            });
        
        Dependencies.ConfigureService(builder.Configuration, builder.Services);
        var app = builder.Build();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Auth}/{action=Index}"
        );
        app.UseStaticFiles();

        app.Run();
    }
}

