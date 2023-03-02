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

        [HttpDelete]
        public async Task EliminateBid(int id)
        {
            await _hviService.EliminateBid(id);
        }

        [HttpGet]
        public async Task <IEnumerable<SellerOffers>> GetSellerOffers()
        {
            var data = await _hviService.GetSellerOffers();

            return data;
        }

        [HttpGet]
        public async Task<IEnumerable<BuyerBid>> GetBuyerBid()
        {
            var data = await _hviService.GetBuyerBid();

            return data;
        }

        [HttpGet]
        public async Task<IEnumerable<Bids>> GetUserBids()
        {
            var data = await _hviService.GetUserBids();

            return data;
        }

    }
}
