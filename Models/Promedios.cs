namespace IntegralTradingJS.Models
{
    public class Promedios
    {
        public decimal Price { get; set; }
        public decimal WhseCode { get; set; }
        public decimal WhseTag { get; set; }
        public decimal C1 { get; set; }
        public decimal C2 { get; set; }
        public decimal Leaf { get; set; }
        public decimal Stpl { get; set; }
        public decimal Mic { get; set; }
        public decimal Str { get; set; }
        public decimal LRR { get; set; }
        public decimal CropYear { get; set; }
        public decimal NetWeight { get; set; }
        public decimal Len { get; set; }
        public decimal Ext { get; set; }
        public decimal RD { get; set; }
        public decimal PlusB { get; set; }
        public decimal Uni { get; set; }
        public decimal Trash { get; set; }
        public DateTime StorageDate { get; set; } = DateTime.UtcNow;
    }
}
