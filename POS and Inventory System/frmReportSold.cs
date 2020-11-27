using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;

namespace POS_and_Inventory_System
{
    public partial class frmReportSold : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        DBConnection dbconn = new DBConnection();
        frmSoldItems frm;
        public frmReportSold(frmSoldItems _frm)
        {
            InitializeComponent();
            conn = new SqlConnection(dbconn.MyConnection());
            frm = _frm;
        }

        public void LoadReport()
        {
            try
            {
                ReportDataSource rptDS;
                string sql = "";
                reportViewer1.LocalReport.ReportPath = Application.StartupPath + @"\Reports\Report2.rdlc";
                reportViewer1.LocalReport.DataSources.Clear();

                DataSet1 ds = new DataSet1();
                SqlDataAdapter da = new SqlDataAdapter();

                conn.Open();
                if (frm.cboCashier.Text == "All Cashier")
                    sql = "SELECT c.id, c.transno, c.pcode, p.pdesc, c.price, c.qty, c.disc as discount, c.total FROM tblCart AS " +
                    "c INNER JOIN tblProduct AS p ON c.pcode=p.pcode WHERE status LIKE 'Sold' AND sdate BETWEEN '" + 
                    frm.dtFrom.Value + "' AND '" + frm.dtTo.Value + "'";
                else
                    sql = "SELECT c.id, c.transno, c.pcode, p.pdesc, c.price, c.qty, c.disc as discount, c.total FROM tblCart AS " +
                    "c INNER JOIN tblProduct AS p ON c.pcode=p.pcode WHERE status LIKE 'Sold' AND sdate BETWEEN '" +
                    frm.dtFrom.Value + "' AND '" + frm.dtTo.Value + "' AND cashier LIKE '" + frm.cboCashier.Text + "'";

                da.SelectCommand = new SqlCommand(sql, conn);
                da.Fill(ds.Tables["dtSoldReport"]);
                conn.Close();
                ReportParameter pDate = new ReportParameter("pDate", "Date From: " + 
                    frm.dtFrom.Value.ToShortDateString() + " To: " + frm.dtTo.Value.ToShortDateString());
                ReportParameter pCashier = new ReportParameter("pCashier", "Cashier: " + frm.cboCashier.Text);
                ReportParameter pHeader = new ReportParameter("pHeader", "SALES REPORT");

                reportViewer1.LocalReport.SetParameters(pDate);
                reportViewer1.LocalReport.SetParameters(pCashier);
                reportViewer1.LocalReport.SetParameters(pHeader);
                rptDS = new ReportDataSource("DataSet1", ds.Tables["dtSoldReport"]);
                reportViewer1.LocalReport.DataSources.Add(rptDS);
                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
            => Dispose();
    }
}
