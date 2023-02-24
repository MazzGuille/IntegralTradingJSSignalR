using IntegralTradingJS.Models;

namespace IntegralTradingJS.Repository.Interfaces
{
    public interface IHviService
    {
        Task<IEnumerable<HVI>> GetHvi();
        Task UpdateStatus(int id);
        void InsertData(Promedios promedio);
        Task<string> SelectUser();
        Task<IEnumerable<Warehouse>> GetWhse();
        Task<IEnumerable<Bids>> GetUserBids();
        Task<bool> Login(Login user);

    }
}
