using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SieuThiMiniXmart
{
    public partial class FrmKhachHang : Form
    {
        string connectionString = DatabaseConnection.GetConnectionString();
        private KhachHangBLL KhachHangBLL;
        private BindingSource bindingSource;
        public FrmKhachHang()
        {
            InitializeComponent();
            KhachHangBLL = new KhachHangBLL();
            bindingSource = new BindingSource();
            dataGridView1.AutoGenerateColumns = false;
        }
        private void LoadData()
        {
            List<KhachHang> KhachHangs = KhachHangBLL.GetAllKhachHang();
            bindingSource.DataSource = KhachHangs;
            dataGridView1.DataSource = bindingSource;
        }
        private void btntimkiem_Click(object sender, EventArgs e)
        {
            string tenncc = textBox6.Text;
            if (!string.IsNullOrEmpty(tenncc))
            {
                List<KhachHang> KhachHangs = KhachHangBLL.GetKhachHangByTenKhachHang(tenncc);
                if (KhachHangs.Count > 0)
                {
                    bindingSource.DataSource = KhachHangs;
                    dataGridView1.DataSource = bindingSource;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhà cung cấp có tên " + tenncc);
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tên nhà cung cấp để tìm kiếm");
            }

        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            try {
                DTO.KhachHang KhachHang = new DTO.KhachHang();
                KhachHang.makh = textBox1.Text;
                KhachHang.tenkh = textBox2.Text;
                KhachHang.diachi = textBox4.Text;
                KhachHang.namsinh = dpNamSinh.Text;
                KhachHang.gioitinh = comboBox1.Text;
                KhachHang.sdt = textBox7.Text;
                KhachHang.email = textBox3.Text;
                int diem;
                if (int.TryParse(textBox5.Text, out diem)) // chuyển giá trị của textbox sang kiểu int
                {
                    KhachHang.diem = diem;
                }
                else
                {
                    // xử lý khi textbox không chứa giá trị hợp lệ (ví dụ: giá trị không phải kiểu số nguyên)
                    // ví dụ:
                    MessageBox.Show("Giá trị điểm không hợp lệ!");
                }

                bool result = KhachHangBLL.AddKhachHang(KhachHang);
                if (result)
                {
                    MessageBox.Show("Thêm khách hàng thành công");
                    LoadData();
                    ResetTextBoxes();
                }
                else
                {
                    MessageBox.Show("Thêm khách hàng thất bại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thực hiển dữ liệu: " + ex.Message);
            }
        }
        private void ResetTextBoxes()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";

        }

        private void FrmKhachHang_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            LoadData();
            ResetTextBoxes();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            try{ 
                        KhachHang KhachHang = new KhachHang();
                        KhachHang.makh = textBox1.Text;
                        KhachHang.tenkh = textBox2.Text;
                        KhachHang.diachi = textBox4.Text;
                        KhachHang.namsinh = dpNamSinh.Text;
                        KhachHang.gioitinh = comboBox1.Text;
                        KhachHang.sdt = textBox7.Text;
                        KhachHang.email = textBox3.Text;
                        int diem;
                        if (int.TryParse(textBox5.Text, out diem)) // chuyển giá trị của textbox sang kiểu int
                        {
                            KhachHang.diem = diem;
                        }
                        else
                        {
                            // xử lý khi textbox không chứa giá trị hợp lệ (ví dụ: giá trị không phải kiểu số nguyên)
                            // ví dụ:
                            MessageBox.Show("Giá trị điểm không hợp lệ!");
                        }


                        bool result = KhachHangBLL.UpdateKhachHang(KhachHang);
                        if (result)
                        {
                            MessageBox.Show("Sửa thông tin khách hàng thành công");
                        LoadData();
                        ResetTextBoxes();
                    }
                    else
                    {
                        MessageBox.Show("Sửa thông tin khách hàng thất bại");
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thực hiển dữ liệu: " + ex.Message);
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
                    SqlCommand cmd = new SqlCommand("delete tb_hoadon where makh = '" + textBox1.Text + "' ", con);
                    con.Open();
                    int ret = cmd.ExecuteNonQuery();
                    con.Close();

                    // Nếu delete thành công, đặt DialogResult của Form là OK
                    if (ret == 1)
                    {
                        //MessageBox.Show("Xóa dữ liệu thành công");
                        //this.DialogResult = DialogResult.OK;
                        LoadData();
                    }
                    else
                    {
                     //   MessageBox.Show("Lỗi khi xóa dữ liệu");
                    }
                }
            }
            catch (Exception ex)
            {
               // MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message);
            }
            //_______________________________


            string mancc = textBox1.Text;
            bool result = KhachHangBLL.DeleteKhachHang(mancc);
            if (result)
            {
                MessageBox.Show("Xóa khách hàng thành công");
                LoadData();
                ResetTextBoxes();
            }
            else
            {
                MessageBox.Show("Xóa khách hàng thất bại");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                textBox1.Text = row.Cells["makh"].Value.ToString();
                textBox2.Text = row.Cells["tenkh"].Value.ToString();
                textBox4.Text = row.Cells["diachi"].Value.ToString();
                dpNamSinh.Text = row.Cells["namsinh"].Value.ToString();
                textBox3.Text = row.Cells["email"].Value.ToString();
                textBox7.Text = row.Cells["sdt"].Value.ToString();
                textBox5.Text = row.Cells["diem"].Value.ToString();
                comboBox1.Text = row.Cells["gioitinh"].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmKhachHang newForm = new FrmKhachHang();
            newForm.FormBorderStyle = FormBorderStyle.Sizable;
            // Hiển thị form mới
            newForm.Show();
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //dem so luong ban ghi
            int recordCount = 0;
            recordCount = dataGridView1.RowCount;
            label11.Text = recordCount.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Tạo một đối tượng Random để sinh chuỗi ngẫu nhiên
            Random random = new Random();

            // Tạo một chuỗi mới gồm 8 kí tự ngẫu nhiên
            string randomString = new string(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz", 8)
                                            .Select(s => s[random.Next(s.Length)]).ToArray());

            // Hiển thị chuỗi ngẫu nhiên trong TextBox1
            textBox1.Text = randomString;
        }

        private void label11_Click(object sender, EventArgs e)
        {

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
