using DTO;
using Microsoft.ReportingServices.Diagnostics.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SieuThiMiniXmart
{
    public partial class FrmHoaDon : Form
    {
        public FrmHoaDon()
        {
            InitializeComponent();
        }

        




    string connectionString = DatabaseConnection.GetConnectionString();
        private void FrmHoaDon_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Thực hiện câu truy vấn và lấy dữ liệu vào DataTable
                string query = "SELECT tb_nhaphanghoa.tenhang FROM tb_nhaphanghoa";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Đưa dữ liệu vào CustomSource của TextBox
                foreach (DataRow row in dataTable.Rows)
                {
                    textBox1.AutoCompleteCustomSource.Add(row["tenhang"].ToString());
                }

                // Đóng kết nối
                connection.Close();
            }

            // TODO: This line of code loads data into the 'xmartDataSet13.tb_cthd' table. You can move, or remove it, as needed.
            //this.tb_cthdTableAdapter.Fill(this.xmartDataSet13.tb_cthd);

            // TODO: This line of code loads data into the 'xmartDataSet12.tb_hoadon' table. You can move, or remove it, as needed.
            //this.tb_hoadonTableAdapter1.Fill(this.xmartDataSet12.tb_hoadon);
            // TODO: This line of code loads data into the 'xmartDataSet11.tb_hoadon' table. You can move, or remove it, as needed.
            //this.tb_hoadonTableAdapter.Fill(this.xmartDataSet11.tb_hoadon);


            //SqlConnection con = new SqlConnection("Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True");
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from tb_khachhang", con);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                comboBox1.DataSource = dt;
                comboBox1.ValueMember = "makh";
                con.Close();
            }
            using (SqlConnection con1 = new SqlConnection(connectionString))
            {
                //SqlConnection con1 = new SqlConnection("Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True");
                SqlDataAdapter da1 = new SqlDataAdapter("select * from tb_nhanvien", con1);
                DataTable dt1 = new DataTable();
                con1.Open();
                da1.Fill(dt1);
                comboBox2.DataSource = dt1;
                comboBox2.ValueMember = "manv";
                con1.Close();
            }
            using (SqlConnection con2 = new SqlConnection(connectionString))
            {
                //SqlConnection con2 = new SqlConnection("Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True");
                SqlDataAdapter da2 = new SqlDataAdapter("select * from tb_nhaphanghoa", con2);
                DataTable dt2 = new DataTable();
                con2.Open();
                da2.Fill(dt2);
                comboBox3.DataSource = dt2;
                comboBox3.ValueMember = "mahang";
                con2.Close();
            }
            //textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //textBox1.AutoCompleteSource = AutoCompleteSource.ListItems;

            comboBox3.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox3.AutoCompleteSource = AutoCompleteSource.ListItems;

            comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;

            comboBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox2.AutoCompleteSource = AutoCompleteSource.ListItems;


            load_data();

            //Không cho phép sửa text ở combobox 4:
            comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void load_data()
        {
            //SqlConnection con = new SqlConnection("Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True");
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from tb_hoadon", con);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }

            //using (SqlConnection con1 = new SqlConnection("Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True"))
            using (SqlConnection con1 = new SqlConnection(connectionString))
            {
                
                SqlDataAdapter da1 = new SqlDataAdapter("select * from tb_cthd where mahd = @ma_hd", con1);
                da1.SelectCommand.Parameters.AddWithValue("@ma_hd", textBox2.Text);
                DataTable dt1 = new DataTable();
                con1.Open();
                da1.Fill(dt1);
                dataGridView2.DataSource = dt1;
            }

            // đưa vào label
            using (SqlConnection con2 = new SqlConnection(connectionString))
            {
                //using (SqlConnection con2 = new SqlConnection("Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True"))
                
                SqlDataAdapter da2 = new SqlDataAdapter("select * from tb_cthd where mahd = @ma_hd", con2);
                da2.SelectCommand.Parameters.AddWithValue("@ma_hd", textBox2.Text);
                DataTable dt2 = new DataTable();
                con2.Open();
                da2.Fill(dt2);
                dataGridView2.DataSource = dt2;
            }
            //hien thi du lieu len label

            // Khởi tạo biến tổng số liệu
            decimal tongSoLieu = 0;

            // Lặp qua từng dòng trong DataGridView
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                // Lấy giá trị của cột thứ 5 trong dòng hiện tại
                decimal giaTri = Convert.ToDecimal(row.Cells[5].Value);

                // Cộng dồn vào tổng số liệu
                tongSoLieu += giaTri;
            }

            // Gán giá trị của tổng số liệu vào Label
            label21.Text = tongSoLieu.ToString();


            //--- Gan gia tri tu bang vao label

            // Tạo kết nối đến database
            using (SqlConnection connection4 = new SqlConnection(connectionString))
            {
                // SqlConnection connection4 = new SqlConnection("Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True");

                // Bước 1: Tạo câu truy vấn SQL để lấy dữ liệu từ bảng tb_doidiem
                string query4 = "SELECT giamgia, thanhtien FROM tb_doidiem WHERE mahd = @mahd";
                SqlCommand command4 = new SqlCommand(query4, connection4);

                // Bước 2: Thêm tham số @mahd vào câu truy vấn và gán giá trị từ label mã hóa đơn vào tham số này
                command4.Parameters.AddWithValue("@mahd", textBox2.Text);

                // Bước 3: Mở kết nối đến database và lấy dữ liệu bằng SqlDataAdapter
                connection4.Open();
                SqlDataAdapter adapter4 = new SqlDataAdapter(command4);
                DataTable table4 = new DataTable();
                adapter4.Fill(table4);

                // Bước 4: Đóng kết nối đến database
                connection4.Close();

                // Bước 5: Kiểm tra xem có dữ liệu trả về không và nếu có, gán giá trị của giamgia và thanhtien vào các label tương ứng
                if (table4.Rows.Count > 0)
                {

                    label22.Text = table4.Rows[0]["giamgia"].ToString();
                    label23.Text = table4.Rows[0]["thanhtien"].ToString();
                }
                else
                {
                    label22.Text = "0";
                    label23.Text = label21.Text;
                }
            }

        }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            try
            {
                // Thực hiện insert vào database
                //SqlConnection con = new SqlConnection("Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True");
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("insert into tb_hoadon values( '" + textBox2.Text + "',  '" + textBox9.Text + "',  '" + textBox10.Text + "',  '" + datengaylap.Text + "',  '" + comboBox1.Text + "',  '" + comboBox2.Text + "' )", con);
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
        private void btnsua_Click(object sender, EventArgs e)
        {
            try
            {
                // Thực hiện update vào database
                //SqlConnection con = new SqlConnection("Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True");
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("update tb_hoadon set TenKH= '" + textBox9.Text + "',TenNL = '" + textBox10.Text + "',  NgayLap = '" + datengaylap.Text + "',makh =   '" + comboBox1.Text + "', manv = '" + comboBox2.Text + "'  where mahd = '" + textBox2.Text + "' ", con);

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
        private void btnxoa_Click(object sender, EventArgs e)
        {
            try
            {

                // Thực hiện delete vào database
                //SqlConnection con = new SqlConnection("Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True");
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("delete tb_cthd where mahd = '" + textBox2.Text + "' ", con);
                    con.Open();
                    int ret = cmd.ExecuteNonQuery();
                    con.Close();

                    // Nếu delete thành công, đặt DialogResult của Form là OK
                    if (ret == 1)
                    {
                        //MessageBox.Show("Xóa dữ liệu thành công");
                        //this.DialogResult = DialogResult.OK;
                        load_data();
                    }
                    else
                    {
                   //     MessageBox.Show("Lỗi khi xóa dữ liệu");
                    }
                }
            }
            catch (Exception ex)
            {
               // MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message);
            }
            //__________________
            try
            {

                // Thực hiện delete vào database
                //SqlConnection con = new SqlConnection("Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True");
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("delete tb_hoadon where mahd = '" + textBox2.Text + "' ", con);
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

        private void btnthemcthd_Click(object sender, EventArgs e)
        {
            //int soluong, diem;
            //if (int.TryParse(textBox3.Text, out soluong) && int.TryParse(textBox7.Text, out diem)) // chuyển giá trị của textbox sang kiểu int
            //{
            //}
            //else
            //{
            //    // xử lý khi textbox không chứa giá trị hợp lệ (ví dụ: giá trị không phải kiểu số nguyên)
            //    // ví dụ:
            //    MessageBox.Show("Giá trị không hợp lệ!");
            //}

            //Câp nhập điểm nếu mua trên 500 đồng
            try
            {
                // Thực hiện insert vào database
                //SqlConnection con = new SqlConnection("Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True");
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("insert into tb_cthd values( '" + textBox2.Text + "',  '" + comboBox3.Text + "',  '" + textBox1.Text + "',  '" + textBox6.Text + "',  '" + textBox3.Text + "',  '" + textBox5.Text + "' )", con);
                    con.Open();
                    int ret = cmd.ExecuteNonQuery();
                    con.Close();

                    // Bước 1: Lấy ra tổng thành tiền của các mặt hàng trong hóa đơn vừa thêm vào
                    double tongTien = 0;
                    foreach (DataGridViewRow row in dataGridView2.Rows)
                    {
                        double thanhTien = Convert.ToDouble(row.Cells["thanhTien"].Value);
                        tongTien += thanhTien;
                    }

                    // Bước 2: Lấy ra mã khách hàng của hóa đơn vừa thêm vào
                    string maKH = "";
                    string query = "SELECT makh FROM tb_hoadon WHERE mahd = @mahd";
                    SqlCommand cmd2 = new SqlCommand(query, con);
                    cmd2.Parameters.AddWithValue("@mahd", textBox2.Text);
                    con.Open();
                    SqlDataReader reader = cmd2.ExecuteReader();
                    if (reader.Read())
                    {
                        maKH = reader["makh"].ToString();
                    }
                    reader.Close();
                    con.Close();

                    // Bước 3: Nếu tổng thành tiền từ 500 trở lên và mua trên 5 món hàng, cập nhật điểm cho khách hàng

                    int recordCount = 0;
                    recordCount = dataGridView2.RowCount;
                    if (tongTien >= 500000 && recordCount >= 5)
                    {
                        int diem = 0;
                        query = "SELECT Diem FROM tb_khachhang WHERE Makh = @makh";
                        SqlCommand cmd3 = new SqlCommand(query, con);
                        cmd3.Parameters.AddWithValue("@makh", maKH);
                        con.Open();
                        reader = cmd3.ExecuteReader();
                        if (reader.Read())
                        {
                            diem = Convert.ToInt32(reader["Diem"]);
                        }
                        reader.Close();
                        diem += 100;
                        query = "UPDATE tb_khachhang SET Diem = @diem WHERE Makh = @makh";
                        SqlCommand cmd4 = new SqlCommand(query, con);
                        cmd4.Parameters.AddWithValue("@makh", maKH);
                        cmd4.Parameters.AddWithValue("@diem", diem);
                        cmd4.ExecuteNonQuery();
                        con.Close();
                    }

                    // Nếu insert thành công, đặt DialogResult của Form là OK
                    if (ret == 1)
                    {
                        MessageBox.Show("Thêm dữ liệu thành công");
                        this.DialogResult = DialogResult.OK;
                        load_data();
                        reset();
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




            try
            {
                // Thực hiện update vào database
                //SqlConnection con1 = new SqlConnection("Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True");
                using (SqlConnection con1 = new SqlConnection(connectionString))
                {
                    SqlCommand cmd1 = new SqlCommand("update tb_nhaphanghoa set soluong = soluong - '" + textBox6.Text + "'  where mahang = '" + comboBox3.Text + "' ", con1);

                    con1.Open();
                    int ret1 = cmd1.ExecuteNonQuery();
                    con1.Close();

                    // Nếu insert thành công, đặt DialogResult của Form là OK
                    if (ret1 == 1)
                    {
                        load_data();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi khi cập nhật dữ liệu");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa dữ liệu: " + ex.Message);
            }
        }

        private void btnxoacthd_Click(object sender, EventArgs e)
        {
            try
            {

                // Thực hiện delete vào database
                //SqlConnection con = new SqlConnection("Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True");
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("delete tb_cthd where mahd = '" + textBox2.Text + "' and mahang = '" + comboBox3.Text + "' ", con);
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

        //---------------------------------------------------------------------------------------------------------------
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection connection1 = new SqlConnection(connectionString))
            {
                //SqlConnection connection1 = new SqlConnection("Data Source=vutringoc;Initial Catalog=xmart;Integrated Security=True");
                // Mở kết nối
                connection1.Open();
                // Tạo câu truy vấn SQL để lấy giá trị thoigianbatdau từ cơ sở dữ liệu
                string sql1 = "SELECT tb_khachhang.tenkh FROM tb_khachhang where tb_khachhang.makh = @KhachHang";
                SqlCommand command1 = new SqlCommand(sql1, connection1);
                command1.Parameters.AddWithValue("@KhachHang", comboBox1.Text);
                // Thực hiện truy vấn và lấy giá trị của tên
                string name = (string)command1.ExecuteScalar();
                // Gán giá trị tên vào Text của Label
                textBox9.Text = name;
                connection1.Close();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection connection2 = new SqlConnection(connectionString))
            {
                //SqlConnection connection2 = new SqlConnection("Data Source=vutringoc;Initial Catalog=xmart;Integrated Security=True");
                // Mở kết nối
                connection2.Open();
                // Tạo câu truy vấn SQL để lấy giá trị thoigianbatdau từ cơ sở dữ liệu
                string sql2 = "SELECT tb_nhanvien.tennv FROM tb_nhanvien where tb_nhanvien.manv = @NhanVien";
                SqlCommand command2 = new SqlCommand(sql2, connection2);
                command2.Parameters.AddWithValue("@NhanVien", comboBox2.Text);
                // Thực hiện truy vấn và lấy giá trị của tên
                string name2 = (string)command2.ExecuteScalar();
                // Gán giá trị tên vào Text của Label
                textBox10.Text = name2;
                connection2.Close();
            }

        }

        private bool isUpdating = false;
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isUpdating)
            {
                using (SqlConnection connection3 = new SqlConnection(connectionString))
                {
                    //SqlConnection connection3 = new SqlConnection("Data Source=vutringoc;Initial Catalog=xmart;Integrated Security=True");
                    // Mở kết nối
                    connection3.Open();
                    // Tạo câu truy vấn SQL để lấy giá trị thoigianbatdau từ cơ sở dữ liệu
                    string sql3 = "SELECT tb_nhaphanghoa.tenhang FROM tb_nhaphanghoa where tb_nhaphanghoa.mahang = @HangHoa";
                    SqlCommand command3 = new SqlCommand(sql3, connection3);
                    command3.Parameters.AddWithValue("@HangHoa", comboBox3.Text);
                    // Thực hiện truy vấn và lấy giá trị của tên
                    string name3 = (string)command3.ExecuteScalar();
                    // Gán giá trị tên vào Text của Label
                    isUpdating = true;
                    textBox1.Text = name3;
                    isUpdating = false;
                    connection3.Close();
                }
            }
            using (SqlConnection connection4 = new SqlConnection(connectionString))
            {
                //SqlConnection connection4 = new SqlConnection("Data Source=vutringoc;Initial Catalog=xmart;Integrated Security=True");
                // Mở kết nối
                connection4.Open();
                // Tạo câu truy vấn SQL để lấy giá trị thoigianbatdau từ cơ sở dữ liệu
                string sql4 = "SELECT tb_nhaphanghoa.dongiaban FROM tb_nhaphanghoa where tb_nhaphanghoa.mahang = @HangHoa";
                SqlCommand command4 = new SqlCommand(sql4, connection4);
                command4.Parameters.AddWithValue("@HangHoa", comboBox3.Text);
                // Thực hiện truy vấn và lấy giá trị của tb_nhaphanghoa.dongiaban
                object result = command4.ExecuteScalar();
                if (result != null)
                {
                    float dongia;
                    if (float.TryParse(result.ToString(), out dongia))
                    {
                        // Gán giá trị tb_nhaphanghoa.dongiaban vào Text của TextBox
                        textBox3.Text = dongia.ToString();
                    }
                    else
                    {
                        // Trường hợp giá trị không thể chuyển đổi thành float
                        // Xử lý theo ý muốn của bạn
                    }
                }
                connection4.Close();
            }
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //SqlConnection connection1 = new SqlConnection("Data Source=vutringoc;Initial Catalog=xmart;Integrated Security=True");
            using (SqlConnection connection1 = new SqlConnection(connectionString))
            {
                // Mở kết nối
                connection1.Open();
                // Tạo câu truy vấn SQL để lấy giá trị thoigianbatdau từ cơ sở dữ liệu
                string sql1 = "SELECT tb_khachhang.tenkh FROM tb_khachhang where tb_khachhang.makh = @KhachHang";
                SqlCommand command1 = new SqlCommand(sql1, connection1);
                command1.Parameters.AddWithValue("@KhachHang", comboBox1.Text);
                // Thực hiện truy vấn và lấy giá trị của tên
                string name = (string)command1.ExecuteScalar();
                // Gán giá trị tên vào Text của Label
                textBox9.Text = name;
                connection1.Close();
            }
        }
        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //SqlConnection connection2 = new SqlConnection("Data Source=vutringoc;Initial Catalog=xmart;Integrated Security=True");
            // Mở kết nối
            using (SqlConnection connection2 = new SqlConnection(connectionString))
            {
                connection2.Open();
                // Tạo câu truy vấn SQL để lấy giá trị thoigianbatdau từ cơ sở dữ liệu
                string sql2 = "SELECT tb_nhanvien.tennv FROM tb_nhanvien where tb_nhanvien.manv = @NhanVien";
                SqlCommand command2 = new SqlCommand(sql2, connection2);
                command2.Parameters.AddWithValue("@NhanVien", comboBox2.Text);
                // Thực hiện truy vấn và lấy giá trị của tên
                string name2 = (string)command2.ExecuteScalar();
                // Gán giá trị tên vào Text của Label
                textBox10.Text = name2;
                connection2.Close();
            }
        }
        private void comboBox3_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //SqlConnection connection3 = new SqlConnection("Data Source=vutringoc;Initial Catalog=xmart;Integrated Security=True");
            // Mở kết nối
            using (SqlConnection connection3 = new SqlConnection(connectionString))
            {
                connection3.Open();
                // Tạo câu truy vấn SQL để lấy giá trị thoigianbatdau từ cơ sở dữ liệu
                string sql3 = "SELECT tb_nhaphanghoa.tenhang FROM tb_nhaphanghoa where tb_nhaphanghoa.mahang = @HangHoa";
                SqlCommand command3 = new SqlCommand(sql3, connection3);
                command3.Parameters.AddWithValue("@HangHoa", comboBox3.Text);
                // Thực hiện truy vấn và lấy giá trị của tên
                string name3 = (string)command3.ExecuteScalar();
                // Gán giá trị tên vào Text của Label
                textBox1.Text = name3;
                connection3.Close();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox2.Text = row.Cells["mahd"].Value.ToString();
                textBox9.Text = row.Cells["tenkh"].Value.ToString();
                textBox10.Text = row.Cells["tennl"].Value.ToString();
                datengaylap.Text = row.Cells["ngaylap"].Value.ToString();
                comboBox1.Text = row.Cells["makh"].Value.ToString();
                comboBox2.Text = row.Cells["manv"].Value.ToString();

            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];
                textBox2.Text = row.Cells["mahd2"].Value.ToString();
                comboBox3.Text = row.Cells["mahang"].Value.ToString();
                textBox1.Text = row.Cells["tenhang"].Value.ToString();
                textBox6.Text = row.Cells["soluong"].Value.ToString();
                textBox3.Text = row.Cells["dongia"].Value.ToString();
                textBox5.Text = row.Cells["thanhtien"].Value.ToString();
                
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            try { 
                if (!string.IsNullOrEmpty(textBox6.Text) && !string.IsNullOrEmpty(textBox3.Text))
             {
                // Lấy giá trị từ TextBox1 và TextBox2
                float number1 = float.Parse(textBox6.Text);
                float number2 = float.Parse(textBox3.Text);

                // Tính kết quả và hiển thị vào TextBox3
                textBox5.Text = (number1 * number2).ToString();
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng nhập số");
            }

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try { 
            if (!string.IsNullOrEmpty(textBox6.Text) && !string.IsNullOrEmpty(textBox3.Text))
            {
                // Lấy giá trị từ TextBox1 và TextBox2
                float number1 = float.Parse(textBox6.Text);
                float number2 = float.Parse(textBox3.Text);

                // Tính kết quả và hiển thị vào TextBox3
                textBox5.Text = (number1 * number2).ToString();
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng nhập số");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {


            //chèn du lieu vào datagridview 2
            //using (SqlConnection con1 = new SqlConnection("Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True"))
            using (SqlConnection con1 = new SqlConnection(connectionString))
            {
                
                SqlDataAdapter da1 = new SqlDataAdapter("select * from tb_cthd where mahd = @ma_hd", con1);
                da1.SelectCommand.Parameters.AddWithValue("@ma_hd", textBox2.Text);
                DataTable dt1 = new DataTable();
                con1.Open();
                da1.Fill(dt1);
                dataGridView2.DataSource = dt1;
            }

            //hien thi du lieu len label

            // Khởi tạo biến tổng số liệu
            decimal tongSoLieu = 0;

            // Lặp qua từng dòng trong DataGridView
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                // Lấy giá trị của cột thứ 5 trong dòng hiện tại
                decimal giaTri = Convert.ToDecimal(row.Cells[5].Value);

                // Cộng dồn vào tổng số liệu
                tongSoLieu += giaTri;
            }

            // Gán giá trị của tổng số liệu vào Label
            label21.Text = tongSoLieu.ToString();



            //chèn giam gia va thanhtien
            // Tạo kết nối đến database

            //SqlConnection connection4 = new SqlConnection("Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True");
            using (SqlConnection connection4 = new SqlConnection(connectionString))
            {
                // Bước 1: Tạo câu truy vấn SQL để lấy dữ liệu từ bảng tb_doidiem
                string query4 = "SELECT giamgia, thanhtien FROM tb_doidiem WHERE mahd = @mahd";
                SqlCommand command4 = new SqlCommand(query4, connection4);

                // Bước 2: Thêm tham số @mahd vào câu truy vấn và gán giá trị từ label mã hóa đơn vào tham số này
                command4.Parameters.AddWithValue("@mahd", textBox2.Text);

                // Bước 3: Mở kết nối đến database và lấy dữ liệu bằng SqlDataAdapter
                connection4.Open();
                SqlDataAdapter adapter4 = new SqlDataAdapter(command4);
                DataTable table4 = new DataTable();
                adapter4.Fill(table4);

                // Bước 4: Đóng kết nối đến database
                connection4.Close();

                // Bước 5: Kiểm tra xem có dữ liệu trả về không và nếu có, gán giá trị của giamgia và thanhtien vào các label tương ứng
                if (table4.Rows.Count > 0)
                {
                    label22.Text = table4.Rows[0]["giamgia"].ToString();
                    label23.Text = table4.Rows[0]["thanhtien"].ToString();
                }
                else
                {
                    label22.Text = "0";
                    label23.Text = label21.Text;

                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // Tạo kết nối đến cơ sở dữ liệu
            //SqlConnection connection = new SqlConnection("Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Thiết kế truy vấn SQL
                string query = "SELECT diem FROM tb_khachhang WHERE makh = @makhach";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@makhach", comboBox1.Text);

                // Thực hiện truy vấn SQL và lấy kết quả trả về
                SqlDataReader reader = command.ExecuteReader();
                int diem = 0;
                if (reader.Read())
                {
                    diem = reader.GetInt32(0);
                }
                reader.Close();
                connection.Close();

                // Hiển thị kết quả trả về
                MessageBox.Show("Số điểm của khách hàng " + comboBox1.Text + " là " + diem);
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox7.Text) )
            {
                
                int number1 = int.Parse(textBox7.Text);


                // Tính kết quả và hiển thị vào TextBox3
                textBox8.Text = ((number1 * 20000)/1000).ToString();
            }
        }
        private void reset()
        {
            
            textBox7.Text = "0";
            textBox4.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmHoaDon newForm = new FrmHoaDon();
            newForm.FormBorderStyle = FormBorderStyle.Sizable;
            // Hiển thị form mới
            newForm.Show();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.SelectedItem.ToString() == "Sử Dụng Điểm")
            {
                try
                {
                    float textBox8Value = float.Parse(textBox8.Text);
                    float label21Value = float.Parse(label21.Text);
                    float result = label21Value - textBox8Value;

                    // Thực hiện insert vào database
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        //SqlConnection con = new SqlConnection("Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True");
                        SqlCommand cmd = new SqlCommand("insert into tb_doidiem values( '" + textBox2.Text + "',  '" + textBox7.Text + "',  '" + datengaylap.Text + "', '" + textBox8.Text + "', '" + result.ToString() + "' )", con);
                        con.Open();
                        int ret = cmd.ExecuteNonQuery();
                        con.Close();
                        // Nếu insert thành công, đặt DialogResult của Form là OK
                        if (ret == 1)
                        {
                            MessageBox.Show("Đổi điểm thành công");
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
                try
                {
                    // Thực hiện update vào database
                    //SqlConnection con1 = new SqlConnection("Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True");
                    using (SqlConnection con1 = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd1 = new SqlCommand("update tb_khachhang set diem = diem - '" + textBox7.Text + "'  where makh = '" + comboBox1.Text + "' ", con1);
                        con1.Open();
                        int ret1 = cmd1.ExecuteNonQuery();
                        con1.Close();
                        // Nếu insert thành công, đặt DialogResult của Form là OK
                        if (ret1 == 1)
                        {
                            load_data();
                        }
                        else
                        {
                            MessageBox.Show("Lỗi khi cập nhật dữ liệu");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật dữ liệu: " + ex.Message);
                }
            }
            else if (comboBox4.SelectedItem.ToString() == "Thêm Tiếp")
            {
                // Thực hiện hành động tương ứng với Item 2

                try
                {

                    // Thực hiện insert vào database
                    //SqlConnection con = new SqlConnection("Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True");

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand("update tb_doidiem set sodiemdoi = sodiemdoi + '" + textBox7.Text + "', giamgia = giamgia + '" + textBox8.Text + "', thanhtien = thanhtien - '" + textBox8.Text + "'  where mahd = '" + textBox2.Text + "' ", con);
                        con.Open();
                        int ret = cmd.ExecuteNonQuery();
                        con.Close();
                        // Nếu insert thành công, đặt DialogResult của Form là OK
                        if (ret == 1)
                        {
                            MessageBox.Show("Đổi điểm thành công");
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

                try
                {
                    // Thực hiện update vào database
                    //SqlConnection con1 = new SqlConnection("Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True");
                    using (SqlConnection con1 = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd1 = new SqlCommand("update tb_khachhang set diem = diem - '" + textBox7.Text + "'  where makh = '" + comboBox1.Text + "' ", con1);
                        con1.Open();
                        int ret1 = cmd1.ExecuteNonQuery();
                        con1.Close();
                        // Nếu insert thành công, đặt DialogResult của Form là OK
                        if (ret1 == 1)
                        {
                            load_data();
                        }
                        else
                        {
                            MessageBox.Show("Lỗi khi cập nhật dữ liệu");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật dữ liệu: " + ex.Message);
                }
            }
        }

        private void btninhd_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ database
            Modify md = new Modify();
            string mahd = textBox2.Text;

            DataTable dt = md.InHDmuahang1(mahd);

            // Tạo instance của form ThongKeDoanhSoThang
            RpInHoaDonMuaHang frm = new RpInHoaDonMuaHang(this);

            // Hiển thị form chứa control reportViewer1
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ database
            Modify md = new Modify();
            string mahd = textBox2.Text;
            
            DataTable dt = md.InHDmuahang(mahd);

            // Tạo instance của form ThongKeDoanhSoThang2
            RpInHoaDonMuaHang2 frm = new RpInHoaDonMuaHang2(this);

            // Hiển thị form chứa control reportViewer1
            frm.Show();
        }
        public string GetMahd()
        {
            return textBox2.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Tạo một đối tượng Random để sinh chuỗi ngẫu nhiên
            Random random = new Random();

            // Tạo một chuỗi mới gồm 8 kí tự ngẫu nhiên
            string randomString = new string(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz", 8)
                                            .Select(s => s[random.Next(s.Length)]).ToArray());

            // Hiển thị chuỗi ngẫu nhiên trong TextBox1
            textBox2.Text = randomString;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Process.Start("calc.exe");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from tb_hoadon where mahd = '" + textBox2.Text + "'", con);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            load_data();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //dem so luong ban ghi
            int recordCount = 0;
            recordCount = dataGridView2.RowCount;
            label24.Text = recordCount.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!isUpdating)
            {
                using (SqlConnection connection3 = new SqlConnection(connectionString))
                {
                    //SqlConnection connection3 = new SqlConnection("Data Source=vutringoc;Initial Catalog=xmart;Integrated Security=True");
                    // Mở kết nối
                    connection3.Open();
                    // Tạo câu truy vấn SQL để lấy giá trị thoigianbatdau từ cơ sở dữ liệu
                    string sql3 = "SELECT tb_nhaphanghoa.mahang FROM tb_nhaphanghoa where tb_nhaphanghoa.tenhang = @HangHoa";
                    SqlCommand command3 = new SqlCommand(sql3, connection3);
                    command3.Parameters.AddWithValue("@HangHoa", textBox1.Text);
                    // Thực hiện truy vấn và lấy giá trị của tên
                    string name3 = (string)command3.ExecuteScalar();
                    // Gán giá trị tên vào Text của Label
                    isUpdating = true;
                    comboBox3.Text = name3;
                    isUpdating = false;
                    connection3.Close();
                }
            }

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

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
