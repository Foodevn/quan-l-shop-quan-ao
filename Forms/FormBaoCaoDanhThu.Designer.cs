namespace Chitietphieunhau
{
    partial class FormBaoCaoDanhThu
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
			this.dtpToDate = new System.Windows.Forms.DateTimePicker();
			this.label3 = new System.Windows.Forms.Label();
			this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.lvNhapHang = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.lblSLPhieuNhap = new System.Windows.Forms.Label();
			this.lblTongTienMuaHang = new System.Windows.Forms.Label();
			this.lblTongTienVanChuyen = new System.Windows.Forms.Label();
			this.lblTongTienThue = new System.Windows.Forms.Label();
			this.lblTongChiPhiKhac = new System.Windows.Forms.Label();
			this.lblTongChiPhiNhapHang = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.lblVat = new System.Windows.Forms.Label();
			this.lblTrangThai = new System.Windows.Forms.Label();
			this.lblShip = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.lvBanHang = new System.Windows.Forms.ListView();
			this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.label13 = new System.Windows.Forms.Label();
			this.lblTongDanhThuBanHang = new System.Windows.Forms.Label();
			this.labelTongTienBanHang = new System.Windows.Forms.Label();
			this.labelSoLuongDonHang = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.dtpToDate);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.dtpFromDate);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(1028, 88);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Chọn Khoảng Thời Gian";
			this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
			// 
			// dtpToDate
			// 
			this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpToDate.Location = new System.Drawing.Point(357, 53);
			this.dtpToDate.Name = "dtpToDate";
			this.dtpToDate.Size = new System.Drawing.Size(200, 22);
			this.dtpToDate.TabIndex = 2;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(264, 59);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(67, 16);
			this.label3.TabIndex = 2;
			this.label3.Text = "Đến Ngày";
			this.label3.Click += new System.EventHandler(this.label3_Click);
			// 
			// dtpFromDate
			// 
			this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpFromDate.Location = new System.Drawing.Point(93, 53);
			this.dtpFromDate.Name = "dtpFromDate";
			this.dtpFromDate.Size = new System.Drawing.Size(152, 22);
			this.dtpFromDate.TabIndex = 2;
			this.dtpFromDate.Value = new System.DateTime(2024, 1, 1, 0, 0, 0, 0);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 59);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(59, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "Từ Ngày";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 29);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(65, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "Thời Gian";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.lvNhapHang);
			this.groupBox2.Controls.Add(this.lblSLPhieuNhap);
			this.groupBox2.Controls.Add(this.lblTongTienMuaHang);
			this.groupBox2.Controls.Add(this.lblTongTienVanChuyen);
			this.groupBox2.Controls.Add(this.lblTongTienThue);
			this.groupBox2.Controls.Add(this.lblTongChiPhiKhac);
			this.groupBox2.Controls.Add(this.lblTongChiPhiNhapHang);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Location = new System.Drawing.Point(12, 121);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(527, 480);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Thống Kê Nhập Hàng";
			this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
			// 
			// lvNhapHang
			// 
			this.lvNhapHang.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
			this.lvNhapHang.GridLines = true;
			this.lvNhapHang.HideSelection = false;
			this.lvNhapHang.Location = new System.Drawing.Point(9, 236);
			this.lvNhapHang.Name = "lvNhapHang";
			this.lvNhapHang.Size = new System.Drawing.Size(498, 227);
			this.lvNhapHang.TabIndex = 8;
			this.lvNhapHang.UseCompatibleStateImageBehavior = false;
			this.lvNhapHang.View = System.Windows.Forms.View.Details;
			this.lvNhapHang.SelectedIndexChanged += new System.EventHandler(this.lvNhapHang_SelectedIndexChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Mã Hàng";
			this.columnHeader1.Width = 77;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Tên Hàng";
			this.columnHeader2.Width = 89;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Số Lượng";
			this.columnHeader3.Width = 87;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Thành Tiền";
			this.columnHeader4.Width = 261;
			// 
			// lblSLPhieuNhap
			// 
			this.lblSLPhieuNhap.AutoSize = true;
			this.lblSLPhieuNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.lblSLPhieuNhap.Location = new System.Drawing.Point(194, 34);
			this.lblSLPhieuNhap.Name = "lblSLPhieuNhap";
			this.lblSLPhieuNhap.Size = new System.Drawing.Size(15, 16);
			this.lblSLPhieuNhap.TabIndex = 2;
			this.lblSLPhieuNhap.Text = "0";
			this.lblSLPhieuNhap.Click += new System.EventHandler(this.lblSLPhieuNhap_Click);
			// 
			// lblTongTienMuaHang
			// 
			this.lblTongTienMuaHang.AutoSize = true;
			this.lblTongTienMuaHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.lblTongTienMuaHang.Location = new System.Drawing.Point(194, 65);
			this.lblTongTienMuaHang.Name = "lblTongTienMuaHang";
			this.lblTongTienMuaHang.Size = new System.Drawing.Size(15, 16);
			this.lblTongTienMuaHang.TabIndex = 3;
			this.lblTongTienMuaHang.Text = "0";
			// 
			// lblTongTienVanChuyen
			// 
			this.lblTongTienVanChuyen.AutoSize = true;
			this.lblTongTienVanChuyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.lblTongTienVanChuyen.Location = new System.Drawing.Point(194, 98);
			this.lblTongTienVanChuyen.Name = "lblTongTienVanChuyen";
			this.lblTongTienVanChuyen.Size = new System.Drawing.Size(15, 16);
			this.lblTongTienVanChuyen.TabIndex = 4;
			this.lblTongTienVanChuyen.Text = "0";
			this.lblTongTienVanChuyen.Click += new System.EventHandler(this.label12_Click);
			// 
			// lblTongTienThue
			// 
			this.lblTongTienThue.AutoSize = true;
			this.lblTongTienThue.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.lblTongTienThue.Location = new System.Drawing.Point(194, 131);
			this.lblTongTienThue.Name = "lblTongTienThue";
			this.lblTongTienThue.Size = new System.Drawing.Size(15, 16);
			this.lblTongTienThue.TabIndex = 5;
			this.lblTongTienThue.Text = "0";
			this.lblTongTienThue.Click += new System.EventHandler(this.label13_Click);
			// 
			// lblTongChiPhiKhac
			// 
			this.lblTongChiPhiKhac.AutoSize = true;
			this.lblTongChiPhiKhac.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.lblTongChiPhiKhac.Location = new System.Drawing.Point(194, 164);
			this.lblTongChiPhiKhac.Name = "lblTongChiPhiKhac";
			this.lblTongChiPhiKhac.Size = new System.Drawing.Size(15, 16);
			this.lblTongChiPhiKhac.TabIndex = 6;
			this.lblTongChiPhiKhac.Text = "0";
			this.lblTongChiPhiKhac.Click += new System.EventHandler(this.label14_Click);
			// 
			// lblTongChiPhiNhapHang
			// 
			this.lblTongChiPhiNhapHang.AutoSize = true;
			this.lblTongChiPhiNhapHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.lblTongChiPhiNhapHang.ForeColor = System.Drawing.Color.Red;
			this.lblTongChiPhiNhapHang.Location = new System.Drawing.Point(194, 204);
			this.lblTongChiPhiNhapHang.Name = "lblTongChiPhiNhapHang";
			this.lblTongChiPhiNhapHang.Size = new System.Drawing.Size(15, 16);
			this.lblTongChiPhiNhapHang.TabIndex = 7;
			this.lblTongChiPhiNhapHang.Text = "0";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.ForeColor = System.Drawing.Color.Red;
			this.label9.Location = new System.Drawing.Point(6, 204);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(155, 16);
			this.label9.TabIndex = 5;
			this.label9.Text = "Tổng Chi Phí Nhập Hàng";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(6, 164);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(116, 16);
			this.label8.TabIndex = 4;
			this.label8.Text = "Tổng Chi Phí Khác";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(6, 131);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(103, 16);
			this.label7.TabIndex = 3;
			this.label7.Text = "Tổng Tiền Thuế";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(6, 98);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(144, 16);
			this.label6.TabIndex = 2;
			this.label6.Text = "Tổng Tiền Vận Chuyển";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 65);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(134, 16);
			this.label5.TabIndex = 1;
			this.label5.Text = "Tổng Tiền Mua Hàng";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 34);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(137, 16);
			this.label4.TabIndex = 0;
			this.label4.Text = "Số Lượng Phiếu Nhập";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.lblVat);
			this.groupBox3.Controls.Add(this.lblTrangThai);
			this.groupBox3.Controls.Add(this.lblShip);
			this.groupBox3.Controls.Add(this.label14);
			this.groupBox3.Controls.Add(this.label12);
			this.groupBox3.Controls.Add(this.lvBanHang);
			this.groupBox3.Controls.Add(this.label13);
			this.groupBox3.Controls.Add(this.lblTongDanhThuBanHang);
			this.groupBox3.Controls.Add(this.labelTongTienBanHang);
			this.groupBox3.Controls.Add(this.labelSoLuongDonHang);
			this.groupBox3.Controls.Add(this.label15);
			this.groupBox3.Controls.Add(this.label11);
			this.groupBox3.Controls.Add(this.label10);
			this.groupBox3.Location = new System.Drawing.Point(561, 121);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(479, 480);
			this.groupBox3.TabIndex = 9;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Thống Kê Bán Hàng";
			// 
			// lblVat
			// 
			this.lblVat.AutoSize = true;
			this.lblVat.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblVat.Location = new System.Drawing.Point(208, 131);
			this.lblVat.Name = "lblVat";
			this.lblVat.Size = new System.Drawing.Size(15, 16);
			this.lblVat.TabIndex = 16;
			this.lblVat.Text = "0";
			// 
			// lblTrangThai
			// 
			this.lblTrangThai.AutoSize = true;
			this.lblTrangThai.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTrangThai.Location = new System.Drawing.Point(208, 164);
			this.lblTrangThai.Name = "lblTrangThai";
			this.lblTrangThai.Size = new System.Drawing.Size(15, 16);
			this.lblTrangThai.TabIndex = 15;
			this.lblTrangThai.Text = "0";
			// 
			// lblShip
			// 
			this.lblShip.AutoSize = true;
			this.lblShip.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblShip.Location = new System.Drawing.Point(208, 98);
			this.lblShip.Name = "lblShip";
			this.lblShip.Size = new System.Drawing.Size(15, 16);
			this.lblShip.TabIndex = 14;
			this.lblShip.Text = "0";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(6, 164);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(146, 16);
			this.label14.TabIndex = 10;
			this.label14.Text = "Số đơn chưa thanh toán";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(6, 131);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(103, 16);
			this.label12.TabIndex = 10;
			this.label12.Text = "Tổng Tiền Thuế";
			// 
			// lvBanHang
			// 
			this.lvBanHang.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
			this.lvBanHang.GridLines = true;
			this.lvBanHang.HideSelection = false;
			this.lvBanHang.Location = new System.Drawing.Point(14, 236);
			this.lvBanHang.Name = "lvBanHang";
			this.lvBanHang.Size = new System.Drawing.Size(445, 227);
			this.lvBanHang.TabIndex = 9;
			this.lvBanHang.UseCompatibleStateImageBehavior = false;
			this.lvBanHang.View = System.Windows.Forms.View.Details;
			this.lvBanHang.SelectedIndexChanged += new System.EventHandler(this.lvBanHang_SelectedIndexChanged);
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Mã Hàng";
			this.columnHeader5.Width = 77;
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "Tên Hàng";
			this.columnHeader6.Width = 89;
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "Số Lượng";
			this.columnHeader7.Width = 87;
			// 
			// columnHeader8
			// 
			this.columnHeader8.Text = "Thành Tiền";
			this.columnHeader8.Width = 261;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(6, 98);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(99, 16);
			this.label13.TabIndex = 9;
			this.label13.Text = "Tổng Tiền Ship";
			// 
			// lblTongDanhThuBanHang
			// 
			this.lblTongDanhThuBanHang.AutoSize = true;
			this.lblTongDanhThuBanHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.lblTongDanhThuBanHang.ForeColor = System.Drawing.Color.Red;
			this.lblTongDanhThuBanHang.Location = new System.Drawing.Point(208, 204);
			this.lblTongDanhThuBanHang.Name = "lblTongDanhThuBanHang";
			this.lblTongDanhThuBanHang.Size = new System.Drawing.Size(15, 16);
			this.lblTongDanhThuBanHang.TabIndex = 9;
			this.lblTongDanhThuBanHang.Text = "0";
			// 
			// labelTongTienBanHang
			// 
			this.labelTongTienBanHang.AutoSize = true;
			this.labelTongTienBanHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.labelTongTienBanHang.Location = new System.Drawing.Point(208, 65);
			this.labelTongTienBanHang.Name = "labelTongTienBanHang";
			this.labelTongTienBanHang.Size = new System.Drawing.Size(15, 16);
			this.labelTongTienBanHang.TabIndex = 13;
			this.labelTongTienBanHang.Text = "0";
			// 
			// labelSoLuongDonHang
			// 
			this.labelSoLuongDonHang.AutoSize = true;
			this.labelSoLuongDonHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.labelSoLuongDonHang.Location = new System.Drawing.Point(208, 34);
			this.labelSoLuongDonHang.Name = "labelSoLuongDonHang";
			this.labelSoLuongDonHang.Size = new System.Drawing.Size(15, 16);
			this.labelSoLuongDonHang.TabIndex = 9;
			this.labelSoLuongDonHang.Text = "0";
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.ForeColor = System.Drawing.Color.Red;
			this.label15.Location = new System.Drawing.Point(11, 204);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(163, 16);
			this.label15.TabIndex = 5;
			this.label15.Text = "Tổng Danh Thu Bán Hàng";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(6, 65);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(132, 16);
			this.label11.TabIndex = 1;
			this.label11.Text = "Tổng Tiền Bán Hàng";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(10, 34);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(127, 16);
			this.label10.TabIndex = 0;
			this.label10.Text = "Số Lượng Đơn Hàng";
			// 
			// FormBaoCaoDanhThu
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1052, 613);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "FormBaoCaoDanhThu";
			this.Text = "Báo Cáo Danh Thu";
			this.Load += new System.EventHandler(this.FormBaoCaoDanhThu_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblSLPhieuNhap;
        private System.Windows.Forms.Label lblTongTienMuaHang;
        private System.Windows.Forms.Label lblTongTienVanChuyen;
        private System.Windows.Forms.Label lblTongTienThue;
        private System.Windows.Forms.Label lblTongChiPhiKhac;
        private System.Windows.Forms.Label lblTongChiPhiNhapHang;
        private System.Windows.Forms.ListView lvNhapHang;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblTongDanhThuBanHang;
        private System.Windows.Forms.Label labelTongTienBanHang;
        private System.Windows.Forms.Label labelSoLuongDonHang;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListView lvBanHang;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.Label lblVat;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.Label lblShip;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
    }
}