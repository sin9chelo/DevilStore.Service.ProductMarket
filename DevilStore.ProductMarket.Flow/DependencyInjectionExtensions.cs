using DevilStore.ProductMarket.Flow.Helpers;
using DevilStore.ProductMarket.Flow.Managers;
using DevilStore.ProductMarket.Flow.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DevilStore.ProductMarket.Flow
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddMarketProductFlow(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddTransient<IMarketRepository, MarketRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();

            services.AddTransient<IMarketManager, MarketManager>();
            services.AddTransient<IProductManager, ProductManager>();

            services.AddAutoMapper(typeof(AutoMapperProfiles));

            return services;
        }
    }
}
