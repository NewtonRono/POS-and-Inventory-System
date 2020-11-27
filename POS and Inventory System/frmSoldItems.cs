using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace POS_and_Inventory_System
{
    public partial class frmSoldItems : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        DBConnection dbconn = new DBConnection();
        public string sUser;
        public frmSoldItems()
        {
            InitializeComponent();
            conn = new SqlConnection(dbconn.MyConnection());
            dtFrom.Value = DateTime.Now;
            dtTo.Value = DateTime.Now;
            LoadRecord();
            LoadCashier();
        }

        public void LoadRecord()
        {
            int i = 0;
            double _total = 0;
            string sql;
            dgvSoldItems.Rows.Clear();
            conn.Open();
            if (cboCashier.Text == "All Cashier")
                sql = "SELECT c.id, c.transno, c.pcode, p.pdesc, c.price, c.qty, c.disc, c.total FROM tblCart AS c INNER JOIN tblProduct " +
                    "AS p ON c.pcode=p.pcode WHERE status LIKE 'Sold' AND sdate BETWEEN '" + dtFrom.Value + "' AND '" + dtTo.Value + "'";
            else
                sql = "SELECT c.id, c.transno, c.pcode, p.pdesc, c.price, c.qty, c.disc, c.total FROM tblCart AS c INNER JOIN tblProduct " +
                    "AS p ON c.pcode=p.pcode WHERE status LIKE 'Sold' AND sdate BETWEEN '" + dtFrom.Value + "' AND '" + dtTo.Value + "' AND cashier LIKE '" + cboCashier.Text + "'";
            cmd = new SqlCommand(sql, conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i += 1;
                _total += double.Parse(dr["total"].ToString());
                dgvSoldItems.Rows.Add(i, dr["id"].ToString(), dr["transno"].ToString(), dr["pcode"].ToString(), dr["pdesc"].ToString(),
                    dr["price"].ToString(), dr["qty"].ToString(), dr["disc"].ToString(), dr["total"].ToString());
            }
            dr.Close();
            conn.Close();
            lblTotal.Text = _total.ToString("#,##0.00");
        }

        private void DtFrom_ValueChanged(object sender, EventArgs e)
            => LoadRecord();

        private void DtTo_ValueChanged(object sender, EventArgs e)
            => LoadRecord();

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            frmReportSold frm = new frmReportSold(this);
            frm.LoadReport();
            frm.ShowDialog();
        }

        private void CboCashier_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        public void LoadCashier()
        {
            cboCashier.Items.Clear();
            cboCashier.Items.Add("All Cashier");
            conn.Open();
            string sql = "SELECT * FROM tblUser where role LIKE 'Cashier'";
            cmd = new SqlCommand(sql, conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cboCashier.Items.Add(dr["username"].ToString());
            }
            dr.Close();
            conn.Close();          
        }

        private void CboCashier_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRecord();
        }

        private void DgvSoldItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvSoldItems.Columns[e.ColumnIndex].Name;
            if (colName == "Cancel")
            {
                frmCancelDetails frm = new frmCancelDetails(this);
                frm.txtId.Text = dgvSoldItems.Rows[e.RowIndex].Cells[1].Value.ToString();
                frm.txtTransNo.Text = dgvSoldItems.Rows[e.RowIndex].Cells[2].Value.ToString();
                frm.txtPCode.Text = dgvSoldItems.Rows[e.RowIndex].Cells[3].Value.ToString();
                frm.txtDescription.Text = dgvSoldItems.Rows[e.RowIndex].Cells[4].Value.ToString();
                frm.txtPrice.Text = dgvSoldItems.Rows[e.RowIndex].Cells[5].Value.ToString();
                frm.txtQty.Text = dgvSoldItems.Rows[e.RowIndex].Cells[6].Value.ToString();
                frm.txtDiscount.Text = dgvSoldItems.Rows[e.RowIndex].Cells[7].Value.ToString();
                frm.txtTotal.Text = dgvSoldItems.Rows[e.RowIndex].Cells[8].Value.ToString();
                frm.txtCancel.Text = sUser;

                frm.ShowDialog();
            }
        }

        private void BtnClose_Click(object sender, EventArgs e) 
            => Dispose();
    }
}
