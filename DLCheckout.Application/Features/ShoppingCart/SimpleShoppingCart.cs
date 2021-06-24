using System;
using System.Collections.Generic;
using System.Linq;

namespace DLCheckout.Application.Features.ShoppingCart
{
    public class SimpleShoppingCart : IShoppingCart
    {
        private List<string> _items = new List<string>();

        public decimal GetTotal()
        {
            var applesCount = _items.Count((x => x == "Apple"));
            var orangesCount = _items.Count(x => x == "Orange");

            var applesCostWithOffersApplied = GetCostWithOffer(2, 1, 0.6M, applesCount);
            var orangesTotalCostWithOffersApplied = GetCostWithOffer(3, 2, 0.25M, orangesCount);

            return applesCostWithOffersApplied + orangesTotalCostWithOffersApplied;
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

        public IEnumerable<string> GetItems()
        {
            return _items;
        }

        public void AddItem(string item)
        {
            AddInternal(item);
        }

        public void AddItems(IEnumerable<string> items)
        {
            foreach (var item in items)
            {
                AddInternal(item);
            }
        }

        private void AddInternal(string item)
        {
            item = item.ToUpper();
            switch (item)
            {
                case "APPLE":
                    {
                        _items.Add("Apple");
                        return;
                    }
                case "ORANGE":
                    {
                        _items.Add("Orange");
                        return;
                    }
                default:
                    {
                        throw new ArgumentException($"{item} cannot be converted into a recognised product");
                    }
            }
        }
    }
}
