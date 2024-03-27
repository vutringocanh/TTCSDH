using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;
using DAL;

namespace BLL
{
    public class KhachHangBLL
    {
        private KhachHangDAL KhachHangDAL;

        public KhachHangBLL()
        {
            KhachHangDAL = new KhachHangDAL();
        }
        public List<KhachHang> GetAllKhachHang()
        {
            return KhachHangDAL.GetAllKhachHang();
        }
        public List<KhachHang> GetKhachHangByTenKhachHang(string tenkh)
        {
            return KhachHangDAL.GetKhachHangByTenKhachHang(tenkh);
        }
        public bool AddKhachHang(KhachHang KhachHang)
        {
            return KhachHangDAL.AddKhachHang(KhachHang);
        }
        public bool UpdateKhachHang(KhachHang KhachHang)
        {
            return KhachHangDAL.UpdateKhachHang(KhachHang);
        }
        public bool DeleteKhachHang(string KhachHang)
        {
            return KhachHangDAL.DeleteKhachHang(KhachHang);
        }
    }
}
