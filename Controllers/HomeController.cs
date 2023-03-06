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

            string res = await _hviService.Login(user);

            if (res != "Error" )
            {

                //Response.Cookies.Append("jwt", res);
               
                _context.HttpContext.Session.SetInt32("userId", user.UserId);
                _context.HttpContext.Session.SetInt32("companyId", user.CompanyId);
                _context.HttpContext.Session.SetString("userEmail", user.Email);
                _context.HttpContext.Session.SetString("jwt", res);


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
            string res = _context.HttpContext.Session.GetString("jwt");
            if ( res != null)
            {
                return View();
            }
            else
            {
              return RedirectToAction("Index", "Unathorize");
            };
           
        }       

        [HttpGet]
        public async Task<IEnumerable<Offers>> GetOfferPrice()
        {
            var hviList = await _hviService.GetPromedios();

            return hviList;         
        }
      

        public IActionResult LogOut()
        {
            Response.Cookies.Delete("jwt");

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task UploadBid(List<string> values)
        {
            try
            {
                string valueTrimmed = values[3];
                valueTrimmed = valueTrimmed.TrimStart('$');
                Bids bid = new()
                {
                    IdOffer = Convert.ToInt32(values[0]),
                    Id_company = Convert.ToInt32(values[1]),
                    IdUsuario = Convert.ToInt32(values[2]),
                    Price = Convert.ToDecimal(valueTrimmed),
                    Comments = values[4].ToString(),
                    UserSeller = values[5].ToString(),
                    UserCompany = values[6].ToString(),
                    OfferPriceBuyer = Convert.ToDecimal(values[7])
                };

                var test = 1;

                await _hviService.UploadBid(bid);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
