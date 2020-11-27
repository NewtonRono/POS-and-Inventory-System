using System.Windows.Forms;
using System.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms.DataVisualization.Charting;

namespace POS_and_Inventory_System
{
    public partial class frmRecords : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        DBConnection dbconn = new DBConnection();
        public frmRecords()
        {
            InitializeComponent();
            conn = new SqlConnection(dbconn.MyConnection());
            LoadCriticalItems();
            LoadInventory();
            CancelledOrders();
            LoadStockInHistory();
        }

        public void LoadRecords()
        {
            int i = 0;
            string sql;
            conn.Open();
            dgvTopSell.Rows.Clear();
            if (cboTopSelect.Text == "SORT BY QTY")
            {
                sql = "SELECT TOP 10 pcode, pdesc, isnull(sum(qty), 0) as qty, isnull(sum(total), 0) as total FROM " +
                    "vwSoldItems WHERE sdate between '" + dtFrom.Value.ToShortDateString() + "' and '" + dtFrom.Value.ToShortDateString() + 
                    "' AND status LIKE 'Sold' GROUP BY pcode, pdesc ORDER BY qty DESC";
            }
            else
            {
                sql = "SELECT TOP 10 pcode, pdesc, isnull(sum(qty), 0) as qty, isnull(sum(total), 0) as total FROM " +
                    "vwSoldItems WHERE sdate between '" + dtFrom.Value.ToShortDateString() + "' and '" + dtFrom.Value.ToShortDateString() +
                    "' AND status LIKE 'Sold' GROUP BY pcode, pdesc ORDER BY total DESC";
            }
            cmd = new SqlCommand(sql, conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvTopSell.Rows.Add(i, dr["pcode"].ToString(), dr["pdesc"].ToString(), dr["qty"].ToString(), 
                    double.Parse(dr["total"].ToString()).ToString("#,##0.0"));
            }
            dr.Close();
            conn.Close();
        }

        public void CancelledOrders()
        {
            int i = 0;
            dgvCancelledRecords.Rows.Clear();
            conn.Open();
            string sql = "SELECT * FROM vwCancelledOrder WHERE sdate BETWEEN '" + dtFrom5.Value.ToString() + "' AND '" + dtTo.Value.ToString() + "'";
            cmd = new SqlCommand(sql, conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvCancelledRecords.Rows.Add(i, dr["transno"].ToString(), dr["pcode"].ToString(), dr["pdesc"].ToString(),
                    dr["price"].ToString(), dr["qty"].ToString(), dr["total"].ToString(), dr["sdate"].ToString(), 
                    dr["voidBy"].ToString(), dr["cancelledby"].ToString(), dr["reason"].ToString(), dr["action"].ToString());
            }
            dr.Close();
            conn.Close();
        }

        public void LoadInventory()
        {
            int i = 0;
            dgvInventory.Rows.Clear();
            conn.Open();
            string sql = "SELECT p.pcode, p.barcode, p.pdesc, b.brand, c.category, p.price, p.qty, p.reorder FROM " +
                "tblProduct AS p INNER JOIN tblBrand AS b on p.bid = b.id INNER JOIN tblCategory AS c on p.cid = c.id";
            cmd = new SqlCommand(sql, conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvInventory.Rows.Add(i, dr["pcode"].ToString(), dr["barcode"].ToString(), dr["pdesc"].ToString(), dr["brand"].ToString(),
                    dr["category"].ToString(), dr["price"].ToString(), dr["reorder"].ToString(), dr["qty"].ToString());
            }
            dr.Close();
            conn.Close();
        }
        public void LoadCriticalItems()
        {
            try
            {
                dgvCriticalStocks.Rows.Clear();
                int i = 0;
                conn.Open();
                cmd = new SqlCommand("SELECT * FROM vwCriticalItems", conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    i++;
                    dgvCriticalStocks.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(),
                        dr[4].ToString(), dr[5].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString());
                }
                dr.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void ImgClose_Click(object sender, EventArgs e)
            => Dispose();

        private void LoadStockInHistory()
        {
            int i = 0;
            dgvStocks2.Rows.Clear();
            conn.Open();
            string sql = "SELECT * FROM vwStockIn WHERE cast(sdate AS date) BETWEEN '" + dtFrom6.Value.ToShortDateString()
                + "' AND '" + dtTo6.Value.ToShortDateString() + "' AND status LIKE 'Done'";
            cmd = new SqlCommand(sql, conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvStocks2.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(),
                    dr[4].ToString(), DateTime.Parse(dr[5].ToString()).ToShortDateString(), dr[6].ToString());
            }
            dr.Close();
            conn.Close();
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            frmInventoryReport f = new frmInventoryReport();
            string sql = "", header = "";
            if (cboTopSelect.Text == "SORT BY QTY")
            {
                sql = "SELECT TOP 10 pcode, pdesc, isnull(sum(qty), 0) AS qty, isnull(sum(total), 0) AS total FROM " +
                    "vwSoldItems WHERE sdate between '" + dtFrom.Value.ToString() + "' AND '" + dtFrom.Value.ToString() +
                    "' AND status LIKE 'Sold' GROUP BY pcode, pdesc ORDER BY qty DESC";
                header = "TOP SELLING ITEMS SORT BY QTY";
            }
            else if (cboTopSelect.Text == "SORT BY TOTAL AMOUNT")
            {
                sql = "SELECT TOP 10 pcode, pdesc, isnull(sum(qty), 0) AS qty, isnull(sum(total), 0) AS total FROM " +
                    "vwSoldItems WHERE sdate between '" + dtFrom.Value.ToString() + "' AND '" + dtFrom.Value.ToString() +
                    "' AND status LIKE 'Sold' GROUP BY pcode, pdesc ORDER BY total DESC";
                header = "TOP SELLING ITEMS SORT BY TOTAL AMOUNT";
            }
            f.LoadTopSelling(sql, "From : " + dtFrom.Value.ToString() + " To : " + dtTo.Value.ToString(), header);
            f.ShowDialog();
        }

        private void LinkPrint2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmInventoryReport f = new frmInventoryReport();
            string sql = "SELECT c.pcode, p.pdesc, c.price, sum(c.qty) AS tot_qty, sum(c.disc) AS tot_disc, sum(c.total) AS total " +
                "FROM tblCart AS c INNER JOIN tblProduct AS p on c.pcode=p.pcode WHERE status LIKE 'Sold' AND sdate BETWEEN '" +
                dtFrom2.Value.ToString() + "' AND '" + dtTo2.Value.ToString() + "' GROUP BY c.pcode, p.pdesc, c.price";
            f.LoadSoldItems(sql, "From : " + dtFrom2.Value.ToString() + " To : " + dtTo2.Value.ToString());
            f.ShowDialog();
        }

        private void BtnLoadData_Click(object sender, EventArgs e)
        {
            if (cboTopSelect.Text == string.Empty)
            {
                MessageBox.Show("Please Select from the dropdown list", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            LoadRecords();
            LoadChartTopSelling();
        }

        public void LoadChartTopSelling()
        {
            SqlDataAdapter da = new SqlDataAdapter();
            conn.Open();
            if (cboTopSelect.Text == "SORT BY QTY")
            {
                da = new SqlDataAdapter("SELECT TOP 10 pcode, isnull(sum(qty), 0) AS qty FROM vwSoldItems WHERE sdate BETWEEN '" +
                    dtFrom.Value.ToString() + "' AND '" + dtFrom.Value.ToShortDateString() + "' AND status LIKE 'Sold' GROUP BY " +
                    "pcode ORDER BY qty DESC", conn);
            }
            else if (cboTopSelect.Text == "SORT BY TOTAL AMOUNT")
            {
                da = new SqlDataAdapter("SELECT TOP 10 pcode, isnull(sum(qty), 0) AS total FROM vwSoldItems WHERE sdate BETWEEN '" +
                    dtFrom.Value.ToString() + "' AND '" + dtFrom.Value.ToShortDateString() + "' AND status LIKE 'Sold' GROUP BY " +
                    "pcode ORDER BY total DESC", conn);
            }
            DataSet ds = new DataSet();
            da.Fill(ds, "TOPSELLING");
            chart1.DataSource = ds.Tables["TOPSELLING"];
            Series series = chart1.Series[0];
            series.ChartType = SeriesChartType.Doughnut;

            series.Name = "TOP SELLING";
            var chart = chart1;
            chart.Series[0].XValueMember = "pcode";
            if (cboTopSelect.Text == "SORT BY QTY")
            {
                chart.Series[0].YValueMembers = "qty";
                chart.Series[0].LabelFormat = "(#,##0)";
            }
            else if (cboTopSelect.Text == "SORT BY TOTAL AMOUNT")
            {
                chart.Series[0].YValueMembers = "total";
                chart.Series[0].LabelFormat = "(#,##0.00)";
            }
            chart.Series[0].IsValueShownAsLabel = true;
            conn.Close();
        }

        private void CboTopSelect_KeyPress(object sender, KeyPressEventArgs e) 
            => e.Handled = true;

        private void BtnPrint2_Click(object sender, EventArgs e)
        {
            try
            {
                dgvSoldItems.Rows.Clear();
                int i = 0;
                conn.Open();
                string sql = "SELECT c.pcode, p.pdesc, c.price, sum(c.qty) as tot_qty, sum(c.disc) as tot_disc, sum(c.total) as total " +
                    "FROM tblCart AS c INNER JOIN tblProduct as p on c.pcode=p.pcode WHERE status LIKE 'Sold' AND sdate BETWEEN '" +
                    dtFrom2.Value.ToString() + "' AND '" + dtTo2.Value.ToString() + "' GROUP BY c.pcode, p.pdesc, c.price";
                cmd = new SqlCommand(sql, conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    i++;
                    dgvSoldItems.Rows.Add(i, dr["pcode"].ToString(), dr["pdesc"].ToString(), double.Parse(dr["price"].ToString()).ToString("#,##0.00"),
                        dr["tot_qty"].ToString(), dr["tot_disc"].ToString(), double.Parse(dr["total"].ToString()).ToString("#,##0.00"));
                }
                dr.Close();
                conn.Close();

                conn.Open();
                string sql1 = "SELECT isnull(sum(total),0) FROM tblCart WHERE status LIKE 'Sold' AND sdate BETWEEN '" + dtFrom2.Value.ToString() + "' AND '" + dtTo2.Value.ToString() + "'";
                cmd = new SqlCommand(sql1, conn);
                lblTotal.Text = double.Parse(cmd.ExecuteScalar().ToString()).ToString("#,##0.00");
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnLoad2_Click(object sender, EventArgs e)
        {
            try
            {
                dgvSoldItems.Rows.Clear();
                int i = 0;
                conn.Open();
                string sql = "SELECT c.pcode, p.pdesc, c.price, sum(c.qty) AS tot_qty, sum(c.disc) AS tot_disc, sum(c.total) AS total " +
                    "FROM tblCart AS c INNER JOIN tblProduct as p on c.pcode=p.pcode WHERE status LIKE 'Sold' AND sdate BETWEEN '" +
                    dtFrom2.Value.ToString() + "' AND '" + dtTo2.Value.ToString() + "' GROUP BY c.pcode, p.pdesc, c.price";
                cmd = new SqlCommand(sql, conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    i++;
                    dgvSoldItems.Rows.Add(i, dr["pcode"].ToString(), dr["pdesc"].ToString(), double.Parse(dr["price"].ToString()),
                        dr[3].ToString(), dr[4].ToString(), double.Parse(dr[5].ToString()).ToString("#,##0.00"));
                }
                dr.Close();
                conn.Close();

                string x;
                conn.Open();
                cmd = new SqlCommand("SELECT isnull(sum(total), 0) FROM tblCart WHERE status LIKE 'Sold' AND sdate BETWEEN '" +
                    dtFrom2.Value.ToString() + "' AND '" + dtTo2.Value.ToString());
                lblTotal.Text = double.Parse(cmd.ExecuteScalar().ToString()).ToString("#,##0.00");
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
            => Util.CloseForm(this);

        private void BtnPrint4_Click(object sender, EventArgs e)
        {
            frmInventoryReport frm = new frmInventoryReport();
            frm.LoadReport();
            frm.ShowDialog();
        }

        private void BtnLoadChart_Click(object sender, EventArgs e)
        {
            frmChart frm = new frmChart();
            frm.lblTitle.Text = "SOLD ITEMS [" + dtFrom2.Value.ToShortDateString() + " - " + dtTo2.Value.ToShortDateString();
            frm.LoadChartSold("SELECT p.pdesc, sum(c.total) AS total FROM tblCart AS c INNER JOIN tblProduct AS p ON c.pcode=p.pcode " +
                "WHERE status LIKE 'Sold' AND sdate BETWEEN '" + dtFrom2.Value.ToString() + "' AND '" + dtTo2.Value.ToString() + 
                "' GROUP BY p.pdesc ORDER BY total desc");
            frm.ShowDialog();
        }

        private void BtnPrint6_Click(object sender, EventArgs e)
        {
            frmInventoryReport frm = new frmInventoryReport();
            string sql = "SELECT * FROM vwStockIn WHERE cast(sdate AS date) BETWEEN '" + dtFrom6.Value.ToShortDateString()
                + "' AND '" + dtTo6.Value.ToShortDateString() + "' AND status LIKE 'Done'";
            string param = "Date Covered: " + dtFrom6.Value.ToShortDateString() + " - " + dtTo6.Value.ToShortDateString();
            frm.LoadStockInReport(sql, param);
            frm.ShowDialog();
        }

        private void BtnLoad6_Click(object sender, EventArgs e)
            => LoadStockInHistory();

        private void BtnLoad5_Click(object sender, EventArgs e)
            => CancelledOrders();

        private void BtnPrint5_Click(object sender, EventArgs e)
        {
            frmInventoryReport frm = new frmInventoryReport();
            string param = "Data Covered: " + dtFrom5.Value.ToString() + " - " + dtTo5.Value.ToString();
            string sql = "SELECT * FROM vwCancelledOrder WHERE sdate BETWEEN '" + dtFrom5.Value.ToString() + "' AND '" + dtTo5.Value.ToString() + "'";
            frm.LoadCancelledOrder(sql, param);
            frm.ShowDialog();
        }
    }
}
