using DLCheckout.Application.Interfaces;
using DLCheckout.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DLCheckout.Persistence
{
    class ProductOfferService : IProductOfferService
    {
        public async Task<IEnumerable<BuyXPayForYProductOffer>> GetAsync()
        {
            var offers = new List<BuyXPayForYProductOffer>()
            {
                new BuyXPayForYProductOffer() { Id = 1, ProductId = 1, BuyXNumber = 2, PayForYNumber = 1 },
                new BuyXPayForYProductOffer() { Id = 2, ProductId = 2, BuyXNumber = 3, PayForYNumber = 2 }
            };

            return offers;
        }
    }
}
