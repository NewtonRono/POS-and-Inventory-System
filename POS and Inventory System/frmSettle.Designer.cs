namespace POS_and_Inventory_System
{
    partial class frmSettle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettle));
            this.label1 = new System.Windows.Forms.Label();
            this.txtSale = new System.Windows.Forms.TextBox();
            this.txtCash = new System.Windows.Forms.TextBox();
            this.txtChange = new System.Windows.Forms.TextBox();
            this.btnEnter = new System.Windows.Forms.Button();
            this.btn00 = new System.Windows.Forms.Button();
            this.btn0 = new System.Windows.Forms.Button();
            this.btnC = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.btn6 = new System.Windows.Forms.Button();
            this.btn9 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            this.btn5 = new System.Windows.Forms.Button();
            this.btn4 = new System.Windows.Forms.Button();
            this.btn8 = new System.Windows.Forms.Button();
            this.btn7 = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(36)))), ((int)(((byte)(71)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Roboto Black", 12F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(268, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Settle Payment";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSale
            // 
            this.txtSale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(26)))), ((int)(((byte)(54)))));
            this.txtSale.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSale.Font = new System.Drawing.Font("Roboto Medium", 14F);
            this.txtSale.ForeColor = System.Drawing.Color.White;
            this.txtSale.Location = new System.Drawing.Point(8, 35);
            this.txtSale.Margin = new System.Windows.Forms.Padding(4);
            this.txtSale.Name = "txtSale";
            this.txtSale.ReadOnly = true;
            this.txtSale.Size = new System.Drawing.Size(250, 23);
            this.txtSale.TabIndex = 2;
            this.txtSale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCash
            // 
            this.txtCash.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(26)))), ((int)(((byte)(54)))));
            this.txtCash.Font = new System.Drawing.Font("Roboto Medium", 14F);
            this.txtCash.ForeColor = System.Drawing.Color.White;
            this.txtCash.Location = new System.Drawing.Point(8, 69);
            this.txtCash.Margin = new System.Windows.Forms.Padding(4);
            this.txtCash.Name = "txtCash";
            this.txtCash.Size = new System.Drawing.Size(250, 30);
            this.txtCash.TabIndex = 0;
            this.txtCash.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCash.TextChanged += new System.EventHandler(this.TxtCash_TextChanged);
            // 
            // txtChange
            // 
            this.txtChange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(26)))), ((int)(((byte)(54)))));
            this.txtChange.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtChange.Font = new System.Drawing.Font("Roboto Medium", 14F);
            this.txtChange.ForeColor = System.Drawing.Color.White;
            this.txtChange.Location = new System.Drawing.Point(8, 108);
            this.txtChange.Margin = new System.Windows.Forms.Padding(4);
            this.txtChange.Name = "txtChange";
            this.txtChange.ReadOnly = true;
            this.txtChange.Size = new System.Drawing.Size(250, 23);
            this.txtChange.TabIndex = 1;
            this.txtChange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnEnter
            // 
            this.btnEnter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(26)))), ((int)(((byte)(54)))));
            this.btnEnter.FlatAppearance.BorderSize = 0;
            this.btnEnter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnter.Font = new System.Drawing.Font("Roboto Medium", 16F);
            this.btnEnter.ForeColor = System.Drawing.Color.White;
            this.btnEnter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEnter.Location = new System.Drawing.Point(8, 330);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(250, 55);
            this.btnEnter.TabIndex = 13;
            this.btnEnter.Text = "Enter";
            this.btnEnter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEnter.UseVisualStyleBackColor = false;
            this.btnEnter.Click += new System.EventHandler(this.BtnEnter_Click);
            // 
            // btn00
            // 
            this.btn00.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(26)))), ((int)(((byte)(54)))));
            this.btn00.FlatAppearance.BorderSize = 0;
            this.btn00.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn00.Font = new System.Drawing.Font("AvenirNext LT Pro Regular", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn00.ForeColor = System.Drawing.Color.White;
            this.btn00.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn00.Location = new System.Drawing.Point(198, 264);
            this.btn00.Name = "btn00";
            this.btn00.Size = new System.Drawing.Size(60, 55);
            this.btn00.TabIndex = 14;
            this.btn00.Text = "00";
            this.btn00.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn00.UseVisualStyleBackColor = false;
            this.btn00.Click += new System.EventHandler(this.Btn00_Click);
            // 
            // btn0
            // 
            this.btn0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(26)))), ((int)(((byte)(54)))));
            this.btn0.FlatAppearance.BorderSize = 0;
            this.btn0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn0.Font = new System.Drawing.Font("AvenirNext LT Pro Regular", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn0.ForeColor = System.Drawing.Color.White;
            this.btn0.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn0.Location = new System.Drawing.Point(198, 203);
            this.btn0.Name = "btn0";
            this.btn0.Size = new System.Drawing.Size(60, 55);
            this.btn0.TabIndex = 15;
            this.btn0.Text = "0";
            this.btn0.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn0.UseVisualStyleBackColor = false;
            this.btn0.Click += new System.EventHandler(this.Btn0_Click);
            // 
            // btnC
            // 
            this.btnC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(26)))), ((int)(((byte)(54)))));
            this.btnC.FlatAppearance.BorderSize = 0;
            this.btnC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnC.Font = new System.Drawing.Font("AvenirNext LT Pro Regular", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnC.ForeColor = System.Drawing.Color.White;
            this.btnC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnC.Location = new System.Drawing.Point(198, 142);
            this.btnC.Name = "btnC";
            this.btnC.Size = new System.Drawing.Size(60, 55);
            this.btnC.TabIndex = 16;
            this.btnC.Text = "C";
            this.btnC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnC.UseVisualStyleBackColor = false;
            this.btnC.Click += new System.EventHandler(this.BtnC_Click);
            // 
            // btn3
            // 
            this.btn3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(26)))), ((int)(((byte)(54)))));
            this.btn3.FlatAppearance.BorderSize = 0;
            this.btn3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn3.Font = new System.Drawing.Font("AvenirNext LT Pro Regular", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn3.ForeColor = System.Drawing.Color.White;
            this.btn3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn3.Location = new System.Drawing.Point(135, 264);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(60, 55);
            this.btn3.TabIndex = 17;
            this.btn3.Text = "3";
            this.btn3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn3.UseVisualStyleBackColor = false;
            this.btn3.Click += new System.EventHandler(this.Btn3_Click);
            // 
            // btn6
            // 
            this.btn6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(26)))), ((int)(((byte)(54)))));
            this.btn6.FlatAppearance.BorderSize = 0;
            this.btn6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn6.Font = new System.Drawing.Font("AvenirNext LT Pro Regular", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn6.ForeColor = System.Drawing.Color.White;
            this.btn6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn6.Location = new System.Drawing.Point(135, 203);
            this.btn6.Name = "btn6";
            this.btn6.Size = new System.Drawing.Size(60, 55);
            this.btn6.TabIndex = 18;
            this.btn6.Text = "6";
            this.btn6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn6.UseVisualStyleBackColor = false;
            this.btn6.Click += new System.EventHandler(this.Btn6_Click);
            // 
            // btn9
            // 
            this.btn9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(26)))), ((int)(((byte)(54)))));
            this.btn9.FlatAppearance.BorderSize = 0;
            this.btn9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn9.Font = new System.Drawing.Font("AvenirNext LT Pro Regular", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn9.ForeColor = System.Drawing.Color.White;
            this.btn9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn9.Location = new System.Drawing.Point(135, 142);
            this.btn9.Name = "btn9";
            this.btn9.Size = new System.Drawing.Size(60, 55);
            this.btn9.TabIndex = 19;
            this.btn9.Text = "9";
            this.btn9.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn9.UseVisualStyleBackColor = false;
            this.btn9.Click += new System.EventHandler(this.Btn9_Click);
            // 
            // btn2
            // 
            this.btn2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(26)))), ((int)(((byte)(54)))));
            this.btn2.FlatAppearance.BorderSize = 0;
            this.btn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn2.Font = new System.Drawing.Font("AvenirNext LT Pro Regular", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn2.ForeColor = System.Drawing.Color.White;
            this.btn2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn2.Location = new System.Drawing.Point(72, 264);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(60, 55);
            this.btn2.TabIndex = 20;
            this.btn2.Text = "2";
            this.btn2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn2.UseVisualStyleBackColor = false;
            this.btn2.Click += new System.EventHandler(this.Btn2_Click);
            // 
            // btn1
            // 
            this.btn1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(26)))), ((int)(((byte)(54)))));
            this.btn1.FlatAppearance.BorderSize = 0;
            this.btn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn1.Font = new System.Drawing.Font("AvenirNext LT Pro Regular", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn1.ForeColor = System.Drawing.Color.White;
            this.btn1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn1.Location = new System.Drawing.Point(8, 264);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(60, 55);
            this.btn1.TabIndex = 21;
            this.btn1.Text = "1";
            this.btn1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn1.UseVisualStyleBackColor = false;
            this.btn1.Click += new System.EventHandler(this.Btn1_Click);
            // 
            // btn5
            // 
            this.btn5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(26)))), ((int)(((byte)(54)))));
            this.btn5.FlatAppearance.BorderSize = 0;
            this.btn5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn5.Font = new System.Drawing.Font("AvenirNext LT Pro Regular", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn5.ForeColor = System.Drawing.Color.White;
            this.btn5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn5.Location = new System.Drawing.Point(72, 203);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(60, 55);
            this.btn5.TabIndex = 22;
            this.btn5.Text = "5";
            this.btn5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn5.UseVisualStyleBackColor = false;
            this.btn5.Click += new System.EventHandler(this.Btn5_Click);
            // 
            // btn4
            // 
            this.btn4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(26)))), ((int)(((byte)(54)))));
            this.btn4.FlatAppearance.BorderSize = 0;
            this.btn4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn4.Font = new System.Drawing.Font("AvenirNext LT Pro Regular", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn4.ForeColor = System.Drawing.Color.White;
            this.btn4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn4.Location = new System.Drawing.Point(8, 203);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(60, 55);
            this.btn4.TabIndex = 23;
            this.btn4.Text = "4";
            this.btn4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn4.UseVisualStyleBackColor = false;
            this.btn4.Click += new System.EventHandler(this.Btn4_Click);
            // 
            // btn8
            // 
            this.btn8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(26)))), ((int)(((byte)(54)))));
            this.btn8.FlatAppearance.BorderSize = 0;
            this.btn8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn8.Font = new System.Drawing.Font("AvenirNext LT Pro Regular", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn8.ForeColor = System.Drawing.Color.White;
            this.btn8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn8.Location = new System.Drawing.Point(72, 142);
            this.btn8.Name = "btn8";
            this.btn8.Size = new System.Drawing.Size(60, 55);
            this.btn8.TabIndex = 24;
            this.btn8.Text = "8";
            this.btn8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn8.UseVisualStyleBackColor = false;
            this.btn8.Click += new System.EventHandler(this.Btn8_Click);
            // 
            // btn7
            // 
            this.btn7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(26)))), ((int)(((byte)(54)))));
            this.btn7.FlatAppearance.BorderSize = 0;
            this.btn7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn7.Font = new System.Drawing.Font("AvenirNext LT Pro Regular", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn7.ForeColor = System.Drawing.Color.White;
            this.btn7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn7.Location = new System.Drawing.Point(8, 142);
            this.btn7.Name = "btn7";
            this.btn7.Size = new System.Drawing.Size(60, 55);
            this.btn7.TabIndex = 25;
            this.btn7.Text = "7";
            this.btn7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn7.UseVisualStyleBackColor = false;
            this.btn7.Click += new System.EventHandler(this.Btn7_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(26)))), ((int)(((byte)(54)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Firebrick;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(36)))), ((int)(((byte)(71)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(218, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(50, 25);
            this.btnClose.TabIndex = 26;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // frmSettle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(36)))), ((int)(((byte)(71)))));
            this.ClientSize = new System.Drawing.Size(268, 397);
            this.ControlBox = false;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.btn00);
            this.Controls.Add(this.btn0);
            this.Controls.Add(this.btnC);
            this.Controls.Add(this.btn3);
            this.Controls.Add(this.btn6);
            this.Controls.Add(this.btn9);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.btn5);
            this.Controls.Add(this.btn4);
            this.Controls.Add(this.btn8);
            this.Controls.Add(this.btn7);
            this.Controls.Add(this.txtChange);
            this.Controls.Add(this.txtCash);
            this.Controls.Add(this.txtSale);
            this.Font = new System.Drawing.Font("Gotham Book", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmSettle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSettle_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button btnEnter;
        public System.Windows.Forms.Button btn00;
        public System.Windows.Forms.Button btn0;
        public System.Windows.Forms.Button btnC;
        public System.Windows.Forms.Button btn3;
        public System.Windows.Forms.Button btn6;
        public System.Windows.Forms.Button btn9;
        public System.Windows.Forms.Button btn2;
        public System.Windows.Forms.Button btn1;
        public System.Windows.Forms.Button btn5;
        public System.Windows.Forms.Button btn4;
        public System.Windows.Forms.Button btn8;
        public System.Windows.Forms.Button btn7;
        public System.Windows.Forms.TextBox txtSale;
        public System.Windows.Forms.TextBox txtCash;
        public System.Windows.Forms.TextBox txtChange;
        private System.Windows.Forms.Button btnClose;
    }
}