using System;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Data.SqlClient;

namespace POS_and_Inventory_System
{
    public partial class frmInventoryReport : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBConnection dbconn = new DBConnection();
        public frmInventoryReport()
        {
            InitializeComponent();
            conn = new SqlConnection(dbconn.MyConnection());
        }

        private void FrmInventoryReport_Load(object sender, EventArgs e)
        {
            reportViewer1.RefreshReport();
        }

        public void LoadSoldItems(string sql, string param)
        {
            try
            {
                ReportDataSource rptDS;
                reportViewer1.LocalReport.ReportPath = Application.StartupPath + @"\Reports\rptSold.rdlc";
                reportViewer1.LocalReport.DataSources.Clear();

                DataSet1 ds = new DataSet1();
                SqlDataAdapter da = new SqlDataAdapter();

                conn.Open();
                da.SelectCommand = new SqlCommand(sql, conn);
                da.Fill(ds.Tables["dtSoldItems"]);
                conn.Close();

                ReportParameter pDate = new ReportParameter("pDate", param);
                reportViewer1.LocalReport.SetParameters(pDate);

                rptDS = new ReportDataSource("DataSet1", ds.Tables["dtSoldItems"]);
                reportViewer1.LocalReport.DataSources.Add(rptDS);
                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;

            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void LoadTopSelling(string sql, string param, string header)
        {
            try
            {
                ReportDataSource rptDS;
                reportViewer1.LocalReport.ReportPath = Application.StartupPath + @"\Reports\rptTop.rdlc";
                reportViewer1.LocalReport.DataSources.Clear();

                DataSet1 ds = new DataSet1();
                SqlDataAdapter da = new SqlDataAdapter();

                conn.Open();
                da.SelectCommand = new SqlCommand(sql, conn);
                da.Fill(ds.Tables["dtTopSelling"]);
                conn.Close();

                ReportParameter pDate = new ReportParameter("pDate", param);
                ReportParameter pHeader = new ReportParameter("pHeader", header);
                reportViewer1.LocalReport.SetParameters(pDate);
                reportViewer1.LocalReport.SetParameters(pHeader);

                rptDS = new ReportDataSource("DataSet1", ds.Tables["dtTopSelling"]);
                reportViewer1.LocalReport.DataSources.Add(rptDS);
                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;

            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void LoadReport()
        {
            ReportDataSource rptDS;
            try
            {
                reportViewer1.LocalReport.ReportPath = Application.StartupPath + @"\Reports\Report3.rdlc";
                reportViewer1.LocalReport.DataSources.Clear();

                DataSet1 ds = new DataSet1();
                SqlDataAdapter da = new SqlDataAdapter();

                conn.Open();
                string sql = "SELECT p.pcode, p.barcode, p.pdesc, b.brand, c.category, p.price, p.qty, p.reorder FROM " +
                    "tblProduct AS p INNER JOIN tblBrand AS b on p.bid = b.id INNER JOIN tblCategory AS c on p.cid = c.id";
                da.SelectCommand = new SqlCommand(sql, conn);
                da.Fill(ds.Tables["dtInventory"]);
                conn.Close();

                rptDS = new ReportDataSource("DataSet1", ds.Tables["dtInventory"]);
                reportViewer1.LocalReport.DataSources.Add(rptDS);
                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void LoadStockInReport(string sql, string param)
        {
            ReportDataSource rptDS;
            try
            {
                reportViewer1.LocalReport.ReportPath = Application.StartupPath + @"\Reports\rptStockIn.rdlc";
                reportViewer1.LocalReport.DataSources.Clear();

                DataSet1 ds = new DataSet1();
                SqlDataAdapter da = new SqlDataAdapter();

                ReportParameter pDate = new ReportParameter("pDate", param);
                reportViewer1.LocalReport.SetParameters(pDate);

                conn.Open();
                da.SelectCommand = new SqlCommand(sql, conn);
                da.Fill(ds.Tables["dtStockIn"]);
                conn.Close();

                rptDS = new ReportDataSource("DataSet1", ds.Tables["dtStockIn"]);
                reportViewer1.LocalReport.DataSources.Add(rptDS);
                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void LoadCancelledOrder(string sql, string param)
        {
            ReportDataSource rptDS;
            try
            {
                reportViewer1.LocalReport.ReportPath = Application.StartupPath + @"\Reports\rptCancelled.rdlc";
                reportViewer1.LocalReport.DataSources.Clear();

                DataSet1 ds = new DataSet1();
                SqlDataAdapter da = new SqlDataAdapter();

                ReportParameter pDate = new ReportParameter("pDate", param);
                reportViewer1.LocalReport.SetParameters(pDate);

                conn.Open();
                da.SelectCommand = new SqlCommand(sql, conn);
                da.Fill(ds.Tables["dtCancelled"]);
                conn.Close();

                rptDS = new ReportDataSource("DataSet1", ds.Tables["dtCancelled"]);
                reportViewer1.LocalReport.DataSources.Add(rptDS);
                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e) 
            => Dispose();
    }
}
