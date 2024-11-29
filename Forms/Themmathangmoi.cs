using BusinessLog;
using DataAccess;
using DataAccess.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlyshopquanao
{
    public partial class Themmathangmoi : Form
    {
        public bool insert;
        public bool update;
        public string MaSP { get; set; }
        public Themmathangmoi(string maSP)
        {
            insert = false;
            update = false;
            InitializeComponent();
            MaSP = maSP;
        }
        List<NhomMatHang> listNhomMatHang = new List<NhomMatHang>();
        List<DataAccess.Size> listSize = new List<DataAccess.Size>();
        List<MauSac> listMauSac = new List<MauSac>();
        List<SanPham> listSanPham = new List<SanPham>();

        SanPham sp=new SanPham();

        private void LoadNhomMatHang()
        {
            NhomMatHangBL nhomMatHangBL = new NhomMatHangBL();
            listNhomMatHang = nhomMatHangBL.GetAll();
            for (int i = 0; i < listNhomMatHang.Count; i++)
            {
                if (listNhomMatHang[i].MaNhomMatHang == "001")
                    listNhomMatHang.Remove(listNhomMatHang[i]);
            }
            cbbNhomMatHang.DataSource = listNhomMatHang;
            cbbNhomMatHang.ValueMember = "MaNhomMatHang";
            cbbNhomMatHang.DisplayMember = "TenNhomMatHang";

        }
        private void LoadSize()
        {
            SizeBL sizeBL = new SizeBL();
            listSize = sizeBL.GetAll();
            for (int i = 0; i < listSize.Count; i++)
            {
                if (listSize[i].MaSize.Trim() == "S0000")
                    listSize.Remove(listSize[i]);
            }
            cbbSize.DataSource = listSize;
            cbbSize.ValueMember = "MaSize";
            cbbSize.DisplayMember = "TenSize";

        }
        private void LoadMau()
        {
            MauSacBL mauSacBL = new MauSacBL();
            listMauSac = mauSacBL.GetAll();
            for (int i = 0; i < listMauSac.Count; i++)
            {
                if (listMauSac[i].MaMau.Trim() == "MS0000")
                    listMauSac.Remove(listMauSac[i]);
            }
            cbbMau.DataSource = listMauSac;
            cbbMau.ValueMember = "MaMau";
            cbbMau.DisplayMember = "TenMau";

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadNhomMatHang();
            LoadSize();
            LoadMau();
            if (insert)
            {
                btnSaveUpdate.Visible = false;
            }
            if (update)
            {
                btnSaveAdd.Visible = false;
                txtMa.Text = MaSP;
                loadSP();
            }
        
        }
        void loadSP()
        {
            SanPhamBL sanPhamBL = new SanPhamBL();
            List<SanPham> listSP=sanPhamBL.GetAll();
            foreach (SanPham sp in listSP)
            {
                if(sp.MaSP==MaSP)
                {                   
                    txtTen.Text = sp.TenSP;
                    txtGiaban.Text = sp.GiaBan.ToString();
                    txtSL.Text=sp.SLTon.ToString();
                    txtNCC.Text=sp.NhaCungCap.ToString();
                    txtMota.Text = sp.GhiChu;
                    if(sp.Enable==1)
                    {
                        cbEnable.Checked = true;
                    }
                    //for(int i=0;i<cbbMau.Items.Count;i++)
                    //{
                    //    if (((Item)cbbMau.Items[i]))
                    //}
                    cbbMau.SelectedIndex = listMauSac.FindIndex(x => x.MaMau == sp.IDMau);
                    cbbSize.SelectedIndex = listSize.FindIndex(x => x.MaSize == sp.IDSize);
                    cbbNhomMatHang.SelectedIndex = listNhomMatHang.FindIndex(x => x.MaNhomMatHang == sp.IDNhomMatHang);

                }
            }


        }
       

        private void button4_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                openFileDialog.Title = "Select an Image";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtImage.Text = openFileDialog.FileName;

                    pbHinh.Image=Image.FromFile(openFileDialog.FileName);
                }
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbbNhomMatHang_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        string ThemSP()
        {
            string Ten = txtTen.Text;
            string NCC = txtNCC.Text;

            int SL = txtSL.Text != "" ? int.Parse(txtSL.Text) : 0;
            int enable = cbEnable.Checked ? 1 : 0;


            if (string.IsNullOrEmpty(Ten) || string.IsNullOrEmpty(txtGiaban.Text) || string.IsNullOrEmpty(NCC))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin cần thiết của sản phẩm");
                return "";
            }
            SanPhamBL sanPhamBL = new SanPhamBL();
            SanPham sp = new SanPham()
            {
                MaSP = "",
                IDNhomMatHang = cbbNhomMatHang.SelectedValue.ToString().Trim(),
                TenSP = txtTen.Text,
                GiaBan = float.Parse(txtGiaban.Text),
                SLTon = SL,
                NhaCungCap = txtNCC.Text,
                IDMau = cbbMau.SelectedValue.ToString().Trim(),
                IDSize = cbbSize.SelectedValue.ToString().Trim(),
                GhiChu = txtMota.Text,
                Enable = enable,
            };
            return sanPhamBL.Insert(sp);
        }

        private void btnSaveAdd_Click(object sender, EventArgs e)
        {
            string s = ThemSP();
            Debug.WriteLine(s);
            if (s != "")
                MessageBox.Show("Thêm mặt hàng thành công");
            else MessageBox.Show("Thêm mặt hàng không thành công. Vui lòng kiểm tra lại dữ liệu nhập");

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        public string UpdateSP()
        {
            SanPham sanpham = sp;
            string Ten = txtTen.Text;
            string NCC = txtNCC.Text;
            int SL = txtSL.Text != "" ? int.Parse(txtSL.Text) : 0;
            int enable = cbEnable.Checked ? 1 : 0;
            if (string.IsNullOrEmpty(Ten) || string.IsNullOrEmpty(txtGiaban.Text) || string.IsNullOrEmpty(NCC))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin cần thiết của sản phẩm");
                return "";
            }
            else
            {
                sanpham.MaSP = MaSP;
                sanpham.TenSP =txtTen.Text;
                sanpham.NhaCungCap=txtNCC.Text;
                sanpham.GhiChu=txtMota.Text;
                sanpham.IDMau=cbbMau.SelectedValue.ToString().Trim();
                sanpham.IDSize=cbbSize.SelectedValue.ToString().Trim();
                sanpham.IDNhomMatHang=cbbNhomMatHang.SelectedValue.ToString().Trim();
                sanpham.GiaBan=float.Parse(txtGiaban.Text);
                SL=int.Parse(txtSL.Text);
                sanpham.SLTon = SL;
                enable=cbEnable.Checked ? 1 : 0;
                sanpham.Enable = enable;
                SanPhamBL sanPhamBL = new SanPhamBL();
                return sanPhamBL.Update(sanpham);
            }
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string s = UpdateSP();
            Debug.WriteLine(s);
            if (s!="")
            {
                MessageBox.Show("Cập nhật mặt hàng thành công");
           
            }
            else MessageBox.Show("Cập nhật hàng không thành công. Vui lòng kiểm tra lại dữ liệu nhập");
            Close();
        }
    }
}
