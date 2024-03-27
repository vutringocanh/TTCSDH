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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SieuThiMiniXmart
{
    public partial class Themtk : Form
    {
        public Themtk()
        {
            InitializeComponent();
        }
        string connectionString = DatabaseConnection.GetConnectionString();
        private void btndangnhap_Click(object sender, EventArgs e)
        {
            try
            {
                // Thực hiện insert vào database
                //SqlConnection con = new SqlConnection("Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True");

                
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("insert into loginquanly values( '" + txttaikhoan.Text + "',  '" + txtmatkhau.Text + "' )", connection);
                    connection.Open();
                    int ret = cmd.ExecuteNonQuery();
                    connection.Close();

                    // Nếu insert thành công, đặt DialogResult của Form là OK
                    if (ret == 1)
                    {
                        MessageBox.Show("Thêm dữ liệu thành công");
                        this.DialogResult = DialogResult.OK;
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

        private void matkhaumoi_TextChanged(object sender, EventArgs e)
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
                    SqlCommand cmd = new SqlCommand("insert into loginnhanvien values( '" + txttaikhoan.Text + "',  '" + txtmatkhau.Text + "' )", con);
                    con.Open();
                    int ret = cmd.ExecuteNonQuery();
                    con.Close();

                    // Nếu insert thành công, đặt DialogResult của Form là OK
                    if (ret == 1)
                    {
                        MessageBox.Show("Thêm dữ liệu thành công");
                        this.DialogResult = DialogResult.OK;
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
