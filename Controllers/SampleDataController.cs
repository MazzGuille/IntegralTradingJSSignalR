using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using IntegralTradingJS.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace IntegralTradingJS.Controllers
{

    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {

        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(SampleData.Orders, loadOptions);
        }

    }
}