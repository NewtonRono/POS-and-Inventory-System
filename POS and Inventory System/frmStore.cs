using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace POS_and_Inventory_System
{
    public partial class frmStore : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;
        DBConnection db = new DBConnection();

        public frmStore()
        {
            InitializeComponent();
            conn = new SqlConnection(db.MyConnection());
        }

        public void LoadRecords()
        {
            conn.Open();
            string sql = "SELECT * FROM tblStore";
            cmd = new SqlCommand(sql, conn);
            dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                txtAddress.Text = dr["address"].ToString();
                txtStore.Text = dr["store"].ToString();
            }
            else
            {
                txtStore.Clear();
                txtAddress.Clear();
            }
            dr.Close();
            conn.Close();
        }


        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("SAVE STORE DETAILS?", "CONFIRM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int count;
                    conn.Open();
                    string sql = "SELECT count(*) FROM tblStore";
                    cmd = new SqlCommand(sql, conn);
                    count = int.Parse(cmd.ExecuteScalar().ToString());
                    conn.Close();
                    if (count > 0)
                    {
                        conn.Open();
                        string sql1 = "UPDATE tblStore SET store=@store, address=@address";
                        cmd = new SqlCommand(sql1, conn);
                        cmd.Parameters.AddWithValue("@store", txtStore.Text);
                        cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        conn.Open();
                        string sql1 = "INSERT into tblStore (store, address) VALUES (@store, @address)";
                        cmd = new SqlCommand(sql1, conn);
                        cmd.Parameters.AddWithValue("@store", txtStore.Text);
                        cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("STORE DETAILS HAS BEEN SUCCESSFULLY SAVED!", "SAVE RECORD", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
            => Dispose();
    }
}
