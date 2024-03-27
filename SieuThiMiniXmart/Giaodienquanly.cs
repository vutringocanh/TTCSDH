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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SieuThiMiniXmart
{
    public partial class Giaodienquanly : Form
    {
        public Giaodienquanly()
        {
            InitializeComponent();
            dataGridView1.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dataGridView1_DataBindingComplete);

        }
        string connectionString = DatabaseConnection.GetConnectionString();
        private Themtk themtk;
        private void button8_Click(object sender, EventArgs e)
        {
            Themtk form2 = new Themtk();
            if (form2.ShowDialog() == DialogResult.OK)
            {
                // Nếu Form 2 được đóng và trả về DialogResult.OK, cập nhật lại dữ liệu trên Form cha
                load_data();
            }
            /*
            if (themtk == null || themtk.Visible == false)
            {
                
                themtk = new Themtk();
                themtk.Show();

            }
            else
            {
                themtk.BringToFront();

            }

            */
        }
        private Suatk suatk;
        private void button9_Click(object sender, EventArgs e)
        {
            /* if (suatk == null || suatk.Visible == false)
             {

                 suatk = new Suatk();
                 suatk.Show();
             }
             else
             {
                 suatk.BringToFront();
             }*/
            Suatk form2 = new Suatk();
            if (form2.ShowDialog() == DialogResult.OK)
            {
                // Nếu Form 2 được đóng và trả về DialogResult.OK, cập nhật lại dữ liệu trên Form cha
                load_data();
            }
        }
        private Xoatk xoatk;
        private void button10_Click(object sender, EventArgs e)
        {
            Xoatk form2 = new Xoatk();
            if (form2.ShowDialog() == DialogResult.OK)
            {
                // Nếu Form 2 được đóng và trả về DialogResult.OK, cập nhật lại dữ liệu trên Form cha
                load_data();
            }
        }
        void load_data()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //SqlConnection con = new SqlConnection("Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True");
                SqlDataAdapter da = new SqlDataAdapter("select * from loginquanly", con);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                dataGridView2.DataSource = dt;
                con.Close();
            }
            using (SqlConnection con1 = new SqlConnection(connectionString))
            {
                //SqlConnection con1 = new SqlConnection("Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True");
                SqlDataAdapter da1 = new SqlDataAdapter("select * from loginnhanvien", con1);
                DataTable dt1 = new DataTable();
                con1.Open();
                da1.Fill(dt1);
                dataGridView1.DataSource = dt1;
                con1.Close();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection("Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True");
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("select tb_NhanVien.MaNV, tb_NhanVien.TenNV, count (ngaychamcong) as 'Số chấm công' from tb_NhanVien, tb_chamcong where tb_NhanVien.MaNV = tb_chamcong.manv and month(ngaychamcong) = '" + cbmonth.Text + "' and year(ngaychamcong) = '" + cbnam.Text + "'   group by tb_NhanVien.MaNV, tb_NhanVien.TenNV", con);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                dataGridView3.DataSource = dt;
                con.Close();
            }
        }

        private void Giaodienquanly_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'xmartDataSet19.loginquanly' table. You can move, or remove it, as needed.
            this.loginquanlyTableAdapter1.Fill(this.xmartDataSet19.loginquanly);
            // TODO: This line of code loads data into the 'xmartDataSet18.loginnhanvien' table. You can move, or remove it, as needed.
            this.loginnhanvienTableAdapter1.Fill(this.xmartDataSet18.loginnhanvien);
            cbmonth.Text = DateTime.Now.Month.ToString();
            cbnam.Text = DateTime.Now.Year.ToString();
            // TODO: This line of code loads data into the 'xmartDataSet1.loginquanly' table. You can move, or remove it, as needed.
            //this.loginquanlyTableAdapter.Fill(this.xmartDataSet1.loginquanly);
            // TODO: This line of code loads data into the 'xmartDataSet.loginnhanvien' table. You can move, or remove it, as needed.
            //this.loginnhanvienTableAdapter.Fill(this.xmartDataSet.loginnhanvien);


            //load

            //SqlConnection con1 = new SqlConnection("Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True");
            using (SqlConnection con1 = new SqlConnection(connectionString))
            {
                SqlDataAdapter da1 = new SqlDataAdapter("select tb_NhanVien.MaNV as 'Mã nhân viên', tb_NhanVien.TenNV as 'Tên nhân viên', count(ngaychamcong) as 'Số chấm công' from tb_NhanVien, tb_chamcong where tb_NhanVien.MaNV = tb_chamcong.manv and month(ngaychamcong) = month(getdate()) and year(ngaychamcong) = year(getdate())   group by tb_NhanVien.MaNV, tb_NhanVien.TenNV ", con1);
                DataTable dt1 = new DataTable();
                con1.Open();
                da1.Fill(dt1);
                dataGridView3.DataSource = dt1;
                con1.Close();
            }



            //____________
            int currentYear2 = DateTime.Now.Year;
            for (int i = currentYear2; i <= currentYear2 + 10; i++)
            {
                cbnam.Items.Add(i.ToString());
            }
            cbnam.SelectedItem = DateTime.Now.Year.ToString();

            // Lấy tháng hiện tại
            int currentMonth2 = DateTime.Now.Month;
            // Gán các mục vào comboBox33
            for (int i = 1; i <= 12; i++)
            {
                cbmonth.Items.Add(i.ToString());
            }
            // Chọn mục tương ứng với tháng hiện tại
            cbmonth.SelectedIndex = currentMonth2 - 1;

        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //dem so luong ban ghi
            int recordCount = 0;
            recordCount = dataGridView1.RowCount;
            label10.Text = "Tổng số tài khoản: " + recordCount.ToString();
        }

        private void dataGridView2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //dem so luong ban ghi
            int recordCount = 0;
            recordCount = dataGridView2.RowCount;
            label11.Text = "Tổng số tài khoản: " + recordCount.ToString();
        }

        private void dataGridView3_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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
    }
}
