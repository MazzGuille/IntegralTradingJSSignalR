namespace IntegralTradingJS.Models
{
    public class BuyerBid
    {
        public int IdOffer { get; set; }
        public int IdBid { get; set; }
        public decimal BidFromBuyer { get; set; }
        public string Comments { get; set; }
        public string CompanyName { get; set; }
        public string UserFullName { get; set; }
        public string SellerFullName { get; set; }
        public string SellerCompany { get; set; }
        public decimal SellerOfferPrice { get; set; }
        public int IdStatus { get; set; }
        public string BidStatus { get; set; }
    }
}
