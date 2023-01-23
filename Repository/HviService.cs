using IntegralTradingJS.Models;
using IntegralTradingJS.Helpers;
using IntegralTradingJS.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System.Data.SqlClient;

namespace IntegralTradingJS.Repository
{
    public class HviService : IHviService
    {
        private readonly SqlString sqlString = new();
        private readonly List<HVI> hviList = new();
        public async Task<List<HVI>> GetHvi()
        {
            await using (SqlConnection cn = new(sqlString.GetSqlString()))
            {
                cn.Open();
                SqlCommand cmd = new("SP_GetHvi", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        hviList.Add(new HVI
                        {
                            ID = Convert.ToInt32(reader["ID"]),
                            UHML = Convert.ToDecimal(reader["UHML"]),
                            UI = Convert.ToDecimal(reader["UI"]),
                            Strength = Convert.ToDecimal(reader["Strength"]),
                            SFI = Convert.ToDecimal(reader["SFI"]),
                            MIC = Convert.ToDecimal(reader["MIC"]),
                            ColorGrade = reader["ColorGrade"].ToString(),
                            TrashId = Convert.ToDecimal(reader["TrashId"]),
                            OrderId = Convert.ToInt32(reader["OrderId"]),
                        });
                    }
                }
            }

            return hviList;
        }


    }
}
