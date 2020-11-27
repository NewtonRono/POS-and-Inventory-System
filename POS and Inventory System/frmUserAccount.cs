using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace POS_and_Inventory_System
{
    public partial class frmUserAccount : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBConnection dbconn = new DBConnection();
        SqlDataReader dr;
        frmDashboard frm;
        public frmUserAccount(frmDashboard _frm)
        {
            InitializeComponent();
            conn = new SqlConnection(dbconn.MyConnection());
            frm = _frm;
        }

        private void FrmUserAccount_Resize(object sender, EventArgs e)
        {
            metroTabControl1.Left = (Width - metroTabControl1.Width) / 2;
            metroTabControl1.Top = (Height - metroTabControl1.Height) / 2;
        }

        private void Clear()
        {
            txtName.Clear();
            txtPass.Clear();
            txtConfirmPass.Clear();
            txtUser.Clear();
            cboRole.Text = "";
            txtUser.Focus();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPass.Text != txtConfirmPass.Text)
                {
                    MessageBox.Show("Password did not match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                conn.Open();
                string sql = "INSERT INTO tblUser (username, password, role, name) VALUES (@username, @password, @role, @name)";
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@username", txtUser.Text);
                cmd.Parameters.AddWithValue("@password", txtPass.Text);
                cmd.Parameters.AddWithValue("@role", cboRole.Text);
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("New Account has saved");
                Clear();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnSave2_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtOldPass2.Text != frm._pass)
                {
                    MessageBox.Show("Old Password did not matched!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (txtNewPass2.Text != txtConfirmPass2.Text)
                {
                    MessageBox.Show("Confirm new password did not matched", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                conn.Open();
                cmd = new SqlCommand("UPDATE tblUser SET password=@password WHERE username=@username",conn);
                cmd.Parameters.AddWithValue("@password", txtNewPass2.Text);
                cmd.Parameters.AddWithValue("@username", txtUser2.Text);
                cmd.ExecuteNonQuery();

                conn.Close();
                MessageBox.Show("Password has been successfully changed!", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtConfirmPass2.Clear();
                txtNewPass2.Clear();
                txtOldPass2.Clear(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void TxtUser3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                cmd = new SqlCommand("SELECT * FROM tblUser WHERE username=@username", conn);
                cmd.Parameters.AddWithValue("@username", txtUser3.Text);
                dr = cmd.ExecuteReader();
                dr.Read();
                cbActive.Checked = dr.HasRows && bool.Parse(dr["isactive"].ToString());
                dr.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnSave3_Click(object sender, EventArgs e)
        {
            try
            {
                bool found = true;
                conn.Open();
                cmd = new SqlCommand("SELECT * FROM tblUser WHERE username=@username", conn);
                cmd.Parameters.AddWithValue("@username", txtUser3.Text);
                dr = cmd.ExecuteReader();
                dr.Read();
                found = dr.HasRows;
                dr.Close();
                conn.Close();

                if (found)
                {
                    conn.Open();
                    cmd = new SqlCommand("UPDATE tblUser SET isactive=@isactive WHERE username=@username", conn);
                    cmd.Parameters.AddWithValue("@isactive", cbActive.Checked.ToString());
                    cmd.Parameters.AddWithValue("@username", txtUser3.Text);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Account status has been successfully updated.", "Update Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtUser3.Clear();
                    cbActive.Checked = true;
                }
                else
                {
                    MessageBox.Show("Account does not exist!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
