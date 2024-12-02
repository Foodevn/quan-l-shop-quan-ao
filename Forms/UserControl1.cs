using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_ly_Shop_Quan_ao_1.Forms
{
	public partial class UserControl1 : UserControl
	{
		public UserControl1(string ten,string gia)
		{
			InitializeComponent();
			this.lbTenMatHang.Text = ten;
			this.lbGia.Text = gia;

		}
	}
}
