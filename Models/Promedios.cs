namespace IntegralTradingJS.Models
{
    public class Promedios
    {

        public string User { get; set; }
        public string Status { get; set; } = "En revision";
        public string Price { get; set; }
        public string PriceType { get; set; }
        public string Warehouse { get; set; }
        public DateTime ValidityDate { get; set; }
        public string ValidityType { get; set; }
        public DateTime OfferDate { get; set; } = DateTime.UtcNow;
        public int CropYear { get; set; }
        public string Maturity { get; set; }
        public string Comp { get; set; } //dato manual
        public string C1 { get; set; }
        public string C2 { get; set; }
        public string Leaf { get; set; }
        public string Stpl { get; set; }
        public string Mic { get; set; }
        public string Str { get; set; }
        public string LRR { get; set; }
        public string NetWeight { get; set; }
        public string Len { get; set; }
        public string Ext { get; set; }
        public string RD { get; set; }
        public string PlusB { get; set; }
        public string Uni { get; set; }
        public string Trash { get; set; }

    }
}
