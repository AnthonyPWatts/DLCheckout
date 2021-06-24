using DLCheckout.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DLCheckout.Application.Interfaces
{
    public interface IProductService
    {
        public Task<IEnumerable<Product>> GetAsync();
    }
}
