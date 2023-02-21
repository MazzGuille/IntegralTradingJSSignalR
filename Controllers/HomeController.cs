using IntegralTradingJS.Models;
using IntegralTradingJS.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace IntegralTradingJS.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHviService _hviService;
        int num;


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

        [HttpGet]
        public async Task<IEnumerable<HVI>> GetOfferPrice()
        {
            var hviList = await _hviService.GetHvi();

            return hviList;         
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
