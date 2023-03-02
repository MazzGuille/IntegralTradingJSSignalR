namespace IntegralTradingJS.Models
{
    public class Bids
    {
        public int IdOffer { get; set; }
        public int Id_company { get; set; }
        public int IdUsuario { get; set; }
        public string Price { get; set; }
        public int IdBidStatusFK { get; set; } = 2;
        public string Comments { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string UserSeller { get; set; }
        public string UserCompany { get; set; }
        public string PriceSeller { get; set; }
    }
}
