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
        private readonly HVI _hvi = new();
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
                            Status= reader["status"].ToString()
                        });
                    }
                }
            }

            return hviList;
        }

        public async Task UpdateStatus(int ob)
        {
            await using (SqlConnection cn = new(sqlString.GetSqlString()))
            {
                cn.Open();
                SqlCommand cmd = new("SP_UpdateStatus", cn);
                cmd.Parameters.AddWithValue("IdOferta", 1);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }            
        }

        public void InsertData(HVI oferta)
        {
            // define INSERT query with parameters
            //string query = "INSERT INTO HVIcsv (WhseCode, WhseTag/*, C1, C2, Leaf,Mic,Str,LRR,CropYear,NetWeight,Comp,Len,Ext,RD,PlusB,Uni,Trash,StorageDate*/) " +
            //               "VALUES (@WhseCode,@WhseTag/*,@C1,@C2,@Leaf,@Mic,@Str,@LRR,@CropYear,@NetWeight,@Comp,@Len,@Ext,@RD,@PlusB,@Uni,@Trash,@StorageDate*/) ";

            /*string query2 = "INSERT INTO HVIcsv VALUES ("+ID+','+WhseCode+','+WhseTag+','+C1+','+C2+','+Leaf+','+Mic+','+Str+','+LRR+','+CropYear+','+NetWeight+','+Comp+','+Len+','+Ext+','+
                RD+','+PlusB+','+Uni+','+Trash+','+StorageDate+");";*/

            // create connection and command
            using (SqlConnection cn = new SqlConnection(sqlString.GetSqlString()))
            using (SqlCommand cmd = new SqlCommand("SP_InsertToDB", cn))
            {
                // define parameters and their values

                
                cmd.Parameters.AddWithValue("WhseCode", oferta.WhseCode);
                cmd.Parameters.AddWithValue("WhseTag", oferta.WhseTag);
                //cmd.Parameters.AddWithValue("@C1", oferta.C1);
                //cmd.Parameters.AddWithValue("@C2", oferta.C2);
                //cmd.Parameters.AddWithValue("@Leaf", oferta.Leaf);
                //cmd.Parameters.AddWithValue("@Mic", oferta.Mic);
                //cmd.Parameters.AddWithValue("@Str", oferta.Str);
                //cmd.Parameters.AddWithValue("@LRR", oferta.LRR);
                //cmd.Parameters.AddWithValue("@CropYear", oferta.CropYear);
                //cmd.Parameters.AddWithValue("@NetWeight", oferta.NetWeight);
                //cmd.Parameters.AddWithValue("@Comp", oferta.Comp);
                //cmd.Parameters.AddWithValue("@Len", oferta.Len);
                //cmd.Parameters.AddWithValue("@Ext", oferta.Ext);
                //cmd.Parameters.AddWithValue("@RD", oferta.RD);
                //cmd.Parameters.AddWithValue("@PlusB", oferta.PlusB);
                //cmd.Parameters.AddWithValue("@Uni", oferta.Uni);
                //cmd.Parameters.AddWithValue("@Trash", oferta.Trash);
                //cmd.Parameters.AddWithValue("@StorageDate", oferta.StorageDate);

                // open connection, execute INSERT, close connection
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }

        }


    }
}
