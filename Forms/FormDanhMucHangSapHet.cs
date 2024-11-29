using BusinessLog;
using DataAccess.Class;
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
    public partial class FormDanhMucHangSapHet : Form
    {
        public FormDanhMucHangSapHet()
        {
            InitializeComponent();
        }
        List<NhomMatHang> listNhomMatHang = new List<NhomMatHang>();
        List<SanPham> listSanPham = new List<SanPham>();
        List<DataAccess.Size> listSize = new List<DataAccess.Size>();
        List<MauSac> listMauSac = new List<MauSac>();
        SanPham sp = new SanPham();
        private void FormDanhMuaHangSapHet_Load(object sender, EventArgs e)
        {
            LoadSanPhamDataToListView(listSanPham);
            nupSLMin.Value = 20;
        }
        public void LoadSanPhamDataToListView(List<SanPham> sanPhams)
        {
            SanPhamBL sanPhamBL = new SanPhamBL();
            listSanPham = sanPhamBL.GetAll();
            SizeBL sizeBL = new SizeBL();
            listSize = sizeBL.GetAll();
            MauSacBL mauSacBL = new MauSacBL();
            listMauSac = mauSacBL.GetAll();
            NhomMatHangBL nhomMatHangBL = new NhomMatHangBL();
            listNhomMatHang = nhomMatHangBL.GetAll();

            lvDS.Items.Clear();
            foreach (var sanPham in sanPhams)
            {
                ListViewItem item = lvDS.Items.Add(sanPham.MaSP);
                string Name = listNhomMatHang
               .Find(x => x.MaNhomMatHang == sanPham.IDNhomMatHang).TenNhomMatHang;
                string NameSize = listSize
               .Find(x => x.MaSize == sanPham.IDSize).TenSize;
                string NameColor = listMauSac
               .Find(x => x.MaMau == sanPham.IDMau).TenMau;
                item.SubItems.Add(Name);
                item.SubItems.Add(sanPham.TenSP);
                item.SubItems.Add(sanPham.GiaBan.ToString());
                item.SubItems.Add(sanPham.SLTon.ToString());
                item.SubItems.Add(sanPham.NhaCungCap);
                item.SubItems.Add(NameColor);
                item.SubItems.Add(NameSize);
                item.SubItems.Add(sanPham.GhiChu);
                string trangThai = "Không bán";
                if (sanPham.Enable == 1)
                {
                    trangThai = "Đang bán";
                }
                item.SubItems.Add(trangThai);
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(cbEnable.Checked==true)
            {
                LoadSanPhamDataToListView(TimSoLuongHangTon((int)nupSLMin.Value));
            }
            else
            {
                LoadSanPhamDataToListView(TimSoLuongConKinhDoanh(1, (int)nupSLMin.Value));
            }
        }

        private void nupSLMin_ValueChanged(object sender, EventArgs e)
        {
           LoadSanPhamDataToListView( TimSoLuongHangTon((int)nupSLMin.Value));
        }

     
 
        List<SanPham> TimSoLuongHangTon(int SoLuong)
        {
            lvDS.Items.Clear();
            List<SanPham> kq = new List<SanPham>();
            foreach (var sanPham in listSanPham)
            {
                if (SoLuong >= sanPham.SLTon)
                {
                    kq.Add(sanPham);
                }
            }
            return kq;
        }
        List<SanPham> TimSoLuongConKinhDoanh(int Enable, int SoLuong)
        {
            lvDS.Items.Clear();
            List<SanPham> kq = new List<SanPham>();
            foreach (var sanPham in listSanPham)
            {
                if (sanPham.Enable==Enable && SoLuong >= sanPham.SLTon)
                {
                    kq.Add(sanPham);
                }
            }
            return kq;
        }
    }
}
