using DLCheckout.Application.Interfaces;
using DLCheckout.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DLCheckout.Persistence
{
    public class ProductService : IProductService
    {
        public async Task<IEnumerable<Product>> GetAsync()
        {
            var products = new List<Product>()
            {
                new Product() { Id = 1, Name = "Apple", UnitCost = 0.6M },
                new Product() { Id = 2, Name = "Orange", UnitCost = 0.25M }
            };

            return products;
        }
    }
}
