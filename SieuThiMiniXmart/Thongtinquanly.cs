using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SieuThiMiniXmart
{
    public partial class Thongtinquanly : Form
    {
        public Thongtinquanly()
        {
            InitializeComponent();
        }
        string connectionString = DatabaseConnection.GetConnectionString();
        private void load_data()
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // SqlConnection con = new SqlConnection("Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True");
                SqlDataAdapter da = new SqlDataAdapter("select * from tb_quanly", con);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
        }
        private void Thongtinquanly_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'xmartDataSet2.tb_quanly' table. You can move, or remove it, as needed.
            //this.tb_quanlyTableAdapter.Fill(this.xmartDataSet2.tb_quanly);




            //SqlConnection con1 = new SqlConnection("Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True");

            using (SqlConnection con1 = new SqlConnection(connectionString))
            {
                SqlDataAdapter da1 = new SqlDataAdapter("select * from loginquanly", con1);
                DataTable dt1 = new DataTable();
                con1.Open();
                da1.Fill(dt1);
                cbtaikhoan.DataSource = dt1;
                cbtaikhoan.ValueMember = "taikhoan";
                con1.Close();
                load_data();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Chuyển đổi hình ảnh sang mảng byte
                byte[] imageBytes;
                using (MemoryStream ms = new MemoryStream())
                {
                    pictureBox1.Image.Save(ms, ImageFormat.Jpeg);
                    imageBytes = ms.ToArray();
                }
                // Thực hiện insert vào database
                //SqlConnection con = new SqlConnection("Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True");

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("insert into tb_quanly values( '" + textBox1.Text + "',  '" + textBox2.Text + "',  '" + comboBox1.Text + "',  '" + dpNamSinh.Text + "',  '" + textBox4.Text + "',  '" + textBox7.Text + "',  '" + cbtaikhoan.Text + "', @image )", con);
                    cmd.Parameters.AddWithValue("@image", imageBytes);
                    con.Open();
                    int ret = cmd.ExecuteNonQuery();
                    con.Close();

                    // Nếu insert thành công, đặt DialogResult của Form là OK
                    if (ret == 1)
                    {
                        MessageBox.Show("Thêm dữ liệu thành công");
                        this.DialogResult = DialogResult.OK;
                        load_data();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi khi thêm dữ liệu");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm dữ liệu: " + ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Mở hộp thoại chọn file ảnh
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Lấy đường dẫn của tệp ảnh đã chọn
                string imagePath = openFileDialog.FileName;

                try
                {
                    // Gán ảnh vào PictureBox
                    pictureBox1.Image = Image.FromFile(imagePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi mở tệp tin: " + ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Chuyển đổi hình ảnh sang mảng byte
                byte[] imageBytes;
                using (MemoryStream ms = new MemoryStream())
                {
                    pictureBox1.Image.Save(ms, ImageFormat.Jpeg);
                    imageBytes = ms.ToArray();
                }
                // Thực hiện update vào database
                //SqlConnection con = new SqlConnection("Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True");

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("update tb_quanly set MaQL= '" + textBox1.Text + "',TenQL = '" + textBox2.Text + "', GioiTinh = '" + comboBox1.Text + "',  namsinh = '" + dpNamSinh.Text + "',diachi =   '" + textBox4.Text + "', sdt = '" + textBox7.Text + "',hinhanh = @image  where taikhoan = '" + cbtaikhoan.Text + "' ", con);
                    cmd.Parameters.AddWithValue("@image", imageBytes);
                    con.Open();
                    int ret = cmd.ExecuteNonQuery();
                    con.Close();

                    // Nếu insert thành công, đặt DialogResult của Form là OK
                    if (ret == 1)
                    {
                        MessageBox.Show("Sửa dữ liệu thành công");
                        this.DialogResult = DialogResult.OK;
                        load_data();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi khi sửa dữ liệu");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa dữ liệu: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                // Thực hiện delete vào database
                //SqlConnection con = new SqlConnection("Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True");

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("delete tb_quanly where taikhoan = '" + cbtaikhoan.Text + "' ", con);
                    con.Open();
                    int ret = cmd.ExecuteNonQuery();
                    con.Close();

                    // Nếu delete thành công, đặt DialogResult của Form là OK
                    if (ret == 1)
                    {
                        MessageBox.Show("Xóa dữ liệu thành công");
                        this.DialogResult = DialogResult.OK;
                        load_data();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi khi xóa dữ liệu");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
            textBox7.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            load_data();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {

                // Thực hiện delete vào database

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    //SqlConnection con = new SqlConnection("Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True");
                    SqlDataAdapter da = new SqlDataAdapter("select * from tb_quanly where tenQL like '" + textBox6.Text + "'  ", con);
                    DataTable dt = new DataTable();
                    con.Open();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    con.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm dữ liệu: " + ex.Message);
            }


            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                textBox1.Text = row.Cells["MaQL"].Value.ToString();
                textBox2.Text = row.Cells["TenQL"].Value.ToString();
                comboBox1.Text = row.Cells["GioiTinh"].Value.ToString();
                dpNamSinh.Text = row.Cells["NamSinh"].Value.ToString();

                textBox4.Text = row.Cells["DiaChi"].Value.ToString();
                textBox7.Text = row.Cells["SDT"].Value.ToString();
                cbtaikhoan.Text = row.Cells["taikhoan"].Value.ToString();

                byte[] imageBytes = (byte[])row.Cells[7].Value;
                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    pictureBox1.Image = Image.FromStream(ms);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //dem so luong ban ghi
            int recordCount = 0;
            recordCount = dataGridView1.RowCount;
            label10.Text = recordCount.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // Tạo một đối tượng Random để sinh chuỗi ngẫu nhiên
            Random random = new Random();

            // Tạo một chuỗi mới gồm 8 kí tự ngẫu nhiên
            string randomString = new string(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz", 8)
                                            .Select(s => s[random.Next(s.Length)]).ToArray());

            // Hiển thị chuỗi ngẫu nhiên trong TextBox1
            textBox1.Text = randomString;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex % 2 == 0)
            {
                // Set background color for even rows
                e.CellStyle.BackColor = Color.LightGray;
            }
            else
            {
                // Set background color for odd rows
                e.CellStyle.BackColor = Color.WhiteSmoke;
            }
        }
    }
}
