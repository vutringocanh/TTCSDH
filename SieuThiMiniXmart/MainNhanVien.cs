using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SieuThiMiniXmart
{
    public partial class MainNhanVien : Form
    {
        public MainNhanVien()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.Sizable;
        }


        string connectionString = DatabaseConnection.GetConnectionString();
        private Trogiup help;
        private Control previousControl;
        private void button4_Click(object sender, EventArgs e)
        {
            /*
            if (help == null || help.Visible == false)
            {
                help = new Trogiup();
                help.Show();
            }
            else
            {
                help.BringToFront();
            }
            */
            
            previousControl = PanelMain.Controls[0];
           
            Trogiup f = new Trogiup();
            f.TopLevel = false;
            f.Size = PanelMain.Size; // Set size of the new form to match PanelMain
            PanelMain.Controls.Clear();
            PanelMain.Controls.Add(f);
            f.Show();
            PanelMain.SizeChanged += (s, ev) => { f.Size = PanelMain.Size; };
            f.SizeChanged += (s, ev) => { PanelMain.Size = f.Size; };
            set_mau();
            button4.BackColor = Color.FromArgb(255, 128, 0);

        }
        private void ReturnToPreviousControl()
        {
            PanelMain.Controls.Clear();
            PanelMain.Controls.Add(previousControl);
        }
        //đăng xuất
        private void label6_Click(object sender, EventArgs e)
        {
            this.Close();
            Login loginForm = Application.OpenForms["Login"] as Login;
            if (loginForm != null)
            {
                loginForm.Show();
            }
        }
        //đổi mật khẩu
        private Doimatkhau dmk;
        private void label5_Click(object sender, EventArgs e)
        {
            dmk = new Doimatkhau();
                dmk.ShowDialog();

            //if (dmk == null || dmk.Visible == false)
            //{
            //    dmk = new Doimatkhau();
            //    dmk.Show();
            //}
            //else
            //{
            //    dmk.BringToFront();
            //}
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            lbdongho.Text = DateTime.Now.ToString("HH : mm : ss");
        }
        //phong to
        private bool isMaximized;
        private bool isReady;

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (!isMaximized) // nếu cửa sổ chưa được phóng to
            {
                this.WindowState = FormWindowState.Maximized; // phóng to cửa sổ
                pictureBox4.Image = Image.FromFile("C:\\Users\\Admin\\Documents\\ThucTap\\SieuThiMiniXmart\\SieuThiMiniXmart\\photo\\tab.png");
                isMaximized = true; // đánh dấu là đã phóng to
            }
            else
            {

                this.WindowState = FormWindowState.Normal; // khôi phục trạng thái cửa sổ trước đó
                pictureBox4.Image = Image.FromFile("C:\\Users\\Admin\\Documents\\ThucTap\\SieuThiMiniXmart\\SieuThiMiniXmart\\photo\\maximum.png");
                isMaximized = false; // đánh dấu là chưa phóng to
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void set_mau()
        {
            button1.BackColor = Color.FromArgb(240, 147, 43);
            button2.BackColor = Color.FromArgb(240, 147, 43);
            button3.BackColor = Color.FromArgb(240, 147, 43);
            button4.BackColor = Color.FromArgb(240, 147, 43);
            button5.BackColor = Color.FromArgb(240, 147, 43);
            button6.BackColor = Color.FromArgb(240, 147, 43);
        }
        

        private void MainNhanVien_Load(object sender, EventArgs e)
        {

            webBrowser1.Navigate("https://www.theweathernow.net/vi/vietnam/thai_nguyen");
            //hiên thị tên đăng nhập
            label1.Text = Login.tenTaiKhoan;
            // Tạo kết nối đến cơ sở dữ liệu
            //SqlConnection connection = new SqlConnection("Data Source=vutringoc;Initial Catalog=xmart;Integrated Security=True");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Tạo câu truy vấn SQL để lấy hình ảnh từ cơ sở dữ liệu
                string sql = "SELECT hinhanh FROM tb_nhanvien, loginnhanvien WHERE tb_nhanvien.taikhoan = loginnhanvien.taikhoan and  loginnhanvien.taikhoan = @Taikhoan";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Taikhoan", label1.Text); // thay `maQL` bằng giá trị khóa chính của bản ghi bạn muốn lấy hình ảnh

                // Thực thi câu truy vấn và lấy dữ liệu hình ảnh
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    byte[] imageData = (byte[])reader["hinhanh"];

                    // Hiển thị hình ảnh trong PictureBox
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        pictureBox8.Image = Image.FromStream(ms);
                    }
                }

                // Đóng kết nối đến cơ sở dữ liệu
                reader.Close();
                connection.Close();
            }
            //hien thi ca
            // Tạo kết nối đến CSDL
            //SqlConnection connection1 = new SqlConnection("Data Source=vutringoc;Initial Catalog=xmart;Integrated Security=True");

            using (SqlConnection connection1 = new SqlConnection(connectionString))
            {
                // Mở kết nối
                connection1.Open();

                // Tạo câu truy vấn SQL để lấy giá trị thoigianbatdau từ cơ sở dữ liệu
                string sql1 = "SELECT thoigianbatdau FROM tb_calam, tb_nhanvien, loginnhanvien WHERE tb_nhanvien.taikhoan = loginnhanvien.taikhoan AND tb_nhanvien.manv = tb_calam.manv AND loginnhanvien.taikhoan = @Taikhoan";
                SqlCommand command1 = new SqlCommand(sql1, connection1);
                command1.Parameters.AddWithValue("@Taikhoan", label1.Text);

                object result = command1.ExecuteScalar();
                if (result != null)
                {
                    TimeSpan thoigianbatdau = (TimeSpan)result;

                    // Gán giá trị thoigianbatdau vào Text của Label
                    label10.Text = thoigianbatdau.ToString();
                }
                else
                {
                    // Không có giá trị thoigianbatdau trả về từ truy vấn
                    // Thực hiện xử lý tương ứng ở đây
                    MessageBox.Show("Nhân viên chưa có ca làm việc bắt đầu");



                }

                // Thực hiện truy vấn và lấy giá trị của thoigianbatdau
                //TimeSpan thoigianbatdau = (TimeSpan)command1.ExecuteScalar();

                // Gán giá trị thoigianbatdau vào Text của Label
                //label10.Text = thoigianbatdau.ToString();

                // Đóng kết nối
                connection1.Close();
            }

            // Tạo kết nối đến CSDL
            //SqlConnection connection2 = new SqlConnection("Data Source=vutringoc;Initial Catalog=xmart;Integrated Security=True");

            using (SqlConnection connection2 = new SqlConnection(connectionString))
            {
                // Mở kết nối
                connection2.Open();

                // Tạo câu truy vấn SQL để lấy giá trị thoigianbatdau từ cơ sở dữ liệu
                string sql2 = "SELECT thoigianketthuc FROM tb_calam, tb_nhanvien, loginnhanvien WHERE tb_nhanvien.taikhoan = loginnhanvien.taikhoan AND tb_nhanvien.manv = tb_calam.manv AND loginnhanvien.taikhoan = @Taikhoan";
                SqlCommand command2 = new SqlCommand(sql2, connection2);
                command2.Parameters.AddWithValue("@Taikhoan", label1.Text);

                object result1 = command2.ExecuteScalar();
                if (result1 != null)
                {
                    TimeSpan thoigianketthuc = (TimeSpan)result1;

                    // Gán giá trị thoigianbatdau vào Text của Label
                    label11.Text = thoigianketthuc.ToString();
                }
                else
                {
                    // Không có giá trị thoigianbatdau trả về từ truy vấn
                    // Thực hiện xử lý tương ứng ở đây
                    MessageBox.Show("Nhân viên chưa có ca làm việc kết thúc");

                }

                // Thực hiện truy vấn và lấy giá trị của thoigianbatdau
                //TimeSpan thoigianketthuc = (TimeSpan)command2.ExecuteScalar();

                // Gán giá trị thoigianbatdau vào Text của Label
                //label11.Text = thoigianketthuc.ToString();

                // Đóng kết nối
                connection2.Close();

            }


            timer1.Enabled = true;
            Giaodiennhanvien f = new Giaodiennhanvien();
            f.TopLevel = false;
            f.Size = PanelMain.Size; // Set size of the new form to match PanelMain
            PanelMain.Controls.Clear();
            PanelMain.Controls.Add(f);
            f.Show();
            PanelMain.SizeChanged += (s, ev) => { f.Size = PanelMain.Size; };
            f.SizeChanged += (s, ev) => { PanelMain.Size = f.Size; };
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Giaodiennhanvien f = new Giaodiennhanvien();
            f.TopLevel = false;
            f.Size = PanelMain.Size; // Set size of the new form to match PanelMain
            PanelMain.Controls.Clear();
            PanelMain.Controls.Add(f);
            f.Show();
            PanelMain.SizeChanged += (s, ev) => { f.Size = PanelMain.Size; };
            f.SizeChanged += (s, ev) => { PanelMain.Size = f.Size; };
            set_mau();
            button6.BackColor = Color.FromArgb(255, 128, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmHangHoa f = new FrmHangHoa();
            f.TopLevel = false;
            f.Size = PanelMain.Size; // Set size of the new form to match PanelMain
            PanelMain.Controls.Clear();
            PanelMain.Controls.Add(f);
            f.Show();
            PanelMain.SizeChanged += (s, ev) => { f.Size = PanelMain.Size; };
            f.SizeChanged += (s, ev) => { PanelMain.Size = f.Size; };
            set_mau();
            button1.BackColor = Color.FromArgb(255, 128, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            set_mau();
            button2.BackColor = Color.FromArgb(255, 128, 0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmKhachHang f = new FrmKhachHang();
            f.TopLevel = false;
            f.Size = PanelMain.Size; // Set size of the new form to match PanelMain
            PanelMain.Controls.Clear();
            PanelMain.Controls.Add(f);
            f.Show();
            PanelMain.SizeChanged += (s, ev) => { f.Size = PanelMain.Size; };
            f.SizeChanged += (s, ev) => { PanelMain.Size = f.Size; };
            set_mau();
            button3.BackColor = Color.FromArgb(255, 128, 0);
        }

        private void label8_Click(object sender, EventArgs e)
        {
            previousControl = PanelMain.Controls[0];

            Thongtinnhanvien f = new Thongtinnhanvien();
            f.TopLevel = false;
            f.Size = PanelMain.Size; // Set size of the new form to match PanelMain
            PanelMain.Controls.Clear();
            PanelMain.Controls.Add(f);
            f.Show();
            PanelMain.SizeChanged += (s, ev) => { f.Size = PanelMain.Size; };
            f.SizeChanged += (s, ev) => { PanelMain.Size = f.Size; };
             

          
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmThongKe f = new FrmThongKe();
            f.TopLevel = false;
            f.Size = PanelMain.Size; // Set size of the new form to match PanelMain
            PanelMain.Controls.Clear();
            PanelMain.Controls.Add(f);
            f.Show();
            PanelMain.SizeChanged += (s, ev) => { f.Size = PanelMain.Size; };
            f.SizeChanged += (s, ev) => { PanelMain.Size = f.Size; };
            set_mau();
            button5.BackColor = Color.FromArgb(255, 128, 0);
        }
    }
}
