using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;
using System.Reflection;
using System.Security.Cryptography;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing.Printing;

namespace SieuThiMiniXmart
{
    public partial class FrmThongKe : Form
    {
        public FrmThongKe()
        {
            InitializeComponent();
        }
        string connectionString = DatabaseConnection.GetConnectionString();
        private void FrmThongKe_Load(object sender, EventArgs e)
        {
            // thay doi kich thuoc
            FrmThongKe f = new FrmThongKe();
            tabControl1.SizeChanged += (s, ev) => { f.Size = tabControl1.Size; };
            f.SizeChanged += (s, ev) => { tabControl1.Size = f.Size; };

            // gan thang nam hien tai vao combobox
            int currentYear = DateTime.Now.Year;
            for (int i = currentYear; i <= currentYear + 10; i++)
            {
                comboBox34.Items.Add(i.ToString());
            }
            comboBox34.SelectedItem = DateTime.Now.Year.ToString();

            // Lấy tháng hiện tại
            int currentMonth = DateTime.Now.Month;
            // Gán các mục vào comboBox33
            for (int i = 1; i <= 12; i++)
            {
                comboBox33.Items.Add(i.ToString());
            }
            // Chọn mục tương ứng với tháng hiện tại
            comboBox33.SelectedIndex = currentMonth - 1;




            int currentYear1 = DateTime.Now.Year;
            for (int i = currentYear1; i <= currentYear1 + 10; i++)
            {
                comboBox3.Items.Add(i.ToString());
            }
            comboBox3.SelectedItem = DateTime.Now.Year.ToString();

            // Lấy tháng hiện tại
            int currentMonth1 = DateTime.Now.Month;
            // Gán các mục vào comboBox33
            for (int i = 1; i <= 12; i++)
            {
                comboBox4.Items.Add(i.ToString());
            }
            // Chọn mục tương ứng với tháng hiện tại
            comboBox4.SelectedIndex = currentMonth1 - 1;

            //____________
            int currentYear2 = DateTime.Now.Year;
            for (int i = currentYear2; i <= currentYear2 + 10; i++)
            {
                comboBox1.Items.Add(i.ToString());
            }
            comboBox1.SelectedItem = DateTime.Now.Year.ToString();

            // Lấy tháng hiện tại
            int currentMonth2 = DateTime.Now.Month;
            // Gán các mục vào comboBox33
            for (int i = 1; i <= 12; i++)
            {
                comboBox2.Items.Add(i.ToString());
            }
            // Chọn mục tương ứng với tháng hiện tại
            comboBox2.SelectedIndex = currentMonth2 - 1;


            //____________
            int currentYear3 = DateTime.Now.Year;
            for (int i = currentYear3; i <= currentYear3 + 10; i++)
            {
                comboBox5.Items.Add(i.ToString());
            }
            comboBox5.SelectedItem = DateTime.Now.Year.ToString();

            // Lấy tháng hiện tại
            int currentMonth3 = DateTime.Now.Month;
            // Gán các mục vào comboBox33
            for (int i = 1; i <= 12; i++)
            {
                comboBox6.Items.Add(i.ToString());
            }
            // Chọn mục tương ứng với tháng hiện tại
            comboBox6.SelectedIndex = currentMonth3 - 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime ngayBatDau = dateTimePicker1.Value;
            DateTime ngayKetThuc = dateTimePicker2.Value;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // Convert DateTime values to string in a format that is compatible with SQL server's date format
                string formattedStartDate = ngayBatDau.ToString("yyyy-MM-dd");
                string formattedEndDate = ngayKetThuc.ToString("yyyy-MM-dd");

                SqlDataAdapter da = new SqlDataAdapter("SELECT tb_hoadon.mahd, tb_hoadon.tenkh, tb_hoadon.tennl, tb_hoadon.ngaylap, tb_hoadon.makh, tb_hoadon.manv, SUM(tb_cthd.thanhtien) AS sumthanhtien FROM tb_hoadon INNER JOIN tb_cthd ON tb_hoadon.mahd = tb_cthd.mahd WHERE tb_hoadon.ngaylap BETWEEN '" + formattedStartDate + "' AND '" + formattedEndDate + "' GROUP BY tb_hoadon.mahd, tb_hoadon.tenkh, tb_hoadon.tennl, tb_hoadon.ngaylap, tb_hoadon.makh, tb_hoadon.manv", con);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();

                double sum = 0;
                foreach (DataRow row in dt.Rows)
                {
                    sum += Convert.ToDouble(row["sumthanhtien"]);
                }

                label4.Text = sum.ToString();
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string formattedStartDate = ngayBatDau.ToString("yyyy-MM-dd");
                string formattedEndDate = ngayKetThuc.ToString("yyyy-MM-dd");
                SqlDataAdapter da = new SqlDataAdapter("SELECT tb_hoadon.ngaylap, SUM(tb_cthd.thanhtien) AS sumthanhtien FROM tb_hoadon INNER JOIN tb_cthd ON tb_hoadon.mahd = tb_cthd.mahd WHERE tb_hoadon.ngaylap BETWEEN '" + formattedStartDate + "' AND '" + formattedEndDate + "' GROUP BY tb_hoadon.ngaylap", con);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();

                // Kiểm tra nếu không có dữ liệu, hiển thị thông báo và thoát
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để hiển thị");
                    return;
                }

                // Khởi tạo biểu đồ và chuỗi dữ liệu
                Chart myChart = new Chart();
                ChartArea chartArea = new ChartArea();
                myChart.ChartAreas.Add(chartArea);
                Series dataSeries = new Series("Doanh thu");

                // Thêm dữ liệu vào chuỗi dữ liệu của biểu đồ
                foreach (DataRow row in dt.Rows)
                {
                    dataSeries.Points.AddXY(row["ngaylap"], row["sumthanhtien"]);
                }

                // Thêm chuỗi dữ liệu vào biểu đồ và cấu hình trục
                myChart.Series.Add(dataSeries);
                myChart.ChartAreas[0].AxisX.Interval = 1;
                myChart.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Days;
                myChart.ChartAreas[0].AxisX.LabelStyle.Format = "dd/MM/yyyy";
                myChart.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
                myChart.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;

                // Cấu hình tiêu đề và kích thước của biểu đồ
                myChart.Titles.Add("Doanh thu từ ngày " + formattedStartDate + " đến ngày " + formattedEndDate);
                myChart.Size = new Size(600, 400);

                // Thêm biểu đồ vào Form
                myChart.Dock = DockStyle.Fill;
                panel1.Controls.Clear();
                panel1.Controls.Add(myChart);
            }


        }

        private void btnxoa1_Click(object sender, EventArgs e)
        {
            int thang = comboBox33.SelectedIndex + 1; // Lấy giá trị tháng từ combobox1
            int nam = Convert.ToInt32(comboBox34.SelectedItem); // Lấy giá trị năm từ combobox2
            //SqlConnection con = new SqlConnection("Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True");
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT tb_hoadon.mahd, tb_hoadon.tenkh, tb_hoadon.tennl, tb_hoadon.ngaylap, tb_hoadon.makh, tb_hoadon.manv, SUM(tb_cthd.thanhtien) AS sumthanhtien " +
                            "FROM tb_hoadon INNER JOIN tb_cthd ON tb_hoadon.mahd = tb_cthd.mahd " +
                            "WHERE MONTH(tb_hoadon.ngaylap) = " + thang + " AND YEAR(tb_hoadon.ngaylap) = " + nam +
                            "GROUP BY tb_hoadon.mahd, tb_hoadon.tenkh, tb_hoadon.tennl, tb_hoadon.ngaylap, tb_hoadon.makh, tb_hoadon.manv";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
                double sum = 0;
                foreach (DataRow row in dt.Rows)
                {
                    sum += Convert.ToDouble(row["sumthanhtien"]);
                }
                label4.Text = sum.ToString();
            }



            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT tb_hoadon.ngaylap, SUM(tb_cthd.thanhtien) AS sumthanhtien FROM tb_hoadon INNER JOIN tb_cthd ON tb_hoadon.mahd = tb_cthd.mahd WHERE MONTH(tb_hoadon.ngaylap) = " + thang + " AND YEAR(tb_hoadon.ngaylap) = " + nam + " GROUP BY tb_hoadon.ngaylap";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để hiển thị");
                    return;
                }

                // Khởi tạo biểu đồ và chuỗi dữ liệu
                Chart myChart = new Chart();
                ChartArea chartArea = new ChartArea();
                myChart.ChartAreas.Add(chartArea);
                Series dataSeries = new Series("Doanh thu");

                // Thêm dữ liệu vào chuỗi dữ liệu của biểu đồ
                foreach (DataRow row in dt.Rows)
                {
                    dataSeries.Points.AddXY(row["ngaylap"], row["sumthanhtien"]);
                }
                string month = comboBox33.Text;
                string year = comboBox34.Text;
                // Thêm chuỗi dữ liệu vào biểu đồ và cấu hình trục
                myChart.Series.Add(dataSeries);
                myChart.ChartAreas[0].AxisX.Interval = 1;
                myChart.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Days;
                myChart.ChartAreas[0].AxisX.LabelStyle.Format = "dd/MM/yyyy";
                myChart.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
                myChart.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;

                // Cấu hình tiêu đề và kích thước của biểu đồ
                myChart.Titles.Add("Doanh thu tháng " + month + " năm " + year);
                myChart.Size = new Size(600, 400);

                // Thêm biểu đồ vào Form
                myChart.Dock = DockStyle.Fill;
                panel1.Controls.Clear();
                panel1.Controls.Add(myChart);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {





            RpThongKeDoanhThuThang formReport = new RpThongKeDoanhThuThang();
            formReport.ShowDialog();




            PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ database
            Modify md = new Modify();
            int thang = comboBox33.SelectedIndex + 1;
            int nam = Convert.ToInt32(comboBox34.SelectedItem);
            DataTable dt = md.LayDuLieuThang(thang, nam);

            // Tạo instance của form ThongKeDoanhSoThang2
            RpThongKeDoanhThuThang2 frm = new RpThongKeDoanhThuThang2(this);

            // Hiển thị form chứa control reportViewer1
            frm.Show();
        }

        public int GetSelectedMonth()
        {
            return comboBox33.SelectedIndex + 1;
        }

        public int GetSelectedYear()
        {
            return Convert.ToInt32(comboBox34.SelectedItem);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DateTime ngayBatDau = dateTimePicker3.Value;
            DateTime ngayKetThuc = dateTimePicker4.Value;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string formattedStartDate = ngayBatDau.ToString("yyyy-MM-dd");
                string formattedEndDate = ngayKetThuc.ToString("yyyy-MM-dd");
                //SqlConnection con = new SqlConnection("Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True");
                SqlDataAdapter da = new SqlDataAdapter("SELECT tb_cthd.mahang, tb_nhaphanghoa.tenhang, SUM(tb_cthd.soluong) AS tong_soluong_ban_ra   FROM tb_cthd   INNER JOIN tb_nhaphanghoa ON tb_cthd.mahang = tb_nhaphanghoa.mahang   INNER JOIN tb_hoadon ON tb_cthd.mahd = tb_hoadon.mahd   WHERE tb_hoadon.ngaylap BETWEEN '" + formattedStartDate + "' AND '" + formattedEndDate + "'   GROUP BY tb_cthd.mahang, tb_nhaphanghoa.tenhang   ORDER BY tong_soluong_ban_ra DESC;", con);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                dataGridView2.DataSource = dt;
                con.Close();

                // do có tb_đổiđiểm lên nếu muốn số liệu chính xác có thể trừ đi ở tb_ đổiđiểm rồi xuất ra label hay label1(sumcthd) - label2(sumdoidiem) = label3 = sumthanhtien (số tiền chính xác) //tự làm, ở đoạn code này tôi chỉ lấy số tiền đã thu được gốc, không tính phần bù đổi điểm)

                double sum = 0;
                foreach (DataRow row in dt.Rows)
                {
                    sum += Convert.ToDouble(row["tong_soluong_ban_ra"]);
                }

                // Gán giá trị tổng vào label1
                label13.Text = sum.ToString();

            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int thang = comboBox2.SelectedIndex + 1;
            int nam = Convert.ToInt32(comboBox1.SelectedItem);
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT tb_cthd.mahang, tb_nhaphanghoa.tenhang, SUM(tb_cthd.soluong) AS tong_soluong_ban_ra FROM tb_cthd INNER JOIN tb_nhaphanghoa ON tb_cthd.mahang = tb_nhaphanghoa.mahang INNER JOIN tb_hoadon ON tb_cthd.mahd = tb_hoadon.mahd WHERE MONTH(tb_hoadon.ngaylap) = " + thang + " AND YEAR(tb_hoadon.ngaylap) = " + nam + " GROUP BY tb_cthd.mahang, tb_nhaphanghoa.tenhang ORDER BY tong_soluong_ban_ra DESC; ";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                dataGridView2.DataSource = dt;
                con.Close();
                double sum = 0;
                foreach (DataRow row in dt.Rows)
                {
                    sum += Convert.ToDouble(row["tong_soluong_ban_ra"]);
                }
                label13.Text = sum.ToString();
            }

        }

        private void button14_Click(object sender, EventArgs e)
        {
            DateTime ngayBatDau = dateTimePicker3.Value;
            DateTime ngayKetThuc = dateTimePicker4.Value;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string formattedStartDate = ngayBatDau.ToString("yyyy-MM-dd");
                string formattedEndDate = ngayKetThuc.ToString("yyyy-MM-dd");
                //SqlConnection con = new SqlConnection("Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True");
                SqlDataAdapter da = new SqlDataAdapter("SELECT tb_cthd.mahang, tb_nhaphanghoa.tenhang, SUM(tb_cthd.soluong) AS total_quantity, (tb_nhaphanghoa.dongiaban - tb_nhaphanghoa.dongianhap) * SUM(tb_cthd.soluong) AS lai FROM tb_cthd INNER JOIN tb_hoadon ON tb_cthd.mahd = tb_hoadon.mahd INNER JOIN tb_nhaphanghoa ON tb_cthd.mahang = tb_nhaphanghoa.mahang WHERE tb_hoadon.ngaylap BETWEEN '" + formattedStartDate + "' AND '" + formattedEndDate + "' GROUP BY tb_cthd.mahang, tb_nhaphanghoa.tenhang, (tb_nhaphanghoa.dongiaban - tb_nhaphanghoa.dongianhap)", con);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                dataGridView3.DataSource = dt;
                con.Close();

                // do có tb_đổiđiểm lên nếu muốn số liệu chính xác có thể trừ đi ở tb_ đổiđiểm rồi xuất ra label hay label1(sumcthd) - label2(sumdoidiem) = label3 = sumthanhtien (số tiền chính xác) //tự làm, ở đoạn code này tôi chỉ lấy số tiền đã thu được gốc, không tính phần bù đổi điểm)

                double sum = 0;
                foreach (DataRow row in dt.Rows)
                {
                    sum += Convert.ToDouble(row["lai"]);
                }

                // Gán giá trị tổng vào label1
                label19.Text = sum.ToString();

            }


        }

        private void button11_Click(object sender, EventArgs e)
        {
            int thang = comboBox4.SelectedIndex + 1;
            int nam = Convert.ToInt32(comboBox3.SelectedItem);
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT tb_cthd.mahang, tb_nhaphanghoa.tenhang, SUM(tb_cthd.soluong) AS total_quantity, (tb_nhaphanghoa.dongiaban - tb_nhaphanghoa.dongianhap) * SUM(tb_cthd.soluong) AS lai FROM tb_cthd INNER JOIN tb_hoadon ON tb_cthd.mahd = tb_hoadon.mahd INNER JOIN tb_nhaphanghoa ON tb_cthd.mahang = tb_nhaphanghoa.mahang WHERE MONTH(tb_hoadon.ngaylap) = '" + @thang + "' AND YEAR(tb_hoadon.ngaylap) = '" + @nam + "'  GROUP BY tb_cthd.mahang, tb_nhaphanghoa.tenhang, (tb_nhaphanghoa.dongiaban - tb_nhaphanghoa.dongianhap)";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                dataGridView3.DataSource = dt;
                con.Close();
                double sum = 0;
                foreach (DataRow row in dt.Rows)
                {
                    sum += Convert.ToDouble(row["lai"]);
                }
                label19.Text = sum.ToString();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void button24_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {
            string month = comboBox6.Text;
            string year = comboBox5.Text;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // Convert DateTime values to string in a format that is compatible with SQL server's date format


                SqlDataAdapter da = new SqlDataAdapter("SELECT tb_nhaphanghoa1.mahd, tb_nhaphanghoa1.mahang, tb_nhaphanghoa1.tenhang, tb_nhaphanghoa1.soluong, tb_nhaphanghoa1.ngaynhap, tb_nhaphanghoa1.dongianhap as 'dongianhap' FROM tb_nhaphanghoa1 WHERE month(tb_nhaphanghoa1.ngaynhap) = '" + month + "' and year(tb_nhaphanghoa1.ngaynhap) = '" + year + "'   ", con);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                dataGridView4.DataSource = dt;
                con.Close();

                double sum = 0;
                foreach (DataRow row in dt.Rows)
                {
                    sum += Convert.ToDouble(row["dongianhap"]);
                }

                label26.Text = sum.ToString();
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void button26_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
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

        private void dataGridView4_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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

        private void button21_Click(object sender, EventArgs e)
        {
            DateTime ngayBatDau = dateTimePicker7.Value;
            DateTime ngayKetThuc = dateTimePicker8.Value;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // Convert DateTime values to string in a format that is compatible with SQL server's date format
                string formattedStartDate = ngayBatDau.ToString("yyyy-MM-dd");
                string formattedEndDate = ngayKetThuc.ToString("yyyy-MM-dd");

                SqlDataAdapter da = new SqlDataAdapter("SELECT tb_nhaphanghoa1.mahd, tb_nhaphanghoa1.mahang, tb_nhaphanghoa1.tenhang, tb_nhaphanghoa1.soluong, tb_nhaphanghoa1.ngaynhap, tb_nhaphanghoa1.dongianhap as 'dongianhap' FROM tb_nhaphanghoa1 WHERE tb_nhaphanghoa1.ngaynhap BETWEEN '" + formattedStartDate + "' AND '" + formattedEndDate + "' ", con);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                dataGridView4.DataSource = dt;
                con.Close();

                double sum = 0;
                foreach (DataRow row in dt.Rows)
                {
                    sum += Convert.ToDouble(row["dongianhap"]);
                }

                label26.Text = sum.ToString();
            }
        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DateTime ngayBatDau = dateTimePicker1.Value;
            DateTime ngayKetThuc = dateTimePicker2.Value;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // Convert DateTime values to string in a format that is compatible with SQL server's date format
                string formattedStartDate = ngayBatDau.ToString("yyyy-MM-dd");
                string formattedEndDate = ngayKetThuc.ToString("yyyy-MM-dd");

                SqlDataAdapter da = new SqlDataAdapter("SELECT tb_hoadon.mahd, tb_hoadon.tenkh, tb_hoadon.tennl, tb_hoadon.ngaylap, tb_hoadon.makh, tb_hoadon.manv, SUM(tb_cthd.thanhtien) AS sumthanhtien FROM tb_hoadon INNER JOIN tb_cthd ON tb_hoadon.mahd = tb_cthd.mahd WHERE tb_cthd.tenhang = '" + textBox1.Text + "' and tb_hoadon.ngaylap BETWEEN '" + formattedStartDate + "' AND '" + formattedEndDate + "' GROUP BY tb_hoadon.mahd, tb_hoadon.tenkh, tb_hoadon.tennl, tb_hoadon.ngaylap, tb_hoadon.makh, tb_hoadon.manv", con);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();

                double sum = 0;
                foreach (DataRow row in dt.Rows)
                {
                    sum += Convert.ToDouble(row["sumthanhtien"]);
                }

                label4.Text = sum.ToString();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            int thang = comboBox33.SelectedIndex + 1; // Lấy giá trị tháng từ combobox1
            int nam = Convert.ToInt32(comboBox34.SelectedItem); // Lấy giá trị năm từ combobox2
            //SqlConnection con = new SqlConnection("Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True");
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT tb_hoadon.mahd, tb_hoadon.tenkh, tb_hoadon.tennl, tb_hoadon.ngaylap, tb_hoadon.makh, tb_hoadon.manv, SUM(tb_cthd.thanhtien) AS sumthanhtien " +
                            "FROM tb_hoadon INNER JOIN tb_cthd ON tb_hoadon.mahd = tb_cthd.mahd " +
                            "WHERE tb_cthd.tenhang = '" + textBox2.Text + "' and MONTH(tb_hoadon.ngaylap) = " + thang + " AND YEAR(tb_hoadon.ngaylap) = " + nam +
                            "GROUP BY tb_hoadon.mahd, tb_hoadon.tenkh, tb_hoadon.tennl, tb_hoadon.ngaylap, tb_hoadon.makh, tb_hoadon.manv";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
                double sum = 0;
                foreach (DataRow row in dt.Rows)
                {
                    sum += Convert.ToDouble(row["sumthanhtien"]);
                }
                label4.Text = sum.ToString();
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            DateTime ngayBatDau = dateTimePicker3.Value;
            DateTime ngayKetThuc = dateTimePicker4.Value;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string formattedStartDate = ngayBatDau.ToString("yyyy-MM-dd");
                string formattedEndDate = ngayKetThuc.ToString("yyyy-MM-dd");
                //SqlConnection con = new SqlConnection("Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True");
                SqlDataAdapter da = new SqlDataAdapter("SELECT tb_cthd.mahang, tb_nhaphanghoa.tenhang, SUM(tb_cthd.soluong) AS total_quantity, (tb_nhaphanghoa.dongiaban - tb_nhaphanghoa.dongianhap) * SUM(tb_cthd.soluong) AS lai FROM tb_cthd INNER JOIN tb_hoadon ON tb_cthd.mahd = tb_hoadon.mahd INNER JOIN tb_nhaphanghoa ON tb_cthd.mahang = tb_nhaphanghoa.mahang WHERE tb_cthd.tenhang = '" + textBox5.Text + "' and tb_hoadon.ngaylap BETWEEN '" + formattedStartDate + "' AND '" + formattedEndDate + "' GROUP BY tb_cthd.mahang, tb_nhaphanghoa.tenhang, (tb_nhaphanghoa.dongiaban - tb_nhaphanghoa.dongianhap)", con);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                dataGridView3.DataSource = dt;
                con.Close();

                // do có tb_đổiđiểm lên nếu muốn số liệu chính xác có thể trừ đi ở tb_ đổiđiểm rồi xuất ra label hay label1(sumcthd) - label2(sumdoidiem) = label3 = sumthanhtien (số tiền chính xác) //tự làm, ở đoạn code này tôi chỉ lấy số tiền đã thu được gốc, không tính phần bù đổi điểm)

                double sum = 0;
                foreach (DataRow row in dt.Rows)
                {
                    sum += Convert.ToDouble(row["lai"]);
                }

                // Gán giá trị tổng vào label1
                label19.Text = sum.ToString();

            }
        }

        private void button29_Click(object sender, EventArgs e)
        {
            int thang = comboBox4.SelectedIndex + 1;
            int nam = Convert.ToInt32(comboBox3.SelectedItem);
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT tb_cthd.mahang, tb_nhaphanghoa.tenhang, SUM(tb_cthd.soluong) AS total_quantity, (tb_nhaphanghoa.dongiaban - tb_nhaphanghoa.dongianhap) * SUM(tb_cthd.soluong) AS lai FROM tb_cthd INNER JOIN tb_hoadon ON tb_cthd.mahd = tb_hoadon.mahd INNER JOIN tb_nhaphanghoa ON tb_cthd.mahang = tb_nhaphanghoa.mahang WHERE tb_cthd.tenhang = '" + textBox6.Text + "' and MONTH(tb_hoadon.ngaylap) = '" + @thang + "' AND YEAR(tb_hoadon.ngaylap) = '" + @nam + "'  GROUP BY tb_cthd.mahang, tb_nhaphanghoa.tenhang, (tb_nhaphanghoa.dongiaban - tb_nhaphanghoa.dongianhap)";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                dataGridView3.DataSource = dt;
                con.Close();
                double sum = 0;
                foreach (DataRow row in dt.Rows)
                {
                    sum += Convert.ToDouble(row["lai"]);
                }
                label19.Text = sum.ToString();
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            DateTime ngayBatDau = dateTimePicker7.Value;
            DateTime ngayKetThuc = dateTimePicker8.Value;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // Convert DateTime values to string in a format that is compatible with SQL server's date format
                string formattedStartDate = ngayBatDau.ToString("yyyy-MM-dd");
                string formattedEndDate = ngayKetThuc.ToString("yyyy-MM-dd");

                SqlDataAdapter da = new SqlDataAdapter("SELECT tb_nhaphanghoa1.mahd, tb_nhaphanghoa1.mahang, tb_nhaphanghoa1.tenhang, tb_nhaphanghoa1.soluong, tb_nhaphanghoa1.ngaynhap, tb_nhaphanghoa1.dongianhap as 'dongianhap' FROM tb_nhaphanghoa1 WHERE tenhang = '" + textBox4.Text + "' and tb_nhaphanghoa1.ngaynhap BETWEEN '" + formattedStartDate + "' AND '" + formattedEndDate + "' ", con);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                dataGridView4.DataSource = dt;
                con.Close();

                double sum = 0;
                foreach (DataRow row in dt.Rows)
                {
                    sum += Convert.ToDouble(row["dongianhap"]);
                }

                label26.Text = sum.ToString();
            }
        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            string month = comboBox6.Text;
            string year = comboBox5.Text;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // Convert DateTime values to string in a format that is compatible with SQL server's date format
                SqlDataAdapter da = new SqlDataAdapter("SELECT tb_nhaphanghoa1.mahd, tb_nhaphanghoa1.mahang, tb_nhaphanghoa1.tenhang, tb_nhaphanghoa1.soluong, tb_nhaphanghoa1.ngaynhap, tb_nhaphanghoa1.dongianhap as 'dongianhap' FROM tb_nhaphanghoa1 WHERE tenhang = '" + textBox3.Text + "' and month(tb_nhaphanghoa1.ngaynhap) = '" + month + "' and year(tb_nhaphanghoa1.ngaynhap) = '" + year + "'   ", con);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                dataGridView4.DataSource = dt;
                con.Close();

                double sum = 0;
                foreach (DataRow row in dt.Rows)
                {
                    sum += Convert.ToDouble(row["dongianhap"]);
                }

                label26.Text = sum.ToString();
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {

        }



        //private PrintDocument printDocument1 = new PrintDocument();
        private void button30_Click(object sender, EventArgs e)
        {
            
        }
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Bitmap bitmap = new Bitmap(panel1.Width, panel1.Height);
            panel1.DrawToBitmap(bitmap, new Rectangle(0, 0, panel1.Width, panel1.Height));
            graphics.DrawImage(bitmap, 0, 0);
        }
    }
}
