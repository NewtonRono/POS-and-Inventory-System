using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace POS_and_Inventory_System
{
    public partial class frmQty : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBConnection dbconn = new DBConnection();
        SqlDataReader dr;
        frmPOS fPos;
        private string pcode;
        private double price;
        private int qty;
        private string transNo;
        public frmQty(frmPOS _fPos)
        {
            InitializeComponent();
            conn = new SqlConnection(dbconn.MyConnection());
            fPos = _fPos;
        }

        public void ProductDetails(string _pcode, double _price, string _transNo, int _qty)
        {
            pcode = _pcode;
            price = _price;
            transNo = _transNo;
            qty = _qty;
        }

        private void TxtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 && txtQty.Text != string.Empty)
            {
                string id = "";
                int cartQty = 0;
                bool found = false;
                conn.Open();
                cmd = new SqlCommand("SELECT * FROM tblCart WHERE transno=@transno AND pcode=@pcode", conn);
                cmd.Parameters.AddWithValue("@transno", fPos.lblTransNo.Text);
                cmd.Parameters.AddWithValue("@pcode", pcode);
                dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    found = true;
                    id = dr["id"].ToString();
                    cartQty = int.Parse(dr["qty"].ToString());
                }
                else found = false;
                dr.Close();
                conn.Close();

                if (found)
                {
                    if (qty < (int.Parse(txtQty.Text) + cartQty))
                    {
                        MessageBox.Show("Unable to proceed. Remaining qty on hand is " + qty, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    conn.Open();
                    cmd = new SqlCommand("UPDATE tblCart SET qty=(qty +" + int.Parse(txtQty.Text) + ") WHERE id= '" + id +"'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    fPos.txtSearch.Clear();
                    fPos.txtSearch.Focus();
                    fPos.LoadCart();
                    Dispose();
                }
                else
                {
                    if (qty < int.Parse(txtQty.Text))
                    {
                        MessageBox.Show("Unable to proceed. Remaining qty on hand is " + qty, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    conn.Open();
                    string sql = "INSERT INTO tblCart (transno, pcode, price, qty, sdate, cashier) VALUES " +
                        "(@transno, @pcode, @price, @qty, @sdate, @cashier)";
                    cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@transno", transNo);
                    cmd.Parameters.AddWithValue("@pcode", pcode);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@qty", int.Parse(txtQty.Text));
                    cmd.Parameters.AddWithValue("@sdate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@cashier", fPos.lblUser.Text);
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    fPos.txtSearch.Clear();
                    fPos.txtSearch.Focus();
                    fPos.LoadCart();
                    Dispose();
                }
            }
        }
    }
}