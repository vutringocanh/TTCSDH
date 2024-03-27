using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using  NUnit.Framework;
namespace SieuThiMiniXmart
{

    public partial class Login : Form
    {
        string connectionString = DatabaseConnection.GetConnectionString();
        public Login()
        {
            InitializeComponent();
            timer1.Interval = 30;
            timer1.Start();
        }
        public static string tenTaiKhoan = "";

        private void label3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Liên hệ fb.com/vutrianhngoc để được hỗ trợ");
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (txtmatkhau.UseSystemPasswordChar)
            {
                txtmatkhau.UseSystemPasswordChar = false;
                pictureBox2.Image = iml.Images[0];
            }
            else
            {
                txtmatkhau.UseSystemPasswordChar = true;
                pictureBox2.Image = iml.Images[1];
            }
        }
        private void txtmatkhau_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtmatkhau.Text))
            {
                pictureBox2.Visible = false;
            }
            else
            {
                pictureBox2.Visible = true;
            }

        }

        private void btndangnhap_Click(object sender, EventArgs e)
        {
            if (rdnhanvien.Checked == true)
            {
                //SqlConnection con = new SqlConnection("Data Source=vutringoc;Initial Catalog=xmart;Integrated Security=True");
                try
                {

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();
                        string tk = txttaikhoan.Text;
                        string mk = txtmatkhau.Text;
                        string sql = "select * from loginnhanvien where taikhoan = '" + tk + "' and matkhau = '" + mk + "' ";
                        SqlCommand cmd = new SqlCommand(sql, con);
                        SqlDataReader dt = cmd.ExecuteReader();
                        if (dt.Read() == true)
                        {
                            tenTaiKhoan = tk; // tk là biến lưu tài khoản được nhập từ textbox

                            // Lưu tên tài khoản và mật khẩu vào file văn bản
                            if (checkghinho.Checked == true)
                            {
                                string path = @"C:\Users\Admin\Downloads\login.txt";
                                using (StreamWriter sw = File.CreateText(path))
                                {
                                    sw.WriteLine(txttaikhoan.Text);
                                    sw.WriteLine(txtmatkhau.Text);
                                }
                            }
                            else
                            {
                                // Xóa file văn bản nếu checkbox "Nhớ mật khẩu" không được chọn
                                string path = @"C:\Users\Admin\Downloads\login.txt";
                                if (File.Exists(path))
                                {
                                    File.Delete(path);
                                }
                            }

                            MessageBox.Show("Đăng nhập thành công");
                            Form Main = new MainNhanVien();
                            Main.Size = this.Size;



                            // Đặt trạng thái của Form2 là toàn màn hình (maximized)
                            if (this.WindowState == FormWindowState.Maximized)
                            {
                                // Đặt trạng thái của Form2 là toàn màn hình (maximized)
                                Main.WindowState = FormWindowState.Maximized;
                            }
                            // Đặt vị trí của Form2 là vị trí của Form1
                            //Main.Location = this.Location;
                            Main.Show();

                            this.Hide();




                        }
                        else
                        {
                            MessageBox.Show("Đăng nhập thất bại");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối" + ex.Message);
                }
            }
            else if (rdquanly.Checked == true)
            {
                //SqlConnection conn = new SqlConnection("Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True");
                try
                {

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string tk = txttaikhoan.Text;
                        string mk = txtmatkhau.Text;
                        string sql = "select * from loginquanly where taikhoan = '" + tk + "' and matkhau = '" + mk + "' ";
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        SqlDataReader dt = cmd.ExecuteReader();
                        if (dt.Read() == true)
                        {
                            tenTaiKhoan = tk; // tk là biến lưu tài khoản được nhập từ textbox

                            // Lưu tên tài khoản và mật khẩu vào file văn bản
                            if (checkghinho.Checked == true)
                            {
                                string path = @"C:\Users\Admin\Downloads\login.txt";
                                using (StreamWriter sw = File.CreateText(path))
                                {
                                    sw.WriteLine(txttaikhoan.Text);
                                    sw.WriteLine(txtmatkhau.Text);
                                }
                            }
                            else
                            {
                                // Xóa file văn bản nếu checkbox "Nhớ mật khẩu" không được chọn
                                string path = @"C:\Users\Admin\Downloads\login.txt";
                                if (File.Exists(path))
                                {
                                    File.Delete(path);
                                }
                            }

                            MessageBox.Show("Đăng nhập thành công");
                            Form Main = new MainAdmin();
                            Main.Size = this.Size;
                            // Đặt trạng thái của Form2 là toàn màn hình (maximized)
                            if (this.WindowState == FormWindowState.Maximized)
                            {
                                // Đặt trạng thái của Form2 là toàn màn hình (maximized)
                                Main.WindowState = FormWindowState.Maximized;
                            }
                            // Đặt vị trí của Form2 là vị trí của Form1
                            //Main.Location = this.Location;
                            Main.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Đăng nhập thất bại");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối" + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn quyền đăng nhập");
            }


            
            
        }

        private void Login_Load(object sender, EventArgs e)
        {
            string path = @"C:\Users\Admin\Downloads\login.txt";
            if (File.Exists(path))
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    txttaikhoan.Text = sr.ReadLine();
                    txtmatkhau.Text = sr.ReadLine();
                }
                checkghinho.Checked = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (label5.Location.X == -label5.Width)
            {
                label5.Location = new Point(this.Width, label5.Location.Y);
            }
            label5.Location = new Point(label5.Location.X - 1, label5.Location.Y);
        }


    }
}
