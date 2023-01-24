using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using IntegralTradingJS.Models;
using IntegralTradingJS.Repository.Interfaces;
using Newtonsoft.Json.Serialization;
using System.Net.Http;
using System.Net;
using DevExtreme.AspNet.Data.ResponseModel;
using System.Net.Http.Formatting;

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
            var data = await _hviService.GetHvi();

            return DataSourceLoader.Load(data, loadOptions);
        }

    }
}
