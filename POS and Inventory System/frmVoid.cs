using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace POS_and_Inventory_System
{
    public partial class frmVoid : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        DBConnection dbconn = new DBConnection();
        frmCancelDetails frm;
        public frmVoid(frmCancelDetails _frm)
        {
            InitializeComponent();
            conn = new SqlConnection(dbconn.MyConnection());
            frm = _frm;
        }

        private void BtnVoid_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPass.Text != string.Empty)
                {
                    string user;
                    string sql = "SELECT * FROM tblUser WHERE username=@username AND password=@password";
                    conn.Open();
                    cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@username", txtUser.Text);
                    cmd.Parameters.AddWithValue("@password", txtPass.Text);
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        user = dr["username"].ToString();
                        dr.Close();
                        conn.Close();

                        SaveCancelOrder(user);
                        if (frm.cboAction.Text == "Yes")
                        {
                            UpdateData("UPDATE tblProduct SET qty = qty + " + int.Parse(frm.txtCancelQty.Text) + " WHERE pcode='" + frm.txtPCode.Text + "'");
                        }

                        UpdateData("UPDATE tblCart SET qty = qty - " + int.Parse(frm.txtCancelQty.Text) + " WHERE id LIKE '" + frm.txtId.Text + "'");

                        MessageBox.Show("Order transaction sucessfully cancelled!", "Cancel Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Dispose();
                        frm.RefreshList();
                        frm.Dispose();
                    }
                    dr.Close();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message);
            }
        }

        public void SaveCancelOrder(string user)
        {
            conn.Open();
            string sql = "INSERT INTO tblCancel (transno, pcode, price, qty, sdate, voidBy, cancelledBy, reason, action) " +
                "VALUES (@transno, @pcode, @price, @qty, @sdate, @voidBy, @cancelledBy, @reason, @action)";
            cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@transno", frm.txtTransNo.Text);
            cmd.Parameters.AddWithValue("@pcode", frm.txtPCode.Text);
            cmd.Parameters.AddWithValue("@price", double.Parse(frm.txtPrice.Text));
            cmd.Parameters.AddWithValue("@qty", int.Parse(frm.txtCancelQty.Text));
            cmd.Parameters.AddWithValue("@sdate", DateTime.Now);
            cmd.Parameters.AddWithValue("@voidBy", user);
            cmd.Parameters.AddWithValue("@cancelledBy", frm.txtCancel.Text);
            cmd.Parameters.AddWithValue("@reason", frm.txtReason.Text);
            cmd.Parameters.AddWithValue("@action", frm.cboAction.Text);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void UpdateData(string sql)
        {
            conn.Open();
            cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        private void BtnClose_Click(object sender, EventArgs e)
            => Dispose();
    }
}
