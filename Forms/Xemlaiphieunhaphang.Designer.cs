namespace quanlyshopquanao
{
    partial class Xemlaiphieunhaphang
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lblTongTien = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.dtpToDate = new System.Windows.Forms.DateTimePicker();
			this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.lvDS = new System.Windows.Forms.ListView();
			this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.lblTongTien);
			this.groupBox1.Controls.Add(this.label11);
			this.groupBox1.Controls.Add(this.dtpToDate);
			this.groupBox1.Controls.Add(this.dtpFromDate);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(1028, 97);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Tìm theo điều kiện";
			// 
			// lblTongTien
			// 
			this.lblTongTien.AutoSize = true;
			this.lblTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTongTien.ForeColor = System.Drawing.Color.Red;
			this.lblTongTien.Location = new System.Drawing.Point(111, 66);
			this.lblTongTien.Name = "lblTongTien";
			this.lblTongTien.Size = new System.Drawing.Size(15, 16);
			this.lblTongTien.TabIndex = 18;
			this.lblTongTien.Text = "0";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label11.ForeColor = System.Drawing.Color.Red;
			this.label11.Location = new System.Drawing.Point(6, 66);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(101, 16);
			this.label11.TabIndex = 17;
			this.label11.Text = "Tổng số tiền: ";
			// 
			// dtpToDate
			// 
			this.dtpToDate.CustomFormat = "dd/MM/yy";
			this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpToDate.Location = new System.Drawing.Point(275, 21);
			this.dtpToDate.Name = "dtpToDate";
			this.dtpToDate.Size = new System.Drawing.Size(102, 22);
			this.dtpToDate.TabIndex = 4;
			// 
			// dtpFromDate
			// 
			this.dtpFromDate.CustomFormat = "dd/MM/yy";
			this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpFromDate.Location = new System.Drawing.Point(78, 21);
			this.dtpFromDate.Name = "dtpFromDate";
			this.dtpFromDate.Size = new System.Drawing.Size(102, 22);
			this.dtpFromDate.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(196, 21);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Đến ngày";
			this.label2.Click += new System.EventHandler(this.label2_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Từ ngày";
			// 
			// lvDS
			// 
			this.lvDS.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14});
			this.lvDS.FullRowSelect = true;
			this.lvDS.GridLines = true;
			this.lvDS.HideSelection = false;
			this.lvDS.Location = new System.Drawing.Point(12, 115);
			this.lvDS.Name = "lvDS";
			this.lvDS.Size = new System.Drawing.Size(1028, 486);
			this.lvDS.TabIndex = 18;
			this.lvDS.UseCompatibleStateImageBehavior = false;
			this.lvDS.View = System.Windows.Forms.View.Details;
			this.lvDS.DoubleClick += new System.EventHandler(this.lvDS_DoubleClick);
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Mã phiếu";
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "Nhân viên";
			this.columnHeader6.Width = 130;
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "Ngày nhập";
			this.columnHeader7.Width = 90;
			// 
			// columnHeader8
			// 
			this.columnHeader8.Text = "Nguồn hàng";
			this.columnHeader8.Width = 80;
			// 
			// columnHeader9
			// 
			this.columnHeader9.Text = "Tiền hàng";
			this.columnHeader9.Width = 80;
			// 
			// columnHeader10
			// 
			this.columnHeader10.Text = "Phí ship";
			this.columnHeader10.Width = 80;
			// 
			// columnHeader11
			// 
			this.columnHeader11.Text = "Tiền thuế";
			this.columnHeader11.Width = 80;
			// 
			// columnHeader12
			// 
			this.columnHeader12.Text = "Chi phí khác ";
			this.columnHeader12.Width = 80;
			// 
			// columnHeader13
			// 
			this.columnHeader13.Text = "Thành tiền";
			this.columnHeader13.Width = 80;
			// 
			// columnHeader14
			// 
			this.columnHeader14.Text = "Ghi chú";
			this.columnHeader14.Width = 260;
			// 
			// Xemlaiphieunhaphang
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1052, 613);
			this.Controls.Add(this.lvDS);
			this.Controls.Add(this.groupBox1);
			this.Name = "Xemlaiphieunhaphang";
			this.Text = "Xem lại phiếu nhập";
			this.Load += new System.EventHandler(this.Xemlaiphieunhaphang_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ListView lvDS;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.Label lblTongTien;
    }
}