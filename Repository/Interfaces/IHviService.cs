using IntegralTradingJS.Models;

namespace IntegralTradingJS.Repository.Interfaces
{
    public interface IHviService
    {
        Task<IEnumerable<HVI>> GetHvi();
        Task UpdateStatus(int ob);
        void InsertData(Promedios promedio);
        Task<string> SelectUser();
    }
}
