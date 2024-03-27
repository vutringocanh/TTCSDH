using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SieuThiMiniXmart
{
    public partial class RpInHoaDonMuaHang2 : Form
    {
        private FrmHoaDon _FrmHoaDon;

        public RpInHoaDonMuaHang2(FrmHoaDon frmHoaDon)
        {
            InitializeComponent();
            _FrmHoaDon = frmHoaDon;
        }

        private void RpInHoaDonMuaHang2_Load(object sender, EventArgs e)
        {
            // Thiết lập tài nguyên báo cáo được nhúng
            reportViewer1.LocalReport.ReportEmbeddedResource = "SieuThiMiniXmart.RpInHoaDonMuaHang2.rdlc";

            // Lấy dữ liệu từ cơ sở dữ liệu
            Modify modify = new Modify();
            string mahd = _FrmHoaDon.GetMahd();
            
            DataTable dt = modify.InHDmuahang(mahd);

            // Tạo đối tượng ReportDataSource và thiết lập tên và giá trị của nó
            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "DataSet1";
            reportDataSource.Value = dt;

            // Thiết lập danh sách các bảng dữ liệu cho báo cáo
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(reportDataSource);

            // Cập nhật và hiển thị báo cáo
            reportViewer1.RefreshReport();



        }
    }
}
