using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace POS_and_Inventory_System
{
    public partial class frmBrand : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBConnection dbconn = new DBConnection();
        frmBrandList fList;
        public frmBrand(frmBrandList _fList)
        {
            InitializeComponent();
            conn = new SqlConnection(dbconn.MyConnection());
            fList = _fList;
        }

        private void Clear()
        {
            btnSave.Enabled = true;
            btnUpdate.Enabled = true;
            txtBrand.Clear();
            txtBrand.Focus();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save this brand?", "", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    conn.Open();
                    string sql = "INSERT INTO tblBrand (brand) VALUES (@brand)";
                    cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@brand", txtBrand.Text);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                    MessageBox.Show("Records has been successfully saved.");
                    Clear();
                    fList.LoadRecords();
                    Dispose();
                }
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to update this brand?", "Update Record", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    conn.Open();
                    string sql = "UPDATE tblBrand SET brand=@brand WHERE id LIKE '" + lblId.Text + "'";
                    cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@brand", txtBrand.Text);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                    MessageBox.Show("Brand Updated Successsfully");
                    Clear();
                    fList.LoadRecords();
                    Dispose();
                }
            }      
        }

        private void BtnClose_Click(object sender, EventArgs e)
            => Dispose();
    }
}
