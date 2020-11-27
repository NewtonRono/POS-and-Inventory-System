using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace POS_and_Inventory_System
{
    public partial class frmSecurity : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        DBConnection dbconn = new DBConnection();
        public string _pass, _username = "";
        public bool _isActive = false;
        public frmSecurity()
        {
            InitializeComponent();
            conn = new SqlConnection(dbconn.MyConnection());
            KeyPreview = true;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit Application", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string _role="", _name = "";
            try
            {
                bool found = false;
                conn.Open();
                string sql = "SELECT * FROM tblUser WHERE username=@username AND password=@password";
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@username", txtUser.Text);
                cmd.Parameters.AddWithValue("@password", txtPass.Text);
                dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    found = true;
                    _username = dr["username"].ToString();
                    _role = dr["role"].ToString();
                    _name = dr["name"].ToString();
                    _pass = dr["password"].ToString();
                    _isActive = bool.Parse(dr["isactive"].ToString());
                }
                else found = false;

                dr.Close();
                conn.Close();

                if (found)
                {
                    if (!_isActive)
                    {
                        MessageBox.Show("Account is deactivated. Unable to login", "Inactivate Account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (_role == "Cashier")
                    {
                        MessageBox.Show("Access Granted! Welcome " + _name, "ACCESS GRANTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtPass.Clear();
                        txtUser.Clear();
                        Hide();
                        frmPOS frm = new frmPOS();
                        frm.lblUser.Text = _username;
                        frm.lblName.Text = _name + " | " + _role;
                        frm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Access Granted! Welcome " + _name, "ACCESS GRANTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtPass.Clear();
                        txtUser.Clear();
                        Hide();
                        frmDashboard frm = new frmDashboard();
                        frm.lblName.Text = _name;
                        //frm.lblUser.Text = _user;
                        frm.lblRole.Text = _role;
                        frm._pass = _pass;
                        frm._user = _username;
                        frm.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password", "ACCESS DENIED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FrmSecurity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return) BtnLogin_Click(sender, e);
            else if (e.KeyCode == Keys.Escape) BtnCancel_Click(sender, e);
        }
    }
}
