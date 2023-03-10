using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using IntegralTradingJS.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace IntegralTradingJS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HVIController : ControllerBase
    {
        private readonly IHviService _hviService;

        public HVIController(IHviService hviService)
        {
            _hviService = hviService;
        }

        [HttpGet]
        public async Task<object> Get(DataSourceLoadOptions loadOptions)
        {
            var data = await _hviService.GetPromedios();

            return DataSourceLoader.Load(data, loadOptions);
        }    

    }
}
