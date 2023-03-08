using IntegralTradingJS.Models;
using IntegralTradingJS.Repository.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Crypto;
using System;
using System.Linq;
using System.Security.Claims;

namespace IntegralTradingJS.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHviService _hviService;
        private IHttpContextAccessor _context;

        public LoginController(IHviService hviService, IHttpContextAccessor context)
        {
            _hviService = hviService;
            _context = context;

        }

        public IActionResult Index()
        {
            ClaimsPrincipal c = HttpContext.User;
            if (c.Identity != null)
            {
                if (c.Identity.IsAuthenticated)
                {
                    return RedirectToAction("HviAPI", "Home");
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginUser user)
        {

            try
            {
                string res = await _hviService.Login(user);

                if (res != "Error")
                {

                    HttpContext.Session.SetInt32("userId", user.UserId);
                    _context.HttpContext.Session.SetInt32("companyId", user.CompanyId);
                    var urlId = _context.HttpContext.Session.GetInt32("userId");
                    _context.HttpContext.Session.SetString("userEmail", user.Email);
                    _context.HttpContext.Session.SetString("jwt", res);

                    List<Claim> claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Email)
                    };
                    ClaimsIdentity ci = new(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    //Esta es la parte opcional para usar el cuadra recordar
                    //AuthenticationProperties p = new();
                    //p.AllowRefresh = true;
                    //p.IsPersistent = user.Active;

                    //if (user.Active)                    
                    //    p.ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(1);
                    
                    //else                    
                    //    p.ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(ci)/*, p */);

                    return RedirectToAction("HviAPI", "Home");
                }
                else
                {
                    ViewData["Mensaje"] = "Credenciales invalidas";
                    return View();
                };
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }           

        }
    }
   
}
