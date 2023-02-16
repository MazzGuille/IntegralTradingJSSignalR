using IntegralTradingJS.Helpers;
using IntegralTradingJS.Models;
using IntegralTradingJS.Repository.Interfaces;
using System.Data;
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
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        hviList.Add(new HVI
                        {
                            ID = Convert.ToInt32(reader["ID"]),
                            User = reader["User"].ToString(),//add
                            Status = reader["status"].ToString(),
                            Price = Convert.ToDecimal(reader["Price"]),
                            PriceType = reader["TipoPrecio"].ToString(),//change to english
                            Warehouse = reader["Almacen"].ToString(),//change to english
                            ValidityDate = Convert.ToDateTime(reader["Validez"]),//change to english
                            ValidityType = reader["TipoFecha"].ToString(),//change to english
                            OfferDate = Convert.ToDateTime(reader["OfferDate"]),
                            CropYear = Convert.ToInt32(reader["CropYear"]),
                            Maturity = reader["Maturity"].ToString(),
                            Comp = reader["Comp"].ToString(),//add
                            C1 = Convert.ToInt32(reader["C1"]),
                            C2 = Convert.ToInt32(reader["C2"]),
                            Leaf = Convert.ToInt32(reader["Leaf"]),
                            Stpl = Convert.ToInt32(reader["Stpl"]),
                            Mic = Convert.ToInt32(reader["Mic"]),
                            Str = (float)Convert.ToDecimal(reader["Leaf"]),
                            LRR = (float)Convert.ToDecimal(reader["LRR"]),                            
                            NetWeight = Convert.ToInt32(reader["NetWeight"]),                            
                            Len = Convert.ToInt32(reader["Len"]),
                            Ext = Convert.ToInt32(reader["Ext"]),
                            RD = (float)Convert.ToDecimal(reader["RD"]),
                            PlusB = Convert.ToInt32(reader["PlusB"]),
                            Uni = (float)Convert.ToDecimal(reader["Uni"]),
                            Trash = Convert.ToInt32(reader["Trash"])                   
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
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }            
        }

        public void InsertData(Promedios promedio)
        {  

            using (SqlConnection cn = new SqlConnection(sqlString.GetSqlString()))
            {
                SqlCommand cmd = new SqlCommand("SP_InsertToDB", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("User", promedio.User);//add
                cmd.Parameters.AddWithValue("Status", promedio.Status);
                cmd.Parameters.AddWithValue("Price", promedio.Price);
                cmd.Parameters.AddWithValue("TipoPrecio", promedio.PriceType);//change to english
                cmd.Parameters.AddWithValue("Almacen", promedio.Warehouse);//change to english
                cmd.Parameters.AddWithValue("Validez", promedio.ValidityDate);//change to english
                cmd.Parameters.AddWithValue("TipoFecha", promedio.ValidityType);//change to english
                cmd.Parameters.AddWithValue("OfferDate", promedio.OfferDate);
                cmd.Parameters.AddWithValue("CropYear", promedio.CropYear);
                cmd.Parameters.AddWithValue("Maturity", promedio.Maturity);
                cmd.Parameters.AddWithValue("Comp", promedio.Comp);//add
                cmd.Parameters.AddWithValue("C1",promedio.C1);
                cmd.Parameters.AddWithValue("C2",promedio.C2);
                cmd.Parameters.AddWithValue("Leaf",promedio.Leaf);
                cmd.Parameters.AddWithValue("Stpl",promedio.Stpl);
                cmd.Parameters.AddWithValue("Mic",promedio.Mic );
                cmd.Parameters.AddWithValue("Str",promedio.Str);
                cmd.Parameters.AddWithValue("LRR",promedio.LRR);                
                cmd.Parameters.AddWithValue("NetWeight",promedio.NetWeight );                
                cmd.Parameters.AddWithValue("Len",promedio.Len );
                cmd.Parameters.AddWithValue("Ext",promedio.Ext );
                cmd.Parameters.AddWithValue("RD",promedio.RD );
                cmd.Parameters.AddWithValue("PlusB",promedio.PlusB );
                cmd.Parameters.AddWithValue("Uni",promedio.Uni );
                cmd.Parameters.AddWithValue("Trash",promedio.Trash );       

                cn.Open();
                cmd.ExecuteNonQuery();
            }      

        }

        public async Task<string> SelectUser()
        {
            string user;
            await using (SqlConnection cn = new(sqlString.GetSqlString()))
            {
                cn.Open();
                SqlCommand cmd = new("SP_SelectUser", cn);
                cmd.Parameters.AddWithValue("Id", 1);
                cmd.CommandType = CommandType.StoredProcedure;
                user =  cmd.ExecuteScalar().ToString();
            } 
            
            return user;
        }
    }
}
