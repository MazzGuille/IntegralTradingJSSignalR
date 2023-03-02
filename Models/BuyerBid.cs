namespace IntegralTradingJS.Models
{
    public class BuyerBid
    {
        public int IdBid { get; set; }
        public decimal Price { get; set; }
        public string Comments { get; set; }
        public string CompanyName { get; set; }
        public string UserName { get; set; }
        public string UserSeller { get; set; }
        public string UserCompany { get; set; }
        public decimal PriceSeller { get; set; }
    }
}
