using DLCheckout.Application;
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
                    services.AddAppliation();
                    services.AddPersistence();
                })
                .Build();

            var svc = ActivatorUtilities.CreateInstance<CheckoutFrontend>(host.Services);
            svc.Run();
        }
    }
}
