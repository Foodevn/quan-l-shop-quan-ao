namespace Quan_ly_Shop_Quan_ao_1.Forms
{
	partial class UserControl1
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.lbTenMatHang = new System.Windows.Forms.Label();
			this.lbGia = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lbTenMatHang
			// 
			this.lbTenMatHang.AutoSize = true;
			this.lbTenMatHang.Location = new System.Drawing.Point(3, 3);
			this.lbTenMatHang.Name = "lbTenMatHang";
			this.lbTenMatHang.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lbTenMatHang.Size = new System.Drawing.Size(92, 16);
			this.lbTenMatHang.TabIndex = 0;
			this.lbTenMatHang.Text = "Tên Mặt Hàng";
			// 
			// lbGia
			// 
			this.lbGia.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.lbGia.Location = new System.Drawing.Point(462, 3);
			this.lbGia.Name = "lbGia";
			this.lbGia.Size = new System.Drawing.Size(324, 16);
			this.lbGia.TabIndex = 0;
			this.lbGia.Text = "Gia bugegffsf";
			this.lbGia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// UserControl1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.lbGia);
			this.Controls.Add(this.lbTenMatHang);
			this.Name = "UserControl1";
			this.Size = new System.Drawing.Size(789, 22);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lbTenMatHang;
		private System.Windows.Forms.Label lbGia;
	}
}
