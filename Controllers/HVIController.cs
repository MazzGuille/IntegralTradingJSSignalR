using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using IntegralTradingJS.Models;
using IntegralTradingJS.Repository;
using IntegralTradingJS.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace IntegralTradingJS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HVIController : ControllerBase
    {
        private readonly IHviService _hviService;
        private readonly DataSourceLoader _loader;

        //public HVIController(IHviService hviService, IHttpContextAccessor contextAccessor)
        //{
        //    _hviService = hviService;
        //    _loader = new DataSourceLoader(contextAccessor.HttpContext.Request);
        //}



        //[HttpGet]
        //public async Task<IActionResult> Get()
        //{
        //    //var data = await  DataSourceLoader.LoadAsync<HVI>(_hviService.LoadToTable(), loadOptions);

        //    var result = await _loader.LoadAsync(_hviService.LoadToTable(), new DataSourceLoadOptionsBase());


        //    return Ok(result);
        //}
    }
}
