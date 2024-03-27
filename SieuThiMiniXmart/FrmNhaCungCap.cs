using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using BLL;
using DTO;
using System.Reflection.Emit;
using System.Data.SqlClient;

namespace SieuThiMiniXmart
{
    public partial class FrmNhaCungCap : Form
    {
        private NhaCungCapBLL NhaCungCapBLL;
        private BindingSource bindingSource;
        public FrmNhaCungCap()
        {
            InitializeComponent();
            NhaCungCapBLL = new NhaCungCapBLL();
            bindingSource = new BindingSource();
            dataGridView1.AutoGenerateColumns = false;
        }
        string connectionString = DatabaseConnection.GetConnectionString();
        private void LoadData()
        {
            List<NhaCungCap> NhaCungCaps = NhaCungCapBLL.GetAllNhaCungCap();
            bindingSource.DataSource = NhaCungCaps;
            dataGridView1.DataSource = bindingSource;
        }
        private void btntimkiem_Click(object sender, EventArgs e)
        {
            string tenncc = textBox6.Text;
            if (!string.IsNullOrEmpty(tenncc))
            {
                List<NhaCungCap> NhaCungCaps = NhaCungCapBLL.GetNhaCungCapByTenNhaCungCap(tenncc);
                if (NhaCungCaps.Count > 0)
                {
                    bindingSource.DataSource = NhaCungCaps;
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
            try
            {
                NhaCungCap NhaCungCap = new NhaCungCap();
                NhaCungCap.mancc = textBox1.Text;
                NhaCungCap.tenncc = textBox2.Text;
                NhaCungCap.diachi = textBox4.Text;
                NhaCungCap.sdt = textBox3.Text;
                NhaCungCap.email = textBox7.Text;
                NhaCungCap.ghichu = textBox5.Text;

                bool result = NhaCungCapBLL.AddNhaCungCap(NhaCungCap);
                if (result)
                {
                    MessageBox.Show("Thêm nhà cung cấp thành công");
                    LoadData();
                    ResetTextBoxes();
                }
                else
                {
                    MessageBox.Show("Thêm nhà cung cấp thất bại");
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

        private void FrmNhaCungCap_Load(object sender, EventArgs e)
        {
            //this.tb_nhacungcapTableAdapter2.Fill(this.xmartDataSet62.tb_nhacungcap);
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
            try
            {
                NhaCungCap NhaCungCap = new NhaCungCap();
                NhaCungCap.mancc = textBox1.Text;
                NhaCungCap.tenncc = textBox2.Text;
                NhaCungCap.diachi = textBox4.Text;
                NhaCungCap.sdt = textBox3.Text;
                NhaCungCap.email = textBox7.Text;
                NhaCungCap.ghichu = textBox5.Text;



                bool result = NhaCungCapBLL.UpdateNhaCungCap(NhaCungCap);
                if (result)
                {
                    MessageBox.Show("Sửa thông tin nhà cung cấp thành công");
                    LoadData();
                    ResetTextBoxes();
                }
                else
                {
                    MessageBox.Show("Sửa thông tin nhà cung cấp thất bại");
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
                    SqlCommand cmd = new SqlCommand("delete tb_nhaphanghoa where mancc = '" + textBox1.Text + "' ", con);
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
                        //MessageBox.Show("Lỗi khi xóa dữ liệu");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message);
            }
            //______________
            try
            {

                // Thực hiện delete vào database
                //SqlConnection con = new SqlConnection("Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True");
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("delete tb_nhaphanghoa where mancc = '" + textBox1.Text + "' ", con);
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
                        MessageBox.Show("Lỗi khi xóa dữ liệu");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message);
            }
            //_____________
            string mancc = textBox1.Text;
            bool result = NhaCungCapBLL.DeleteNhaCungCap(mancc);
            if (result)
            {
                MessageBox.Show("Xóa nhà cung cấp thành công");
                LoadData();
                ResetTextBoxes();
            }
            else
            {
                MessageBox.Show("Xóa nhà cung cấp thất bại");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                textBox1.Text = row.Cells["mancc"].Value.ToString();
                textBox2.Text = row.Cells["tenncc"].Value.ToString();
                textBox4.Text = row.Cells["diachi"].Value.ToString();
                textBox3.Text = row.Cells["sdt"].Value.ToString();
                textBox7.Text = row.Cells["email"].Value.ToString();
                textBox5.Text = row.Cells["ghichu"].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmNhaCungCap newForm = new FrmNhaCungCap();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
