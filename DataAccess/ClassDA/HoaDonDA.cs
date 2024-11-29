﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ClassDA
{
    public class HoaDonDA
    {
        public List<HoaDon> GetAll()
        {
            SqlConnection sqlConn = new SqlConnection(Ultilities.ConnectionString);
            sqlConn.Open();

            SqlCommand command = sqlConn.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = Ultilities.HoaDon_GetAll;

            SqlDataReader reader = command.ExecuteReader();
            List<HoaDon> list = new List<HoaDon>();
            while (reader.Read())
            {
                HoaDon hoaDon = new HoaDon();
                hoaDon.MaHoaDon = reader["MaHoaDon"].ToString();
                hoaDon.NgayLap = DateTime.Parse(reader["NgayLap"].ToString());
                hoaDon.TongTien = Convert.ToInt32(reader["TongTien"]);
                hoaDon.MaKH = reader["MaKH"].ToString();
                hoaDon.MaNV = reader["MaNV"].ToString();
				hoaDon.GiamGiaHD = Convert.ToSingle(reader["GiamGiaHD"]);
				hoaDon.PhiShip = Convert.ToInt32(reader["PhiShip"]);
				hoaDon.Vat = Convert.ToSingle(reader["Vat"]);
				hoaDon.GhiChu = reader["GhiChu"].ToString();
				hoaDon.TrangThai = reader["TrangThai"].ToString();
                hoaDon.Enable = Convert.ToInt32(reader["Enable"]);
                list.Add(hoaDon);
            }
            sqlConn.Close();
            return list;
        }
        public string Insert_Update_Delete(HoaDon hoaDon, int action)
        {
            SqlConnection sqlConn = new SqlConnection(Ultilities.ConnectionString);
            sqlConn.Open();

            SqlCommand command = sqlConn.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = Ultilities.HoaDon_InsertUpdateDelete;

            SqlParameter IDPara = new SqlParameter("@MaHoaDon", SqlDbType.Char, 10);
            IDPara.Direction = ParameterDirection.InputOutput;

            command.Parameters.Add(IDPara).Value = hoaDon.MaHoaDon;
            command.Parameters.Add("@NgayLap", SqlDbType.Date).Value = hoaDon.NgayLap;
            command.Parameters.Add("@TongTien", SqlDbType.Int).Value = hoaDon.TongTien;
            command.Parameters.Add("@MaKH", SqlDbType.Char, 10).Value = hoaDon.MaKH;
            command.Parameters.Add("@MaNV", SqlDbType.Char, 10).Value = hoaDon.MaNV;
			command.Parameters.Add("@GiamGiaHD", SqlDbType.Float).Value = hoaDon.GiamGiaHD;
			command.Parameters.Add("@PhiShip", SqlDbType.Float).Value = hoaDon.PhiShip;
			command.Parameters.Add("@Vat", SqlDbType.Float).Value = hoaDon.Vat;
			command.Parameters.Add("@GhiChu", SqlDbType.Char, 255).Value = hoaDon.GhiChu;
			command.Parameters.Add("@TrangThai", SqlDbType.Char, 255).Value = hoaDon.TrangThai;
            command.Parameters.Add("@Enable", SqlDbType.Int).Value=hoaDon.Enable;
            command.Parameters.Add("@Action", SqlDbType.Int).Value = action;

            int result = command.ExecuteNonQuery();
            if (result > 0) // Nếu thành công thì trả về ID đã thêm
                return (string)command.Parameters["@MaHoaDon"].Value;
            return "";
        }

    }
}

