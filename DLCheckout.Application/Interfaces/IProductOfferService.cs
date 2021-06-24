using DLCheckout.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DLCheckout.Application.Interfaces
{
    public interface IProductOfferService
    {
        public Task<IEnumerable<BuyXPayForYProductOffer>> GetAsync();
    }
}
