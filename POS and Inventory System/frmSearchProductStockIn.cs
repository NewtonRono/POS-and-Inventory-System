using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace POS_and_Inventory_System
{
    public partial class frmSearchProductStockIn : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBConnection dbconn = new DBConnection();
        SqlDataReader dr;
        frmStockIn fList;
        public frmSearchProductStockIn(frmStockIn _fList)
        {
            InitializeComponent();
            conn = new SqlConnection(dbconn.MyConnection());
            fList = _fList;
        }

        public void LoadProduct()
        {
            try
            {
                int i = 0;
                dgvProductList.Rows.Clear();
                conn.Open();
                string sql = "SELECT pcode, pdesc, qty FROM tblProduct WHERE pdesc LIKE '%" + txtSearch.Text + "%' ORDER BY pdesc";
                cmd = new SqlCommand(sql, conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    i++;
                    dgvProductList.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString());
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
            }
        }

        private void DgvProductList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvProductList.Columns[e.ColumnIndex].Name;
            if (colName == "Select")
            {
                if (fList.txtRefNo.Text == string.Empty)
                {
                    MessageBox.Show("Please Enter Reference No", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    fList.txtRefNo.Focus();
                    return;
                }
                if (fList.txtStockInBy.Text == string.Empty)
                {
                    MessageBox.Show("Please Enter Stock-In by", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    fList.txtStockInBy.Focus();
                    return;
                }
                if (MessageBox.Show("Add this item?", "Add Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    conn.Open();
                    string sql = "INSERT INTO tblStockIn (refno, pcode, sdate, qty, stockInBy, status, vendorId) VALUES " +
                        "(@refno, @pcode, @sdate, @qty, @stockInBy, @status, @vendorId)";
                    cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@refno", fList.txtRefNo.Text);
                    cmd.Parameters.AddWithValue("@pcode", dgvProductList.Rows[e.RowIndex].Cells[1].Value.ToString());
                    cmd.Parameters.AddWithValue("@sdate", fList.dtStockInDate.Value);
                    cmd.Parameters.AddWithValue("@qty", 0);
                    cmd.Parameters.AddWithValue("@stockInBy", fList.txtStockInBy.Text);
                    cmd.Parameters.AddWithValue("@status", "Pending");
                    cmd.Parameters.AddWithValue("@vendorId", fList.lblVendorId.Text);
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Successfully added!", "Add Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fList.LoadStockIn();                 
                }
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e) 
            => LoadProduct();

        private void BtnClose_Click(object sender, EventArgs e)
            => Dispose();
    }
}
