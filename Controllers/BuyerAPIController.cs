using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using IntegralTradingJS.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntegralTradingJS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyerAPIController : ControllerBase
    {
        private readonly IHviService _hviService;

        public BuyerAPIController(IHviService hviService)
        {
            _hviService = hviService;
        }

        [HttpGet]
        public async Task<object> GetBids(DataSourceLoadOptions loadOptions)
        {
            var data = await _hviService.GetUserBids();

            return DataSourceLoader.Load(data, loadOptions);
        }
    }
}
