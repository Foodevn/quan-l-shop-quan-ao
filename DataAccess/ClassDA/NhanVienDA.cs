using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ClassDA
{
	public class NhanVienDA
	{
		public List<NhanVien> GetAll()
		{

			SqlConnection sqlConn = new SqlConnection(Ultilities.ConnectionString);
			sqlConn.Open();

			SqlCommand command = sqlConn.CreateCommand();
			command.CommandType = CommandType.StoredProcedure;
			command.CommandText = Ultilities.NhanVien_GetAll;


			SqlDataReader reader = command.ExecuteReader();
			List<NhanVien> list = new List<NhanVien>();
			while (reader.Read())
			{
				NhanVien nhanVien = new NhanVien();
				nhanVien.MaNhanVien = reader["MaNhanVien"].ToString();
				nhanVien.MatKhau = reader["MatKhau"].ToString();
				nhanVien.HoTen = reader["HoTen"].ToString();
				nhanVien.NgaySinh = Convert.ToDateTime(reader["NgaySinh"]);
				nhanVien.CCCD = reader["CCCD"].ToString();
			
				nhanVien.Email = reader["Email"].ToString();
				nhanVien.SDT = ( reader["SDT"]).ToString();
				nhanVien.NgayVaoLam = Convert.ToDateTime(reader["NgayVaoLam"]);
				
				if(reader["NgayThoiViec"]!=DBNull.Value)
				{
					nhanVien.NgayThoiViec = Convert.ToDateTime(reader["NgayThoiViec"]);
				}
				else
				{
					nhanVien.NgayThoiViec = new DateTime(1001,1,1);
				}
				nhanVien.GhiChu = reader["GhiChu"].ToString();

				nhanVien.Enable = Convert.ToInt32(reader["Enable"]);
				list.Add(nhanVien);

			}
			sqlConn.Close();
			return list;
		}
		public string Insert_Update_Delete(NhanVien nhanVien, int action)
		{

			SqlConnection sqlConn = new SqlConnection(Ultilities.ConnectionString);
			sqlConn.Open();

			SqlCommand command = sqlConn.CreateCommand();
			command.CommandType = CommandType.StoredProcedure;
			command.CommandText = Ultilities.NhanVien_InsertUpdateDelete;


			SqlParameter IDPara = new SqlParameter("@MaNhanVien", SqlDbType.Char, 10);
			IDPara.Direction = ParameterDirection.InputOutput;
			command.Parameters.Add(IDPara).Value = nhanVien.MaNhanVien;
			command.Parameters.Add("@MatKhau", SqlDbType.Char,100).Value = nhanVien.MatKhau;
			command.Parameters.Add("@HoTen", SqlDbType.NVarChar, 255).Value = nhanVien.HoTen;
			command.Parameters.Add("@NgaySinh", SqlDbType.DateTime).Value = nhanVien.NgaySinh;
			command.Parameters.Add("@CCCD", SqlDbType.Char, 15).Value = nhanVien.CCCD;

			command.Parameters.Add("@Email", SqlDbType.Char, 255).Value = nhanVien.Email;
			command.Parameters.Add("@SDT", SqlDbType.Char,13).Value = nhanVien.SDT;
			command.Parameters.Add("@NgayVaoLam", SqlDbType.DateTime).Value = nhanVien.NgayVaoLam;
			//command.Parameters.Add("@NgayThoiViec", SqlDbType.DateTime).Value = nhanVien.NgayThoiViec;
			command.Parameters.Add("@NgayThoiViec", SqlDbType.DateTime).Value = nhanVien.NgayThoiViec ?? (object)DBNull.Value;
			command.Parameters.Add("@GhiChu", SqlDbType.Char, 255).Value = nhanVien.GhiChu;

			command.Parameters.Add("@Enable", SqlDbType.Int).Value = nhanVien.Enable;
			command.Parameters.Add("@Action", SqlDbType.Int).Value = action;

			int result = command.ExecuteNonQuery();
			if (result > 0)
				return (string)command.Parameters["@MaNhanVien"].Value;
			return "";
		}
	}
}
