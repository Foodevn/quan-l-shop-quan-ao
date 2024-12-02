using BusinessLog;
using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XemLaiHoaDon
{
	public partial class FrmXemLaiHoaDon : Form
	{
		List<HoaDon> listHoaDon;
		List<NhanVien> listNhanVien;
		List<KhachHang> listKhachHang;
		public FrmXemLaiHoaDon()
		{
			InitializeComponent();
		}
		void LoadHoaDontoLV(List<HoaDon> listHoaDon)
		{
			DateTime fromDate = dtpNgayLap.Value.Date;
			DateTime toDate = dtpNgayDen.Value.Date;
			var validHoaDonIds = listHoaDon
			  .Where(p => p.NgayLap >= fromDate && p.NgayLap <= toDate)
			  .ToList();
			lvDSHoaDon.Items.Clear();
			foreach (HoaDon hd in validHoaDonIds)
			{
				ListViewItem item = lvDSHoaDon.Items.Add(hd.MaHoaDon);
				string tenNhanVien = listNhanVien.Find(x => x.MaNhanVien == hd.MaNV).HoTen;
				item.SubItems.Add(tenNhanVien);
				item.SubItems.Add(hd.NgayLap.ToString("dd/MM/yyyy"));
				string tenKhachHang = listKhachHang.Find(x => x.MaKhachHang == hd.MaKH).TenKhachHang;

				item.SubItems.Add(tenKhachHang);
				string sdt = listKhachHang.Find(x => x.MaKhachHang == hd.MaKH).SDT;
				item.SubItems.Add(sdt);
				item.SubItems.Add(hd.TongTien.ToString("N0"));
				item.SubItems.Add(hd.GiamGiaHD.ToString("F2"));
				item.SubItems.Add(hd.PhiShip.ToString("F0"));
				item.SubItems.Add(hd.Vat.ToString("F2"));
				float thanhTien = hd.TongTien - hd.TongTien * hd.GiamGiaHD / 100 + hd.PhiShip + hd.Vat * hd.TongTien / 100;
				item.SubItems.Add(thanhTien.ToString("F0"));
				item.SubItems.Add(hd.TrangThai);
			}
		}
		private void DateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			LoadHoaDontoLV(listHoaDon);
		}
		void LoadNhanVientoCBB(List<NhanVien> listNhanVien)
		{
			cbNhanVienLap.DataSource = listNhanVien;
			cbNhanVienLap.DisplayMember = "HoTen";
			cbNhanVienLap.ValueMember = "MaNhanVien";
		}
		List<HoaDon> TimKiem_TenKH(string s)
		{
			s = s.ToLower().Trim();
			List<HoaDon> listHD = new List<HoaDon>();
			foreach (KhachHang kh in listKhachHang)
			{
				string tenKH = kh.TenKhachHang.Trim().ToLower();
				if (tenKH.Contains(s))
				{
					foreach (HoaDon hd in listHoaDon)
					{
						if (kh.MaKhachHang.Trim() == hd.MaKH.Trim())
						{
							listHD.Add(hd);
						}
					}
				}
			}
			return listHD;
		}
		List<HoaDon> TimKiem_SDT(string s)
		{
			s = s.Trim();
			List<HoaDon> listHD = new List<HoaDon>();
			foreach (KhachHang kh in listKhachHang)
			{
				string sdt = kh.SDT.Trim();
				if (sdt.Contains(s))
				{
					foreach (HoaDon hd in listHoaDon)
					{
						if (kh.MaKhachHang.Trim() == hd.MaKH.Trim())
						{
							listHD.Add(hd);
						}
					}

				}
			}
			return listHD;
		}
		List<HoaDon> TimKiem_NhanVien(string s)
		{
			s = s.Trim();
			List<HoaDon> listHD = new List<HoaDon>();
			foreach (HoaDon hd in listHoaDon)
			{
				string maNhanVien = hd.MaNV.Trim();
				if (maNhanVien.Contains(s))
				{
					listHD.Add(hd);
				}
			}
			return listHD;
		}
		List<HoaDon> TimKiem_TrangThai(bool s)
		{
			string ktra = "C";
			if (s)
			{
				ktra = "ã";
			}

			List<HoaDon> listHD = new List<HoaDon>();
			foreach (HoaDon hd in listHoaDon)
			{

				if (hd.TrangThai.Contains(ktra))
				{
					listHD.Add(hd);
				}
			}
			return listHD;
		}
		void TinhTong(List<HoaDon> listHD)
		{
			lblTongDoanhThu.Text = listHD.Sum(hd => hd.TongTien - hd.TongTien * hd.GiamGiaHD
			/ 100 + hd.PhiShip + hd.Vat * hd.TongTien / 100).ToString("N0");
		}
		private void FrmXemLaiHoaDon_Load(object sender, EventArgs e)
		{
			HoaDonBL hoaDonBL = new HoaDonBL();
			listHoaDon = hoaDonBL.GetAll();

			NhanVienBL nhanVienBL = new NhanVienBL();
			listNhanVien = nhanVienBL.GetAll();

			KhachHangBL khachHangBL = new KhachHangBL();
			listKhachHang = khachHangBL.GetAll();
			dtpNgayLap.ValueChanged += DateTimePicker_ValueChanged;
			dtpNgayDen.ValueChanged += DateTimePicker_ValueChanged;
			LoadNhanVientoCBB(listNhanVien);
			LoadHoaDontoLV(listHoaDon);
			


		}

		private void txtKhachHang_TextChanged(object sender, EventArgs e)
		{
			string key = txtKhachHang.Text;

			LoadHoaDontoLV(TimKiem_TenKH(key));
			TinhTong(TimKiem_TenKH(key));
		}

		private void txtSdt_TextChanged(object sender, EventArgs e)
		{
			string key = txtSdt.Text;
			LoadHoaDontoLV(TimKiem_SDT(key));
			TinhTong(TimKiem_SDT(key));
		}

		private void cbTrangThai_SelectedIndexChanged(object sender, EventArgs e)
		{
			bool ktra = false;
			if (cbTrangThai.Text == "Hoàn Thành")
			{
				ktra = true;
			}
			Debug.Write(ktra);
			LoadHoaDontoLV(TimKiem_TrangThai(ktra));
			TinhTong(TimKiem_TrangThai(ktra));
		}

		private void cbNhanVienLap_SelectedIndexChanged(object sender, EventArgs e)
		{

			string key = cbNhanVienLap.SelectedValue.ToString();
			LoadHoaDontoLV(TimKiem_NhanVien(key));
			TinhTong(TimKiem_NhanVien(key));
		}

		private void lvDSHoaDon_DoubleClick(object sender, EventArgs e)
		{
			if (lvDSHoaDon.SelectedItems.Count > 0)
			{
				ListViewItem item = lvDSHoaDon.SelectedItems[0];
				string s = item.SubItems[0].Text;
				string tt = item.SubItems[10].Text.Trim();
				int ktTT = 1;
				if (tt.Contains("ã"))
					ktTT = 0;
				FrmXemLai xemlai = new FrmXemLai(s, ktTT);
				xemlai.Show();
				xemlai.FormClosed += FrmXemLaiHoaDon_Load;

			}
		}
	}
}