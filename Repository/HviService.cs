using IntegralTradingJS.Helpers;
using IntegralTradingJS.Models;
using IntegralTradingJS.Repository.Interfaces;
using System.Data.SqlClient;

namespace IntegralTradingJS.Repository
{
    public class HviService : IHviService
    {
        private readonly SqlString sqlString = new();
        private readonly List<HVI> hviList = new();
        public async Task<IEnumerable<HVI>> GetHvi()
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
                            WhseCode = Convert.ToInt32(reader["WhseCode"]),
                            WhseTag = Convert.ToInt32(reader["WhseTag"]),
                            C1 = Convert.ToInt32(reader["C1"]),
                            C2 = Convert.ToInt32(reader["C2"]),
                            Leaf = Convert.ToInt32(reader["Leaf"]),
                            Stpl = Convert.ToInt32(reader["Stpl"]),
                            Mic = Convert.ToInt32(reader["Mic"]),
                            Str = (float)Convert.ToDecimal(reader["Leaf"]),
                            LRR = (float)Convert.ToDecimal(reader["LRR"]),
                            CropYear = Convert.ToInt32(reader["CropYear"]),
                            NetWeight = Convert.ToInt32(reader["NetWeight"]),
                            Comp = reader["Comp"].ToString(),
                            Len = Convert.ToInt32(reader["Len"]),
                            Ext = Convert.ToInt32(reader["Ext"]),
                            RD = (float)Convert.ToDecimal(reader["RD"]),
                            PlusB = Convert.ToInt32(reader["PlusB"]),
                            Uni = (float)Convert.ToDecimal(reader["Uni"]),
                            Trash = Convert.ToInt32(reader["Trash"]),
                            StorageDate = Convert.ToDateTime(reader["StorageDate"])
                        });
                    }
                }
            }

            return hviList;
        }


    }
}
