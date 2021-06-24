using Microsoft.Extensions.DependencyInjection;
using DLCheckout.Application.Interfaces;

namespace DLCheckout.Persistence
{
    public static class DependencyInjection
    {
        public static void AddPersistence(this IServiceCollection services)
        {

            services.AddSingleton<IProductService, ProductService>();
        }
    }
}