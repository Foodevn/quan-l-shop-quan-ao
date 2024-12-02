using BusinessLog;
using DataAccess;
using Quan_ly_Shop_Quan_ao_1.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_ly_Shop_Quan_ao_1
{
	public partial class InHoaDon : Form
	{
		int y = 20;
		int loactionY = 250;
		int formSizeY = 450;
		string maHoaDon { get; set; }
		List<HoaDon> listHoaDons;
		List<KhachHang> listKhachHang;
		List<ChiTietHoaDon> listChiTietHoaDon;
		List<SanPham> listSanPham;
		public InHoaDon(string maHoaDon)
		{
			InitializeComponent();
			this.maHoaDon = maHoaDon; /*"HD0001";*/
		}
		private void InHoaDon_Load(object sender, EventArgs e)
		{
			HoaDonBL hoaDonBL = new HoaDonBL();
			listHoaDons = hoaDonBL.GetAll();
			KhachHangBL khachHangBL = new KhachHangBL();
			listKhachHang = khachHangBL.GetAll();
			ChiTietHoaDonBL chiTietHoaDonBL = new ChiTietHoaDonBL();
			listChiTietHoaDon = chiTietHoaDonBL.GetAll();
			SanPhamBL sanPhamBL = new SanPhamBL();
			listSanPham= sanPhamBL.GetAll();	
			load();
			

		}
		void load()
		{
			float tong = 0;
			foreach (ChiTietHoaDon chiTietHoaDon in listChiTietHoaDon)
			{
				if (chiTietHoaDon.MaHD.Contains(maHoaDon))
				{
					string tenSP = listSanPham.Find(x => x.MaSP == chiTietHoaDon.MaSP).TenSP;
					string gia = chiTietHoaDon.SL.ToString() + " x " + (chiTietHoaDon.GiaBan/ chiTietHoaDon.SL).ToString("N0") + " = " + ( chiTietHoaDon.GiaBan).ToString("N0")+" đ";
					tong +=  chiTietHoaDon.GiaBan;
					them(tenSP, gia);

				}
			}
			lblTongThanhTien.Text = tong.ToString("N0")+" đ";
			foreach (HoaDon hoaDon in listHoaDons)
			{
				if (hoaDon.MaHoaDon.Contains(maHoaDon))
				{
					lbNgayGio.Text = hoaDon.NgayLap.ToString();
					lbKhangHang.Text = listKhachHang.Find(x => hoaDon.MaKH == x.MaKhachHang).TenKhachHang;
					lbSDT.Text = listKhachHang.Find(x => hoaDon.MaKH == x.MaKhachHang).SDT;
					lblGiamGia.Text=hoaDon.GiamGiaHD.ToString("F1")+"%";
					lblPhaiThanhToan.Text = (tong - tong * hoaDon.GiamGiaHD/100).ToString("N0")+" đ";
					return;
				}

			}
			
		}
		void them(string tenSP, string tien)
		{
			UserControl1 userControl1 = new UserControl1(tenSP, tien);
			flowLayoutPanel1.Controls.Add(userControl1);
			this.flowLayoutPanel1.Size = new System.Drawing.Size(780, y);
			this.panel1.Location = new System.Drawing.Point(18, loactionY);

			this.Size = new System.Drawing.Size(657, formSizeY);
			y += 22;
			loactionY += 22;
			formSizeY += 22;
		}

		


	}
}
