using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace POS_and_Inventory_System
{
    public partial class frmLookUp : Form
    {
        frmPOS frm;
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        DBConnection dbconn = new DBConnection();
        public frmLookUp(frmPOS _frm)
        {
            InitializeComponent();
            conn = new SqlConnection(dbconn.MyConnection());
            frm = _frm;
            KeyPreview = true;
        }

        public void LoadRecords()
        {
            int i = 0;
            dgvProductList.Rows.Clear();
            conn.Open();
            string sql = "SELECT p.pcode, p.barcode, p.pdesc, b.brand, c.category, p.price, p.qty FROM tblProduct AS p INNER JOIN tblBrand " +
                "AS b ON b.id=p.bid INNER JOIN tblCategory AS c ON c.id=p.cid WHERE p.pdesc LIKE '%" + txtSearch.Text + "%' order by p.pdesc";
            cmd = new SqlCommand(sql, conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvProductList.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(),
                    dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
            }
            dr.Close();
            conn.Close();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e) 
            => LoadRecords();

        private void DgvProductList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvProductList.Columns[e.ColumnIndex].Name;
            if (colName == "Select")
            {
                frmQty frmQty = new frmQty(frm);
                frmQty.ProductDetails(dgvProductList.Rows[e.RowIndex].Cells[1].Value.ToString(),
                    double.Parse(dgvProductList.Rows[e.RowIndex].Cells[6].Value.ToString()), frm.lblTransNo.Text, 
                    int.Parse(dgvProductList.Rows[e.RowIndex].Cells[7].Value.ToString()));
                frmQty.ShowDialog();
            }
        }

        private void FrmLookUp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Dispose();
        }

        private void BtnClose_Click(object sender, EventArgs e) 
            => Dispose();
    }
}
