using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using DTO;

namespace SieuThiMiniXmart
{
    public partial class MainAdmin : Form
    {
        //bientoancuc public static de goi den bat ki dau
        public static SqlConnection connection = new SqlConnection("Data Source=NGOC\\SQLEXPRESS;Initial Catalog=xmart;Integrated Security=True");
        


        /*private string GetWeatherData()
        {
            string url = "http://api.weatherstack.com/current?access_key=7edf8c87886c16f5aa26745de935935a&query=Viet%20Nam";
            WebClient client = new WebClient();
            return client.DownloadString(url);
         
        } */
        public MainAdmin()
        {
            InitializeComponent();
        
            this.FormBorderStyle = FormBorderStyle.Sizable;
            

        }
        string connectionString = DatabaseConnection.GetConnectionString();
        private void set_mau()
        {
            button12.BackColor = Color.FromArgb(240, 147, 43);
            button1.BackColor = Color.FromArgb(240, 147, 43);
            button2.BackColor = Color.FromArgb(240, 147, 43);
            button3.BackColor = Color.FromArgb(240, 147, 43);
            button4.BackColor = Color.FromArgb(240, 147, 43);
            button5.BackColor = Color.FromArgb(240, 147, 43);
            button6.BackColor = Color.FromArgb(240, 147, 43);
            button7.BackColor = Color.FromArgb(240, 147, 43);
        }
        private void MainAdmin_Load(object sender, EventArgs e)
        {


            //webBrowser1.Navigate("https://www.theweathernow.net/vi/vietnam/thai_nguyen");

            //hiên thị tên đăng nhập
            label1.Text = Login.tenTaiKhoan;


            // Tạo kết nối đến cơ sở dữ liệu
            //SqlConnection connection = new SqlConnection("Data Source=vutringoc;Initial Catalog=xmart;Integrated Security=True");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Tạo câu truy vấn SQL để lấy hình ảnh từ cơ sở dữ liệu
                string sql = "SELECT hinhanh FROM tb_quanly, loginquanly WHERE tb_quanly.taikhoan = loginquanly.taikhoan and  loginquanly.taikhoan = @Taikhoan";
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


            // TODO: This line of code loads data into the 'xmartDataSet1.loginquanly' table. You can move, or remove it, as needed.
            //this.loginquanlyTableAdapter.Fill(this.xmartDataSet1.loginquanly);
            // TODO: This line of code loads data into the 'xmartDataSet.loginnhanvien' table. You can move, or remove it, as needed.
            //this.loginnhanvienTableAdapter.Fill(this.xmartDataSet.loginnhanvien);
            timer1.Enabled = true;
            //timer1.Start();

            //truyen pannel = from giaodienquanly
            Giaodienquanly f = new Giaodienquanly();
            f.TopLevel = false;
            f.Size = PanelMain.Size; // Set size of the new form to match PanelMain
            PanelMain.Controls.Clear();
            PanelMain.Controls.Add(f);
            f.Show();
            PanelMain.SizeChanged += (s, ev) => { f.Size = PanelMain.Size; };
            f.SizeChanged += (s, ev) => { PanelMain.Size = f.Size; };



            // string json = GetWeatherData();
            //dynamic result = JsonConvert.DeserializeObject(json);

            //double temperature = result.current.temperature;
            //string weatherDescription = result.current.weather_descriptions[0];

            /* if (temperature >= 30)
             {
                 pictureBox2.Image = imageIndex.Images[2]; // hot weather image
             }
             else if (temperature >= 20)
             {
                 pictureBox2.Image = imageIndex.Images[0]; // warm weather image
             }
             else if (temperature >= 10)
             {
                 pictureBox2.Image = imageIndex.Images[1]; // rain weather image
             }

             label2.Text = $"Temperature: {temperature}°C";
             label3.Text = $"Weather: {weatherDescription}";
            */

        }

        private void PanelMain_Paint(object sender, PaintEventArgs e)
        {

        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            lbdongho.Text = DateTime.Now.ToString("HH : mm : ss");
        }

        private void lbdongho_Click(object sender, EventArgs e)
        {

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
            if (dmk == null || dmk.Visible == false)
            {
                dmk = new Doimatkhau();
                dmk.Show();
            }
            else
            {
                dmk.BringToFront();
            }
        }
        //HIển thị trợ giúp 1 lần
        private Trogiup help;
        //luu ctrll
        private void button7_Click(object sender, EventArgs e)
        {
            set_mau();
            button7.BackColor = Color.FromArgb(255, 128, 0);
            /*if (help == null || help.Visible == false)
            {
                help = new Trogiup();
                help.Show();
            }
            else
            {
                help.BringToFront();
            }*/


            Trogiup f = new Trogiup();
            f.TopLevel = false;
            f.Size = PanelMain.Size; // Set size of the new form to match PanelMain
            PanelMain.Controls.Clear();
            PanelMain.Controls.Add(f);
            f.Show();
            PanelMain.SizeChanged += (s, ev) => { f.Size = PanelMain.Size; };
            f.SizeChanged += (s, ev) => { PanelMain.Size = f.Size; };
             
        }
        
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //phóng to cửa sổ
        bool isMaximized = false; // khởi tạo biến lưu trạng thái cửa sổ

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

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private Themtk themtk;
   

        private Suatk suatk;
        private void button9_Click(object sender, EventArgs e)
        {
            if (suatk == null || suatk.Visible == false)
            {
                
                suatk = new Suatk();
                suatk.Show();
            }
            else
            {
                suatk.BringToFront();
            }
        }
        

        private void label12_Click(object sender, EventArgs e)
        {
            Thongtinquanly f = new Thongtinquanly();
            f.TopLevel = false;
            f.Size = PanelMain.Size; // Set size of the new form to match PanelMain
            PanelMain.Controls.Clear();
            PanelMain.Controls.Add(f);
            f.Show();
            PanelMain.SizeChanged += (s, ev) => { f.Size = PanelMain.Size; };
            f.SizeChanged += (s, ev) => { PanelMain.Size = f.Size; };
        }
        private Xoatk xoatk;

            
   

        private void button12_Click(object sender, EventArgs e)
        {
            set_mau();
            button12.BackColor = Color.FromArgb(255, 128, 0);
            Giaodienquanly f = new Giaodienquanly();
            f.TopLevel = false;
            f.Size = PanelMain.Size; // Set size of the new form to match PanelMain
            PanelMain.Controls.Clear();
            PanelMain.Controls.Add(f);
            f.Show();
            PanelMain.SizeChanged += (s, ev) => { f.Size = PanelMain.Size; };
            f.SizeChanged += (s, ev) => { PanelMain.Size = f.Size; };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            set_mau();
            button1.BackColor = Color.FromArgb(255, 128, 0);
            FrmHangHoa f = new FrmHangHoa();
            f.TopLevel = false;
            f.Size = PanelMain.Size; // Set size of the new form to match PanelMain
            PanelMain.Controls.Clear();
            PanelMain.Controls.Add(f);
            f.Show();
            PanelMain.SizeChanged += (s, ev) => { f.Size = PanelMain.Size; };
            f.SizeChanged += (s, ev) => { PanelMain.Size = f.Size; };

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            set_mau();
            button2.BackColor = Color.FromArgb(255, 128, 0);
            FrmHoaDon f = new FrmHoaDon();
            f.TopLevel = false;
            f.Size = PanelMain.Size; // Set size of the new form to match PanelMain
            PanelMain.Controls.Clear();
            PanelMain.Controls.Add(f);
            f.Show();
            PanelMain.SizeChanged += (s, ev) => { f.Size = PanelMain.Size; };
            f.SizeChanged += (s, ev) => { PanelMain.Size = f.Size; };
        }

        private void button3_Click(object sender, EventArgs e)
        {
            set_mau();
            button3.BackColor = Color.FromArgb(255, 128, 0);
            FrmKhachHang f = new FrmKhachHang();
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
            set_mau();
            button5.BackColor = Color.FromArgb(255, 128, 0);
            Quanlynhanvien f = new Quanlynhanvien();
            f.TopLevel = false;
            f.Size = PanelMain.Size; // Set size of the new form to match PanelMain
            PanelMain.Controls.Clear();
            PanelMain.Controls.Add(f);
            f.Show();
            PanelMain.SizeChanged += (s, ev) => { f.Size = PanelMain.Size; };
            f.SizeChanged += (s, ev) => { PanelMain.Size = f.Size; };
        }

        private void button4_Click(object sender, EventArgs e)
        {
            set_mau();
            button4.BackColor = Color.FromArgb(255, 128, 0);
            FrmNhaCungCap f = new FrmNhaCungCap();
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
            set_mau();
            button6.BackColor = Color.FromArgb(255, 128, 0);
            FrmThongKe f = new FrmThongKe();
            f.TopLevel = false;
            f.Size = PanelMain.Size; // Set size of the new form to match PanelMain
            PanelMain.Controls.Clear();
            PanelMain.Controls.Add(f);
            f.Show();
            PanelMain.SizeChanged += (s, ev) => { f.Size = PanelMain.Size; };
            f.SizeChanged += (s, ev) => { PanelMain.Size = f.Size; };
        }
    }
}
