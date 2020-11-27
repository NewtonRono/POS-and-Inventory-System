namespace POS_and_Inventory_System
{
    partial class frmPOS
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPOS));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label10 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblSalesTotal = new System.Windows.Forms.Label();
            this.lblDisplayTotal = new System.Windows.Forms.Label();
            this.lblVatable = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDailySales = new System.Windows.Forms.Button();
            this.btnSearchProd = new System.Windows.Forms.Button();
            this.btnClearCart = new System.Windows.Forms.Button();
            this.btnAddDiscount = new System.Windows.Forms.Button();
            this.btnSetPayment = new System.Windows.Forms.Button();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.lblVat = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtQty = new MetroFramework.Controls.MetroTextBox();
            this.txtSearch = new MetroFramework.Controls.MetroTextBox();
            this.lblDateNo = new System.Windows.Forms.Label();
            this.lblTransNo = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvBrandList = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblName = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAdd = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colRemove = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBrandList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Roboto Medium", 10F);
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(206)))), ((int)(((byte)(222)))));
            this.label10.Location = new System.Drawing.Point(9, 34);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 17);
            this.label10.TabIndex = 0;
            this.label10.Text = "Discount";
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Roboto Medium", 10F);
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(206)))), ((int)(((byte)(222)))));
            this.label17.Location = new System.Drawing.Point(10, 83);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(58, 17);
            this.label17.TabIndex = 0;
            this.label17.Text = "Vatable";
            // 
            // lblSalesTotal
            // 
            this.lblSalesTotal.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblSalesTotal.AutoSize = true;
            this.lblSalesTotal.Font = new System.Drawing.Font("Roboto Medium", 10F);
            this.lblSalesTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(206)))), ((int)(((byte)(222)))));
            this.lblSalesTotal.Location = new System.Drawing.Point(378, 9);
            this.lblSalesTotal.Name = "lblSalesTotal";
            this.lblSalesTotal.Size = new System.Drawing.Size(36, 17);
            this.lblSalesTotal.TabIndex = 0;
            this.lblSalesTotal.Text = "0.00";
            // 
            // lblDisplayTotal
            // 
            this.lblDisplayTotal.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblDisplayTotal.Font = new System.Drawing.Font("Roboto", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplayTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(194)))), ((int)(((byte)(255)))));
            this.lblDisplayTotal.Location = new System.Drawing.Point(1068, 0);
            this.lblDisplayTotal.Name = "lblDisplayTotal";
            this.lblDisplayTotal.Size = new System.Drawing.Size(130, 47);
            this.lblDisplayTotal.TabIndex = 0;
            this.lblDisplayTotal.Text = "0.00";
            this.lblDisplayTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblVatable
            // 
            this.lblVatable.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblVatable.AutoSize = true;
            this.lblVatable.Font = new System.Drawing.Font("Roboto Medium", 10F);
            this.lblVatable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(206)))), ((int)(((byte)(222)))));
            this.lblVatable.Location = new System.Drawing.Point(378, 83);
            this.lblVatable.Name = "lblVatable";
            this.lblVatable.Size = new System.Drawing.Size(36, 17);
            this.lblVatable.TabIndex = 0;
            this.lblVatable.Text = "0.00";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(40)))), ((int)(((byte)(76)))));
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Controls.Add(this.panel3);
            this.panel7.Controls.Add(this.panel9);
            this.panel7.Controls.Add(this.panel4);
            this.panel7.Controls.Add(this.dgvBrandList);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1198, 551);
            this.panel7.TabIndex = 5;
            // 
            // panel8
            // 
            this.panel8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(40)))), ((int)(((byte)(76)))));
            this.panel8.Controls.Add(this.lblDate);
            this.panel8.Controls.Add(this.lblTime);
            this.panel8.Location = new System.Drawing.Point(3, 442);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(596, 106);
            this.panel8.TabIndex = 3;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Roboto Medium", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(101)))), ((int)(((byte)(155)))));
            this.lblDate.Location = new System.Drawing.Point(10, 78);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(74, 25);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "label1";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Roboto Medium", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(101)))), ((int)(((byte)(155)))));
            this.lblTime.Location = new System.Drawing.Point(2, 2);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(291, 77);
            this.lblTime.TabIndex = 0;
            this.lblTime.Text = "00:00:00";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(40)))), ((int)(((byte)(76)))));
            this.panel3.Controls.Add(this.btnNew);
            this.panel3.Controls.Add(this.btnClose);
            this.panel3.Controls.Add(this.btnDailySales);
            this.panel3.Controls.Add(this.btnSearchProd);
            this.panel3.Controls.Add(this.btnClearCart);
            this.panel3.Controls.Add(this.btnAddDiscount);
            this.panel3.Controls.Add(this.btnSetPayment);
            this.panel3.Location = new System.Drawing.Point(1034, 33);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(164, 243);
            this.panel3.TabIndex = 5;
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(40)))), ((int)(((byte)(76)))));
            this.btnNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNew.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNew.FlatAppearance.BorderSize = 0;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Roboto Medium", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(206)))), ((int)(((byte)(222)))));
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(0, 0);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(164, 28);
            this.btnNew.TabIndex = 19;
            this.btnNew.Text = "     New Transaction";
            this.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(40)))), ((int)(((byte)(76)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Roboto Medium", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(206)))), ((int)(((byte)(222)))));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(0, 203);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(164, 28);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "     Logout";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // btnDailySales
            // 
            this.btnDailySales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(40)))), ((int)(((byte)(76)))));
            this.btnDailySales.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDailySales.FlatAppearance.BorderSize = 0;
            this.btnDailySales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDailySales.Font = new System.Drawing.Font("Roboto Medium", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDailySales.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(206)))), ((int)(((byte)(222)))));
            this.btnDailySales.Image = ((System.Drawing.Image)(resources.GetObject("btnDailySales.Image")));
            this.btnDailySales.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDailySales.Location = new System.Drawing.Point(0, 169);
            this.btnDailySales.Name = "btnDailySales";
            this.btnDailySales.Size = new System.Drawing.Size(164, 28);
            this.btnDailySales.TabIndex = 16;
            this.btnDailySales.Text = "     Daily Sales";
            this.btnDailySales.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDailySales.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDailySales.UseVisualStyleBackColor = false;
            this.btnDailySales.Click += new System.EventHandler(this.BtnDailySales_Click);
            // 
            // btnSearchProd
            // 
            this.btnSearchProd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(40)))), ((int)(((byte)(76)))));
            this.btnSearchProd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchProd.FlatAppearance.BorderSize = 0;
            this.btnSearchProd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchProd.Font = new System.Drawing.Font("Roboto Medium", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchProd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(206)))), ((int)(((byte)(222)))));
            this.btnSearchProd.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchProd.Image")));
            this.btnSearchProd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearchProd.Location = new System.Drawing.Point(0, 34);
            this.btnSearchProd.Name = "btnSearchProd";
            this.btnSearchProd.Size = new System.Drawing.Size(164, 28);
            this.btnSearchProd.TabIndex = 12;
            this.btnSearchProd.Text = "     Search Product";
            this.btnSearchProd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearchProd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearchProd.UseVisualStyleBackColor = false;
            this.btnSearchProd.Click += new System.EventHandler(this.BtnSearchProd_Click);
            // 
            // btnClearCart
            // 
            this.btnClearCart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(40)))), ((int)(((byte)(76)))));
            this.btnClearCart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearCart.Enabled = false;
            this.btnClearCart.FlatAppearance.BorderSize = 0;
            this.btnClearCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearCart.Font = new System.Drawing.Font("Roboto Medium", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearCart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(206)))), ((int)(((byte)(222)))));
            this.btnClearCart.Image = ((System.Drawing.Image)(resources.GetObject("btnClearCart.Image")));
            this.btnClearCart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClearCart.Location = new System.Drawing.Point(0, 135);
            this.btnClearCart.Name = "btnClearCart";
            this.btnClearCart.Size = new System.Drawing.Size(164, 28);
            this.btnClearCart.TabIndex = 15;
            this.btnClearCart.Text = "     Clear Cart";
            this.btnClearCart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClearCart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClearCart.UseVisualStyleBackColor = false;
            this.btnClearCart.Click += new System.EventHandler(this.BtnClearCart_Click);
            // 
            // btnAddDiscount
            // 
            this.btnAddDiscount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(40)))), ((int)(((byte)(76)))));
            this.btnAddDiscount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddDiscount.Enabled = false;
            this.btnAddDiscount.FlatAppearance.BorderSize = 0;
            this.btnAddDiscount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddDiscount.Font = new System.Drawing.Font("Roboto Medium", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddDiscount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(206)))), ((int)(((byte)(222)))));
            this.btnAddDiscount.Image = ((System.Drawing.Image)(resources.GetObject("btnAddDiscount.Image")));
            this.btnAddDiscount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddDiscount.Location = new System.Drawing.Point(0, 68);
            this.btnAddDiscount.Name = "btnAddDiscount";
            this.btnAddDiscount.Size = new System.Drawing.Size(164, 28);
            this.btnAddDiscount.TabIndex = 13;
            this.btnAddDiscount.Text = "     Add Discount";
            this.btnAddDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddDiscount.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddDiscount.UseVisualStyleBackColor = false;
            this.btnAddDiscount.Click += new System.EventHandler(this.BtnAddDiscount_Click);
            // 
            // btnSetPayment
            // 
            this.btnSetPayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(40)))), ((int)(((byte)(76)))));
            this.btnSetPayment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSetPayment.Enabled = false;
            this.btnSetPayment.FlatAppearance.BorderSize = 0;
            this.btnSetPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetPayment.Font = new System.Drawing.Font("Roboto Medium", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetPayment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(206)))), ((int)(((byte)(222)))));
            this.btnSetPayment.Image = ((System.Drawing.Image)(resources.GetObject("btnSetPayment.Image")));
            this.btnSetPayment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSetPayment.Location = new System.Drawing.Point(0, 101);
            this.btnSetPayment.Name = "btnSetPayment";
            this.btnSetPayment.Size = new System.Drawing.Size(164, 28);
            this.btnSetPayment.TabIndex = 14;
            this.btnSetPayment.Text = "     Settle Payment";
            this.btnSetPayment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSetPayment.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSetPayment.UseVisualStyleBackColor = false;
            this.btnSetPayment.Click += new System.EventHandler(this.BtnSetPayment_Click);
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(40)))), ((int)(((byte)(76)))));
            this.panel9.Controls.Add(this.label8);
            this.panel9.Controls.Add(this.label10);
            this.panel9.Controls.Add(this.lblVatable);
            this.panel9.Controls.Add(this.label12);
            this.panel9.Controls.Add(this.lblDiscount);
            this.panel9.Controls.Add(this.label17);
            this.panel9.Controls.Add(this.lblVat);
            this.panel9.Controls.Add(this.lblSalesTotal);
            this.panel9.Location = new System.Drawing.Point(614, 442);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(420, 109);
            this.panel9.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Roboto Medium", 10F);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(206)))), ((int)(((byte)(222)))));
            this.label8.Location = new System.Drawing.Point(9, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 17);
            this.label8.TabIndex = 0;
            this.label8.Text = "Sales Total";
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Roboto Medium", 10F);
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(206)))), ((int)(((byte)(222)))));
            this.label12.Location = new System.Drawing.Point(10, 58);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(30, 17);
            this.label12.TabIndex = 0;
            this.label12.Text = "Vat";
            // 
            // lblDiscount
            // 
            this.lblDiscount.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Font = new System.Drawing.Font("Roboto Medium", 10F);
            this.lblDiscount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(206)))), ((int)(((byte)(222)))));
            this.lblDiscount.Location = new System.Drawing.Point(378, 33);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(36, 17);
            this.lblDiscount.TabIndex = 0;
            this.lblDiscount.Text = "0.00";
            // 
            // lblVat
            // 
            this.lblVat.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblVat.AutoSize = true;
            this.lblVat.Font = new System.Drawing.Font("Roboto Medium", 10F);
            this.lblVat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(206)))), ((int)(((byte)(222)))));
            this.lblVat.Location = new System.Drawing.Point(378, 58);
            this.lblVat.Name = "lblVat";
            this.lblVat.Size = new System.Drawing.Size(36, 17);
            this.lblVat.TabIndex = 0;
            this.lblVat.Text = "0.00";
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(40)))), ((int)(((byte)(76)))));
            this.panel4.Controls.Add(this.txtQty);
            this.panel4.Controls.Add(this.txtSearch);
            this.panel4.Controls.Add(this.lblDateNo);
            this.panel4.Controls.Add(this.lblTransNo);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Font = new System.Drawing.Font("Roboto", 8.25F);
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1198, 31);
            this.panel4.TabIndex = 2;
            // 
            // txtQty
            // 
            this.txtQty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtQty.CustomButton.Image = null;
            this.txtQty.CustomButton.Location = new System.Drawing.Point(16, 1);
            this.txtQty.CustomButton.Name = "";
            this.txtQty.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtQty.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtQty.CustomButton.TabIndex = 1;
            this.txtQty.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtQty.CustomButton.UseSelectable = true;
            this.txtQty.CustomButton.Visible = false;
            this.txtQty.Enabled = false;
            this.txtQty.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
            this.txtQty.Lines = new string[] {
        "1"};
            this.txtQty.Location = new System.Drawing.Point(1149, 4);
            this.txtQty.MaxLength = 32767;
            this.txtQty.Name = "txtQty";
            this.txtQty.PasswordChar = '\0';
            this.txtQty.PromptText = "Qty";
            this.txtQty.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtQty.SelectedText = "";
            this.txtQty.SelectionLength = 0;
            this.txtQty.SelectionStart = 0;
            this.txtQty.ShortcutsEnabled = true;
            this.txtQty.Size = new System.Drawing.Size(38, 23);
            this.txtQty.TabIndex = 8;
            this.txtQty.Text = "1";
            this.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtQty.UseSelectable = true;
            this.txtQty.WaterMark = "Qty";
            this.txtQty.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtQty.WaterMarkFont = new System.Drawing.Font("Roboto", 10F);
            this.txtQty.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtSearch.CustomButton.Image = null;
            this.txtSearch.CustomButton.Location = new System.Drawing.Point(258, 1);
            this.txtSearch.CustomButton.Name = "";
            this.txtSearch.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtSearch.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtSearch.CustomButton.TabIndex = 1;
            this.txtSearch.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtSearch.CustomButton.UseSelectable = true;
            this.txtSearch.CustomButton.Visible = false;
            this.txtSearch.DisplayIcon = true;
            this.txtSearch.Icon = ((System.Drawing.Image)(resources.GetObject("txtSearch.Icon")));
            this.txtSearch.Lines = new string[0];
            this.txtSearch.Location = new System.Drawing.Point(864, 4);
            this.txtSearch.MaxLength = 32767;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.PromptText = "Search Barcode...";
            this.txtSearch.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtSearch.SelectedText = "";
            this.txtSearch.SelectionLength = 0;
            this.txtSearch.SelectionStart = 0;
            this.txtSearch.ShortcutsEnabled = true;
            this.txtSearch.Size = new System.Drawing.Size(280, 23);
            this.txtSearch.TabIndex = 8;
            this.txtSearch.UseSelectable = true;
            this.txtSearch.WaterMark = "Search Barcode...";
            this.txtSearch.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtSearch.WaterMarkFont = new System.Drawing.Font("Roboto", 10F);
            this.txtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);
            // 
            // lblDateNo
            // 
            this.lblDateNo.AutoSize = true;
            this.lblDateNo.Font = new System.Drawing.Font("Roboto Medium", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(206)))), ((int)(((byte)(222)))));
            this.lblDateNo.Location = new System.Drawing.Point(307, 8);
            this.lblDateNo.Name = "lblDateNo";
            this.lblDateNo.Size = new System.Drawing.Size(112, 17);
            this.lblDateNo.TabIndex = 0;
            this.lblDateNo.Text = "0000000000000";
            // 
            // lblTransNo
            // 
            this.lblTransNo.AutoSize = true;
            this.lblTransNo.Font = new System.Drawing.Font("Roboto Medium", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(113)))), ((int)(((byte)(74)))));
            this.lblTransNo.Location = new System.Drawing.Point(123, 8);
            this.lblTransNo.Name = "lblTransNo";
            this.lblTransNo.Size = new System.Drawing.Size(112, 17);
            this.lblTransNo.TabIndex = 0;
            this.lblTransNo.Text = "0000000000000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Roboto Medium", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(206)))), ((int)(((byte)(222)))));
            this.label5.Location = new System.Drawing.Point(260, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Roboto Medium", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(206)))), ((int)(((byte)(222)))));
            this.label3.Location = new System.Drawing.Point(5, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Transaction No.";
            // 
            // dgvBrandList
            // 
            this.dgvBrandList.AllowUserToAddRows = false;
            this.dgvBrandList.BackgroundColor = System.Drawing.Color.White;
            this.dgvBrandList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(40)))), ((int)(((byte)(76)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Roboto Medium", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(206)))), ((int)(((byte)(222)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBrandList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBrandList.ColumnHeadersHeight = 30;
            this.dgvBrandList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvBrandList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column8,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column7,
            this.Column6,
            this.colAdd,
            this.colRemove,
            this.Delete});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Roboto Thin", 10F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBrandList.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvBrandList.EnableHeadersVisualStyles = false;
            this.dgvBrandList.GridColor = System.Drawing.Color.White;
            this.dgvBrandList.Location = new System.Drawing.Point(2, 33);
            this.dgvBrandList.Name = "dgvBrandList";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Roboto", 10F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBrandList.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvBrandList.RowHeadersVisible = false;
            this.dgvBrandList.Size = new System.Drawing.Size(1032, 408);
            this.dgvBrandList.TabIndex = 4;
            this.dgvBrandList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvBrandList_CellContentClick);
            this.dgvBrandList.SelectionChanged += new System.EventHandler(this.DgvBrandList_SelectionChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(63, 47);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 47);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1198, 551);
            this.panel2.TabIndex = 10;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Roboto Medium", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(206)))), ((int)(((byte)(222)))));
            this.lblName.Location = new System.Drawing.Point(65, 29);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(50, 17);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Walter";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(40)))), ((int)(((byte)(76)))));
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.lblUser);
            this.panel5.Controls.Add(this.lblName);
            this.panel5.Controls.Add(this.lblDisplayTotal);
            this.panel5.Controls.Add(this.pictureBox1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1198, 47);
            this.panel5.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("AvenirNext LT Pro Bold", 15.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(101)))), ((int)(((byte)(155)))));
            this.label2.Location = new System.Drawing.Point(65, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "POS System";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Roboto Medium", 10F);
            this.lblUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(206)))), ((int)(((byte)(222)))));
            this.lblUser.Location = new System.Drawing.Point(374, 29);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(50, 17);
            this.lblUser.TabIndex = 1;
            this.lblUser.Text = "Walter";
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column1.HeaderText = "#";
            this.Column1.Name = "Column1";
            this.Column1.Width = 40;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "ID";
            this.Column2.Name = "Column2";
            this.Column2.Visible = false;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "PCode";
            this.Column8.Name = "Column8";
            this.Column8.Visible = false;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "Description";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column4.HeaderText = "Price";
            this.Column4.Name = "Column4";
            this.Column4.Width = 64;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column5.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column5.HeaderText = "Qty";
            this.Column5.Name = "Column5";
            this.Column5.Width = 53;
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column7.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column7.HeaderText = "Discount";
            this.Column7.Name = "Column7";
            this.Column7.Width = 87;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column6.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column6.HeaderText = "Total";
            this.Column6.Name = "Column6";
            this.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column6.Width = 64;
            // 
            // colAdd
            // 
            this.colAdd.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colAdd.HeaderText = "";
            this.colAdd.Name = "colAdd";
            this.colAdd.Width = 5;
            // 
            // colRemove
            // 
            this.colRemove.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colRemove.HeaderText = "";
            this.colRemove.Name = "colRemove";
            this.colRemove.Width = 5;
            // 
            // Delete
            // 
            this.Delete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Delete.HeaderText = "";
            this.Delete.Image = ((System.Drawing.Image)(resources.GetObject("Delete.Image")));
            this.Delete.Name = "Delete";
            this.Delete.Width = 5;
            // 
            // frmPOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1198, 598);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel5);
            this.Font = new System.Drawing.Font("Roboto Medium", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmPOS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmPOS_KeyDown);
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBrandList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label17;
        public System.Windows.Forms.Label lblSalesTotal;
        private System.Windows.Forms.Label lblDisplayTotal;
        public System.Windows.Forms.Label lblVatable;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel4;
        public MetroFramework.Controls.MetroTextBox txtSearch;
        private System.Windows.Forms.Label lblDateNo;
        public System.Windows.Forms.Label lblTransNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.Label lblDiscount;
        public System.Windows.Forms.Label lblVat;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label lblUser;
        public MetroFramework.Controls.MetroTextBox txtQty;
        public System.Windows.Forms.DataGridView dgvBrandList;
        private System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.Button btnDailySales;
        public System.Windows.Forms.Button btnSearchProd;
        public System.Windows.Forms.Button btnClearCart;
        public System.Windows.Forms.Button btnAddDiscount;
        public System.Windows.Forms.Button btnSetPayment;
        public System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewButtonColumn colAdd;
        private System.Windows.Forms.DataGridViewButtonColumn colRemove;
        private System.Windows.Forms.DataGridViewImageColumn Delete;
    }
}