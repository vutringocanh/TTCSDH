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
    public partial class Xoatk : Form
    {
        public Xoatk()
        {
            InitializeComponent();
        }
        string connectionString = DatabaseConnection.GetConnectionString();
        private void Xoatk_Load(object sender, EventArgs e)
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

            //SqlConnection con1 = new SqlConnection("Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True");

            using (SqlConnection con1 = new SqlConnection(connectionString))
            {
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

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {

                //SqlConnection con = new SqlConnection("Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True");

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("delete from tb_nhanvien where taikhoan ='" + comboBox2.Text + "' ", con);
                    con.Open();
                    int ret = cmd.ExecuteNonQuery();
                    con.Close();

                    // Nếu insert thành công, đặt DialogResult của Form là OK
                    if (ret == 1)
                    {
                        //MessageBox.Show("Xóa dữ liệu thành công");
                        //this.DialogResult = DialogResult.OK;
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
            //++++++++++++++++++++++++++++++++++++++
            try
            {

                //SqlConnection con = new SqlConnection("Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True");

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("delete from loginnhanvien where taikhoan ='" + comboBox2.Text + "' ", con);
                    con.Open();
                    int ret = cmd.ExecuteNonQuery();
                    con.Close();

                    // Nếu insert thành công, đặt DialogResult của Form là OK
                    if (ret == 1)
                    {
                        MessageBox.Show("Xóa dữ liệu thành công");
                        this.DialogResult = DialogResult.OK;
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

        private void btndangnhap_Click(object sender, EventArgs e)
        {
            try
            {
                //SqlConnection con = new SqlConnection("Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True");
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("delete from tb_quanly where taikhoan ='" + comboBox1.Text + "' ", con);
                    con.Open();
                    int ret = cmd.ExecuteNonQuery();
                    con.Close();

                    // Nếu insert thành công, đặt DialogResult của Form là OK
                    if (ret == 1)
                    {
                        //MessageBox.Show("Xóa dữ liệu thành công");
                        //this.DialogResult = DialogResult.OK;
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

            //_______________________
            try
            {
                //SqlConnection con = new SqlConnection("Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True");

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("delete from loginquanly where taikhoan ='" + comboBox1.Text + "' ", con);
                    con.Open();
                    int ret = cmd.ExecuteNonQuery();
                    con.Close();

                    // Nếu insert thành công, đặt DialogResult của Form là OK
                    if (ret == 1)
                    {
                        MessageBox.Show("Xóa dữ liệu thành công");
                        this.DialogResult = DialogResult.OK;
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
    }
}
