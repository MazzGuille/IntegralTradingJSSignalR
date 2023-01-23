using IntegralTradingJS.Models;
using Microsoft.AspNetCore.SignalR;
using System.Data.SqlClient;
using IntegralTradingJS.Helpers;
using IntegralTradingJS.Repository;
using System.Data;
using IntegralTradingJS.Repository.Interfaces;

namespace IntegralTradingJS.Hubs
{
    public class HviHub : Hub
    {
        private readonly IHviService _service;

        public HviHub(IHviService service)
        {
            _service = service;
        }

        public async Task ExecuteProcedure()
        {
            var result = await _service.GetHvi();

            await Clients.All.SendAsync("ReceiveStoredProcedureResult", result);
        }

















        //public static List<string> hviList = new();
        //public static List<HVI> hviNew = new();


        //public async Task SendHvi(int ID, decimal UHML, decimal UI, decimal Strength, decimal SFI, decimal MIC, string ColorGrade, decimal TrashId, int OrderId)
        //{

        //    var baseList = new HVI()
        //    {
        //        ID = ID,
        //        UHML = UHML,
        //        UI = UI,
        //        Strength = Strength,
        //        SFI = SFI,
        //        MIC = MIC,
        //        ColorGrade = ColorGrade,
        //        TrashId = TrashId,
        //        OrderId = OrderId
        //    };
        //    hviNew.Add(baseList);
        //    var count = hviNew.Count;

        //    await Clients.All.SendAsync("ReceiveHvi", baseList.ID, baseList.UHML, baseList.UI, baseList.Strength, baseList.SFI, baseList.MIC, baseList.ColorGrade, baseList.TrashId, baseList.OrderId, count);
        //}

        //public async Task ResetHvi()
        //{
        //    hviNew.Clear();
        //    await Clients.All.SendAsync("ReceiveResetHvi");
        //}



    }
}
