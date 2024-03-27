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
    public partial class Thongtinnhanvien : Form
    {
        public Thongtinnhanvien()
        {
            InitializeComponent();
        }
        string connectionString = DatabaseConnection.GetConnectionString();
        private void button9_Click(object sender, EventArgs e)
        {
            try
            {

                // Thực hiện delete vào database
                //SqlConnection con = new SqlConnection("Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True");

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlDataAdapter da = new SqlDataAdapter("select * from tb_nhanvien where tenNV like '" + textBox1.Text + "'  ", con);
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
        private void load_data()
        {
            //SqlConnection con = new SqlConnection("Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True");

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from tb_nhanvien", con);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
        }
        private void Thongtinnhanvien_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'xmartDataSet3.tb_nhanvien' table. You can move, or remove it, as needed.
            this.tb_nhanvienTableAdapter.Fill(this.xmartDataSet3.tb_nhanvien);
            load_data();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            load_data();
        }

        private void dataGridView1_CellErrorTextNeeded(object sender, DataGridViewCellErrorTextNeededEventArgs e)
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
