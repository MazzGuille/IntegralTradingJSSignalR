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

            Promedios promedio = new Promedios()
            {
                C1 = Convert.ToDecimal(values[0]),
                C2 = Convert.ToDecimal(values[1]),
                Leaf = Convert.ToDecimal(values[2]),
                Stpl = Convert.ToDecimal(values[3]),
                Mic = Convert.ToDecimal(values[4]),
                Str = Convert.ToDecimal(values[5]),
                LRR = Convert.ToDecimal(values[6]),
                NetWeight = Convert.ToDecimal(values[7]),
                Len = Convert.ToDecimal(values[8]),
                Ext = Convert.ToDecimal(values[9]),
                RD = Convert.ToDecimal(values[10]),
                PlusB = Convert.ToDecimal(values[11]),
                Uni = Convert.ToDecimal(values[12]),
                Trash = Convert.ToDecimal(values[13]),
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
    }
}
