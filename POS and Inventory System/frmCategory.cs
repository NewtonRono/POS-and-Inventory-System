using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace POS_and_Inventory_System
{
    public partial class frmCategory : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBConnection dbconn = new DBConnection();
        frmCategoryList fList;
        public frmCategory(frmCategoryList frm)
        {
            InitializeComponent();
            conn = new SqlConnection(dbconn.MyConnection());
            fList = frm;
        }

        public void Clear()
        {
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            txtCategory.Clear();
            txtCategory.Focus();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to save this category?", "Saving Record", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    conn.Open();
                    string sql = "INSERT INTO tblCategory(category) VALUES (@category)";
                    cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@category", txtCategory.Text);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
                MessageBox.Show("Category has been successfully saved");
                Clear();
                fList.LoadCategory();
                Dispose();
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to update this category?", "Update Category", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    conn.Open();
                    string sql = "UPDATE tblCategory SET category=@category WHERE id LIKE '" + lblId.Text + "'";
                    cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@category", txtCategory.Text);
                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
                MessageBox.Show("Record has been successfully updated");
                fList.LoadCategory();
                Dispose();
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
            => Dispose();
    }
}
