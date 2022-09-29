using apiSalesNet.Models;
using apiSalesNet.StoredProcedures;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;

namespace apiSalesNet.Database
{
    public class DataSales
    {
        public DataSales() { }

        //Lista de sales1

        public List<Sales1> Sales1(int[] year)
        {
            var json_year = JsonConvert.SerializeObject(year);
            var list = new List<Sales1>();
            var conn = new DBConnection();
            using (var sqlconn = new SqlConnection(conn.getConnection()))
            {
                sqlconn.Open();
                Console.WriteLine("Coneccion a base de datos:" + sqlconn.State);
                SqlCommand cmd = new SqlCommand(Procedures.sp_sales1, sqlconn);
                cmd.Parameters.AddWithValue("year", json_year);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var res = cmd.ExecuteReader())
                {
                    while (res.Read())
                    {
                        Sales1 tmp = new Sales1();
                        tmp.BusinessEntityID = Convert.ToInt32(res["BusinessEntityID"]);
                        tmp.jan = Convert.ToInt32(res["Jan"]);
                        tmp.feb = Convert.ToInt32(res["Feb"]);
                        tmp.mar = Convert.ToInt32(res["Marc"]);
                        tmp.apr = Convert.ToInt32(res["Apr"]);
                        tmp.may = Convert.ToInt32(res["May"]);
                        tmp.jun = Convert.ToInt32(res["Jun"]);
                        tmp.jul = Convert.ToInt32(res["Jul"]);
                        tmp.aug = Convert.ToInt32(res["Aug"]);
                        tmp.sep = Convert.ToInt32(res["Sep"]);
                        tmp.oct = Convert.ToInt32(res["Oct"]);
                        tmp.nov = Convert.ToInt32(res["Nov"]);
                        tmp.dec = Convert.ToInt32(res["Dec"]);

                        list.Add(tmp);
                    }
                }
            }
            return list;
        }

        public List<Sales1> Sales2(int[] year)
        {
            var json_year = JsonConvert.SerializeObject(year);
            var list = new List<Sales1>();
            var conn = new DBConnection();
            using (var sqlconn = new SqlConnection(conn.getConnection()))
            {
                sqlconn.Open();
                Console.WriteLine("Coneccion a base de datos:" + sqlconn.State);
                SqlCommand cmd = new SqlCommand(Procedures.sp_sales1, sqlconn);
                cmd.Parameters.AddWithValue("year", json_year);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var res = cmd.ExecuteReader())
                {
                    while (res.Read())
                    {
                        Sales1 tmp = new Sales1();
                        tmp.BusinessEntityID = Convert.ToInt32(res["BusinessEntityID"]);
                        tmp.jan = Convert.ToInt32(res["Jan"]);
                        tmp.feb = Convert.ToInt32(res["Feb"]);
                        tmp.mar = Convert.ToInt32(res["Marc"]);
                        tmp.apr = Convert.ToInt32(res["Apr"]);
                        tmp.may = Convert.ToInt32(res["May"]);
                        tmp.jun = Convert.ToInt32(res["Jun"]);
                        tmp.jul = Convert.ToInt32(res["Jul"]);
                        tmp.aug = Convert.ToInt32(res["Aug"]);
                        tmp.sep = Convert.ToInt32(res["Sep"]);
                        tmp.oct = Convert.ToInt32(res["Oct"]);
                        tmp.nov = Convert.ToInt32(res["Nov"]);
                        tmp.dec = Convert.ToInt32(res["Dec"]);

                        list.Add(tmp);
                    }
                }
            }
            return list;
        }

        public List<Sales3> Sales3(int[] year)
        {

            var json_year = JsonConvert.SerializeObject(year);
            var list = new List<Sales3>();
            var conn = new DBConnection();
            using (var sqlconn = new SqlConnection(conn.getConnection()))
            {
                sqlconn.Open();
                Console.WriteLine("conexión a base de datos:" + sqlconn.State);
                SqlCommand cmd = new SqlCommand(Procedures.sp_sales3, sqlconn);
                cmd.Parameters.AddWithValue("year", json_year);
               Console.WriteLine("jsj");
                cmd.CommandType = CommandType.StoredProcedure;
                using (var res = cmd.ExecuteReader())
                {
                    while (res.Read())
                    {
                        Console.WriteLine("neni");
                        Sales3 tmp = new Sales3();
                        tmp.Id = Convert.ToInt32(res["BusinessEntityID"]);
                        tmp.sales = Convert.ToInt32(res["Sales"]);
                        tmp.year = Convert.ToInt32(res["Year"]);

                        list.Add(tmp);
                    }
                }
            }
            Console.WriteLine("si llego");
            return list;
        }


        //End sales1
    }
}