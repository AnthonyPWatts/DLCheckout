using DLCheckout.Application.Features.ShoppingCart;
using DLCheckout.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DLCheckout.ConsoleApp
{
    class CheckoutFrontend : ICheckoutFrontend
    {
        private readonly IShoppingCart _cart;
        private readonly IProductService _productService;

        public CheckoutFrontend(IShoppingCart cart, IProductService productService)
        {
            _cart = cart;
            _productService = productService;
        }

        public void Run()
        {
            DisplayPreamble();
            var cartItems = GetCartItemIdsFromUser();

            try
            {
                _cart.AddItemsById((cartItems));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unable to add items to cart: {ex.Message}");
                Console.WriteLine("Exiting application.");
                PressAnyKey();
                return;
            }

            var cartTotal = _cart.GetTotal();
            Console.WriteLine($"Cart total is: £{cartTotal}");

            PressAnyKey();
        }

        private void DisplayPreamble()
        {
            Console.WriteLine("DL Checkout");
            Console.WriteLine("===========");
            Console.WriteLine();
            var products = _productService.GetAsync().GetAwaiter().GetResult();
            foreach (var product in products)
            {
                Console.WriteLine($"Name: {product.Name}    ID: {product.Id}");
            }
            Console.WriteLine();
        }

        private int GetCartItemIdFromUser()
        {
            while(true)
            {
                Console.WriteLine("Enter a valid product ID to add to shopping cart or -1 to continue with current cart:");
                var inputString = Console.ReadLine();

                if (Int32.TryParse(inputString, out int inputInt))
                {
                    if (inputInt == -1 || _productService.GetAsync().GetAwaiter().GetResult().SingleOrDefault(x => x.Id == inputInt) != null)
                    return inputInt;
                }

                Console.WriteLine("Incorrect input.  Please try again.");
            };
        }

        private List<int> GetCartItemIdsFromUser()
        {
            List<int> cartItems = new();
            bool exitInput = false;
            while (!exitInput)
            {
                var input = GetCartItemIdFromUser();
                if (input == -1)
                {
                    exitInput = true;
                }
                else
                {
                    cartItems.Add(input);
                }
            }

            return cartItems;
        }

        private void PressAnyKey()
        {
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
