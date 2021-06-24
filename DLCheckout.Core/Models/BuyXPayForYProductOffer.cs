using System;

namespace DLCheckout.Core.Models
{
    public class BuyXPayForYProductOffer
    {
        public int Id { get; set; }
        public int ProductId { get; set; }

        private int _buyXNumber;
        public int BuyXNumber
        {
            get { return _buyXNumber; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Value must be positive", nameof(BuyXNumber));
                }

                _buyXNumber = value;
            }
        }
        private int _payForYNumber;
        public int PayForYNumber 
        {
            get { return _payForYNumber; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Value must be positive", nameof(PayForYNumber));
                }

                _payForYNumber = value;
            }
        }
    }
}
