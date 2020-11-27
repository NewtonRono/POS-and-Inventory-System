using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace POS_and_Inventory_System
{
    public partial class frmSettle : Form
    {
        frmPOS fpos;
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBConnection dbconn = new DBConnection();
        public frmSettle(frmPOS _fpos)
        {
            InitializeComponent();
            fpos = _fpos;
            conn = new SqlConnection(dbconn.MyConnection());
            KeyPreview = true;
        }

        private void TxtCash_TextChanged(object sender, EventArgs e)
        {
            double sale = double.Parse(txtSale.Text);
            double cash = double.Parse(txtCash.Text);
            double change = cash - sale;
            try
            {
                txtChange.Text = change.ToString("#,##0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show(change.ToString());
                txtChange.Text = "0.00";
            }
        }

        private void Btn7_Click(object sender, EventArgs e) 
            => txtCash.Text += btn7.Text;

        private void Btn8_Click(object sender, EventArgs e)
            => txtCash.Text += btn8.Text;

        private void Btn9_Click(object sender, EventArgs e)
            => txtCash.Text += btn9.Text;

        private void BtnC_Click(object sender, EventArgs e)
        {
            txtCash.Clear();
            txtCash.Focus();
        }

        private void Btn4_Click(object sender, EventArgs e)
            => txtCash.Text += btn4.Text;

        private void Btn5_Click(object sender, EventArgs e)
            => txtCash.Text += btn5.Text;

        private void Btn6_Click(object sender, EventArgs e)
            => txtCash.Text += btn6.Text;

        private void Btn0_Click(object sender, EventArgs e)
            => txtCash.Text += btn0.Text;

        private void Btn1_Click(object sender, EventArgs e)
            => txtCash.Text += btn1.Text;

        private void Btn2_Click(object sender, EventArgs e)
            => txtCash.Text += btn2.Text;

        private void Btn3_Click(object sender, EventArgs e)
            => txtCash.Text += btn3.Text;

        private void Btn00_Click(object sender, EventArgs e)
            => txtCash.Text += btn00.Text;

        private void BtnEnter_Click(object sender, EventArgs e)
        {
            try
            {
                if (double.Parse(txtChange.Text) < 0 || txtChange.Text == string.Empty)
                {
                    MessageBox.Show("Insufficient Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    for (int i = 0; i < fpos.dgvBrandList.Rows.Count; i++)
                    {
                        conn.Open();
                        string sql = "UPDATE tblProduct SET qty=qty - " + int.Parse(fpos.dgvBrandList.Rows[i].Cells[5].Value.ToString()) +
                            " WHERE pcode='" + fpos.dgvBrandList.Rows[i].Cells[2].Value.ToString() + "'";
                        cmd = new SqlCommand(sql, conn);
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        conn.Open();
                        string sql1 = "UPDATE tblCart SET status='Sold' WHERE id='" + fpos.dgvBrandList.Rows[i].Cells[1].Value.ToString() + "'";
                        cmd = new SqlCommand(sql1, conn);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    frmReceipt frm = new frmReceipt(fpos);
                    frm.LoadReport(txtCash.Text, txtChange.Text);
                    frm.ShowDialog();

                    MessageBox.Show("Payment Successfully Saved!", "Payment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fpos.GetTransNo();
                    fpos.LoadCart();
                    Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //MessageBox.Show("Insufficient Amount. Please Enter the correct amount!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FrmSettle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Dispose();
            else if (e.KeyCode == Keys.Enter)
                BtnEnter_Click(sender, e);
        }

        private void BtnClose_Click(object sender, EventArgs e)
            => Dispose();
    }
}
