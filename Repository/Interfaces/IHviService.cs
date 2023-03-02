using IntegralTradingJS.Models;

namespace IntegralTradingJS.Repository.Interfaces
{
    public interface IHviService
    {
        Task<IEnumerable<HVI>> GetHvi();
        Task<IEnumerable<Offers>> GetPromedios();
        Task UpdateStatus(int id);
        void InsertData(Promedios promedio);
        Task<string> SelectUser();
        Task<IEnumerable<Warehouse>> GetWhse();
        Task<IEnumerable<Bids>> GetUserBids();
        Task<string> Login(Login user);
        Task<IEnumerable<BuyerBid>> GetBuyerBid();
        Task<IEnumerable<SellerOffers>> GetSellerOffers();
        Task EliminateBid(int id);
        Task UploadBid(Bids bid);

    }
}
