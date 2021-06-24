using System.Collections.Generic;

namespace DLCheckout.Application.Features.ShoppingCart
{
    public interface IShoppingCart
    {
        public decimal GetTotal();
        public IEnumerable<int> GetItemIds();
        public void AddItemById(int itemId);
        public void AddItemsById(IEnumerable<int> itemIds);
    }
}
