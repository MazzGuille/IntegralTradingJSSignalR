using IntegralTradingJS.Models;
using IntegralTradingJS.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntegralTradingJS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferUploadController : ControllerBase
    {
        private readonly IHviService _hviService;

        public OfferUploadController(IHviService hviService)
        {
            _hviService = hviService;
        }

        //[Route("/seller/InsertData")]
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
                //Price = Convert.ToDecimal(values[14]),
                //TipoPrecio = values[15].ToString(),
                //Almacen = values[16].ToString(),
                //Validez = values[17].ToString(),
                //TipoFecha = values[18].ToString(),
                CropYear = Convert.ToInt32(values[19]),
                Maturity = values[20].ToString()
            };

               _hviService.InsertData(promedio);
        }
    }
}
