using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace POS_and_Inventory_System
{
    public partial class frmProduct : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBConnection dbconn = new DBConnection();
        SqlDataReader dr;
        frmProductList fList;
        public frmProduct(frmProductList frm)
        {
            InitializeComponent();
            conn = new SqlConnection(dbconn.MyConnection());
            fList = frm;
        }

        public void LoadCategory()
        {
            try
            {
                cboCategory.Items.Clear();
                conn.Open();
                string sql = "SELECT category FROM tblCategory";
                cmd = new SqlCommand(sql, conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cboCategory.Items.Add(dr[0].ToString());
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

        public void LoadBrand()
        {
            try
            {
                cboBrand.Items.Clear();
                conn.Open();
                string sql = "SELECT brand FROM tblBrand";
                cmd = new SqlCommand(sql, conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cboBrand.Items.Add(dr[0].ToString());
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

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to save this product?", "Save Product",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string bid = "", cid = "";
                    conn.Open();
                    string sql = "SELECT id FROM tblBrand WHERE brand LIKE '" + cboBrand.Text + "'";
                    cmd = new SqlCommand(sql, conn);
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows) bid = dr[0].ToString();
                    dr.Close();
                    conn.Close();

                    conn.Open();
                    string sql1 = "SELECT id FROM tblCategory WHERE category LIKE '" + cboCategory.Text + "'";
                    cmd = new SqlCommand(sql1, conn);
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows) cid = dr[0].ToString();
                    dr.Close();
                    conn.Close();

                    conn.Open();
                    string sql2 = "INSERT INTO tblProduct (pcode, barcode, pdesc, bid, cid, price, reorder) " +
                        "VALUES (@pcode, @barcode, @pdesc, @bid, @cid, @price, @reorder)";
                    cmd = new SqlCommand(sql2, conn);
                    cmd.Parameters.AddWithValue("@pcode", txtPCode.Text);
                    cmd.Parameters.AddWithValue("@barcode", txtBarcode.Text);
                    cmd.Parameters.AddWithValue("@pdesc", txtDescription.Text);
                    cmd.Parameters.AddWithValue("@bid", bid);
                    cmd.Parameters.AddWithValue("@cid", cid);
                    cmd.Parameters.AddWithValue("@price", double.Parse(txtPrice.Text));
                    cmd.Parameters.AddWithValue("@reorder", int.Parse(txtReOrder.Text));
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Product has been success saved.", "Product Saving", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                    fList.LoadRecords();
                }
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
        }

        public void Clear()
        {
            txtPrice.Clear();
            txtDescription.Clear();
            txtPCode.Clear();
            txtBarcode.Clear();
            cboBrand.Text = "";
            cboCategory.Text = "";
            txtPCode.Clear();
            txtReOrder.Text = "";
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to update this product?", "Save Product", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string bid = "";
                    string cid = "";
                    conn.Open();
                    string sql = "SELECT id FROM tblBrand WHERE brand LIKE '" + cboBrand.Text + "'";
                    cmd = new SqlCommand(sql, conn);
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows) bid = dr[0].ToString();
                    dr.Close();
                    conn.Close();

                    conn.Open();
                    string sql1 = "SELECT id FROM tblCategory WHERE category LIKE '" + cboCategory.Text + "'";
                    cmd = new SqlCommand(sql1, conn);
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows) cid = dr[0].ToString();
                    dr.Close();
                    conn.Close();

                    conn.Open();
                    string sql2 = "UPDATE tblProduct SET barcode=@barcode, pdesc=@pdesc, bid=@bid, cid=@cid, " +
                        "price=@price, reorder=@reorder WHERE pcode LIKE @pcode";
                    cmd = new SqlCommand(sql2, conn);
                    cmd.Parameters.AddWithValue("@pcode", txtPCode.Text);
                    cmd.Parameters.AddWithValue("@barcode", txtBarcode.Text);
                    cmd.Parameters.AddWithValue("@pdesc", txtDescription.Text);
                    cmd.Parameters.AddWithValue("@bid", bid);
                    cmd.Parameters.AddWithValue("@cid", cid);
                    cmd.Parameters.AddWithValue("@price", double.Parse(txtPrice.Text));
                    cmd.Parameters.AddWithValue("@reorder", int.Parse(txtReOrder.Text));
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Product has been successfully updated.", "Product Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                    fList.LoadRecords();
                    Dispose();
                }
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void TxtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar)) return;
            if (Char.IsControl(e.KeyChar)) return;
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.Contains('.'.ToString()) == false)) return;
            if ((e.KeyChar == '.') && ((sender as TextBox).SelectionLength == (sender as TextBox).TextLength)) return;
            e.Handled = true;
        }

        private void BtnClose_Click(object sender, EventArgs e)
            => Dispose();
    }
}