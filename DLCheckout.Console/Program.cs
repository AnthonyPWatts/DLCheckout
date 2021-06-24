using DLCheckout.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DLCheckout.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => 
                {
                    services.AddPersistence();
                })
                .Build();

            var svc = ActivatorUtilities.CreateInstance<CheckoutService>(host.Services);
            svc.Run();
        }
    }
}
