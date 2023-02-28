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

        public HomeController(IHviService hviService)
        {
            _hviService = hviService;
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

                return RedirectToAction("HviAPI", "Home", res);
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
        public async Task<IEnumerable<HVI>> GetOfferPrice()
        {
            var hviList = await _hviService.GetHvi();

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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
