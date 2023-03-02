

using IntegralTradingJS.Helpers;
using IntegralTradingJS.Models;
using IntegralTradingJS.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace IntegralTradingJS.Repository
{
    public class HviService : IHviService
    {
        private readonly IHttpContextAccessor _cntx;
        private readonly SqlString sqlString = new();
        private readonly List<HVI> hviList = new();
        private readonly List<Offers> OfferList = new();
        private readonly HVI _hvi = new();
        private readonly List<Warehouse> whseList = new();
        private readonly List<Bids> bidsList = new();
        private readonly List<BuyerBid> SellerBidsList = new();
        private readonly List<SellerOffers> SellerOffersList = new();
        private readonly JWTConfiguration _jwt = new(); //INSTANCIA PARA APLICAR EL JWT


        public HviService(IHttpContextAccessor cntx)
        {
            _cntx = cntx;
        }

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
                            ID= Convert.ToInt32(reader["ID"]),
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

        public async Task<IEnumerable<Offers>> GetPromedios()
        {
            await using (SqlConnection cn = new(sqlString.GetSqlString()))
            {
                cn.Open();
                SqlCommand cmd = new("SP_OfferList", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        OfferList.Add(new Offers
                        {
                            IdOffer = Convert.ToInt32(reader["IdOffer"]),
                            IdWarehouse = Convert.ToInt32(reader["IdWarehouse"]),
                            C1 = Convert.ToDecimal(reader["C1"]),
                            C2 = Convert.ToDecimal(reader["C2"]),
                            Leaf = Convert.ToDecimal(reader["Leaf"]),
                            Stpl = Convert.ToDecimal(reader["Stpl"]),
                            Mic = Convert.ToDecimal(reader["Mic"]),
                            Str = Convert.ToDecimal(reader["Str"]),
                            LRR = Convert.ToDecimal(reader["LRR"]),
                            CropYear = Convert.ToInt32(reader["CropYear"]),
                            NetWeight = Convert.ToDecimal(reader["NetWeight"]),
                            Comp = reader["Comp"].ToString(),
                            Len = Convert.ToDecimal(reader["Len"]),
                            Ext = Convert.ToDecimal(reader["Ext"]),
                            RD = Convert.ToDecimal(reader["RD"]),
                            PlusB = Convert.ToDecimal(reader["RD"]),
                            Uni = Convert.ToDecimal(reader["Uni"]),
                            Trash = Convert.ToDecimal(reader["Trash"]),
                            OfferDate = Convert.ToDateTime(reader["OfferDate"]),
                            Price = Convert.ToDecimal(reader["Price"]),
                            PriceType = reader["PriceType"].ToString(),
                            IdStatus = Convert.ToInt32(reader["IdStatus"]),
                            Maturity = reader["Maturity"].ToString(),
                            IdUser = Convert.ToInt32(reader["IdUser"]),
                            ValidityDate = Convert.ToDateTime(reader["ValidityDate"]),
                            ValidityType = reader["ValidityType"].ToString()
                        });
                    }
                }
                
            }

            return OfferList;
        }

        public async Task UpdateStatus(int id)
        {
            await using (SqlConnection cn = new(sqlString.GetSqlString()))
            {
                cn.Open();
                SqlCommand cmd = new("SP_UpdateStatus", cn);
                cmd.Parameters.AddWithValue("IdOferta", id);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }            
        }

        //public void InsertData(Promedios promedio)
        //{  

        //    using (SqlConnection cn = new SqlConnection(sqlString.GetSqlString()))
        //    {
        //        SqlCommand cmd = new SqlCommand("SP_InsertToDB", cn);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        cmd.Parameters.AddWithValue("User", promedio.User);//add
        //        cmd.Parameters.AddWithValue("Status", promedio.Status);
        //        cmd.Parameters.AddWithValue("Price", promedio.Price);
        //        cmd.Parameters.AddWithValue("TipoPrecio", promedio.PriceType);//change to english
        //        cmd.Parameters.AddWithValue("Almacen", promedio.Warehouse);//change to english
        //        cmd.Parameters.AddWithValue("Validez", promedio.ValidityDate);//change to english
        //        cmd.Parameters.AddWithValue("TipoFecha", promedio.ValidityType);//change to english
        //        cmd.Parameters.AddWithValue("OfferDate", promedio.OfferDate);
        //        cmd.Parameters.AddWithValue("CropYear", promedio.CropYear);
        //        cmd.Parameters.AddWithValue("Maturity", promedio.Maturity);
        //        cmd.Parameters.AddWithValue("Comp", promedio.Comp);//add
        //        cmd.Parameters.AddWithValue("C1",promedio.C1);
        //        cmd.Parameters.AddWithValue("C2",promedio.C2);
        //        cmd.Parameters.AddWithValue("Leaf",promedio.Leaf);
        //        cmd.Parameters.AddWithValue("Stpl",promedio.Stpl);
        //        cmd.Parameters.AddWithValue("Mic",promedio.Mic );
        //        cmd.Parameters.AddWithValue("Str",promedio.Str);
        //        cmd.Parameters.AddWithValue("LRR",promedio.LRR);                
        //        cmd.Parameters.AddWithValue("NetWeight",promedio.NetWeight );                
        //        cmd.Parameters.AddWithValue("Len",promedio.Len );
        //        cmd.Parameters.AddWithValue("Ext",promedio.Ext );
        //        cmd.Parameters.AddWithValue("RD",promedio.RD );
        //        cmd.Parameters.AddWithValue("PlusB",promedio.PlusB );
        //        cmd.Parameters.AddWithValue("Uni",promedio.Uni );
        //        cmd.Parameters.AddWithValue("Trash",promedio.Trash );       

        //        cn.Open();
        //        cmd.ExecuteNonQuery();
        //    }      

        //}

        public void InsertData(Promedios promedio)
        {

            using (SqlConnection cn = new SqlConnection(sqlString.GetSqlString()))
            {
                SqlCommand cmd = new SqlCommand("SP_InsertToDB", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("IdWarehouse", promedio.IdWarehouse);//add
                cmd.Parameters.AddWithValue("C1", promedio.C1);
                cmd.Parameters.AddWithValue("C2", promedio.C2);
                cmd.Parameters.AddWithValue("Leaf", promedio.Leaf);//change to english
                cmd.Parameters.AddWithValue("Stpl", promedio.Stpl);//change to english
                cmd.Parameters.AddWithValue("Mic", promedio.Mic);//change to english
                cmd.Parameters.AddWithValue("Str", promedio.Str);//change to english
                cmd.Parameters.AddWithValue("LRR", promedio.LRR);
                cmd.Parameters.AddWithValue("CropYear", promedio.CropYear);
                cmd.Parameters.AddWithValue("NetWeight", promedio.NetWeight);
                cmd.Parameters.AddWithValue("Comp", promedio.Comp);//add
                cmd.Parameters.AddWithValue("Len", promedio.Len);
                cmd.Parameters.AddWithValue("Ext", promedio.Ext);
                cmd.Parameters.AddWithValue("RD", promedio.RD);
                cmd.Parameters.AddWithValue("PlusB", promedio.PlusB);
                cmd.Parameters.AddWithValue("Uni", promedio.Uni);
                cmd.Parameters.AddWithValue("Trash", promedio.Trash);
                cmd.Parameters.AddWithValue("OfferDate", promedio.OfferDate);
                cmd.Parameters.AddWithValue("Price", promedio.Price);
                cmd.Parameters.AddWithValue("PriceType", promedio.PriceType);
                cmd.Parameters.AddWithValue("IdStatus", promedio.IdStatus);
                cmd.Parameters.AddWithValue("Maturity", promedio.Maturity);
                cmd.Parameters.AddWithValue("IdUser", promedio.IdUser);
                cmd.Parameters.AddWithValue("ValidityDate", promedio.ValidityDate);
                cmd.Parameters.AddWithValue("ValidityType", promedio.ValidityType);

                cn.Open();
                cmd.ExecuteNonQuery();
            }

        }

        public async Task<string> SelectUser()
        {
            string user;
            await using (SqlConnection cn = new(sqlString.GetSqlString()))
            {
                var idUsu = _cntx.HttpContext.Session.GetInt32("userId");
                cn.Open();
                SqlCommand cmd = new("SP_SelectUser", cn);
                cmd.Parameters.AddWithValue("Id", idUsu);
                cmd.CommandType = CommandType.StoredProcedure;
                user =  cmd.ExecuteScalar().ToString();
            } 
            
            return user;
        }

        public async Task<IEnumerable<Warehouse>> GetWhse()
        {
            await using (SqlConnection cn = new(sqlString.GetSqlString()))
            {
                cn.Open();
                SqlCommand cmd = new("SP_GetWhse", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        whseList.Add(new Warehouse
                        {
                            Id_whse = Convert.ToInt32(reader["Id_whse"]),
                            Id_company = Convert.ToInt32(reader["Id_company"]),
                            Name = Convert.ToString(reader["Name"]),
                            Region = Convert.ToString(reader["Region"]),
                            Town = Convert.ToString(reader["Town"]),
                            State = Convert.ToString(reader["State"]),
                            Country = Convert.ToString(reader["Country"]),
                            id_creadorAlmacen = Convert.ToInt32(reader["Id_creadorAlmacen"])

                        });
                    }
                }
            }

            return whseList;
        }

        public async Task<IEnumerable<Bids>> GetUserBids()
        {
            await using (SqlConnection cn = new(sqlString.GetSqlString()))
            {
                cn.Open();
                SqlCommand cmd = new("SP_GetUserBids", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("IdUsuario", 1);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        bidsList.Add(new Bids
                        {
                            IdOffer = Convert.ToInt32(reader["IdOffer"]),
                            Id_company = Convert.ToInt32(reader["Id_company"]),
                            IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                            Price = reader["Price"].ToString(),
                            IdBidStatusFK = Convert.ToInt32(reader["IdBidStatusFK"]),
                            Comments = Convert.ToString(reader["Comments"]),
                            Date = Convert.ToDateTime(reader["Date"])

                        });
                    }
                }
            }

            return bidsList;
        }

        public async Task<string> Login(Login user)
        {
            string res;

            await using (SqlConnection cn = new(sqlString.GetSqlString()))
            {
                cn.Open();
                SqlCommand cmd = new("SP_Login", cn);
                cmd.Parameters.AddWithValue("Email", user.Email);
                cmd.Parameters.AddWithValue("Password", user.Password);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        user.CompanyId = Convert.ToInt32(reader["Id_company"]);
                        user.UserId = Convert.ToInt32(reader["Id_user"]);
                    }
                }
            } 
            
            if(user.UserId != 0)
            {
                res = _jwt.token(user);
            }
            else
            {
                res = "Error";
            }

            return res;
        }

        public async Task<IEnumerable<BuyerBid>> GetBuyerBid()
        {
            await using (SqlConnection cn = new(sqlString.GetSqlString()))
            {
                var idUsu = _cntx.HttpContext.Session.GetInt32("userId");
                var idComp = _cntx.HttpContext.Session.GetInt32("companyId");

                cn.Open();
                SqlCommand cmd = new("SP_BuyerBids", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("IdCompany", idComp);
                cmd.Parameters.AddWithValue("IdUsuario", idUsu);
            

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        SellerBidsList.Add(new BuyerBid
                        {
                            IdBid = Convert.ToInt32(reader["IdBid"]),
                            Price = Convert.ToDecimal(reader["Price"]),
                            Comments = reader["Comments"].ToString(),
                            CompanyName = reader["Razon_Social"].ToString(),
                            UserName = reader["FullName"].ToString(),
                            UserSeller = reader["UserSeller"].ToString() ,
                            UserCompany = reader["CompanySeller"].ToString(),
                            PriceSeller = Convert.ToDecimal(reader["PriceSeller"])
                        });
                    }
                }
            }

            return SellerBidsList;
        }

        public async Task<IEnumerable<SellerOffers>> GetSellerOffers()
        {
            await using (SqlConnection cn = new(sqlString.GetSqlString()))
            {
                var idUsu = _cntx.HttpContext.Session.GetInt32("userId");
                var idComp = _cntx.HttpContext.Session.GetInt32("companyId");

                cn.Open();
                SqlCommand cmd = new("SP_SellerOffers", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("IdCompany", idComp);
                cmd.Parameters.AddWithValue("IdUsuario", idUsu);


                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        SellerOffersList.Add(new SellerOffers
                        {
                            IdOffer = Convert.ToInt32(reader["IdOffer"]),
                            IdBid = Convert.ToInt32(reader["IdBid"]),
                            Price = Convert.ToDecimal(reader["Price"]),
                            Comments = reader["Comments"].ToString(),
                            CompanyName = reader["Razon_Social"].ToString(),
                            UserName = reader["FullName"].ToString(),
                        });
                    }
                }
            }

            return SellerOffersList;
        }

        public async Task EliminateBid(int id)
        {
            await using (SqlConnection cn = new(sqlString.GetSqlString()))
            {
                cn.Open();
                SqlCommand cmd = new("SP_EliminateBid", cn);
                cmd.Parameters.AddWithValue("BidId", id);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }

        }

        public async Task UploadBid(Bids bid)
        {
            try
            {
                await using (SqlConnection cn = new(sqlString.GetSqlString()))
                {
                    cn.Open();
                    SqlCommand cmd = new("SP_CreateBuyerBid", cn);
                    cmd.Parameters.AddWithValue("IdOffer", bid.IdOffer);
                    cmd.Parameters.AddWithValue("Id_company", bid.Id_company);
                    cmd.Parameters.AddWithValue("Id_usuario", bid.IdUsuario);
                    cmd.Parameters.AddWithValue("Price", bid.Price);
                    cmd.Parameters.AddWithValue("Comments", bid.Comments);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {

                throw new Exception (e.Message.ToString());
            }
           
        }

      
    }
}
