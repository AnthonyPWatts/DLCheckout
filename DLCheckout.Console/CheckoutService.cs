using DLCheckout.Application.Features.ShoppingCart;
using DLCheckout.Application.Interfaces;
using System;
using System.Collections.Generic;

namespace DLCheckout.ConsoleApp
{
    class CheckoutService : ICheckoutService
    {
        private static List<int> _exampleCartItems => new() { 1, 1, 2, 1 };
        private readonly IProductService _productService;
        public CheckoutService(IProductService productService)
        {
            _productService = productService;
        }
        public void Run()
        {
            var cart = new SimpleShoppingCart(_productService);

            try
            {
                cart.AddItemsById((_exampleCartItems));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unable to add items to cart: {ex.Message}");
                Console.WriteLine("Exiting application.");
                PressAnyKey();
                return;
            }

            var cartTotal = cart.GetTotal();
            Console.WriteLine($"Cart total is: £{cartTotal}");

            PressAnyKey();
        }

        private static void PressAnyKey()
        {
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
