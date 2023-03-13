using IntegralTradingJS.Models;
using IntegralTradingJS.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NPOI.HSSF.UserModel;
using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Org.BouncyCastle.Crypto;
using System.Collections.Generic;
using System.Globalization;

namespace IntegralTradingJS.Controllers
{
    public class SellerController : Controller
    {
        private readonly IHviService _hviService;
        private readonly IHttpContextAccessor _context;
        public List<HviRed> HviData = new();
        HVI hvi = new();
        

        public SellerController(IHviService hviService, IHttpContextAccessor context)
        {
            _hviService = hviService;
            _context = context;
        }

        public IActionResult SellerOffers()
        {
            string res = _context.HttpContext.Session.GetString("jwt");
            var idUsu = _context.HttpContext.Session.GetInt32("userId");
            if (res != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Unathorize");
            }; ;
        }
       
        public ActionResult OfferUpload()
        {
            string res = _context.HttpContext.Session.GetString("jwt");
            var idUsu = _context.HttpContext.Session.GetInt32("userId");
            if (res != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Unathorize");
            };
        }
       
        [HttpPost]
        public IActionResult MostrarDatos([FromForm] IFormFile ArchivoExcel)
        {

            Stream stream = ArchivoExcel.OpenReadStream();

            IWorkbook MiExcel = null;

            if (Path.GetExtension(ArchivoExcel.FileName) == ".xlsx")
            {
                MiExcel = new XSSFWorkbook(stream);
            }
            else
            {
                MiExcel = new HSSFWorkbook(stream);
            }

            ISheet HojaExcel = MiExcel.GetSheetAt(0);

            int cantidadFila = HojaExcel.LastRowNum;
            for (int i = 1; i < cantidadFila; i++)
            {
                IRow fila = HojaExcel.GetRow(i);
                HviData.Add(new HviRed
                {
                    C1 = fila.GetCell(0).ToString(),
                    C2 = fila.GetCell(1).ToString(),
                    Leaf = fila.GetCell(2).ToString(),
                    Stpl = fila.GetCell(3).ToString(),
                    Mic = fila.GetCell(4).ToString(),
                    Str = fila.GetCell(5).ToString(),
                    LRR = fila.GetCell(6).ToString(),
                    NetWeight = fila.GetCell(7).ToString(),
                    Len = fila.GetCell(8).ToString(),
                    Ext = fila.GetCell(9).ToString(),
                    RD = fila.GetCell(10).ToString(),
                    PlusB = fila.GetCell(11).ToString(),
                    Uni = fila.GetCell(12).ToString(),
                    Trash = fila.GetCell(13).ToString()
                });
            }
            return StatusCode(StatusCodes.Status200OK, HviData);
        }
        
        public ActionResult InsertData()
        {           
            return View();
        }       

        [HttpPost]
        public void InsertData(List<string> values)
        {
            CultureInfo culture = CultureInfo.InvariantCulture;
            Promedios promedio = new()
            {
                C1 = decimal.Parse(values[0], culture),
                C2 = decimal.Parse(values[1], culture),
                Leaf = decimal.Parse(values[2], culture),
                Stpl = decimal.Parse(values[3], culture),
                Mic = decimal.Parse(values[4], culture),
                Str = decimal.Parse(values[5], culture),
                LRR = decimal.Parse(values[6], culture),
                NetWeight = decimal.Parse(values[7], culture),
                Len = decimal.Parse(values[8], culture),
                Ext = decimal.Parse(values[9], culture),
                RD = decimal.Parse(values[10], culture),
                PlusB = decimal.Parse(values[11], culture),
                Uni = decimal.Parse(values[12], culture),
                Trash = decimal.Parse(values[13], culture),
                Price = decimal.Parse(values[14], culture),
                PriceType = values[15].ToString(),
                IdWarehouse = Convert.ToInt32(values[16]),                
                ValidityDate= Convert.ToDateTime(values[17]),
                ValidityType = values[18].ToString(),
                CropYear = Convert.ToInt32(values[19]),
                Maturity = values[20].ToString(),
                Comp = values[21].ToString(),
                IdUser = Convert.ToInt32(values[22])
            };

            _hviService.InsertData(promedio);
        }

        [HttpPost]
        public void InsertHVI(List<string> values) {
            CultureInfo culture = CultureInfo.InvariantCulture;
            HVIs hvis = new()
            {
                C1 = decimal.Parse(values[0], culture),
                C2 = decimal.Parse(values[1], culture),
                Leaf = decimal.Parse(values[2], culture),
                Stpl = decimal.Parse(values[3], culture),
                Mic = decimal.Parse(values[4], culture),
                Str = decimal.Parse(values[5], culture),
                LRR = decimal.Parse(values[6], culture),
                NetWeight = decimal.Parse(values[7], culture),
                Len = decimal.Parse(values[8], culture),
                Ext = decimal.Parse(values[9], culture),
                RD = decimal.Parse(values[10], culture),
                PlusB = decimal.Parse(values[11], culture),
                Uni = decimal.Parse(values[12], culture),
                Trash = decimal.Parse(values[13], culture),
                Paca = int.Parse(values[14],culture)
            };
            _hviService.InsertHVI(hvis);
        }

        [HttpGet]
        public async Task<string> Username()
        {
            string user = await _hviService.SelectUser();

            return user;
        }

        [HttpGet]
        public async Task<IEnumerable<Warehouse>> GetWhse()
        {
            var data = await _hviService.GetWhse();

            return data.ToList();
        }

        [HttpPut]
        public async Task UpdateStatus(List<int> values)
        {
            try
            {
                int idBid = Convert.ToInt32(values[0]);
                int bidStatus = Convert.ToInt32(values[1]);

                await _hviService.ChangeStatusBid(idBid, bidStatus);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message) ;
            }
            
        }

        public IActionResult UploadedOffers()
        {
            return View();
        }
    }
}
