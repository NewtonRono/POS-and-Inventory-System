using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace POS_and_Inventory_System.DAL
{
    class DashboardDAL
    {
        private static string connString = @"Data Source=WALL-E;Initial Catalog=POS_DB;Integrated Security=True";
        public void LoadDashboard(Chart chart)
        {
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                conn.Open();
                string sql = "SELECT Year(sdate) AS year, isnull(sum(total), 0.0) AS total FROM tblCart WHERE status LIKE 'Sold' GROUP BY YEAR(sdate)";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataSet1 ds = new DataSet1();

                da.Fill(ds, "Sales");
                chart.DataSource = ds.Tables["Sales"];
                Series series = chart.Series["Series1"];
                series.ChartType = SeriesChartType.Doughnut;

                series.Name = "SALES";

                chart.Series[series.Name].XValueMember = "year";
                chart.Series[series.Name].YValueMembers = "total";
                chart.Series[0].IsValueShownAsLabel = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
