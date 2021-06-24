using DLCheckout.Application.Features.ShoppingCart;
using System;
using System.Collections.Generic;

namespace DLCheckout.ConsoleApp
{
    class Program
    {
       private static List<string> ExampleCartItems => new(){ "Apple", "Apple", "Orange", "Apple" };

        static void Main(string[] args)
        {
            var cart = new SimpleShoppingCart();

            try
            {
                cart.AddItems((ExampleCartItems));
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
