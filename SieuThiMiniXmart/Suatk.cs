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
    public partial class Suatk : Form
    {
        public Suatk()
        {
            InitializeComponent();
        }
        string connectionString = DatabaseConnection.GetConnectionString();
        private void Suatk_Load(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection("Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True");

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from loginquanly", con);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "taikhoan";
                //comboBox1.ValueMember = "mancc";

                con.Close();
            }

            using (SqlConnection con1 = new SqlConnection(connectionString))
            {

                //SqlConnection con1 = new SqlConnection("Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True");
                SqlDataAdapter da1 = new SqlDataAdapter("select * from loginnhanvien", con1);
                DataTable dt1 = new DataTable();
                con1.Open();
                da1.Fill(dt1);
                comboBox2.DataSource = dt1;
                comboBox2.DisplayMember = "taikhoan";
                //comboBox1.ValueMember = "mancc";

                con1.Close();
            }
        }

        private void btndangnhap_Click(object sender, EventArgs e)
        {
            try
            {
                // Thực hiện insert vào database
                //SqlConnection con = new SqlConnection("Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True");

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("update loginquanly set matkhau = '" + matkhaumoi.Text + "' where taikhoan ='" + comboBox1.Text + "' and matkhau = '" + textBox1.Text + "'  ", con);
                    con.Open();
                    int ret = cmd.ExecuteNonQuery();
                    con.Close();

                    // Nếu insert thành công, đặt DialogResult của Form là OK
                    if (ret == 1)
                    {
                        MessageBox.Show("Đổi mật khẩu thành công");
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Lỗi khi đổi mật khẩu");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đổi mật khẩu: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Thực hiện insert vào database

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    //SqlConnection con = new SqlConnection("Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True");
                    SqlCommand cmd = new SqlCommand("update loginnhanvien set matkhau = '" + matkhaumoi.Text + "' where taikhoan ='" + comboBox2.Text + "' and matkhau = '" + textBox1.Text + "' ", con);
                    con.Open();
                    int ret = cmd.ExecuteNonQuery();
                    con.Close();

                    // Nếu insert thành công, đặt DialogResult của Form là OK
                    if (ret == 1)
                    {
                        MessageBox.Show("Đổi mật khẩu thành công");
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Lỗi khi đổi mật khẩu");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đổi mật khẩu: " + ex.Message);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
