using BusinessLog;
using DataAccess;
using DataAccess.Class;

using Microsoft.VisualBasic;
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

namespace quanlyshopquanao
{
	public partial class Lapphieunhaphangmoi : Form
	{
		List<SanPham> listSanPham = new List<SanPham>();
		List<MauSac> listMauSac = new List<MauSac>();
		List<DataAccess.Size> listSize = new List<DataAccess.Size>();
		List<SanPham> listDSChiTiet = new List<SanPham>();
		List<NhomMatHang> listNhomMatHang = new List<NhomMatHang>();
		public string MaNhanVienFromNhapHang { get; set; }
		public Lapphieunhaphangmoi()
		{
			InitializeComponent();
		}

		private void Lapphieunhaphangmoi_Load(object sender, EventArgs e)
		{

			TaiDanhSach();

		}
		void TaiDanhSach()
		{

			SanPhamBL sanPhamBL = new SanPhamBL();
			listSanPham = sanPhamBL.GetAll();

			MauSacBL mauSacBL = new MauSacBL();
			listMauSac = mauSacBL.GetAll();

			SizeBL sizeBL = new SizeBL();
			listSize = sizeBL.GetAll();

			NhomMatHangBL nhomMatHangBL = new NhomMatHangBL();
			listNhomMatHang = nhomMatHangBL.GetAll();

			LoadSPtoLVSanPham(listSanPham);
			LoadMauSac();
			LoadSize();
		}
		private void LoadMauSac()
		{
			cbbMau.SelectedIndexChanged -= cbbMau_SelectedIndexChanged;
			cbbMau.DataSource = listMauSac;

			cbbMau.ValueMember = "MaMau";
			cbbMau.DisplayMember = "TenMau";
			cbbMau.SelectedIndexChanged += cbbMau_SelectedIndexChanged;
		}
		void LoadSize()
		{

			cbbSize.DataSource = listSize;
			cbbSize.ValueMember = "MaSize";
			cbbSize.DisplayMember = "TenSize";
		}
		void LoadSPtoLVSanPham(List<SanPham> listSanPham)
		{
			lvDSSanPham.Items.Clear();
			foreach (SanPham sp in listSanPham)
			{
				ListViewItem item = lvDSSanPham.Items.Add(sp.MaSP);
				item.SubItems.Add(sp.TenSP);
				item.SubItems.Add(sp.GiaNhap.ToString());
				item.SubItems.Add(sp.GiamGia.ToString());
				item.SubItems.Add(sp.SLTon.ToString());
				item.SubItems.Add(sp.NhaCungCap.ToString());

				string tenMauSac = listMauSac.Find(x => x.MaMau == sp.IDMau).TenMau;
				item.SubItems.Add(tenMauSac);

				string tenSize = listSize.Find(x => x.MaSize == sp.IDSize).TenSize;
				item.SubItems.Add(tenSize);

				string nhaCungCap = listNhomMatHang.Find(x => x.MaNhomMatHang == sp.IDNhomMatHang).TenNhomMatHang;
				item.SubItems.Add(nhaCungCap);

				item.SubItems.Add(sp.GhiChu.ToString());
			}
			lvDSSanPham.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
		}
		void LoadSPtoLVDonHang(List<SanPham> listSanPham)
		{
			lvDSPhieuNhap.Items.Clear();
			foreach (SanPham sp in listSanPham)
			{
				ListViewItem item = lvDSPhieuNhap.Items.Add(sp.MaSP);
				item.SubItems.Add(sp.TenSP);
				item.SubItems.Add(sp.GiaNhap.ToString());
				item.SubItems.Add(sp.SLTon.ToString());
				float thanhTien = sp.GiaNhap * sp.SLTon;
				item.SubItems.Add(thanhTien.ToString("F0"));
				string tenMauSac = listMauSac.Find(x => x.MaMau == sp.IDMau).TenMau;
				item.SubItems.Add(tenMauSac);

				string tenSize = listSize.Find(x => x.MaSize == sp.IDSize).TenSize;
				item.SubItems.Add(tenSize);

				item.SubItems.Add(sp.GhiChu.ToString());
			}
			lvDSPhieuNhap.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
		}
		void KhongDuocNhapChu(KeyPressEventArgs e)
		{
			if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
			{
				e.Handled = true; // Ngăn không cho nhập ký tự
			}
		}
		private void txtTimKiem_TextChanged(object sender, EventArgs e)
		{
			TimKiemv2();

		}
		void TimKiem(List<SanPham> KetQua)
		{

			List<ListViewItem> ketQuaTimKiem = new List<ListViewItem>();
			if (cbbMau.Text.ToLower() == "tất cả" && cbbSize.Text.ToLower() == "tất cả")
			{
				lvDSSanPham.Items.Clear();
				LoadSPtoLVSanPham(KetQua);
				return;
			}
			foreach (ListViewItem item in lvDSSanPham.Items)
			{
				string maMau = item.SubItems[6].Text.ToLower();
				string maSize = item.SubItems[7].Text.ToLower();
				if (maMau.Contains(cbbMau.Text.ToLower()) || maSize == cbbSize.Text.ToLower())
				{
					ketQuaTimKiem.Add(item);
				}
			}
			lvDSSanPham.Items.Clear();
			foreach (ListViewItem resultItem in ketQuaTimKiem)
			{
				lvDSSanPham.Items.Add(resultItem);
			}
		}
		List<SanPham> TimKiemv2()
		{
			string searchText = txtTimKiem.Text.ToLower();
			List<SanPham> ketQuaTimKiem = new List<SanPham>();
			if (string.IsNullOrEmpty(searchText))
			{
				lvDSSanPham.Items.Clear();
				LoadSPtoLVSanPham(listSanPham);
				return listSanPham;
			}
			foreach (SanPham sp in listSanPham)
			{
				string maHang = sp.MaSP.ToLower();
				string tenHang = sp.TenSP.ToLower();

				if (maHang.Contains(searchText) || tenHang.Contains(searchText))
				{
					ketQuaTimKiem.Add(sp);

				}
			}
			lvDSSanPham.Items.Clear();
			LoadSPtoLVSanPham(ketQuaTimKiem);
			TimKiem(ketQuaTimKiem);
			return ketQuaTimKiem;

		}
		void DeleteSanPham_TheoMa(List<SanPham> listSP, string MaSP)
		{
			for (int i = listSP.Count - 1; i >= 0; i--)
			{
				if (listSP[i].MaSP == MaSP)
				{
					listSP.RemoveAt(i);
				}
			}
		}
		void TongDonHang()
		{
			TongSoLuong();
			float tongTienHang = TongTienHang();
			float cacPhiKhach = txtB.Text != "" ? float.Parse(txtB.Text) : 0;
			float phiVanCHuyen = txtC.Text != "" ? float.Parse(txtC.Text) : 0;
			float thueVAT = txtD.Text != "" ? float.Parse(txtD.Text) : 0;

			float tongThanhToan = tongTienHang + cacPhiKhach + tongTienHang * thueVAT / 100 + phiVanCHuyen;
			txtThanhToan.Text = tongThanhToan.ToString("F0");

		}
		float TongTienHang()
		{
			float tongTienHang = listDSChiTiet.Sum(x => x.GiaNhap * x.SLTon);
			txtA.Text = tongTienHang.ToString("F0");
			return tongTienHang;

		}
		int TongSoLuong()
		{
			int tongSoLuong = listDSChiTiet.Sum(x => x.SLTon);
			lbTongSoLuong.Text = tongSoLuong.ToString("F0");
			return tongSoLuong;
		}
		string Insert_PhieuNhap()
		{
			PhieuNhapHang phieuNhapHang = new PhieuNhapHang()
			{
				MaPhieuNhap = "",
				NgayNhap = DateTime.Now,
				MaNhanVien = MaNhanVienFromNhapHang,
				NguonHang = txtGhiChu.Text != "" ? txtD.Text : "",
				TongTienHang = txtA.Text != "" ? float.Parse(txtA.Text) : 0,
				CacPhiKhac = txtB.Text != "" ? float.Parse(txtB.Text) : 0,
				PhiVanChuyen = txtC.Text != "" ? float.Parse(txtC.Text) : 0,
				ThueVat = txtD.Text != "" ? float.Parse(txtD.Text) : 0,
				GhiChu = txtGhiChu.Text != "" ? txtD.Text : "",
				Enable = 1,

			};
			PhieuNhapHangBL phieuNhapHangBL = new PhieuNhapHangBL();
			return phieuNhapHangBL.Insert(phieuNhapHang);
		}
		void Insert_ChiTietPhieuNhap(string maPhieuNhap)
		{
			foreach (SanPham sp in listDSChiTiet)
			{
				ChiTietPhieuNhap chiTietPhieuNhap = new ChiTietPhieuNhap()
				{
					MaPhieuNhap = maPhieuNhap,
					MaSP = sp.MaSP,
					SL = sp.SLTon,
					GiaNhap = sp.GiaNhap,
					Enable = 1,

				};
				ChiTietPhieuNhapBL chiTietPhieuNhapBL = new ChiTietPhieuNhapBL();
				Debug.WriteLine(chiTietPhieuNhapBL.Insert(chiTietPhieuNhap));

			}

		}
		private void ClearForm()
		{
			txtNguonHang.Text = "";
			txtGhiChu.Text = "";
			txtA.Clear();
			txtB.Text = "";
			txtC.Text = "";
			txtD.Text = "";
			lvDSPhieuNhap.Items.Clear();
			txtThanhToan.Text = "";

		}
		private void cbbMau_SelectedIndexChanged(object sender, EventArgs e)
		{
			TimKiem(TimKiemv2());
		}
		private void cbbSize_SelectedIndexChanged(object sender, EventArgs e)
		{
			TimKiem(TimKiemv2());
		}
		private void btnXoa_Click(object sender, EventArgs e)
		{
			txtTimKiem.Text = "";
		}
		private void btnTaiLaiDanhSach_Click(object sender, EventArgs e)
		{
			LoadSPtoLVSanPham(listSanPham);
		}
		private void btnHuyBo_Click(object sender, EventArgs e)
		{
			ClearForm();
			listDSChiTiet.Clear();
		}
		private void lvDSSanPham_DoubleClick(object sender, EventArgs e)
		{
			if (lvDSSanPham.SelectedItems.Count > 0)
			{
				ListViewItem Item1 = lvDSSanPham.SelectedItems[0];
				string s = Item1.SubItems[0].Text;
				foreach (SanPham sp2 in listDSChiTiet)
				{
					if (sp2.MaSP.Contains(s))
					{
						sp2.SLTon++;

						LoadSPtoLVDonHang(listDSChiTiet);
						TongDonHang();

						return;
					}

				}
				foreach (SanPham sp in listSanPham)
				{
					if (sp.MaSP.Contains(s))
					{
						sp.SLTon = 1;

						listDSChiTiet.Add(sp);
						LoadSPtoLVDonHang(listDSChiTiet);
						TongDonHang();

						return;
					}

				}
			}
		}
		private void sốLươnhtToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string soluong = Interaction.InputBox("Nhận số", "Số Lượng", "2");
			if (int.Parse(soluong) < 1)
			{
				MessageBox.Show("không thể thêm sản phẩm có số lượng bằng 0");
				return;
			}
			if (lvDSSanPham.SelectedItems.Count > 0)
			{
				ListViewItem Item1 = lvDSSanPham.SelectedItems[0];
				string s = Item1.SubItems[0].Text;
				foreach (SanPham sp2 in listDSChiTiet)
				{
					if (sp2.MaSP.Contains(s))
					{
						sp2.SLTon = int.Parse(soluong);


						LoadSPtoLVDonHang(listDSChiTiet);
						TongDonHang();

						return;
					}

				}
				foreach (SanPham sp in listSanPham)
				{
					if (sp.MaSP.Contains(s))
					{
						sp.SLTon = int.Parse(soluong);


						listDSChiTiet.Add(sp);
						LoadSPtoLVDonHang(listDSChiTiet);

						TongDonHang();
						return;
					}

				}
			}
		}
		private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (lvDSPhieuNhap.SelectedItems.Count > 0)
			{
				ListViewItem Item1 = lvDSPhieuNhap.SelectedItems[0];
				string s = Item1.SubItems[0].Text;
				foreach (SanPham sp2 in listDSChiTiet)
				{
					if (sp2.MaSP.Contains(s))
					{
						DeleteSanPham_TheoMa(listDSChiTiet, sp2.MaSP);
						LoadSPtoLVDonHang(listDSChiTiet);
						return;
					}

				}

			}
		}
		private void button4_Click(object sender, EventArgs e)
		{
			MessageBox.Show(MaNhanVienFromNhapHang+"1");
		}
		private void txtB_KeyPress(object sender, KeyPressEventArgs e)
		{
			KhongDuocNhapChu(e);
		}
		private void txtC_KeyPress(object sender, KeyPressEventArgs e)
		{
			KhongDuocNhapChu(e);

		}
		private void txtD_KeyPress(object sender, KeyPressEventArgs e)
		{
			KhongDuocNhapChu(e);

		}
		private void txtB_TextChanged(object sender, EventArgs e)
		{
			TongDonHang();
		}
		private void txtC_TextChanged(object sender, EventArgs e)
		{
			TongDonHang();
		}
		private void txtD_TextChanged(object sender, EventArgs e)
		{
			TongDonHang();
		}
		private void button2_Click(object sender, EventArgs e)
		{
			if (listDSChiTiet.Count < 1)
			{
				MessageBox.Show("Chưa có mặt hàng nào!");
				return;
			}
			string maPhieuNhap = Insert_PhieuNhap();
			Insert_ChiTietPhieuNhap(maPhieuNhap);
			if (!string.IsNullOrEmpty(maPhieuNhap))
			{
				MessageBox.Show("Hóa đơn đã được lưu ");
				ClearForm();
			}
		}
		private void giáNhậpToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string soluong = Interaction.InputBox("Nhận số lượng của sản phẩm", "Số Lượng", "2");
			string giaNhap = Interaction.InputBox("Giá Nhập của sản phẩm ", "Giá Nhập", "2");
			if (int.Parse(soluong) < 1)
			{
				MessageBox.Show("không thể thêm sản phẩm có số lượng bằng 0");
				return;
			}
			if (lvDSSanPham.SelectedItems.Count > 0)
			{
				ListViewItem Item1 = lvDSSanPham.SelectedItems[0];
				string s = Item1.SubItems[0].Text;
				foreach (SanPham sp2 in listDSChiTiet)
				{
					if (sp2.MaSP.Contains(s))
					{
						sp2.SLTon = int.Parse(soluong);
						sp2.GiaNhap = int.Parse(giaNhap);

						LoadSPtoLVDonHang(listDSChiTiet);
						TongDonHang();

						return;
					}

				}
				foreach (SanPham sp in listSanPham)
				{
					if (sp.MaSP.Contains(s))
					{
						sp.SLTon = int.Parse(soluong);
						sp.GiaNhap = int.Parse(giaNhap);
						listDSChiTiet.Add(sp);
						LoadSPtoLVDonHang(listDSChiTiet);
						TongDonHang();
						return;
					}

				}
			}
		}
	}
}
