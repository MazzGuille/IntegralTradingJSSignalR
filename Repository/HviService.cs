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
                            StorageDate = Convert.ToDateTime(reader["StorageDate"]),
                            Price = (float)Convert.ToDecimal(reader["Price"]),
                            Status= Convert.ToBoolean(reader["status"])
                        });
                    }
                }
            }

            return hviList;
        }

        private void InsertData(int ID, int WhseCode, int WhseTag, int C1, int C2, int Leaf, int Mic, float Str, float LRR, int CropYear, int NetWeight, String Comp, int Len, int Ext,
            float RD, int PlusB, float Uni, int Trash, int StorageDate)
        {
            // define INSERT query with parameters
            string query = "INSERT INTO HVIcsv (ID, WhseCode, WhseTag, C1, C2, Leaf,Mic,Str,LRR,CropYear,NetWeight,Comp,Len,Ext,RD,PlusB,Uni,Trash,StorageDate) " +
                           "VALUES (@ID,@WhseCode,@WhseTag,@C1,@C2,@Leaf,@Mic,@Str,@LRR,@CropYear,@NetWeight,@Comp,@Len,@Ext,@RD,@PlusB,@Uni,@Trash,@StorageDate) ";

            /*string query2 = "INSERT INTO HVIcsv VALUES ("+ID+','+WhseCode+','+WhseTag+','+C1+','+C2+','+Leaf+','+Mic+','+Str+','+LRR+','+CropYear+','+NetWeight+','+Comp+','+Len+','+Ext+','+
                RD+','+PlusB+','+Uni+','+Trash+','+StorageDate+");";*/

            // create connection and command
            using (SqlConnection cn = new SqlConnection(sqlString.GetSqlString()))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                // define parameters and their values

                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@WhseCode", WhseCode);
                cmd.Parameters.AddWithValue("@WhsetAG", WhseTag);
                cmd.Parameters.AddWithValue("@C1", C1);
                cmd.Parameters.AddWithValue("@C2", C2);
                cmd.Parameters.AddWithValue("@Leaf", Leaf);
                cmd.Parameters.AddWithValue("@Mic", Mic);
                cmd.Parameters.AddWithValue("@Str", Str);
                cmd.Parameters.AddWithValue("@LRR", LRR);
                cmd.Parameters.AddWithValue("@CropYear", CropYear);
                cmd.Parameters.AddWithValue("@NetWeight", NetWeight);
                cmd.Parameters.AddWithValue("@Comp", Comp);
                cmd.Parameters.AddWithValue("@Len", Len);
                cmd.Parameters.AddWithValue("@Ext", Ext);
                cmd.Parameters.AddWithValue("@RD", RD);
                cmd.Parameters.AddWithValue("@PlusB", PlusB);
                cmd.Parameters.AddWithValue("@Uni", Uni);
                cmd.Parameters.AddWithValue("@Trash", Trash);
                cmd.Parameters.AddWithValue("@StorageDate", StorageDate);

                // open connection, execute INSERT, close connection
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }

        }


    }
}
