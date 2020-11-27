using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace POS_and_Inventory_System
{
    public partial class frmBrandList : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        DBConnection dbconn = new DBConnection();
        public frmBrandList()
        {
            InitializeComponent();
            conn = new SqlConnection(dbconn.MyConnection());
            LoadRecords();
        }
        public void LoadRecords()
        {
            try
            {
                int i = 0;
                dgvBrandList.Rows.Clear();
                conn.Open();
                string sql = "SELECT * FROM tblBrand ORDER BY brand";
                cmd = new SqlCommand(sql, conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    i++;
                    dgvBrandList.Rows.Add(i, dr["id"].ToString(), dr["brand"].ToString());
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

        private void DgvBrandList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvBrandList.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                frmBrand frm = new frmBrand(this);
                frm.lblId.Text = dgvBrandList[1, e.RowIndex].Value.ToString();
                frm.txtBrand.Text = dgvBrandList[2, e.RowIndex].Value.ToString();
                frm.ShowDialog();
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this record", "Delete Record",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        conn.Open();
                        string sql = "DELETE FROM tblBrand WHERE id LIKE '" + dgvBrandList[1, e.RowIndex].Value.ToString() + "'";
                        cmd = new SqlCommand(sql, conn);
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                        MessageBox.Show("Brand has been successfully Deleted", "POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadRecords();
                    }
                }
            }
        }

        private void BtnClose_Click(object sender, EventArgs e) 
            => Util.CloseForm(this);

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            frmBrand frm = new frmBrand(this);
            frm.ShowDialog();
        }
    }
}
