using DataAccess.ClassDA;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLog
{
    public class ChiTietPhieuNhapBL
    {
        ChiTietPhieuNhapDA ChiTietPhieuNhapDA = new ChiTietPhieuNhapDA();
        public List<ChiTietPhieuNhap> GetAll()
        {
            return ChiTietPhieuNhapDA.GetAll();
        }
        public string Insert(ChiTietPhieuNhap chiTietPhieuNhap)
        {
            return ChiTietPhieuNhapDA.Insert_Update_Delete(chiTietPhieuNhap, 0);
        }
        public string Update(ChiTietPhieuNhap chiTietPhieuNhap)
        {
            return ChiTietPhieuNhapDA.Insert_Update_Delete(chiTietPhieuNhap, 1);
        }
        public string Delete(ChiTietPhieuNhap chiTietPhieuNhap)
        {
            return ChiTietPhieuNhapDA.Insert_Update_Delete(chiTietPhieuNhap, 2);
        }
    }
}
