using IntegralTradingJS.Models;
using IntegralTradingJS.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntegralTradingJS.Controllers
{
    public class BuyerController : Controller
    {
        private readonly IHviService _hviService;
        private readonly IHttpContextAccessor _context;


        public BuyerController(IHviService hviService, IHttpContextAccessor context)
        {
            _hviService = hviService;
            _context = context;
        }


        // GET: BuyerController
        public ActionResult Index()
        {
            string res = _context.HttpContext.Session.GetString("jwt");
            if (res != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Unathorize");
            };
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
