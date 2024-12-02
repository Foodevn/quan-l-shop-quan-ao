using BusinessLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccess.ClassDA;
using DataAccess;

namespace Quan_ly_Shop_Quan_ao_1.Forms
{
    public partial class FormKhachHang : Form
    {
        List<KhachHang> listKhachHang;
        List<HoaDon> listHoaDon;
        public FormKhachHang()
        {
            InitializeComponent();
            
        }
        
        private void KhachHang_Load(object sender, EventArgs e)
        {
            KhachHangBL khachHangBL = new KhachHangBL();
            listKhachHang = khachHangBL.GetAll();
            HoaDonBL hoaDonBL = new HoaDonBL();
            listHoaDon = hoaDonBL.GetAll();
            LoadKhachHangDataToListView(listKhachHang);
        }
        void LoadKhachHangDataToListView(List<KhachHang> listKH)
        {
            lvKhachHang.Items.Clear();
            foreach(KhachHang khachHang in listKH)
            {
                ListViewItem item = lvKhachHang.Items.Add(khachHang.MaKhachHang);
                item.SubItems.Add(khachHang.TenKhachHang);
                item.SubItems.Add(khachHang.DiaChi);
                item.SubItems.Add(khachHang.SDT.ToString());
                int soHoaDon = listHoaDon.Count(x=>x.MaKH==khachHang.MaKhachHang);
                item.SubItems.Add(soHoaDon.ToString());
            }
        }

        private void txtNameSearch_TextChanged(object sender, EventArgs e)
        {
            string key = txtNameSearch.Text;
            LoadKhachHangDataToListView(TimKiem_TenKH(key));
        }
        List<KhachHang> TimKiem_TenKH(string s)
        {
            s = s.ToLower().Trim();
            List<KhachHang> listKH = new List<KhachHang>();
            foreach (KhachHang kh in listKhachHang)
            {
                string tenKH = kh.TenKhachHang.Trim().ToLower();
                if (tenKH.Contains(s))
                {
                    listKH.Add(kh);
                }
            }
            return listKH;
        }

        private void txtTelSearch_TextChanged(object sender, EventArgs e)
        {
            string key = txtTelSearch.Text;
            LoadKhachHangDataToListView(TimKiem_Tel(key));
        }
        List<KhachHang> TimKiem_Tel(string s)
        {
            s = s.ToLower().Trim();
            List<KhachHang> listKH = new List<KhachHang>();
            foreach (KhachHang kh in listKhachHang)
            {
                string tenKH = kh.SDT.Trim().ToLower();
                if (tenKH.Contains(s))
                {
                    listKH.Add(kh);
                }
            }
            return listKH;
        }
    }
}
