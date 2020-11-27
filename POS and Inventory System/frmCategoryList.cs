using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace POS_and_Inventory_System
{
    public partial class frmCategoryList : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBConnection dbconn = new DBConnection();
        SqlDataReader dr;
        public frmCategoryList()
        {
            InitializeComponent();
            conn = new SqlConnection(dbconn.MyConnection());
            LoadCategory();
        }

        public void LoadCategory()
        {
            try
            {
                int i = 0;
                dataGridView1.Rows.Clear();
                conn.Open();
                string sql = "SELECT * FROM tblCategory ORDER BY category";
                cmd = new SqlCommand(sql, conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    i++;
                    dataGridView1.Rows.Add(i, dr[0].ToString(), dr[1].ToString());
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

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridView1.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                frmCategory frm = new frmCategory(this);
                frm.lblId.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                frm.txtCategory.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                frm.btnSave.Enabled = false;
                frm.btnUpdate.Enabled = true;
                frm.ShowDialog();
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this category?", "Delete Category", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        conn.Open();
                        string sql = "DELETE FROM tblCategory WHERE id LIKE '" + dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + "'";
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
                        MessageBox.Show("Record has been successfully deleted");
                        LoadCategory();
                    }
                }
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            frmCategory frm = new frmCategory(this);
            frm.btnSave.Enabled = true;
            frm.btnUpdate.Enabled = false;
            frm.ShowDialog();
        }

        private void BtnClose_Click(object sender, EventArgs e)
            => Util.CloseForm(this);
    }
}
