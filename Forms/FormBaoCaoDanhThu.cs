using BusinessLog;
using DataAccess;
using DataAccess.ClassDA;
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
    public partial class FormBaoCaoDanhThu : Form
    {
        public FormBaoCaoDanhThu()
        {
            InitializeComponent();
        }
        List<SanPham> listSanPham = new List<SanPham>();
        List<ChiTietPhieuNhap> listChiTietPN = new List<ChiTietPhieuNhap>();
        List<PhieuNhapHang> listPhieuNhap = new List<PhieuNhapHang>();
        List<HoaDon> listHoaDon = new List<HoaDon>();
        List<ChiTietHoaDon> listChiTietHoaDon=new List<ChiTietHoaDon>();
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void lvNhapHang_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvBanHang_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void FormBaoCaoDanhThu_Load(object sender, EventArgs e)
        {
           
            dtpFromDate.ValueChanged += DateTimePicker_ValueChanged;
            dtpToDate.ValueChanged += DateTimePicker_ValueChanged;
            LoadSanPhamNhapDataToListView1();
            TongSoNH();
            LoadSanPhamBanDataToListView();
            TongSoBH();
        }      
        private void lblSLPhieuNhap_Click(object sender, EventArgs e)
        {

        }
        private void TongSoNH()
        {
            DateTime fromDate = dtpFromDate.Value.Date;
            DateTime toDate = dtpToDate.Value.Date;
            var item = listPhieuNhap
                .Where(p => p.NgayNhap >= fromDate && p.NgayNhap <= toDate)
                .ToList();
            int tongPhieuNhap = item.Count;
            lblSLPhieuNhap.Text = $" {tongPhieuNhap}";
            float tongSoTienHang = item.Sum(p => p.TongTienHang);
            lblTongTienMuaHang.Text = $"{tongSoTienHang}";
            float tongTienVC = item.Sum(p => p.PhiVanChuyen);
            lblTongTienVanChuyen.Text = $"{tongTienVC}";
            float tongTienThue = item.Sum(p => (p.ThueVat * p.TongTienHang) / 100);
            lblTongTienThue.Text = $"{tongTienThue}";
            float tongChiPhiKhac = item.Sum(p => p.CacPhiKhac);
            lblTongChiPhiKhac.Text = $"{tongChiPhiKhac}";
            float tongAll = tongSoTienHang + tongTienVC + tongTienThue + tongChiPhiKhac;
            lblTongChiPhiNhapHang.Text = $"{tongAll}";
        }
        private void DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            TongSoNH();
            LoadSanPhamNhapDataToListView1();
            LoadSanPhamBanDataToListView();
            TongSoBH();
        }

        public void LoadSanPhamNhapDataToListView1()
        {
            DateTime fromDate = dtpFromDate.Value.Date;
            DateTime toDate = dtpToDate.Value.Date;
            SanPhamBL sanPhamBL = new SanPhamBL();
            listSanPham = sanPhamBL.GetAll();
            ChiTietPhieuNhapBL chiTietPNBL = new ChiTietPhieuNhapBL();
            listChiTietPN = chiTietPNBL.GetAll();
            PhieuNhapHangBL phieuNhapBL = new PhieuNhapHangBL();
            listPhieuNhap = phieuNhapBL.GetAll();
            var validPhieuNhapIds = listPhieuNhap
              .Where(p => p.NgayNhap >= fromDate && p.NgayNhap <= toDate)
              .Select(p => p.MaPhieuNhap)
              .ToList();
            var filteredChiTietPhieuNhap = listChiTietPN
               .Where(ct => validPhieuNhapIds.Contains(ct.MaPhieuNhap))
               .ToList();
            lvNhapHang.Items.Clear();
            foreach (var chiTiet in filteredChiTietPhieuNhap)
            {
                ListViewItem item = lvNhapHang.Items.Add(chiTiet.MaSP);
                string Name = listSanPham.Find(x => x.MaSP == chiTiet.MaSP).TenSP;
                item.SubItems.Add(Name);
                item.SubItems.Add(chiTiet.SL.ToString());
                item.SubItems.Add(chiTiet.GiaNhap.ToString());
            }
        }
        private void TongSoBH()
        {
            DateTime fromDate = dtpFromDate.Value.Date;
            DateTime toDate = dtpToDate.Value.Date;
            var item = listHoaDon
                .Where(p => p.NgayLap >= fromDate && p.NgayLap <= toDate)
                .ToList();
            int tongSoHoaDon = item.Count;
            labelSoLuongDonHang.Text = $"{tongSoHoaDon}";
            float tongSoTienHang = item.Sum(p => p.TongTien);
            labelTongTienBanHang.Text = $"{tongSoTienHang}";
            float tongTienShip = item.Sum(p => p.PhiShip);
            lblShip.Text = $"{tongTienShip}";
            float tongTienThue = item.Sum(p => (p.Vat * p.TongTien) / 100);
            lblVat.Text = $"{tongTienThue}";
            int trangThai = item.Count(p => p.TrangThai == "Chua thanh toán");
            lblTrangThai.Text = $"{trangThai}";
            float Total = tongSoTienHang + tongTienShip + tongTienThue;
            lblTongDanhThuBanHang.Text = $"{Total}";
        }
        public void LoadSanPhamBanDataToListView()
        {
            DateTime fromDate = dtpFromDate.Value.Date;
            DateTime toDate = dtpToDate.Value.Date;
            SanPhamBL sanPhamBL = new SanPhamBL();
            listSanPham = sanPhamBL.GetAll();
            ChiTietHoaDonBL chiTietHDBL = new ChiTietHoaDonBL();
            listChiTietHoaDon = chiTietHDBL.GetAll();
            HoaDonBL hoaDonBL = new HoaDonBL();
            listHoaDon = hoaDonBL.GetAll();
            var validHoaDonIds = listHoaDon
              .Where(p => p.NgayLap >= fromDate && p.NgayLap <= toDate)
              .Select(p => p.MaHoaDon)
              .ToList();
            var filteredChiTietHoaDon = listChiTietHoaDon
               .Where(ct => validHoaDonIds.Contains(ct.MaHD))
               .ToList();
            lvBanHang.Items.Clear();
            foreach (var chiTiet in filteredChiTietHoaDon)
            {
                ListViewItem item = lvBanHang.Items.Add(chiTiet.MaSP);
                string Name = listSanPham.Find(x => x.MaSP == chiTiet.MaSP).TenSP;
                item.SubItems.Add(Name);
                item.SubItems.Add(chiTiet.SL.ToString());
                item.SubItems.Add(chiTiet.GiaBan.ToString());
            }
        }
    }
}
