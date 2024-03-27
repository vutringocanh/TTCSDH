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
    public partial class Doimatkhau : Form
    {
        public Doimatkhau()
        {
            InitializeComponent();
        }
        string connectionString = DatabaseConnection.GetConnectionString();
        private void btndangnhap_Click(object sender, EventArgs e)
        {

            try
            {
                if (matkhaumoi.Text == nhaplaimk.Text)
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        //SqlConnection con = new SqlConnection("Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True");
                        SqlCommand cmd = new SqlCommand("update loginquanly set matkhau =  '" + matkhaumoi.Text + "' where matkhau = '" + matkhaucu.Text + "'  ", con);
                        con.Open();
                        int ret = cmd.ExecuteNonQuery();
                        if (ret == 1)
                            MessageBox.Show("Đổi mật khẩu thành công");
                        else
                            MessageBox.Show("Mật khẩu không chính xác");
                        con.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Mật khẩu không trùng lặp");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thực hiển dữ liệu: " + ex.Message);
            }


        }
    }
}
