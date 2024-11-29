using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLog;
using DataAccess;
using DataAccess.Class;
using DataAccess.ClassDA;
using quanlyshopquanao;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace XemLaiHoaDon
{
    public partial class FrmXemDSHang : Form
    {
        private DataTable DSHang;
        private List<string> data;

        public FrmXemDSHang()
        {
            InitializeComponent();

        }
        List<NhomMatHang> listNhomMatHang = new List<NhomMatHang>();
        List<SanPham> listSanPham = new List<SanPham>();
        List<DataAccess.Size> listSize = new List<DataAccess.Size>();
        List<MauSac> listMauSac = new List<MauSac>();
        SanPham sp = new SanPham();

        private void FrmXemDSHang_Load(object sender, EventArgs e)
        {
            LoadNhomMatHang();
            LoadSanPhamDataToListView();
        }
        private void LoadNhomMatHang()
        {
            NhomMatHangBL nhomMatHangBL = new NhomMatHangBL();
            listNhomMatHang = nhomMatHangBL.GetAll();
            cbbNhomMatHang.DataSource = listNhomMatHang;
            cbbNhomMatHang.ValueMember = "MaNhomMatHang";
            cbbNhomMatHang.DisplayMember = "TenNhomMatHang";
        }

        public void LoadSanPhamDataToListView()
        {
            SanPhamBL sanPhamBL = new SanPhamBL();
            listSanPham = sanPhamBL.GetAll();
            SizeBL sizeBL = new SizeBL();
            listSize = sizeBL.GetAll();
            MauSacBL mauSacBL = new MauSacBL();
            listMauSac = mauSacBL.GetAll();

            lvDS.Items.Clear();
            foreach (var sanPham in listSanPham)
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



        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim().ToLower();

            List<ListViewItem> ketQuaTimKiem = new List<ListViewItem>();

            foreach (ListViewItem item in lvDS.Items)
            {

                string maHang = item.SubItems[0].Text.ToLower();
                string tenHang = item.SubItems[1].Text.ToLower();
                string tenSP = item.SubItems[2].Text.ToLower();


                if (maHang.Contains(searchText) || tenHang.Contains(searchText) || tenSP.Contains(searchText))
                {

                    ketQuaTimKiem.Add(item);
                }
            }
            lvDS.Items.Clear();
            foreach (ListViewItem resultItem in ketQuaTimKiem)
            {
                lvDS.Items.Add(resultItem);

            }
            if (ketQuaTimKiem.Count == 0)
            {
                MessageBox.Show("Không tìm thấy kết quả phù hợp!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            cbbNhomMatHang.SelectedValue = "001";
            lvDS.Items.Clear();
            LoadSanPhamDataToListView();
            return;
        }

        private void cbbNhomMatHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            TimKiemv2();
        }
        void LoadlvDS(List<SanPham> list)
        {
            lvDS.Items.Clear();
            foreach (SanPham sp in list)
            {
                ListViewItem item = lvDS.Items.Add(sp.MaSP);
                string tenNhomMatHang = listNhomMatHang.Find(x => x.MaNhomMatHang == sp.IDNhomMatHang).TenNhomMatHang;
                item.SubItems.Add(tenNhomMatHang);
                item.SubItems.Add(sp.TenSP);
                item.SubItems.Add(sp.GiaBan.ToString());
                item.SubItems.Add(sp.SLTon.ToString());
                item.SubItems.Add(sp.NhaCungCap.ToString());
                string tenMauSac = listMauSac.Find(x => x.MaMau == sp.IDMau).TenMau;
                item.SubItems.Add(tenMauSac);
                string tenSize = listSize.Find(x => x.MaSize == sp.IDSize).TenSize;
                item.SubItems.Add(tenSize);
                item.SubItems.Add(sp.GhiChu.ToString());
                string trangThai = "Không bán";
                if (sp.Enable == 1)
                {
                    trangThai = "Đang bán";
                }
                item.SubItems.Add(trangThai);
            }
            lvDS.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvDS.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        List<SanPham> TimKiemv2()
        {
            string searchText = cbbNhomMatHang.SelectedValue.ToString();
            List<SanPham> ketQuaTimKiem = new List<SanPham>();
            if (searchText == "001")
            {
                lvDS.Items.Clear();
                LoadSanPhamDataToListView();
                return ketQuaTimKiem;
            }
            foreach (SanPham sp in listSanPham)
            {
                string maHang = sp.IDNhomMatHang;


                if (maHang.Contains(searchText))
                {
                    ketQuaTimKiem.Add(sp);
                }
            }
            lvDS.Items.Clear();
            LoadlvDS(ketQuaTimKiem);
            return ketQuaTimKiem;

        }

        private void btnThemHang_Click(object sender, EventArgs e)
        {
            Themmathangmoi themmathangmoi = new Themmathangmoi("");
            themmathangmoi.insert = true;
            themmathangmoi.ShowDialog();
        }

        private void cậpNhậtSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cmsUpdate_Opening(object sender, CancelEventArgs e)
        {

        }

        private void cậpNhậtSảnPhẩmToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (lvDS.SelectedItems.Count > 0)
            {
                ListViewItem item = lvDS.SelectedItems[0];
                string masp = item.SubItems[0].Text;
                Themmathangmoi themmathangmoi = new Themmathangmoi(masp);
                themmathangmoi.update = true;
                themmathangmoi.Show();
                themmathangmoi.FormClosed += FrmXemDSHang_Load;
            }

        }


    }
}
