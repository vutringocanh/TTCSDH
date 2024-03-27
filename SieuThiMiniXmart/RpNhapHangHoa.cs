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
using BLL;

namespace SieuThiMiniXmart
{
    public partial class RpNhapHangHoa : Form
    {
        public RpNhapHangHoa()
        {
            InitializeComponent();
        }
        Modify modify = new Modify();
        private void RpNhapHangHoa_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.ReportEmbeddedResource = "SieuThiMiniXmart.RpNhapHangHoa.rdlc";
            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "DataSet1";
            reportDataSource.Value = modify.GetNhapHangHoa();
            reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer1.RefreshReport();

            
        }
    }
}
