using IntegralTradingJS.Models;
using IntegralTradingJS.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntegralTradingJS.Controllers
{
    public class BuyerController : Controller
    {
        private readonly IHviService _hviService;
        

        public BuyerController(IHviService hviService)
        {
            _hviService = hviService;
        }


        // GET: BuyerController
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IEnumerable<Bids>> GetUserBids()
        {
            var data = await _hviService.GetUserBids();

            return data;
        }

    }
}
