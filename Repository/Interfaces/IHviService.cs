using IntegralTradingJS.Models;

namespace IntegralTradingJS.Repository.Interfaces
{
    public interface IHviService
    {
        Task<IEnumerable<HVI>> GetHvi();
    }
}
