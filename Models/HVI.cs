namespace IntegralTradingJS.Models
{
    public class HVI
    {
        public int ID { get; set; }
        public string User { get; set; }
        public string Status { get; set; } = "En revision";
        public decimal Price { get; set; }
        public string PriceType { get; set; }
        public string Warehouse { get; set; }
        public DateTime ValidityDate { get; set; }
        public string ValidityType { get; set; }
        public DateTime OfferDate { get; set; } = DateTime.UtcNow;
        public int CropYear { get; set; }
        public string Maturity { get; set; }
        public string Comp { get; set; } //dato manual        
        public decimal C1 { get; set; }
        public decimal C2 { get; set; }
        public decimal Leaf { get; set; }
        public decimal Stpl { get; set; }
        public decimal Mic { get; set; }
        public float Str { get; set; }
        public float LRR { get; set; }        
        public decimal NetWeight { get; set; }
        public decimal Len { get; set; }
        public decimal Ext { get; set; }
        public float RD { get; set; }
        public decimal PlusB { get; set; }
        public float Uni { get; set; }
        public decimal Trash { get; set; }  

    }
}
