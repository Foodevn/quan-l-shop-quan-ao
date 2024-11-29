using BusinessLog;
using DataAccess;
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

namespace XemLaiHoaDon
{
    public partial class FrmXemLai : Form
    {
        public string MaHoaDon { get; set; }
        public int TrangThai { get;set; }
        public FrmXemLai(string maHoaDon,int trangThai)
        {
            InitializeComponent();
            MaHoaDon = maHoaDon;
            TrangThai = trangThai;
        }
        List<KhachHang> listKhachHang = new List<KhachHang>();
        List<SanPham> listSanPham=new List<SanPham>();
        List<ChiTietHoaDon> listCTHD = new List<ChiTietHoaDon>();
        List<HoaDon> listHD = new List<HoaDon>();
        HoaDon hoaDon = new HoaDon();
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void FrmXemLai_Load(object sender, EventArgs e)
        {
           
            LoadHoaDon();
            LoadCTHDToLV();
        }
   
        void LoadHoaDon()
        {
            HoaDonBL hoaDonBL = new HoaDonBL();
            listHD = hoaDonBL.GetAll();
            List<HoaDon> listHoaDon = hoaDonBL.GetAll();
            KhachHangBL khachHangBL = new KhachHangBL();
            listKhachHang = khachHangBL.GetAll();
            foreach (HoaDon hd in listHoaDon)
            {
                if (hd.MaHoaDon == MaHoaDon)
                {
                    txtKhachHang.Text = listKhachHang.Find(p => p.MaKhachHang == hd.MaKH).TenKhachHang;
                    txtSdt.Text = listKhachHang.Find(p => p.MaKhachHang == hd.MaKH).SDT;
                    txtDCKhach.Text = listKhachHang.Find(p => p.MaKhachHang == hd.MaKH).DiaChi;
                    txtNguoiNhan.Text = listKhachHang.Find(p => p.MaKhachHang == hd.MaKH).TenKhachHang;
                    txtNgayGioGiao.Text = hd.NgayLap.ToString();
                    txtDCGiao.Text = listKhachHang.Find(p => p.MaKhachHang == hd.MaKH).DiaChi;



                    txtNgayLap.Text = hd.NgayLap.ToString();
                    cbTrangThai.SelectedIndex = TrangThai;
                    txtTienHang.Text = hd.TongTien.ToString();
                    txtGiamGia.Text = hd.GiamGiaHD.ToString();
                    txtPhiShip.Text = hd.PhiShip.ToString();
                    txtTienThue.Text = hd.Vat.ToString();
                    float tongAll = hd.TongTien + hd.PhiShip + ((hd.Vat * hd.TongTien) / 100) - ((hd.GiamGiaHD * hd.TongTien) / 100);
                    txtTongTien.Text = tongAll.ToString();
                    txtGhiChu.Text = hd.GhiChu;

                    hoaDon = hd;
                    return;
                }
            }

        }
        void LoadCTHDToLV()
        {
            ChiTietHoaDonBL CTHDBL=new ChiTietHoaDonBL();
            listCTHD =CTHDBL.GetAll();
            SanPhamBL spBL= new SanPhamBL();
            listSanPham=spBL.GetAll();
            int count = 1;
            foreach(ChiTietHoaDon CTHD in listCTHD)
            {
                if(CTHD.MaHD==MaHoaDon)
                {
                    ListViewItem item = lvChiTietDonHang.Items.Add(count.ToString());
                    count++;
                    item.SubItems.Add(CTHD.MaSP);
                    string ten=listSanPham.Find(x=>x.MaSP==CTHD.MaSP).TenSP;
                    item.SubItems.Add(ten);
                    item.SubItems.Add(CTHD.GiaBan.ToString());
                    item.SubItems.Add(CTHD.SL.ToString());
                    float thanhTien = CTHD.SL * CTHD.GiaBan;
                    item.SubItems.Add(thanhTien.ToString());
                    item.SubItems.Add(CTHD.GhiChu);

                }
            }
        }
        public string UpdateHD()
        {
            HoaDon hd = hoaDon;   
            hd.TrangThai = cbTrangThai.Text;
            hd.GhiChu = txtGhiChu.Text;
            HoaDonBL hoaDonBL = new HoaDonBL();
            return hoaDonBL.Update(hd);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string s = UpdateHD();
            Debug.WriteLine(s);
            if (s != "")
            {
                MessageBox.Show("Cập nhật mặt hàng thành công");

            }
            else MessageBox.Show("Cập nhật hàng không thành công. Vui lòng kiểm tra lại dữ liệu nhập");
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
