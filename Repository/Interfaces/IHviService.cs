using IntegralTradingJS.Models;

namespace IntegralTradingJS.Repository.Interfaces
{
    public interface IHviService
    {
        Task<List<HVI>> GetHvi();
    }
}
