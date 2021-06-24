using DLCheckout.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DLCheckout.Application.Features.ShoppingCart
{
    public class SimpleShoppingCart : IShoppingCart
    {
        private List<int> _itemIds = new List<int>();
        private readonly IProductService _productService;

        public SimpleShoppingCart(IProductService productService)
        {
            _productService = productService;
        }

        public decimal GetTotal()
        {
            var itemFrequency = _itemIds.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());

            var runningTotal = 0M;
            foreach (var itemIdFrequency in itemFrequency)
            {
                var product = _productService.GetAsync().GetAwaiter().GetResult().Single(x => x.Id == itemIdFrequency.Key);
                int buyN = 2;
                int payForN = 1;

                // nasty, breaks easily, but we can get away with it for now
                // since we only have the two products, it's either 3 for 2, or 2 for 1
                if (product.Name == "Orange")
                {
                    buyN = 3;
                    payForN = 2;
                }

                var itemTotal = GetCostWithOffer(buyN, payForN, product.UnitCost, itemIdFrequency.Value);
                runningTotal += itemTotal;
            }

            return runningTotal;
        }

        private decimal GetCostWithOffer(int getNumberOfItems, int forCostOfNumberOfItems, decimal unitCost, int numberOfItems)
        {
            if (getNumberOfItems == 0)
            {
                throw new ArgumentException("An offer cannot be to get zero items", nameof(getNumberOfItems));
            }

            int itemsToChargeFor = (numberOfItems / getNumberOfItems) * forCostOfNumberOfItems;
            itemsToChargeFor += numberOfItems % getNumberOfItems;

            return itemsToChargeFor * unitCost;
        }

        public IEnumerable<int> GetItemIds()
        {
            return _itemIds;
        }

        public void AddItemById(int itemId)
        {
            AddInternal(itemId);
        }

        public void AddItemsById(IEnumerable<int> itemIds)
        {
            foreach (var itemId in itemIds)
            {
                AddInternal(itemId);
            }
        }

        private void AddInternal(int itemId)
        {
            var products = _productService.GetAsync().GetAwaiter().GetResult();

            if (!products.Any(x => x.Id == itemId))
            {
                throw new ArgumentException($"{itemId} cannot be converted into a recognised product");
            }

            _itemIds.Add(itemId);
        }
    }
}
