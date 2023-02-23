namespace IntegralTradingJS.Models
{
    public class Bids
    {
        public int IdBid { get; set; }
        public int IdOffer { get; set; }
        public int Id_company { get; set; }
        public int IdUsuario { get; set; }
        public float Price { get; set; }
        public int IdBidStatusFK { get; set; }
        public string Comments { get; set; }
        public DateTime Date { get; set; }
    }
}
