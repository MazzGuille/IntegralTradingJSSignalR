using IntegralTradingJS.Models;
using IntegralTradingJS.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Collections.Generic;

namespace IntegralTradingJS.Controllers
{
    public class SellerController : Controller
    {
        private readonly IHviService _hviService;
        public List<HviRed> HviData = new();
        HVI hvi = new();

        public SellerController(IHviService hviService)
        {
            _hviService= hviService;
        }

        public IActionResult SellerOffers()
        {
            return View();
        }
       
        public ActionResult OfferUpload()
        {
            return View();
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

            Promedios promedio = new()
            {
                C1 = values[0].ToString(),
                C2 = values[1].ToString(),
                Leaf = values[2].ToString(),
                Stpl =values[3].ToString(),
                Mic =values[4].ToString(),
                Str = values[5].ToString(),
                LRR = values[6].ToString(),
                NetWeight = values[7].ToString(),
                Len = values[8].ToString(),
                Ext = values[9].ToString(),
                RD = values[10].ToString(),
                PlusB = values[11].ToString(),
                Uni = values[12].ToString(),
                Trash = values[13].ToString(),
                Price = values[14].ToString(),
                PriceType = values[15].ToString(),
                Warehouse = values[16].ToString(),                
                ValidityDate= Convert.ToDateTime(values[17]),
                ValidityType = values[18].ToString(),
                CropYear = Convert.ToInt32(values[19]),
                Maturity = values[20].ToString(),
                Comp = values[21].ToString(),
                User = values[22].ToString()
            };

            _hviService.InsertData(promedio);
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

        public IActionResult PendingOffersList()
        {
            return View();
        }
    }
}
