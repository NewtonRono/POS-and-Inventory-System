using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using Tulpep.NotificationWindow;

namespace POS_and_Inventory_System
{
    public partial class frmPOS : Form
    {
        private SqlConnection conn;
        private SqlCommand cmd;
        private SqlDataReader dr;
        private DBConnection dbconn = new DBConnection();

        int qty;
        string id;
        string price;
        public frmPOS()
        {
            InitializeComponent();
            lblDateNo.Text = DateTime.Now.ToLongDateString();
            conn = new SqlConnection(dbconn.MyConnection());
            KeyPreview = true;
            NotifyCriticalItems();
        }

        public void NotifyCriticalItems()
        {
            string critical = "";
            conn.Open();
            cmd = new SqlCommand("SELECT count(*) FROM vwCriticalItems", conn);
            string count = cmd.ExecuteScalar().ToString();
            conn.Close();

            int i = 0;
            conn.Open();
            cmd = new SqlCommand("SELECT * FROM vwCriticalItems", conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i++;
                critical += i + ". " + dr["pdesc"].ToString() + Environment.NewLine;
            }
            dr.Close();
            conn.Close();

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.error;
            popup.TitleText = count + "Critical Item(s)";
            popup.ContentText = critical;
            popup.Popup();
        }

        public void GetTransNo()
        {
            try
            {
                string sdate = DateTime.Now.ToString("yyyyMMdd");
                string transNo;
                int count;
                conn.Open();
                string sql = "SELECT top 1 transno FROM tblCart where transno like '" + sdate + "%' order by id";
                cmd = new SqlCommand(sql, conn);
                dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    transNo = dr[0].ToString();
                    count = int.Parse(transNo.Substring(8, 4));
                    lblTransNo.Text = sdate + (count + 1);
                }
                else
                {
                    transNo = sdate + "1001";
                    lblTransNo.Text = transNo;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                dr.Close();
                conn.Close();
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {

            lblTime.Text = DateTime.Now.ToString("hh:mm:ss tt");
            lblDate.Text = DateTime.Now.ToLongDateString();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtSearch.Text == string.Empty) return;
                else
                {
                    string _pcode;
                    double _price;
                    int _qty;
                    conn.Open();
                    string sql = "SELECT * FROM tblProduct WHERE barcode LIKE '" + txtSearch.Text + "'";
                    cmd = new SqlCommand(sql, conn);
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {

                        qty = int.Parse(dr["qty"].ToString());
                        _pcode = dr["pcode"].ToString();
                        _price = double.Parse(dr["price"].ToString());
                        _qty = int.Parse(txtQty.Text);

                        dr.Close();
                        conn.Close();

                        AddToCart(_pcode, _price, _qty);
                    }
                    else
                    {
                        dr.Close();
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                dr.Close();
                conn.Close();
            }
        }

        private void AddToCart(string _pcode, double _price, int _qty)
        {
            string id = "";
            bool found = false;
            int cartQty = 0;
            conn.Open();
            string sql = "SELECT * FROM tblCart WHERE transno=@transno AND pcode=@pcode";
            cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@transno", lblTransNo.Text);
            cmd.Parameters.AddWithValue("@pcode", _pcode);
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
                string sql1 = "UPDATE tblCart SET qty=(qty +" + _qty + ") WHERE id= '" + id + "'";
                cmd = new SqlCommand(sql1, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

                txtSearch.SelectionStart = 0;
                txtSearch.SelectionLength = txtSearch.Text.Length;
                LoadCart();
                //Dispose();
            }
            else
            {
                if (qty < int.Parse(txtQty.Text))
                {
                    MessageBox.Show("Unable to proceed. Remaining qty on hand is " + qty, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                conn.Open();
                string sql1 = "INSERT INTO tblCart (transno, pcode, price, qty, sdate, cashier) " +
                    "VALUES (@transno, @pcode, @price, @qty, @sdate, @cashier)";
                cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.AddWithValue("@transno", lblTransNo.Text);
                cmd.Parameters.AddWithValue("@pcode", _pcode);
                cmd.Parameters.AddWithValue("@price", _price);
                cmd.Parameters.AddWithValue("@qty", _qty);
                cmd.Parameters.AddWithValue("@sdate", DateTime.Now);
                cmd.Parameters.AddWithValue("@cashier", lblUser.Text);
                cmd.ExecuteNonQuery();
                conn.Close();

                txtSearch.SelectionStart = 0;
                txtSearch.SelectionLength = txtSearch.Text.Length;
                LoadCart();
                //Dispose();
            }
        }

        public void LoadCart()
        {
            try
            {
                bool hasRecord = false;
                dgvBrandList.Rows.Clear();
                int i = 0;
                double total = 0, discount = 0;
                conn.Open();
                string sql = "SELECT c.id, c.pcode, p.pdesc, c.price, c.qty, c.disc, c.total FROM tblCart AS c INNER JOIN " +
                    "tblProduct AS p on c.pcode=p.pcode WHERE transno LIKE '" + lblTransNo.Text + "' AND status LIKE 'Pending'";
                cmd = new SqlCommand(sql, conn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    i++;
                    total += double.Parse(dr["total"].ToString());
                    discount += double.Parse(dr["disc"].ToString());
                    dgvBrandList.Rows.Add(i, dr["id"].ToString(), dr["pcode"].ToString(), dr["pdesc"].ToString(), dr["price"].ToString(),
                        dr["qty"].ToString(), dr["disc"].ToString(), dr["total"].ToString());
                    hasRecord = true;
                }
                dr.Close();
                conn.Close();
                lblSalesTotal.Text = total.ToString("#,##0.00");
                lblDiscount.Text = discount.ToString("#,##0.00");
                GetCartTotal();
                btnSetPayment.Enabled = hasRecord;
                btnAddDiscount.Enabled = hasRecord;
                btnClearCart.Enabled = hasRecord;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }


        private void DgvBrandList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvBrandList.Columns[e.ColumnIndex].Name;
            if (colName == "Delete")
            {
                if (MessageBox.Show("Remove this item", "Remove Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    conn.Open();
                    string sql = "DELETE FROM tblCart WHERE id LIKE '" + dgvBrandList.Rows[e.RowIndex].Cells[1].Value.ToString() + "'";
                    cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("item has successfully removed", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCart();
                }
            }
            else if (colName == "colAdd")
            {
                int i = 0;
                conn.Open();
                string sql = "SELECT sum(qty) AS qty FROM tblProduct WHERE pcode LIKE '" + 
                    dgvBrandList.Rows[e.RowIndex].Cells[2].Value.ToString() + "' GROUP BY pcode";
                cmd = new SqlCommand(sql, conn);
                i = int.Parse(cmd.ExecuteScalar().ToString());
                conn.Close();

                if (int.Parse(dgvBrandList.Rows[e.RowIndex].Cells[5].Value.ToString()) < i)
                {
                    conn.Open();
                    string sql2 = "UPDATE tblCart SET qty = qty +" + int.Parse(txtQty.Text) + " WHERE transno LIKE '" + 
                        lblTransNo.Text + "' AND pcode LIKE '" + dgvBrandList.Rows[e.RowIndex].Cells[2].Value.ToString() + "'";
                    cmd = new SqlCommand(sql2, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    LoadCart();
                }
                else
                {
                    MessageBox.Show("Remaining qty on hand is " + i + " !", "Out of Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else if (colName == "colRemove")
            {
                int i = 0;
                conn.Open();
                string sql = "SELECT sum(qty) AS qty FROM tblCart WHERE pcode LIKE '" + dgvBrandList.Rows[e.RowIndex].Cells[2].Value.ToString() + 
                    "' AND transno LIKE '" + lblTransNo.Text + "' GROUP BY transno, pcode";
                cmd = new SqlCommand(sql, conn);
                i = int.Parse(cmd.ExecuteScalar().ToString());
                conn.Close();

                if (i > 1)
                {
                    conn.Open();
                    string sql2 = "UPDATE tblCart SET qty = qty - " + int.Parse(txtQty.Text) + " WHERE transno LIKE '" +
                        lblTransNo.Text + "' AND pcode LIKE '" + dgvBrandList.Rows[e.RowIndex].Cells[2].Value.ToString() + "'";
                    cmd = new SqlCommand(sql2, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    LoadCart();
                }
                else
                {
                    MessageBox.Show("Remaining qty on cart is " + i + " !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }

        public void GetCartTotal()
        {
            double discount = double.Parse(lblDiscount.Text);
            double sales = double.Parse(lblSalesTotal.Text);
            double vat = sales * dbconn.GetVal();
            double vatable = sales - vat;

            lblVat.Text = vat.ToString("#,##0.00");
            lblVatable.Text = vatable.ToString("#,##0.00");
            lblDisplayTotal.Text = sales.ToString("#,##0.00");
        }

        private void DgvBrandList_SelectionChanged(object sender, EventArgs e)
        {
            int i = dgvBrandList.CurrentRow.Index;
            id = dgvBrandList[1, i].Value.ToString();
            price = dgvBrandList[4, i].Value.ToString();
        }

        private void FrmPOS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                BtnNew_Click(sender, e);
            else if (e.KeyCode == Keys.F2)
                BtnSearchProd_Click(sender, e);
            else if (e.KeyCode == Keys.F3)
                BtnAddDiscount_Click(sender, e);
            else if (e.KeyCode == Keys.F4)
                BtnSetPayment_Click(sender, e);
            else if (e.KeyCode == Keys.F5)
                BtnClearCart_Click(sender, e);
            else if (e.KeyCode == Keys.F6)
                BtnDailySales_Click(sender, e);
            else if (e.KeyCode == Keys.F8)
            {
                txtSearch.SelectionStart = 0;
                txtSearch.SelectionLength = txtSearch.Text.Length;
            }
            else if (e.KeyCode == Keys.F10)
                BtnClose_Click(sender, e);
        }

        private void BtnSearchProd_Click(object sender, EventArgs e)
        {
            if (lblTransNo.Text == "0000000000000") return;
            frmLookUp lookUpFrm = new frmLookUp(this);
            lookUpFrm.LoadRecords();
            lookUpFrm.ShowDialog();
        }

        private void BtnAddDiscount_Click(object sender, EventArgs e)
        {
            frmDiscount discountFrm = new frmDiscount(this);
            discountFrm.lblId.Text = id;
            discountFrm.txtPrice.Text = price;
            discountFrm.ShowDialog();
        }

        private void BtnSetPayment_Click(object sender, EventArgs e)
        {
            frmSettle setFrm = new frmSettle(this);
            setFrm.txtSale.Text = lblDisplayTotal.Text;
            setFrm.ShowDialog();
        }

        private void BtnClearCart_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Remove all items from cart?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                conn.Open();
                cmd = new SqlCommand("DELETE FROM tblCart WHERE transno LIKE '" + lblTransNo.Text + "'", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("All items has been successful removed", "Remove Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCart();
            }
        }

        private void BtnDailySales_Click(object sender, EventArgs e)
        {
            frmSoldItems soldFrm = new frmSoldItems();
            soldFrm.dtFrom.Enabled = false;
            soldFrm.dtTo.Enabled = false;
            soldFrm.sUser = lblUser.Text;
            soldFrm.cboCashier.Enabled = false;
            soldFrm.cboCashier.Text = lblUser.Text;
            soldFrm.ShowDialog();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            if (dgvBrandList.Rows.Count > 0)
            {
                MessageBox.Show("Unable to Logout. Please cancel the transaction", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Logout Application", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Hide();
                frmSecurity frm = new frmSecurity();
                frm.ShowDialog();
            }
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            if (dgvBrandList.Rows.Count > 0) return;
            GetTransNo();
            txtSearch.Enabled = true;
            txtSearch.Focus();
        }
    }
}
