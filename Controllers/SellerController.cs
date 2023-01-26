using IntegralTradingJS.Models;
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
        public List<HviRed> HviData = new();
       
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
                    UHML = fila.GetCell(0).ToString(),
                    UI = fila.GetCell(1).ToString(),
                    Strength = fila.GetCell(2).ToString(),
                    SFI = fila.GetCell(3).ToString(),
                    Mic = fila.GetCell(4).ToString(),
                    ColorGrade = fila.GetCell(5).ToString(),
                    TrashID = fila.GetCell(6).ToString(),
                });
            }
            return StatusCode(StatusCodes.Status200OK, HviData);
        }

        // GET: SellerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SellerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SellerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SellerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SellerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SellerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
