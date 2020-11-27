using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace POS_and_Inventory_System
{
    public partial class frmDiscount : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBConnection dbconn = new DBConnection();
        frmPOS frm;
        public frmDiscount(frmPOS _frm)
        {
            InitializeComponent();
            conn = new SqlConnection(dbconn.MyConnection());
            frm = _frm;
            KeyPreview = true;
        }

        private void TxtDiscount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double discount = double.Parse(txtPrice.Text) * double.Parse(txtPercent.Text);
                txtAmount.Text = discount.ToString("#,##0.00");
            }
            catch (Exception ex)
            {
                txtAmount.Text = "0.00";
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Add Discount?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    conn.Open();
                    string sql = "UPDATE tblCart set disc=@disc, disc_percent=@disc_percent WHERE id=@id";
                    cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@disc", double.Parse(txtAmount.Text));
                    cmd.Parameters.AddWithValue("@disc_percent", double.Parse(txtPercent.Text));
                    cmd.Parameters.AddWithValue("@id", int.Parse(lblId.Text));
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    frm.LoadCart();
                    Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Dispose();
        }

        private void BtnClose_Click(object sender, EventArgs e)
            => Dispose();
    }
}
