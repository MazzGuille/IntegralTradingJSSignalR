using IntegralTradingJS.Models;
using IntegralTradingJS.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace IntegralTradingJS.Controllers
{    
    public class HomeController : Controller
    {
        private readonly IHviService _hviService;
        private readonly IHttpContextAccessor _context;

        public HomeController(IHviService hviService, IHttpContextAccessor context)
        {
            _hviService = hviService;
            _context = context;
        }

        public IActionResult Index()
        {            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Login user)
        {          

            var res = await _hviService.Login(user);

            if (res != "Error")
            {

                Response.Cookies.Append("jwt", res);
               
                _context.HttpContext.Session.SetInt32("userId", user.UserId);
                _context.HttpContext.Session.SetInt32("companyId", user.CompanyId);
                _context.HttpContext.Session.SetString("userEmail", user.Email);


                return RedirectToAction("HviAPI", "Home");
            }
            else
            {
                ViewData["Mensaje"] = "Credenciales invalidas";
                return View();
            };
            
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
        public async Task<IEnumerable<Offers>> GetOfferPrice()
        {
            var hviList = await _hviService.GetPromedios();

            return hviList;         
        }

        [HttpPut]
        public async Task UpdateStatus(int id)
        {
            await _hviService.UpdateStatus(id);
        }

        public IActionResult LogOut()
        {
            Response.Cookies.Delete("jwt");

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task UploadBid(List<string> values)
        {
            Bids bid = new()
            {
               IdOffer = Convert.ToInt32(values[0]),
               Id_company = Convert.ToInt32(values[1]),
               IdUsuario = Convert.ToInt32(values[2]),
               Price = (values[3]).ToString(),
               Comments = values[4].ToString(),
               UserSeller = values[5].ToString(),
               UserCompany = values[6].ToString(),
               PriceSeller = (values[7]).ToString()
            };

            await _hviService.UploadBid(bid);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
