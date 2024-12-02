using BusinessLog;
using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chitietphieunhau
{
    public partial class FormChitietphieunhap : Form
    {
		List<PhieuNhapHang> listPhieuNhap;
		List<ChiTietPhieuNhap> listChiTietPhieuNhap;
		List<NhanVien> listNhanVien;
		List<SanPham> listSanPham;
		public string MaPhieuNhap {  get; set; }
		public FormChitietphieunhap(string maPhieuNhap)
        {
			MaPhieuNhap = maPhieuNhap;
            InitializeComponent();
        }

		private void FormChitietphieunhap_Load(object sender, EventArgs e)
		{
			PhieuNhapHangBL phieuNhapHangBL = new PhieuNhapHangBL();
			listPhieuNhap = phieuNhapHangBL.GetAll();

			ChiTietPhieuNhapBL chiTietPhieuNhapBL = new ChiTietPhieuNhapBL();
			listChiTietPhieuNhap= chiTietPhieuNhapBL.GetAll();

			NhanVienBL nhanVienBL = new NhanVienBL();
			listNhanVien = nhanVienBL.GetAll();

			SanPhamBL sanPhamBL = new SanPhamBL();
			listSanPham = sanPhamBL.GetAll();
			LoadDuLieu();
			LoadPhieuNhapToLV(listChiTietPhieuNhap);
		}
		void LoadDuLieu()
		{
		

			foreach (PhieuNhapHang phieuNhapHang in listPhieuNhap)
			{
				if (phieuNhapHang.MaPhieuNhap.Trim() == MaPhieuNhap.Trim())
				{
					txtbNgayNhap.Text = phieuNhapHang.NgayNhap.ToString("dd/mm/yyyy");
					txtbNguoiNhap.Text = listNhanVien.Find(x => x.MaNhanVien == phieuNhapHang.MaNhanVien).HoTen;
					txtbNguonHang.Text = phieuNhapHang.NguonHang;
					txtbChiPhiShip.Text = phieuNhapHang.PhiVanChuyen.ToString("N0");
					txtbTienThue.Text = phieuNhapHang.ThueVat.ToString("F2");
					txtbChiPhiKhac.Text=phieuNhapHang.CacPhiKhac.ToString("F2");
					txtbGhiChuKhac.Text = phieuNhapHang.GhiChu;
					labelTongSoLuong.Text = listChiTietPhieuNhap.Count(x => x.MaPhieuNhap == phieuNhapHang.MaPhieuNhap).ToString();
					labelTongTienHang.Text =phieuNhapHang.TongTienHang.ToString("N0");
					labelTongChiPhiNhapHang.Text =(phieuNhapHang.CacPhiKhac+phieuNhapHang.PhiVanChuyen+phieuNhapHang.ThueVat* phieuNhapHang.TongTienHang/100).ToString("F2");
					return;
				}

				
			}
			
		}
		void LoadPhieuNhapToLV(List<ChiTietPhieuNhap> listChiTietPhieuNhap)
		{
			int count = 1;
			foreach (ChiTietPhieuNhap CT in listChiTietPhieuNhap)
			{
				
				if (CT.MaPhieuNhap == MaPhieuNhap)
				{
					ListViewItem item = lvChiTietDanhSachNhap.Items.Add(count.ToString());
					item.SubItems.Add(CT.MaPhieuNhap);
					string tenSaNPham=listSanPham.Find(x=>x.MaSP==CT.MaSP).TenSP;
					item.SubItems.Add(tenSaNPham);
					item.SubItems.Add(CT.GiaNhap.ToString());
					item.SubItems.Add(CT.SL.ToString());
					float thanhTien=CT.GiaNhap*CT.SL;
					item.SubItems.Add(thanhTien.ToString());




					count++;
				}
				
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
