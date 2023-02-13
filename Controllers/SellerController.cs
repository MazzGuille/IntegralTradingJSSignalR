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
                    Price = fila.GetCell(0).ToString(),
                    WhseCode = fila.GetCell(1).ToString(),
                    WhseTag = fila.GetCell(2).ToString(),
                    C1 = fila.GetCell(3).ToString(),
                    C2 = fila.GetCell(4).ToString(),
                    Leaf = fila.GetCell(5).ToString(),
                    Stpl = fila.GetCell(6).ToString(),
                    Mic = fila.GetCell(7).ToString(),
                    Str = fila.GetCell(8).ToString(),
                    LRR = fila.GetCell(9).ToString(),
                    CropYear = fila.GetCell(10).ToString(),
                    NetWeight = fila.GetCell(11).ToString(),
                    Len = fila.GetCell(12).ToString(),
                    Ext = fila.GetCell(13).ToString(),
                    RD = fila.GetCell(14).ToString(),
                    PlusB = fila.GetCell(15).ToString(),
                    Uni = fila.GetCell(16).ToString(),
                    Trash = fila.GetCell(17).ToString()
                });
            }
            return StatusCode(StatusCodes.Status200OK, HviData);
        }
        
        public ActionResult InsertData()
        {           
            return View();
        }

        [HttpPost]
        public ActionResult InsertData(List<string> values)
        {            

            Promedios promedio = new Promedios()
            {
                Price = Convert.ToDecimal(values[0]),
                WhseCode = Convert.ToDecimal(values[1]),
                WhseTag = Convert.ToDecimal(values[2]),
                C1 = Convert.ToDecimal(values[3]),
                C2 = Convert.ToDecimal(values[4]),
                Leaf = Convert.ToDecimal(values[5]),
                Stpl = Convert.ToDecimal(values[6]),
                Mic = Convert.ToDecimal(values[7]),
                Str = Convert.ToDecimal(values[8]),
                LRR = Convert.ToDecimal(values[9]),
                CropYear = Convert.ToDecimal(values[10]),
                NetWeight = Convert.ToDecimal(values[11]),
                Len = Convert.ToDecimal(values[12]),
                Ext = Convert.ToDecimal(values[13]),
                RD = Convert.ToDecimal(values[14]),
                PlusB = Convert.ToDecimal(values[15]),
                Uni = Convert.ToDecimal(values[16]),
                Trash = Convert.ToDecimal(values[17])
            };           

            _hviService.InsertData(promedio);

            return RedirectToAction("HviAPI", "Home");
        }
    }
}
