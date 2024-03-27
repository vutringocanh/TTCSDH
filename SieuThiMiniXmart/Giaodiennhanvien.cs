using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SieuThiMiniXmart
{
    public partial class Giaodiennhanvien : Form
    {

        public Giaodiennhanvien()
        {
            InitializeComponent();
        }
        string connectionString = DatabaseConnection.GetConnectionString();
        private void pictureBox8_Click(object sender, EventArgs e)
        {

            try
            {
                //SqlConnection con = new SqlConnection("Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True");
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("insert into tb_chamcong values('" + datechamcong.Text + "', '" + textBox1.Text + "') ", con);
                    con.Open();
                    int ret = cmd.ExecuteNonQuery();
                    if (ret == 1)
                    {
                        MessageBox.Show("Chấm công thành công");
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bạn đã chấm công hôm nay");
            }
        }

        private void Giaodiennhanvien_Load(object sender, EventArgs e)
        {
            label2.Text = Login.tenTaiKhoan;

            //hien thi 
            // Tạo kết nối đến CSDL
            //SqlConnection connection1 = new SqlConnection("Data Source=vutringoc;Initial Catalog=xmart;Integrated Security=True");
            using (SqlConnection connection1 = new SqlConnection(connectionString))
            {
                // Mở kết nối
                connection1.Open();

                // Tạo câu truy vấn SQL để lấy giá trị thoigianbatdau từ cơ sở dữ liệu
                string sql1 = "SELECT tb_nhanvien.manv FROM  tb_calam, tb_nhanvien, loginnhanvien WHERE tb_nhanvien.manv = tb_calam.manv AND tb_nhanvien.taikhoan = loginnhanvien.taikhoan and loginnhanvien.taikhoan = @Taikhoan";
                SqlCommand command1 = new SqlCommand(sql1, connection1);
                command1.Parameters.AddWithValue("@Taikhoan", label2.Text);
                // Thực hiện truy vấn và lấy giá trị của tên
                string name = (string)command1.ExecuteScalar();
                // Gán giá trị tên vào Text của Label
                textBox1.Text = name;
                connection1.Close();


            }
        }
    }
}
