using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace POS_and_Inventory_System
{
    public partial class frmAdjustment : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;
        DBConnection dbconn = new DBConnection();

        frmDashboard frm;
        int qty = 0;
        public frmAdjustment(frmDashboard _frm)
        {
            InitializeComponent();
            conn = new SqlConnection(dbconn.MyConnection());
            frm = _frm;
            LoadRecords();
            Random rnd = new Random();
            txtRefNo.Text = rnd.Next().ToString();
        }

        public void LoadRecords()
        {
            int i = 0;
            dgvProduct.Rows.Clear();
            conn.Open();
            string sql = "SELECT p.pcode, p.barcode, p.pdesc, b.brand, c.category, p.price, p.qty FROM tblProduct AS p INNER JOIN tblBrand " +
                "AS b ON b.id=p.bid INNER JOIN tblCategory AS c ON c.id=p.cid WHERE p.pdesc LIKE '%" + txtSearch.Text + "%' order by p.pdesc";
            cmd = new SqlCommand(sql, conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvProduct.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(),
                    dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
            }
            dr.Close();
            conn.Close();
        }

        private void TxtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                LoadRecords();
            }
        }

        private void DgvProductList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvProduct.Columns[e.ColumnIndex].Name;
            if (colName == "Select")
            {
                txtPCode.Text = dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtDesc.Text = dgvProduct.Rows[e.RowIndex].Cells[3].Value.ToString() + " " + dgvProduct.Rows[e.RowIndex].Cells[4].Value.ToString() +
                    " " + dgvProduct.Rows[e.RowIndex].Cells[5].Value.ToString();
                qty = int.Parse(dgvProduct.Rows[e.RowIndex].Cells[7].Value.ToString());
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(txtQty.Text) > qty)
                {
                    MessageBox.Show("Stock on Hand Quantity should be greater than from adjustment qty", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cboCommand.Text == "REMOVE FROM INVENTORY")
                {
                    SqlStatement("UPDATE tblProduct SET qty=(qty - " + int.Parse(txtQty.Text) + ") WHERE pcode LIKE '" + txtPCode.Text + "'");
                }
                else if (cboCommand.Text == "ADD TO INVENTORY")
                {
                    SqlStatement("UPDATE tblProduct SET qty=(qty +" + int.Parse(txtQty.Text) + ") WHERE pcode LIKE '" + txtPCode.Text + "'");
                }

                SqlStatement("INSERT INTO tblAdjustment(referenceno, pcode, qty, action, remarks, sdate, [user]) VALUES ('" +
                    txtRefNo.Text + "','" + txtPCode.Text + "','" + int.Parse(txtQty.Text) + "','" + cboCommand.Text + 
                    "','" + txtRemarks.Text + "','" + DateTime.Now.ToShortDateString() + "','" + txtUser.Text + "')");

                MessageBox.Show("Stock has been successfully adjusted", "Process completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadRecords();
                Clear();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message, "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void Clear()
        {
            txtDesc.Clear();
            txtPCode.Clear();
            txtQty.Clear();
            txtRefNo.Clear();
            txtRemarks.Clear();
            cboCommand.Text = "";
            Random rnd = new Random();
            txtRefNo.Text = rnd.Next().ToString();
        }

        public void SqlStatement(string _sql)
        {
            conn.Open();
            cmd = new SqlCommand(_sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void BtnClose_Click(object sender, EventArgs e) 
            => Dispose();
    }
}
