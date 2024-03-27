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
    public class NhapHangHoaBLL
    {
        private NhapHangHoaDAL NhapHangHoaDAL;

        public NhapHangHoaBLL()
        {
            NhapHangHoaDAL = new NhapHangHoaDAL();
        }
        public List<NhapHangHoa> GetAllNhapHangHoa()
        {
            return NhapHangHoaDAL.GetAllNhapHangHoa();
        }
        public NhapHangHoa GetNhapHangHoaByTenNhapHangHoa(string tenhang)
        {
            return NhapHangHoaDAL.GetNhapHangHoaByTenNhapHangHoa(tenhang);
        }
        public bool AddNhapHangHoa(NhapHangHoa NhapHangHoa)
        {
            return NhapHangHoaDAL.AddNhapHangHoa(NhapHangHoa);
        }
        public bool UpdateNhapHangHoa(NhapHangHoa NhapHangHoa)
        {
            return NhapHangHoaDAL.UpdateNhapHangHoa(NhapHangHoa);
        }
        public bool DeleteNhapHangHoa(string NhapHangHoa)
        {
            return NhapHangHoaDAL.DeleteNhapHangHoa(NhapHangHoa);
        }
    }
}
