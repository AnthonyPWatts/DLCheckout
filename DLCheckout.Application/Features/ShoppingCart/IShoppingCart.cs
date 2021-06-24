using System.Collections.Generic;

namespace DLCheckout.Application.Features.ShoppingCart
{
    public interface IShoppingCart
    {
        public decimal GetTotal();
        public IEnumerable<string> GetItems();
        public void AddItem(string item);
        public void AddItems(IEnumerable<string> items);
    }
}
