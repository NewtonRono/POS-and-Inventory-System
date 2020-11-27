using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms.DataVisualization.Charting;

namespace POS_and_Inventory_System
{
    public partial class frmChart : Form
    {
        SqlConnection conn;
        DBConnection dbconn = new DBConnection();

        public frmChart()
        {
            InitializeComponent();
            conn = new SqlConnection(dbconn.MyConnection());
        }

        private void BtnClose_Click(object sender, EventArgs e)
            => Dispose();

        public void LoadChartSold(string sql)
        {
            SqlDataAdapter da;

            conn.Open();
            da = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "SOLD");
            chart1.DataSource = ds.Tables["SOLD"];
            Series series = chart1.Series[0];
            series.ChartType = SeriesChartType.Doughnut;

            series.Name = "SOLD ITEMS";
            chart1.Series[0].XValueMember = "pdesc";
            //chart1.Series[0]["PieLabelStyle"] = "Outside";
            chart1.Series[0].YValueMembers = "total";
            chart1.Series[0].LabelFormat = "(#,##0.00)";
            chart1.Series[0].IsValueShownAsLabel = true;
            conn.Close();
        }
    }
}
