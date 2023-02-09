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
                    ID = fila.GetCell(0).ToString(),
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
                    Comp = fila.GetCell(12).ToString(),
                    Len = fila.GetCell(13).ToString(),
                    Ext = fila.GetCell(14).ToString(),
                    RD = fila.GetCell(15).ToString(),
                    PlusB = fila.GetCell(16).ToString(),
                    Uni = fila.GetCell(17).ToString(),
                    Trash = fila.GetCell(18).ToString(),
                    StorageDate = fila.GetCell(19).ToString()
                });
            }
            return StatusCode(StatusCodes.Status200OK, HviData);
        }
        
        public IActionResult InsertData()
        {           
            return View();
        }

        [HttpPost]
        public ActionResult InsertDataToDB()
        {
            _hviService.InsertData(hvi);

            return RedirectToAction("Seller/InsertData");
        }
    }
}
