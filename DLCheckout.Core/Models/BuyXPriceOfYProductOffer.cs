namespace DLCheckout.Core.Models
{
    public class BuyXPriceOfYProductOffer
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int BuyXNumber { get; set; }
        public int PayForYNumber { get; set; }
    }
}
