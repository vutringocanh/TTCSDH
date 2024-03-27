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
    
    public class NhaCungCapBLL
    {
        private NhaCungCapDAL NhaCungCapDAL;

        public NhaCungCapBLL()
        {
            NhaCungCapDAL = new NhaCungCapDAL();
        }
        public List<NhaCungCap> GetAllNhaCungCap()
        {
            return NhaCungCapDAL.GetAllNhaCungCap();
        }
        public List<NhaCungCap> GetNhaCungCapByTenNhaCungCap(string tenncc)
        {
            return NhaCungCapDAL.GetNhaCungCapByTenNhaCungCap(tenncc);
        }

        public bool AddNhaCungCap(NhaCungCap NhaCungCap)
        {
            return NhaCungCapDAL.AddNhaCungCap(NhaCungCap);
        }
        public bool UpdateNhaCungCap(NhaCungCap NhaCungCap)
        {
            return NhaCungCapDAL.UpdateNhaCungCap(NhaCungCap);
        }
        public bool DeleteNhaCungCap(string NhaCungCap)
        {
            return NhaCungCapDAL.DeleteNhaCungCap(NhaCungCap);
        }
    }
}
