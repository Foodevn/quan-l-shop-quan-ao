using BusinessLog;
using Chitietphieunhau;
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

namespace quanlyshopquanao
{
    public partial class Xemlaiphieunhaphang : Form
    {
        public Xemlaiphieunhaphang()
        {
            InitializeComponent();
        }
        List<PhieuNhapHang> listPhieuNhap = new List<PhieuNhapHang>();
        List<NhanVien> listNhanVien = new List<NhanVien>();
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Xemlaiphieunhaphang_Load(object sender, EventArgs e)
        {
            dtpFromDate.ValueChanged += DateTimePicker_ValueChanged;
            dtpToDate.ValueChanged += DateTimePicker_ValueChanged;
            LoadSanPhamBanDataToListView();
            TongSoNH();
        }
        public void LoadSanPhamBanDataToListView()
        {
            DateTime fromDate = dtpFromDate.Value.Date;
            DateTime toDate = dtpToDate.Value.Date;
            NhanVienBL sanPhamBL = new NhanVienBL();
            listNhanVien = sanPhamBL.GetAll();

            PhieuNhapHangBL hoaDonBL = new PhieuNhapHangBL();
            listPhieuNhap = hoaDonBL.GetAll();
            var validHoaDonIds = listPhieuNhap
              .Where(p => p.NgayNhap >= fromDate && p.NgayNhap <= toDate)
              .ToList();

            lvDS.Items.Clear();
            foreach (var chiTiet in validHoaDonIds)
            {
                ListViewItem item = lvDS.Items.Add(chiTiet.MaPhieuNhap);
                string Name = listNhanVien.Find(x => x.MaNhanVien == chiTiet.MaNhanVien).HoTen;
                item.SubItems.Add(Name);
                item.SubItems.Add(chiTiet.NgayNhap.ToString());
                item.SubItems.Add(chiTiet.NguonHang);
                item.SubItems.Add(chiTiet.TongTienHang.ToString());
                item.SubItems.Add(chiTiet.PhiVanChuyen.ToString());
                item.SubItems.Add(chiTiet.ThueVat.ToString());
                item.SubItems.Add(chiTiet.CacPhiKhac.ToString());
                float thanhTien = chiTiet.TongTienHang + chiTiet.PhiVanChuyen + ((chiTiet.ThueVat * chiTiet.TongTienHang) / 100) + chiTiet.CacPhiKhac;
                item.SubItems.Add(thanhTien.ToString());
                item.SubItems.Add(chiTiet.GhiChu);

            }
        }
        private void DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            TongSoNH();
            LoadSanPhamBanDataToListView();
        }
        private void TongSoNH()
        {
            DateTime fromDate = dtpFromDate.Value.Date;
            DateTime toDate = dtpToDate.Value.Date;
            var item = listPhieuNhap
                .Where(p => p.NgayNhap >= fromDate && p.NgayNhap <= toDate)
                .ToList();
            float tongSoTienHang = item.Sum(p => p.TongTienHang);
            float tongTienVC = item.Sum(p => p.PhiVanChuyen);
            float tongTienThue = item.Sum(p => (p.ThueVat * p.TongTienHang) / 100);
            float tongChiPhiKhac = item.Sum(p => p.CacPhiKhac);
            float tongAll = tongSoTienHang + tongTienVC + tongTienThue + tongChiPhiKhac;
            lblTongTien.Text = $"{tongAll}";
        }

		private void lvDS_DoubleClick(object sender, EventArgs e)
		{
            if (lvDS.SelectedItems.Count > 0)
            {
               string maHoaDon= lvDS.SelectedItems[0].Text;
                FormChitietphieunhap formCT=new FormChitietphieunhap(maHoaDon);
                formCT.ShowDialog();

            }
		}
	}
}
