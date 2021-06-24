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
        private readonly IProductOfferService _productOfferService;

        public SimpleShoppingCart(IProductService productService, IProductOfferService productOfferService)
        {
            _productService = productService;
            _productOfferService = productOfferService;
        }

        public decimal GetTotal()
        {
            var itemFrequency = _itemIds.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());

            var runningTotal = 0M;
            foreach (var itemIdFrequency in itemFrequency)
            {
                var itemTotal = GetCostWithOffer(itemIdFrequency.Key, itemIdFrequency.Value);
                runningTotal += itemTotal;
            }

            return runningTotal;
        }

        private decimal GetCostWithOffer(int itemId, int numberOfItems)
        {
            var product = _productService.GetAsync().GetAwaiter().GetResult().Single(x => x.Id == itemId);
            var offer = _productOfferService.GetAsync().GetAwaiter().GetResult().SingleOrDefault(o => o.ProductId == itemId);

            if (offer == null)
            {
                return product.UnitCost * numberOfItems;
            }

            int itemsToChargeFor = (numberOfItems / offer.BuyXNumber) * offer.PayForYNumber;
            itemsToChargeFor += numberOfItems % offer.BuyXNumber;

            return itemsToChargeFor * product.UnitCost;
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
