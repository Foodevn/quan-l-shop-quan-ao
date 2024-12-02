using BusinessLog;
using DataAccess;
using DataAccess.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chitietphieunhau
{
	public partial class FormQuanLyTaiKhoanNguoiDung : Form
	{
		List<NhanVien> listNhanVien;
		NhanVien nhanVien;
		List<RoleNhanVien> listRoleNhanVien;
		public FormQuanLyTaiKhoanNguoiDung()
		{
			InitializeComponent();
		}
		void Clear()
		{
			txtMaNV.Clear();
			txtHoTen.Clear();
			txtCCCD.Clear();
			txtSDT.Clear();

			txtMatKhau.Clear();
			txtDiaChi.Clear();
			txtEmail.Clear();
			txtLuY.Clear();
			rdBtnNhanVien.Checked = false;
			rdBtnQuanLy.Checked = false;
			label4.Visible = true;
			dateTimePickerNgayThoiViec.Visible = true;
			dateTimePickerNgaySinh.Value = DateTime.Now;
			dateTimePickerNgayVaoLam.Value = DateTime.Now;
			dateTimePickerNgayThoiViec.Value = new DateTime(1753, 1, 1);
		}
		void LoadNhanVienToLV(List<NhanVien> listNhanVien)
		{

			listViewNhanVien.Items.Clear();
			foreach (NhanVien nv in listNhanVien)
			{
				ListViewItem item = listViewNhanVien.Items.Add(nv.MaNhanVien);
				item.SubItems.Add(nv.HoTen);
				item.SubItems.Add(nv.NgaySinh.ToString("dd/MM/yyyy"));
				item.SubItems.Add($"{nv.CCCD}");
				item.SubItems.Add($"{nv.SDT}");

				item.SubItems.Add($"{nv.Email}");
				item.SubItems.Add($"{nv.NgayVaoLam.ToString("dd/MM/yyyy")}");

				string ngayThoiViec = nv.NgayThoiViec.Value.Year == 1001 ? "" : nv.NgayThoiViec.Value.ToString("dd/MM/yyyy");
				item.SubItems.Add(ngayThoiViec);
			}
			listViewNhanVien.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

		}
		private void FormQuanLyTaiKhoanNguoiDung_Load(object sender, EventArgs e)
		{
			NhanVienBL nhanVienBL = new NhanVienBL();
			listNhanVien = nhanVienBL.GetAll();

			LoadNhanVienToLV(listNhanVien);

			RoleNhanVienBL roleNhanVienBL = new RoleNhanVienBL();
			listRoleNhanVien = roleNhanVienBL.GetAll();

		}
		private void radioButton2_CheckedChanged(object sender, EventArgs e)
		{

		}
		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{

		}
		private void btnXoa_Click(object sender, EventArgs e)
		{
			Clear();

		}

		private void listViewNhanVien_DoubleClick(object sender, EventArgs e)
		{

			if (listViewNhanVien.SelectedItems.Count > 0)
			{
				ListViewItem item = listViewNhanVien.SelectedItems[0];
				foreach (NhanVien nv in listNhanVien)
				{
					if (nv.MaNhanVien.Contains(item.SubItems[0].Text))
					{
						txtMaNV.Text = nv.MaNhanVien;
						txtHoTen.Text = nv.HoTen;
						dateTimePickerNgaySinh.Value = nv.NgaySinh;

						txtCCCD.Text = nv.CCCD;
						txtSDT.Text = nv.SDT.ToString();
						txtEmail.Text = nv.Email;
						txtMatKhau.Text = nv.MatKhau;

						dateTimePickerNgayVaoLam.Value = nv.NgayVaoLam;
						if (nv.NgayThoiViec.Value.Year != 1001)
							dateTimePickerNgayThoiViec.Value = nv.NgayThoiViec.Value;

						txtLuY.Text = nv.GhiChu;

						LoadRole(item.SubItems[0].Text);
					}
				}
			}
		}
		void LoadRole(string maNV)
		{
			foreach (RoleNhanVien rNV in listRoleNhanVien)
			{
				if (rNV.MaNhanVien.Contains(maNV))
				{
					if (rNV.MaRole.Contains("3"))
					{
						rdBtnNhanVien.Checked = true;
					}
					else rdBtnQuanLy.Checked = true;
					return;
				}
			}
		}
		private void btnLuu_Click(object sender, EventArgs e)
		{
			if (!rdBtnQuanLy.Checked && !rdBtnNhanVien.Checked)
			{
				MessageBox.Show("Chưa chọn Chọn Vai Trò cho Nhân viên");
				return;
			}
			if (string.IsNullOrEmpty(txtMaNV.Text))
				InsertNhanVien();
			else
				UpdateNhanVien();
			NhanVienBL nhanVienBL = new NhanVienBL();
			listNhanVien = nhanVienBL.GetAll();
			RoleNhanVienBL roleNhanVienBL = new RoleNhanVienBL();
			listRoleNhanVien = roleNhanVienBL.GetAll();
			LoadNhanVienToLV(listNhanVien);
			Clear();
		}
		void LayNhanVien()
		{

			nhanVien = new NhanVien()
			{
				MaNhanVien = txtMaNV.Text,
				MatKhau = txtMatKhau.Text,
				HoTen = txtHoTen.Text,
				NgaySinh = dateTimePickerNgaySinh.Value,
				CCCD = txtCCCD.Text,
				Email = txtEmail.Text,
				SDT = txtSDT.Text,
				NgayVaoLam = dateTimePickerNgayVaoLam.Value,
				NgayThoiViec = dateTimePickerNgayThoiViec.Value,
				GhiChu = txtLuY.Text,
			};

		}
		void UpdateNhanVien()
		{
			LayNhanVien();
			NhanVienBL nhanVienBL = new NhanVienBL();
			string maNhanVien = nhanVienBL.Update(nhanVien);
			UpdateRoleNhanVien(maNhanVien);
			if (!string.IsNullOrEmpty(maNhanVien))
				MessageBox.Show("Đã sửa thông tin nhân viên");

		}
		void UpdateRoleNhanVien(string maNhanVien)
		{
			RoleNhanVienBL roleNhanVienBL = new RoleNhanVienBL();
			string role = "002";
			if (rdBtnNhanVien.Checked)
				role = "003";
			RoleNhanVien roleNhanVien = new RoleNhanVien()
			{
				MaNhanVien = maNhanVien,
				MaRole = role,
				KhichHoat = 1,
				GhiChu = "kich hoat",
			};
			roleNhanVienBL.Update(roleNhanVien);
		}
		void InsertNhanVien()
		{
			LayNhanVien();
			nhanVien.MaNhanVien = "";

			DateTime? nu = null;
			nhanVien.NgayThoiViec = dateTimePickerNgayThoiViec.Value.Year != new DateTime(1753, 1, 1).Year ? dateTimePickerNgayThoiViec.Value : nu;
			NhanVienBL nhanVienBL = new NhanVienBL();
			string ma = nhanVienBL.Insert(nhanVien);
			InsertRoleNhanVien(ma);
			if (!string.IsNullOrEmpty(ma))
				MessageBox.Show("Thêm nhân viên mới thành công");

		}
		void InsertRoleNhanVien(string ma)
		{
			RoleNhanVienBL roleNhanVienBL = new RoleNhanVienBL();

			string role = "002";
			if (rdBtnNhanVien.Checked)
				role = "003";
			RoleNhanVien roleNhanVien = new RoleNhanVien()
			{
				MaNhanVien = ma,
				MaRole = role,
				KhichHoat = 1,
				GhiChu = "kich hoat",
			};
			roleNhanVienBL.Insert(roleNhanVien);
		}

	}
}
