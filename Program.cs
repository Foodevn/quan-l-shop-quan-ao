﻿using Chitietphieunhau;
using quan_ly_shop_quan_ao;
using quanlyshopquanao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using XemLaiHoaDon;



namespace Quan_ly_Shop_Quan_ao_1
{
	internal static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new formDangNhap());
			//Application.Run(new menu());
			//Application.Run(new formShop());
			//Application.Run(new test());
			//Application.Run(new FrmXemDSHang());
			//Application.Run(new Lapphieunhaphangmoi());
			//Application.Run(new FrmXemLaiHoaDon());
			//Application.Run(new Xemlaiphieunhaphang());
			//Application.Run(new FormQuanLyTaiKhoanNguoiDung());
			//Application.Run(new InHoaDon(""));



		}
	}
}
