namespace IntegralTradingJS.Models
{
    public class Warehouse
    {
        public int Id_whse { get; set; }
        public int Id_company { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
        public string Town { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int id_creadorAlmacen { get; set; }
    }
}
