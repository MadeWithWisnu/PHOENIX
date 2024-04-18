using PhoenixBussiness;
using PhoenixBussiness.Interfaces;
using PhoenixBussiness.Repositories;
using PhoenixWeb.Services;

namespace PhoenixWeb.Configurations;

public static class ConfigureBusinessService
{
     public static IServiceCollection AddBusinessService(this IServiceCollection services)
    {
        services.AddScoped<IAdministratorRepository, AdministratorRepostirory>();
        // services.AddScoped<IHistoryRepository, HistoryRepository>();
        // services.AddScoped<IProductRepository, ProductRepository>();
        // services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IGuestRepository, GuestRepository>();
        // services.AddScoped<ISellerRepository, SellerRepository>();
        // services.AddScoped<IProfileRepository, ProfileRepository>();
        services.AddScoped<AuthService>();
        // services.AddScoped<ProfileService>();
        // services.AddScoped<ShopService>();
        // services.AddScoped<MerchandiseService>();
        // services.AddScoped<HistoryService>();
        return services;
    }
}
