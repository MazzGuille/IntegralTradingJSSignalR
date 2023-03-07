using IntegralTradingJS.Models;

namespace IntegralTradingJS.Repository.Interfaces
{
    public interface IHviService
    {
        Task<IEnumerable<HVI>> GetHvi();
        Task<IEnumerable<Offers>> GetOffersById();
        Task<IEnumerable<Offers>> GetPromedios();
        //Task UpdateStatus(int id);
        void InsertData(Promedios promedio);
        Task<string> SelectUser();
        Task<IEnumerable<Warehouse>> GetWhse();
        Task<IEnumerable<Bids>> GetUserBids();
        Task<string> Login(LoginUser user);
        Task<IEnumerable<BuyerBid>> GetBuyerBid();
        Task<IEnumerable<SellerOffers>> GetSellerOffers();
        Task EliminateBid(int id);
        Task UploadBid(Bids bid);
        Task ChangeStatusBid(int BidId, int Id_Status);



    }
}
