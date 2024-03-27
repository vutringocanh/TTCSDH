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
    public partial class Trogiup : Form
    {
        public Trogiup()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("____________________________HƯỚNG DẪN_______________________________\r\n- Click file: SieuThiMiniXmart.sln để mở mở solution chứa folder/code \r\n- Sử dụng tài khoản được cấp(tk: admin, mk: admin) để đăng nhập vào hệ thống (khi đăng nhập thành công bạn có thể tạo thêm tài khoản mới)\r\n- Attach database cũ (file mdf hoặc bak) vào sql server 'xem hướng dẫn trên youtube cách backup dữ liệu với file mdf, bak'\r\n- Thay đổi tên server trong file 'DatabaseConnection.cs' và 'DAL/DatabaseConnection.cs', thay đổi tên server 'vutringoc' thành server của máy ví dụ 'ADMIN\\SQLEXPRESS' (xem thông tin server trên sql server)\r\n- Chức năng lưu tài khoản mật khẩu ở form đăng nhập (Khi bạn đăng nhập thành công, hệ thống sẽ lưu tài khoản mật khẩu vào file text để lần sau khi bạn mở thì hệ thống không yêu cầu bạn nhập lại tài khoản mật khẩu nữa) nhưng cần Thay đổi vị trí file text tại file Login.cs (@\"C:\\Users\\Admin\\Downloads\\login.txt\") thành vị trí bạn đặt file ví dụ: @\"C:\\TUANANH\\Downloads\\login.txt\"\r\n- Phân quyền:\r\n+ Nhân Viên: quản lý khách hàng, quản lý hóa đơn, quản Lý hàng hóa, xem ds..\r\n+ Quản Lý: Thống Kê + full quyền\r\n- Để tạo chi tiết hóa đơn đơn cần tạo hóa đơn trước\r\n- In hóa đơn: để sử dụng chức năng này bạn cần cài 2 tool là report tại nuget package và extention report dành cho winform (xem hd trên youtube)\r\n- Thay đổi địa chỉ tại file: mainAdmin.cs, mainNhanvien.cs \"C:\\\\Users\\\\Admin\\\\Documents\\\\ThucTap\\\\SieuThiMiniXmart\\\\SieuThiMiniXmart\\\\photo\\\\maximum.png\" (thay đổi \"C:\\\\Users\\\\Admin\\\\Documents\\\\\" thành vị trí bạn đặt file ví dụ trong trường hợp bạn tải về để tại Download: \"C:\\\\Users\\\\TUANANH\\\\DownloadS\\\\ThucTap\\\\SieuThiMiniXmart\\\\SieuThiMiniXmart\\\\photo\\\\maximum.png\")\r\nviệc thay đổi trên để hiển thị hình ảnh góc trên bên phải (phóng to, thu nhỏ, dấu x đóng) \r\n- Thêm thông tin cần nhập đủ thông tin\r\n- Chỉnh sửa thông tin theo mã\r\n- Xóa thông tin theo mã \r\n- Tìm kiếm theo tên hoặc theo mã hoặc theo thời gian\r\n- Thống kê doanh thu theo tháng, theo thời gian\r\n- Thống kê hàng tồn trong kho\r\n\r\n\r\n\r\n- Liên hệ: fb.com/vutrianhngoc");
        }

        private void Trogiup_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://www.fb.com/vutrianhngoc");
            webBrowser2.Navigate("https://www.google.com");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (webBrowser1.CanGoBack)
            {
                webBrowser1.GoBack();
            }
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            if (webBrowser1.CanGoForward)
            {
                webBrowser1.GoForward();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (webBrowser2.CanGoForward)
            {
                webBrowser2.GoForward();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser2.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (webBrowser2.CanGoBack)
            {
                webBrowser2.GoBack();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (webBrowser2.CanGoBack)
            {
                webBrowser2.GoBack();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            webBrowser2.Refresh();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (webBrowser2.CanGoForward)
            {
                webBrowser2.GoForward();
            }
        }
    }
}
