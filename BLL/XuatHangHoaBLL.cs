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
    public class XuatHangHoaBLL
    {
        private XuatHangHoaDAL XuatHangHoaDAL;

        public XuatHangHoaBLL()
        {
            XuatHangHoaDAL = new XuatHangHoaDAL();
        }
        public List<XuatHangHoa> GetAllXuatHangHoa()
        {
            return XuatHangHoaDAL.GetAllXuatHangHoa();
        }
        public XuatHangHoa GetXuatHangHoaByTenXuatHangHoa(string mahd)
        {
            return XuatHangHoaDAL.GetXuatHangHoaByTenXuatHangHoa(mahd);
        }
        public bool AddXuatHangHoa(XuatHangHoa XuatHangHoa)
        {
            return XuatHangHoaDAL.AddXuatHangHoa(XuatHangHoa);
        }
        public bool UpdateXuatHangHoa(XuatHangHoa XuatHangHoa)
        {
            return XuatHangHoaDAL.UpdateXuatHangHoa(XuatHangHoa);
        }
        public bool DeleteXuatHangHoa(string XuatHangHoa)
        {
            return XuatHangHoaDAL.DeleteXuatHangHoa(XuatHangHoa);
        }
    }
}
