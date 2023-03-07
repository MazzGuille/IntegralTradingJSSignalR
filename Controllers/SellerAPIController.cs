using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using IntegralTradingJS.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntegralTradingJS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerAPIController : ControllerBase
    {
        private readonly IHviService _hviService;

        public SellerAPIController(IHviService hviService)
        {
            _hviService = hviService;
        }


        [HttpGet]
        [Route("Bids")]
        public async Task<object> GetSellerOffers(DataSourceLoadOptions loadOptions)
        {
            var data = await _hviService.GetSellerOffers();

            return DataSourceLoader.Load(data, loadOptions);
        }

        [HttpGet]
        [Route("OffersById")]
        public async Task<object> GetSellerOffersById(DataSourceLoadOptions loadOptions)
        {
            var data = await _hviService.GetOffersById();

            return DataSourceLoader.Load(data, loadOptions);
        }
    }
}
