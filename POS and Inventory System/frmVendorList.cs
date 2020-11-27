using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace POS_and_Inventory_System
{
    public partial class frmVendorList : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;
        DBConnection dbconn = new DBConnection();
        public frmVendorList()
        {
            InitializeComponent();
            conn = new SqlConnection(dbconn.MyConnection());
            LoadRecords();
        }

        public void LoadRecords()
        {
            dgvVendor.Rows.Clear();
            int i = 0;
            conn.Open();
            cmd = new SqlCommand("SELECT * FROM tblVendor", conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvVendor.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(),
                    dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
            }
            dr.Close();
            conn.Close();
        }

        private void DgvVendor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvVendor.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                frmVendor frm = new frmVendor(this);
                frm.lblId.Text = dgvVendor.Rows[e.RowIndex].Cells[1].Value.ToString();
                frm.txtVendor.Text = dgvVendor.Rows[e.RowIndex].Cells[2].Value.ToString();
                frm.txtAddress.Text = dgvVendor.Rows[e.RowIndex].Cells[3].Value.ToString();
                frm.txtContact.Text = dgvVendor.Rows[e.RowIndex].Cells[4].Value.ToString();
                frm.txtMobile.Text = dgvVendor.Rows[e.RowIndex].Cells[5].Value.ToString();
                frm.txtEmail.Text = dgvVendor.Rows[e.RowIndex].Cells[6].Value.ToString();
                frm.txtFax.Text = dgvVendor.Rows[e.RowIndex].Cells[7].Value.ToString();
                frm.btnSave.Enabled = false;
                frm.btnUpdate.Enabled = true;
                frm.ShowDialog();
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Delete this record?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    conn.Open();
                    string sql = "DELETE FROM tblVendor WHERE id LIKE '" + dgvVendor.Rows[e.RowIndex].Cells[1].Value.ToString() + "'";
                    cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Record has been updated successfully", "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadRecords();
                }
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
            => Util.CloseForm(this);

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            frmVendor frm = new frmVendor(this);
            frm.btnSave.Enabled = true;
            frm.btnUpdate.Enabled = false;
            frm.ShowDialog();
        }
    }
}
