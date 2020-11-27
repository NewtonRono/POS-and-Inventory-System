using System;
using System.Data.SqlClient;

namespace POS_and_Inventory_System
{
    class DBConnection
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;
        private double dailySales;
        private int productLine;
        private int stockOnHand;
        private int critical;
        string connString;
        public string MyConnection()
        {
            //string conn = @"datasource = localhost; username = root; password = ; database = pos_inventory_db";
            connString = @"Data Source=WALL-E;Initial Catalog=POS_DB;Integrated Security=True";
            return connString;
        }

        public double DailySales()
        {
            string sdate = DateTime.Now.ToShortDateString();
            conn = new SqlConnection(MyConnection());
            conn.Open();
            string sql = "SELECT isnull(sum(total), 0) AS total FROM tblCart WHERE sdate BETWEEN '" + 
                sdate + "' AND '" + sdate + "' AND status LIKE 'Sold'";
            cmd = new SqlCommand(sql, conn);
            dailySales = double.Parse(cmd.ExecuteScalar().ToString());
            conn.Close();
            return dailySales;
        }

        public int ProductLine()
        {
            conn = new SqlConnection(MyConnection());
            conn.Open();
            cmd = new SqlCommand("SELECT count(*) FROM tblProduct", conn);
            productLine = int.Parse(cmd.ExecuteScalar().ToString());
            conn.Close();
            return productLine;
        }

        public int StockOnHand()
        {
            conn = new SqlConnection(MyConnection());
            conn.Open();
            cmd = new SqlCommand("SELECT isnull(sum(qty),0) AS qty FROM tblProduct", conn);
            stockOnHand = int.Parse(cmd.ExecuteScalar().ToString());
            conn.Close();
            return stockOnHand;
        }

        public int CriticalItems()
        {
            conn = new SqlConnection(MyConnection());
            conn.Open();
            cmd = new SqlCommand("SELECT count(*) FROM vwCriticalItems", conn);
            critical = int.Parse(cmd.ExecuteScalar().ToString());
            conn.Close();
            return critical;
        }

        public double GetVal()
        {
            double vat = 0;
            conn = new SqlConnection(MyConnection());
            //conn.ConnectionString = MyConnection();
            conn.Open();
            string sql = "SELECT * FROM tblVat";
            cmd = new SqlCommand(sql, conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                vat = double.Parse(dr["vat"].ToString());
            }
            dr.Close();
            conn.Close();
            return vat;
        }

        public string GetPassword(string user)
        {
            string password = "";
            conn = new SqlConnection(MyConnection());
            //conn.ConnectionString = MyConnection();
            conn.Open();
            string sql = "SELECT * FROM tblUser WHERE username=@username";
            cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@username", user);
            dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                password = dr["password"].ToString();
            }
            dr.Close();
            conn.Close();
            return password;
        }
    }
}
