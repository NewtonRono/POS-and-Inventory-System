using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace POS_and_Inventory_System
{
    public partial class frmStockIn : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBConnection dbconn = new DBConnection();
        SqlDataReader dr;
        public frmStockIn()
        {
            InitializeComponent();
            conn = new SqlConnection(dbconn.MyConnection());
            LoadVendor();
        }

        public void LoadStockIn()
        {
            int i = 0;
            dgvStocks.Rows.Clear();
            conn.Open();
            string sql = "SELECT * FROM vwStockIn WHERE refno LIKE '" + txtRefNo.Text + "' AND status LIKE 'Pending'";
            cmd = new SqlCommand(sql, conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvStocks.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), 
                    dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr["vendor"].ToString());
            }
            dr.Close();
            conn.Close();
        }

        public void Clear()
        {
            txtStockInBy.Clear();
            txtRefNo.Clear();
            dtStockInDate.Value = DateTime.Now;
        }
        private void LoadStockInHistory()
        {
            try
            {
                int i = 0;
                dgvStocks2.Rows.Clear();
                conn.Open();
                string sql = "SELECT * FROM vwStockIn WHERE cast(sdate AS date) BETWEEN '" + dtFrom.Value.ToShortDateString() 
                    + "' AND '" + dtTo.Value.ToShortDateString() + "' AND status LIKE 'Done'";
                cmd = new SqlCommand(sql, conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    i++;
                    dgvStocks2.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(),  dr[4].ToString(), 
                        DateTime.Parse(dr[5].ToString()).ToShortDateString(), dr[6].ToString(), dr["vendor"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dr.Close();
                conn.Close();
                btnSave.Show();
            }
        }

        private void BtnLoadRecord_Click(object sender, EventArgs e)
        {
            LoadStockInHistory();
        }

        private void TxtRefNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar)) return;
            if (Char.IsControl(e.KeyChar)) return;
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.Contains('.'.ToString()) == false)) return;
            if ((e.KeyChar == '.') && ((sender as TextBox).SelectionLength == (sender as TextBox).TextLength)) return;
            e.Handled = true;
        }

        public void LoadVendor()
        {
            cboVendor.Items.Clear();
            conn.Open();
            string sql = "SELECT * FROM tblVendor";
            cmd = new SqlCommand(sql, conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cboVendor.Items.Add(dr["vendor"].ToString());
            }
            dr.Close();
            conn.Close();
        }

        private void CboVendor_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void CboVendor_TextChanged(object sender, EventArgs e)
        {
            conn.Open();
            string sql = "SELECT * FROM tblVendor WHERE vendor LIKE '" + cboVendor.Text + "'";
            cmd = new SqlCommand(sql, conn);
            dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                lblVendorId.Text = dr["id"].ToString();
                txtContactPerson.Text = dr["contactperson"].ToString();
                txtAddress.Text = dr["address"].ToString();
            }
            dr.Close();
            conn.Close();
        }

        private void LinkGenerate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Random rnd = new Random();
            txtRefNo.Clear();
            txtRefNo.Text += rnd.Next();
        }

        private void LinkLblBrowseProduct_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmSearchProductStockIn frm = new frmSearchProductStockIn(this);
            frm.LoadProduct();
            frm.ShowDialog();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvStocks.Rows.Count > 0)
                {
                    if (MessageBox.Show("Are you sure you want to save this records?", "",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        for (int i = 0; i < dgvStocks.Rows.Count; i++)
                        {
                            // UPDATE PRODUCT TABLE QUANTITY
                            conn.Open();
                            string sql = "UPDATE tblProduct SET qty=qty + " + int.Parse(dgvStocks.Rows[i].Cells[5].Value.ToString()) +
                                " WHERE pcode LIKE '" + dgvStocks.Rows[i].Cells[3].Value.ToString() + "'";
                            cmd = new SqlCommand(sql, conn);
                            cmd.ExecuteNonQuery();
                            conn.Close();

                            // UPDATE STOCK TABLE QUANTITY
                            conn.Open();
                            string sql1 = "UPDATE tblStockIn SET qty=qty + " + int.Parse(dgvStocks.Rows[i].Cells[5].Value.ToString()) +
                                ", status='Done' WHERE id LIKE '" + dgvStocks.Rows[i].Cells[1].Value.ToString() + "'";
                            cmd = new SqlCommand(sql1, conn);
                            cmd.ExecuteNonQuery();
                            conn.Close();
                        }
                        Clear();
                        LoadStockIn();
                    }
                }
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }        
        }

        private void DgvStocks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvStocks.Columns[e.ColumnIndex].Name;
            if (colName == "Delete")
            {
                if (MessageBox.Show("Remove this item", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    conn.Open();
                    cmd = new SqlCommand("DELETE FROM tblStockIn WHERE id = '" + dgvStocks.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Item has been successfully removed.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadStockIn();
                }
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Util.CloseForm(this);
        }
    }
}
