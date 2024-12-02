using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
	public class NhanVien
	{
		public string MaNhanVien { get; set; }
		public string MatKhau {  get; set; }
		public string HoTen { get; set; }
		public DateTime NgaySinh { get; set; }

		public string CCCD { get; set; }
		public string Email { get; set; }
		public string SDT { get; set; }
		public DateTime NgayVaoLam { get; set; }
		public DateTime? NgayThoiViec { get; set; }
		public string GhiChu { get; set; }

		public int Enable { get; set; }
	}

}
