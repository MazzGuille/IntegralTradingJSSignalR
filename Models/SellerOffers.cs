namespace IntegralTradingJS.Models
{
    public class SellerOffers
    {
        public int IdOffer { get; set; }
        public int IdBid { get; set; }
        public decimal Price { get; set; }
        public string Comments { get; set; }
        public int IdCompany { get; set; }
        public string CompanyName { get; set; }
        public string UserFullName { get; set; }
        public int IdStatus { get; set; }
        public string BidStatus { get; set; }
    }
}
