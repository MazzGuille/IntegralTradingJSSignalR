using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntegralTradingJS.Hubs;
using IntegralTradingJS.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IntegralTradingJS.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHviService _hviService;


        public HomeController(IHviService hviService)
        {
            _hviService = hviService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetHvi()
        {
            var list = await _hviService.GetHvi();
            return View(list);
        }

        public IActionResult HviAPI()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
