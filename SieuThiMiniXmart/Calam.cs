using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
    

    public partial class Calam : Form
    {
        private bool isEditMode = false;

        string connectionString = DatabaseConnection.GetConnectionString();
        public Calam()
        {
            InitializeComponent();

            comboBox1.Enabled = false; // Khóa các textbox
            comboBox2.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false; // Khóa button Save
            button6.Enabled = false;

        }

        private void Calam_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'xmartDataSet4.tb_calam' table. You can move, or remove it, as needed.
            //this.tb_calamTableAdapter.Fill(this.xmartDataSet4.tb_calam);
            //SqlConnection con1 = new SqlConnection("Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True");
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter da1 = new SqlDataAdapter("select * from tb_nhanvien", con);
                DataTable dt1 = new DataTable();
                con.Open();
                da1.Fill(dt1);
                comboBox1.DataSource = dt1;
                comboBox1.ValueMember = "manv";
                con.Close();

                
            }
            load_data();

        }
        private void load_data()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //SqlConnection con1 = new SqlConnection("Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True");
                SqlDataAdapter da1 = new SqlDataAdapter("select * from tb_calam", con);
                DataTable dt1 = new DataTable();
                con.Open();
                da1.Fill(dt1);
                dataGridView1.DataSource = dt1;
                con.Close();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.Enabled = true; // Khóa các textbox
            comboBox2.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true; // Khóa button Save
            button6.Enabled = true;
            isEditMode = false;
            /*
            try
            {
                // Thực hiện insert vào database
                SqlConnection con = new SqlConnection("Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True");
                SqlCommand cmd = new SqlCommand("insert into tb_calam values( '" + comboBox1.Text + "',  '" + comboBox2.Text + "',  '" + textBox4.Text + "',  '" + textBox5.Text + "')", con);
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
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm dữ liệu: " + ex.Message);
            }
            */
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.Enabled = true; // Khóa các textbox
            comboBox2.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true; // Khóa button Save
            button6.Enabled = true;
            isEditMode = true;
            /*
            try
            {
                // Thực hiện update vào database
                SqlConnection con = new SqlConnection("Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True");
                SqlCommand cmd = new SqlCommand("update tb_calam set MaCa= '" + comboBox2.Text + "',Thoigianbatdau = '" + textBox4.Text + "', Thoigianketthuc = '" + textBox5.Text + "' where taikhoan = '" + comboBox1.Text + "' ", con);
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
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa dữ liệu: " + ex.Message);
            }
            */
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox5.Clear();
            textBox4.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            load_data();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                // Thực hiện delete vào database
                //SqlConnection con = new SqlConnection("Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True");
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("delete tb_calam where manv = '" + comboBox1.Text + "' ", con);
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

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {

                // Thực hiện delete vào database
                //SqlConnection con = new SqlConnection("Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True");
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlDataAdapter da = new SqlDataAdapter("select * from tb_calam where manv like '" + textBox1.Text + "'  ", con);
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

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    //SqlConnection con = new SqlConnection("Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True");
                    if (isEditMode)
                    {
                        // Thực hiện update dữ liệu
                        SqlCommand cmd = new SqlCommand("update tb_calam set maca = @value1, thoigianbatdau = @value2, thoigianketthuc = @value3 where manv = @Manv", con);
                        cmd.Parameters.AddWithValue("@value1", comboBox2.Text);
                        cmd.Parameters.AddWithValue("@value2", textBox4.Text);
                        cmd.Parameters.AddWithValue("@value3", textBox5.Text);
                        cmd.Parameters.AddWithValue("@Manv", comboBox1.Text); // Giả sử id là giá trị của cột id trong bảng tb_calam
                        con.Open();
                        int ret = cmd.ExecuteNonQuery();
                        con.Close();
                        if (ret == 1)
                        {
                            MessageBox.Show("Cập nhật dữ liệu thành công");
                            this.DialogResult = DialogResult.OK;
                            load_data();
                        }
                        else
                        {
                            MessageBox.Show("Lỗi khi cập nhật dữ liệu");
                        }
                    }
                    else
                    {
                        // Thực hiện insert dữ liệu
                        SqlCommand cmd = new SqlCommand("insert into tb_calam values( @value1,  @value2,  @value3, @value4)", con);
                        cmd.Parameters.AddWithValue("@value1", comboBox1.Text);
                        cmd.Parameters.AddWithValue("@value2", comboBox2.Text);
                        cmd.Parameters.AddWithValue("@value3", textBox4.Text);
                        cmd.Parameters.AddWithValue("@value4", textBox5.Text);
                        con.Open();
                        int ret = cmd.ExecuteNonQuery();
                        con.Close();
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
                    // Khóa lại các textbox và button Save sau khi lưu dữ liệu thành công
                    comboBox1.Enabled = false;
                    comboBox2.Enabled = false;
                    textBox4.Enabled = false;
                    textBox5.Enabled = false;
                    button6.Enabled = false;
                    // Đặt isEditMode = false
                    isEditMode = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // Hủy thao tác hiện tại và trở về trạng thái ban đầu của form
            textBox5.Text = "";
            textBox4.Text = "";
            //comboBox1.SelectedIndex = -1;
            //comboBox2.SelectedIndex = -1;
            button1.Enabled = true;
            button2.Enabled = true;
            button6.Enabled = false;
            isEditMode = false;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem.ToString() == "Ca 1")
            {
                textBox4.Text = "7:30:00";
                textBox5.Text = "15:00:00";
                textBox4.Enabled = false;
                textBox5.Enabled = false;
            }
            else if (comboBox2.SelectedItem.ToString() == "Ca 2")
            {
                textBox4.Text = "14:30:00";
                textBox5.Text = "21:00:00";
                textBox4.Enabled = false;
                textBox5.Enabled = false;
            }
            else {
                textBox4.Enabled = true;
                textBox5.Enabled = true;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            comboBox1.Text = row.Cells["manv"].Value.ToString();
            comboBox2.Text = row.Cells["maca"].Value.ToString();
            textBox4.Text = row.Cells["thoigianbatdau"].Value.ToString();
            textBox5.Text = row.Cells["thoigianketthuc"].Value.ToString();
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
