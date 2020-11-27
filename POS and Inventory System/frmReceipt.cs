using System;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Data.SqlClient;

namespace POS_and_Inventory_System
{
    public partial class frmReceipt : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBConnection dbconn = new DBConnection();
        string store = "Walter Ville";
        string address = "nowhere lmao fuck off";
        frmPOS frm;
        public frmReceipt(frmPOS _frm)
        {
            InitializeComponent();
            conn = new SqlConnection(dbconn.MyConnection());
            frm = _frm;
            KeyPreview = true;
        }

        private void FrmReceipt_Load(object sender, EventArgs e)
        {
            reportViewer1.RefreshReport();
        }

        public void LoadReport(string pcash, string pchange)
        {
            ReportDataSource rptDataSource;
            try
            {
                reportViewer1.LocalReport.ReportPath = Application.StartupPath + @"\Reports\Report1.rdlc";
                reportViewer1.LocalReport.DataSources.Clear();

                DataSet1 ds = new DataSet1();
                SqlDataAdapter da = new SqlDataAdapter();

                conn.Open();
                string sql = "SELECT c.id, c.transno, c.pcode, c.price, c.qty, c.disc, c.total, c.sdate, c.status, p.pdesc FROM tblCart AS c " +
                    "INNER JOIN tblProduct as p on p.pcode = c.pcode WHERE transno like '" + frm.lblTransNo.Text + "'";
                da.SelectCommand = new SqlCommand(sql, conn);
                da.Fill(ds.Tables["dtSold"]);
                conn.Close();

                ReportParameter pVatable = new ReportParameter("pVatable", frm.lblVatable.Text);
                ReportParameter pVat = new ReportParameter("pVat", frm.lblVat.Text);
                ReportParameter pDiscount = new ReportParameter("pDiscount", frm.lblDiscount.Text);
                ReportParameter pTotal = new ReportParameter("pTotal", frm.lblSalesTotal.Text);
                ReportParameter pCash = new ReportParameter("pCash", pcash);
                ReportParameter pChange = new ReportParameter("pChange", pchange);
                ReportParameter pStore = new ReportParameter("pStore", store);
                ReportParameter pAddress = new ReportParameter("pAddress", address);
                ReportParameter pTransaction = new ReportParameter("pTransaction", "Invoice #: " + frm.lblTransNo.Text);
                ReportParameter pCashier = new ReportParameter("pCashier", frm.lblUser.Text);

                reportViewer1.LocalReport.SetParameters(pVatable);
                reportViewer1.LocalReport.SetParameters(pVat);
                reportViewer1.LocalReport.SetParameters(pDiscount);
                reportViewer1.LocalReport.SetParameters(pTotal);
                reportViewer1.LocalReport.SetParameters(pCash);
                reportViewer1.LocalReport.SetParameters(pChange);
                reportViewer1.LocalReport.SetParameters(pStore);
                reportViewer1.LocalReport.SetParameters(pAddress);
                reportViewer1.LocalReport.SetParameters(pTransaction);
                reportViewer1.LocalReport.SetParameters(pCashier);


                rptDataSource = new ReportDataSource("DataSet1", ds.Tables["dtSold"]);
                reportViewer1.LocalReport.DataSources.Add(rptDataSource);
                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 30;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmReceipt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Dispose();
        }

        private void BtnClose_Click(object sender, EventArgs e)
            => Dispose();
    }
}
