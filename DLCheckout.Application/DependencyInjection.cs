using DLCheckout.Application.Features.ShoppingCart;
using Microsoft.Extensions.DependencyInjection;

namespace DLCheckout.Application
{
    public static class DependencyInjection
    {
        public static void AddAppliation(this IServiceCollection services)
        {
            services.AddSingleton<IShoppingCart, SimpleShoppingCart>();
        }
    }
}
