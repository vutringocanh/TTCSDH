using BLL;
using DTO;
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
using System.Reflection.Emit;
using System.Drawing.Imaging;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Text.RegularExpressions;

namespace SieuThiMiniXmart
{
    public partial class FrmHangHoa : Form
    {
        //private void ExportToExcel(DataGridView dgv)
        //{
        //    Excel.Application excel = new Excel.Application();
        //    Excel.Workbook workbook = excel.Workbooks.Add(Type.Missing);
        //    Excel.Worksheet worksheet = null;

        //    try
        //    {
        //        worksheet = workbook.ActiveSheet;

        //        for (int i = 1; i <= dgv.Columns.Count; i++)
        //        {
        //            worksheet.Cells[1, i] = dgv.Columns[i - 1].HeaderText;
        //        }

        //        for (int i = 0; i < dgv.Rows.Count; i++)
        //        {
        //            for (int j = 0; j < dgv.Columns.Count; j++)
        //            {
        //                worksheet.Cells[i + 2, j + 1] = dgv.Rows[i].Cells[j].Value.ToString();
        //            }
        //        }

        //        SaveFileDialog saveFileDialog = new SaveFileDialog();
        //        saveFileDialog.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
        //        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        //        {
        //            workbook.SaveAs(saveFileDialog.FileName);
        //            MessageBox.Show("Xuất thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        excel.Quit();
        //        workbook = null;
        //        excel = null;
        //    }
        //}
        public FrmHangHoa()
        {
            InitializeComponent();
            NhapHangHoaBLL = new NhapHangHoaBLL();
            
            bindingSource = new BindingSource();
            dataGridView1.AutoGenerateColumns = false;

            XuatHangHoaBLL = new XuatHangHoaBLL();
            bindingSource = new BindingSource();
            dataGridView2.AutoGenerateColumns = false;

        }
        string connectionString = DatabaseConnection.GetConnectionString();
        private void FrmHangHoa_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'xmartDataSet22.tb_nhaphanghoa1' table. You can move, or remove it, as needed.
            this.tb_nhaphanghoa1TableAdapter2.Fill(this.xmartDataSet22.tb_nhaphanghoa1);
            // TODO: This line of code loads data into the 'xmartDataSet21.tb_xuathanghoa' table. You can move, or remove it, as needed.
            this.tb_xuathanghoaTableAdapter3.Fill(this.xmartDataSet21.tb_xuathanghoa);
            // TODO: This line of code loads data into the 'xmartDataSet20.tb_nhaphanghoa' table. You can move, or remove it, as needed.
            this.tb_nhaphanghoaTableAdapter1.Fill(this.xmartDataSet20.tb_nhaphanghoa);
            // TODO: This line of code loads data into the 'xmartDataSet16.tb_nhaphanghoa1' table. You can move, or remove it, as needed.
    
            
            
            //set ngay xuat = ngay hom nay:
            dateTimePicker3.Text = DateTime.Now.ToString();
            

            // TODO: This line of code loads data into the 'xmartDataSet10.tb_xuathanghoa' table. You can move, or remove it, as needed.
           // this.tb_xuathanghoaTableAdapter1.Fill(this.xmartDataSet10.tb_xuathanghoa);
            // TODO: This line of code loads data into the 'xmartDataSet9.tb_xuathanghoa' table. You can move, or remove it, as needed.
            //this.tb_xuathanghoaTableAdapter.Fill(this.xmartDataSet9.tb_xuathanghoa);
            // TODO: This line of code loads data into the 'xmartDataSet8.tb_nhaphanghoa' table. You can move, or remove it, as needed.
            //this.tb_nhaphanghoaTableAdapter.Fill(this.xmartDataSet8.tb_nhaphanghoa);

            using (SqlConnection con1 = new SqlConnection(connectionString))
            {
                //SqlConnection con1 = new SqlConnection("Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True");
                SqlDataAdapter da1 = new SqlDataAdapter("select * from tb_nhacungcap", con1);
                DataTable dt1 = new DataTable();
                con1.Open();
                da1.Fill(dt1);
                comboBox2.DataSource = dt1;
                comboBox2.ValueMember = "mancc";
                // Tạo danh sách gợi ý cho ComboBox từ cột "mancc" trong DataTable
                AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();
                foreach (DataRow row in dt1.Rows)
                {
                    autoCompleteCollection.Add(row["mancc"].ToString());
                }
                // Thiết lập các thuộc tính cho ComboBox
                comboBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                comboBox2.AutoCompleteSource = AutoCompleteSource.CustomSource;
                comboBox2.AutoCompleteCustomSource = autoCompleteCollection;
                // Hiển thị ComboBox trên giao diện người dùng
                comboBox2.Visible = true;
                // Đóng kết nối
                con1.Close();
            }

            //SqlConnection con = new SqlConnection("Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True");
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from tb_nhacungcap", con);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                comboBox3.DataSource = dt;
                comboBox3.ValueMember = "mancc";
                comboBox7.DataSource = dt;
                comboBox7.ValueMember = "mancc";

                con.Close();
            }

            load_data();
            FrmHangHoa f = new FrmHangHoa();
            tabControl1.SizeChanged += (s, ev) => { f.Size = tabControl1.Size; };
            f.SizeChanged += (s, ev) => { tabControl1.Size = f.Size; };


            //tb het han su dung
            // Lấy dữ liệu từ bảng hàng hóa

            // Lấy dữ liệu từ bảng hàng hóa
            DataTable dt10 = this.xmartDataSet8.tb_nhaphanghoa;
            int expiredItemCount = 0;
            // Duyệt qua tất cả các mặt hàng và tìm các mặt hàng sắp hết hạn sử dụng
            foreach (DataRow row in dt10.Rows)
            {
                DateTime expirationDate = Convert.ToDateTime(row["hansudung"]);
                TimeSpan diff = expirationDate.Subtract(DateTime.Now);
                int daysLeft = diff.Days;

                // Kiểm tra nếu còn 3 ngày nữa là hết hạn sử dụng
                if (daysLeft <= 3)
                {
                    if (daysLeft < 0) // kiểm tra nếu mặt hàng đã hết hạn
                    {
                        expiredItemCount++; // tăng biến đếm lên 1 nếu mặt hàng đã hết hạn
                    }
                    else // nếu mặt hàng sắp hết hạn
                    {
                        MessageBox.Show("Mặt hàng " + row["tenhang"].ToString() + " sắp hết hạn sử dụng trong " + daysLeft + " ngày!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }

            if (expiredItemCount > 0) // kiểm tra nếu có mặt hàng đã hết hạn
            {
                MessageBox.Show("Có " + expiredItemCount + " mặt hàng đã hết hạn sử dụng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            //chuyển combo box không cho nhập
            comboBox5.DropDownStyle = ComboBoxStyle.DropDownList;
        }

    

        private NhapHangHoaBLL NhapHangHoaBLL;
        private BindingSource bindingSource;

        private XuatHangHoaBLL XuatHangHoaBLL;
        private void LoadData()
        {
            List<NhapHangHoa> NhapHangHoas = NhapHangHoaBLL.GetAllNhapHangHoa();
            bindingSource.DataSource = NhapHangHoas;
            dataGridView1.DataSource = bindingSource;
        }

        private void LoadData2()
        {
            //2
            List<XuatHangHoa> XuatHangHoas = XuatHangHoaBLL.GetAllXuatHangHoa();
            bindingSource.DataSource = XuatHangHoas;
            dataGridView2.DataSource = bindingSource;

        }

        private void load_data()
        {
            //SqlConnection con = new SqlConnection("Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True");

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from tb_nhaphanghoa1", con);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                dataGridView3.DataSource = dt;
                con.Close();
            }
        }
        private void btntimkiem1_Click(object sender, EventArgs e)
        {
            //if (!Regex.IsMatch(textBox6.Text, @"^[a-zA-Z0-9]+$"))
            //{
            //    MessageBox.Show("Mã hàng không được bỏ trống");
            //    return;
            //}
            bool timThay = false;  //tim kiem theo 2 cach, cach 1 tim duoc thi dung khong tim cach 2
            DateTime ngayNhap;
            if (DateTime.TryParse(textBox6.Text, out ngayNhap))
            {
                //SqlConnection con = new SqlConnection("Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True");
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlDataAdapter da = new SqlDataAdapter("select * from tb_nhaphanghoa where ngaynhap = '" + ngayNhap.ToString("yyyy-MM-dd") + "'  ", con);
                    DataTable dt = new DataTable();
                    con.Open();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    con.Close();

                    if (dt.Rows.Count > 0)
                    {
                        // Nếu tìm thấy bản ghi, đặt cờ là true và không thực hiện đoạn code sau
                        timThay = true;
                    }
                }
            }
            else
            {
                string tenhang = textBox6.Text;
                if (!string.IsNullOrEmpty(tenhang))
                {
                    NhapHangHoa NhapHangHoa = NhapHangHoaBLL.GetNhapHangHoaByTenNhapHangHoa(tenhang);
                    if (NhapHangHoa != null)
                    {
                        List<NhapHangHoa> NhapHangHoas = new List<NhapHangHoa>();
                        NhapHangHoas.Add(NhapHangHoa);
                        bindingSource.DataSource = NhapHangHoas;
                        dataGridView1.DataSource = bindingSource;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy hàng hóa có tên " + tenhang);
                        LoadData();
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập hàng hóa cấp để tìm kiếm");
                }
            }
        }
        private void btnthem1_Click(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(textBox1.Text, @"^[a-zA-Z0-9]+$"))
            {
                MessageBox.Show("Mã hàng không được bỏ trống");
                return;
            }
            //if (!Regex.IsMatch(textBox2.Text, @"^[a-zA-Z0-9]+$"))
            //{
            //    MessageBox.Show("Tên hàng không được bỏ trống");
            //    return;
            //}
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Tên hàng không được bỏ trống");
                return;
            }
            if (!Regex.IsMatch(textBox3.Text, @"^[0-9]+$"))
            {
                MessageBox.Show("Số lượng không được bỏ trống");
                return;
            }
            if (!Regex.IsMatch(textBox4.Text, @"^[0-9]+$"))
            {
                MessageBox.Show("Đơn giá nhập không được bỏ trống");
                return;
            }
            if (!Regex.IsMatch(textBox5.Text, @"^[0-9]+$"))
            {
                MessageBox.Show("Đơn giá bán không được bỏ trống");
                return;
            }


            try
            {



                DTO.NhapHangHoa NhapHangHoa = new DTO.NhapHangHoa();
                NhapHangHoa.mahang = textBox1.Text;
                NhapHangHoa.tenhang = textBox2.Text;
                NhapHangHoa.ngaynhap = datengaynhap.Text;
                NhapHangHoa.hansudung = datehansd.Text;
                NhapHangHoa.mancc = comboBox2.Text;
                int soluong;
                if (int.TryParse(textBox3.Text, out soluong)) // chuyển giá trị của textbox sang kiểu int
                {
                    if (soluong < 0)
                    {
                        MessageBox.Show("Số lượng nhập không được âm. Vui lòng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        NhapHangHoa.soluong = soluong;
                    }
                }
                else
                {
                    // xử lý khi textbox không chứa giá trị hợp lệ (ví dụ: giá trị không phải kiểu số nguyên)
                    // ví dụ:
                    MessageBox.Show("Số lượng nhập không hợp lệ. Vui lòng nhập lại số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                NhapHangHoa.donvitinh = comboBox1.Text;
                float dongianhap;
                if (float.TryParse(textBox4.Text, out dongianhap)) // chuyển giá trị của textbox sang kiểu int
                {
                    if (dongianhap <= 0)
                    {
                        MessageBox.Show("Đơn giá nhập không được âm. Vui lòng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        NhapHangHoa.dongianhap = dongianhap;

                    }
                }
                else
                {
                    // xử lý khi textbox không chứa giá trị hợp lệ (ví dụ: giá trị không phải kiểu số nguyên)
                    // ví dụ:
                    MessageBox.Show("Giá trị không hợp lệ, vui lòng nhập số");
                }
                float dongiaban;
                if (float.TryParse(textBox5.Text, out dongiaban)) // chuyển giá trị của textbox sang kiểu int
                {
                    if (dongiaban <= 0)
                    {
                        MessageBox.Show("Đơn giá bán không được âm. Vui lòng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        NhapHangHoa.dongiaban = dongiaban;
                    }

                }
                else
                {
                    MessageBox.Show("Giá trị không hợp lệ, vui lòng nhập số!");
                }
                if (float.TryParse(textBox4.Text, out dongianhap) && float.TryParse(textBox5.Text, out dongiaban) && int.TryParse(textBox3.Text, out soluong) && soluong > 0 && dongianhap > 0 && dongiaban > 0)
                {
                    if (dongiaban <= dongianhap)
                    {
                        MessageBox.Show("Giá trị của Đơn giá bán phải lớn hơn giá trị của Đơn giá nhập.");
                    }
                    else
                    {

                        bool result = NhapHangHoaBLL.AddNhapHangHoa(NhapHangHoa);
                        if (result)
                        {
                            MessageBox.Show("Thêm hàng hóa thành công");
                            LoadData();
                            ResetTextBoxes();
                        }
                        else
                        {
                            MessageBox.Show("Thêm hàng hóa thất bại");
                        }

                    }
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
        }
        private void ResetTextBoxes2()
        {
            textBox10.Text = "";
            textBox9.Text = "";
            textBox9.Text = "";
            textBox7.Text = "";
        }
        private void btnclear1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
        }

        private void btnrefresh1_Click(object sender, EventArgs e)
        {
            LoadData();
            ResetTextBoxes();
            datengaynhap.Text = DateTime.Now.ToString();
        }

        private void btnsua1_Click(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(textBox1.Text, @"^[a-zA-Z0-9]+$"))
            {
                MessageBox.Show("Mã hàng không được bỏ trống");
                return;
            }
            try
            {
                NhapHangHoa NhapHangHoa = new NhapHangHoa();
                NhapHangHoa.mahang = textBox1.Text;
                NhapHangHoa.tenhang = textBox2.Text;
                int soluong;
                if (int.TryParse(textBox3.Text, out soluong)) // chuyển giá trị của textbox sang kiểu int
                {
                    if (soluong <= 0)
                    {
                        MessageBox.Show("Số lượng không được âm. Vui lòng nhập lại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        NhapHangHoa.soluong = soluong;
                    }
                }
                else
                {
                    // xử lý khi textbox không chứa giá trị hợp lệ (ví dụ: giá trị không phải kiểu số nguyên)
                    // ví dụ:
                    MessageBox.Show("Giá trị không hợp lệ! Vui lòng nhập lại số");
                }
                NhapHangHoa.donvitinh = comboBox1.Text;
                float dongianhap;
                if (float.TryParse(textBox4.Text, out dongianhap)) // chuyển giá trị của textbox sang kiểu int
                {
                    if (dongianhap <= 0)
                    {
                        MessageBox.Show("Đơn giá nhập không được âm. Vui lòng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        NhapHangHoa.dongianhap = dongianhap;
                    }
                }
                else
                {
                    // xử lý khi textbox không chứa giá trị hợp lệ (ví dụ: giá trị không phải kiểu số nguyên)
                    MessageBox.Show("Giá trị không hợp lệ");
                }
                float dongiaban;
                if (float.TryParse(textBox5.Text, out dongiaban)) // chuyển giá trị của textbox sang kiểu int
                {
                    if (dongiaban <= 0)
                    {
                        MessageBox.Show("Đơn giá bán không được âm. Vui lòng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        NhapHangHoa.dongiaban = dongiaban;
                    }
                }
                else
                {
                    MessageBox.Show("Giá trị không hợp lệ");
                }
                NhapHangHoa.ngaynhap = datengaynhap.Text;
                NhapHangHoa.hansudung = datehansd.Text;
                NhapHangHoa.mancc = comboBox2.Text;
                bool result = NhapHangHoaBLL.UpdateNhapHangHoa(NhapHangHoa);
                if (result && float.TryParse(textBox5.Text, out dongiaban) && float.TryParse(textBox4.Text, out dongianhap) && dongianhap > 0 && dongiaban > 0 && int.TryParse(textBox3.Text, out soluong) && soluong > 0 && dongiaban > dongianhap)
                {
                    if (dongiaban <= dongianhap)
                    {
                        MessageBox.Show("Giá trị của Đơn giá bán phải lớn hơn giá trị của Đơn giá nhập.");
                    }
                    else
                    {

                        MessageBox.Show("Sửa thông tin thành công");
                        LoadData();
                        ResetTextBoxes();
                    }
                }
                else
                {
                    MessageBox.Show("Sửa thông tin thất bại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thực hiển dữ liệu: " + ex.Message);
            }
        }

        private void btnxoa1_Click(object sender, EventArgs e)
        {

            if (!Regex.IsMatch(textBox1.Text, @"^[a-zA-Z0-9]+$"))
            {
                MessageBox.Show("Mã hàng không được bỏ trống");
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này không?", "Xác nhận xóa", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {

                    // Thực hiện delete vào database
                    //SqlConnection con = new SqlConnection("Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True");

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand("delete tb_xuathanghoa where mahang = '" + textBox1.Text + "' ", con);
                        con.Open();
                        int ret = cmd.ExecuteNonQuery();
                        con.Close();

                        // Nếu delete thành công, đặt DialogResult của Form là OK
                        if (ret == 1)
                        {
                            //MessageBox.Show("Xóa dữ liệu thành công");
                            //this.DialogResult = DialogResult.OK;
                            load_data();
                        }
                        else
                        {
                            //MessageBox.Show("Lỗi khi xóa dữ liệu");
                        }
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message);
                }
                try
                {

                    // Thực hiện delete vào database
                    //SqlConnection con = new SqlConnection("Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True");

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand("delete tb_nhaphanghoa1 where mahang = '" + textBox1.Text + "' ", con);
                        con.Open();
                        int ret = cmd.ExecuteNonQuery();
                        con.Close();

                        // Nếu delete thành công, đặt DialogResult của Form là OK
                        if (ret == 1)
                        {
                            //MessageBox.Show("Xóa dữ liệu thành công");
                            //this.DialogResult = DialogResult.OK;
                            load_data();
                        }
                        else
                        {
                            //MessageBox.Show("Lỗi khi xóa dữ liệu");
                        }
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message);
                }
                try
                {

                    // Thực hiện delete vào database
                    //SqlConnection con = new SqlConnection("Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True");
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand("delete tb_cthd where mahang = '" + textBox1.Text + "' ", con);
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
                string mahang = textBox1.Text;
                bool result = NhapHangHoaBLL.DeleteNhapHangHoa(mahang);
                if (result)
                {
                    MessageBox.Show("Xóa dữ liệu thành công");
                    LoadData();
                    ResetTextBoxes();
                }
                else
                {
                    MessageBox.Show("Xóa dữ liệu thất bại");
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["mahang"].Value.ToString();
                textBox2.Text = row.Cells["tenhang"].Value.ToString();
                textBox3.Text = row.Cells["soluong"].Value.ToString();
                textBox4.Text = row.Cells["dongianhap"].Value.ToString();
                textBox5.Text = row.Cells["dongiaban"].Value.ToString();
                datengaynhap.Text = row.Cells["ngaynhap"].Value.ToString();
                comboBox1.Text = row.Cells["donvitinh"].Value.ToString();
                comboBox2.Text = row.Cells["mancc"].Value.ToString();
                datehansd.Text = row.Cells["hansudung"].Value.ToString();
                
            }
        }

        private void btnthem2_Click(object sender, EventArgs e)
        {

            if (!Regex.IsMatch(textBox10.Text, @"^[a-zA-Z0-9]+$"))
            {
                MessageBox.Show("Mã hàng không được bỏ trống");
                return;
            }
            //if (!Regex.IsMatch(textBox9.Text, @"^[a-zA-Z0-9]+$"))
            //{
            //    MessageBox.Show("Tên hàng không được bỏ trống");
            //    return;
            //}

            if (string.IsNullOrWhiteSpace(textBox9.Text))
            {
                MessageBox.Show("Tên hàng không được bỏ trống");
                return;
            }
            if (!Regex.IsMatch(textBox8.Text, @"^[0-9]+$"))
            {
                MessageBox.Show("Số lượng hàng không được bỏ trống");
                return;

            }
            if (!Regex.IsMatch(textBox18.Text, @"^[a-zA-Z0-9]+$"))
            {
                MessageBox.Show("Mã hóa đơn không được bỏ trống");
                return;

            }
            if (!Regex.IsMatch(textBox19.Text, @"^[a-zA-Z0-9]+$"))
            {
                MessageBox.Show("Mã nhân viên không được bỏ trống");
                return;

            }
            if (!Regex.IsMatch(textBox7.Text, @"^[0-9]+$"))
            {
                MessageBox.Show("Giá nhập hàng không được bỏ trống");
                return;
            }
            try
            {
                DTO.XuatHangHoa XuatHangHoa = new DTO.XuatHangHoa();
                XuatHangHoa.mahang = textBox10.Text;
                XuatHangHoa.tenhang = textBox9.Text;
                XuatHangHoa.mahd = textBox18.Text;
                XuatHangHoa.manv = textBox19.Text;

                int soluong;
                if (int.TryParse(textBox8.Text, out soluong)) // chuyển giá trị của textbox sang kiểu int
                {
                    if (soluong <= 0)
                    {
                        MessageBox.Show("Số lượng không được âm. Vui lòng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        XuatHangHoa.soluong = soluong;
                    }
                }
                else
                {
                    // xử lý khi textbox không chứa giá trị hợp lệ (ví dụ: giá trị không phải kiểu số nguyên)
                    // ví dụ:
                    MessageBox.Show("Số lượng nhập không hợp lệ. Vui lòng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                XuatHangHoa.donvitinh = comboBox4.Text;
                float dongianhap;
                if (float.TryParse(textBox7.Text, out dongianhap)) // chuyển giá trị của textbox sang kiểu int
                {
                    if (dongianhap <= 0)
                    {
                        MessageBox.Show("Đơn giá nhập không được âm. Vui lòng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        XuatHangHoa.dongianhap = dongianhap;
                    }
                }
                else
                {
                    // xử lý khi textbox không chứa giá trị hợp lệ (ví dụ: giá trị không phải kiểu số nguyên)
                    // ví dụ:
                    MessageBox.Show("Giá trị không hợp lệ!");
                }
                XuatHangHoa.ngayxuat = dateTimePicker3.Text;
                XuatHangHoa.mancc = comboBox3.Text;
                XuatHangHoa.ghichu = richTextBox1.Text;
                int soluongcu, soluongmoi;
                if (float.TryParse(textBox7.Text, out dongianhap) && dongianhap > 0 && int.TryParse(textBox3.Text, out soluongcu) && int.TryParse(textBox8.Text, out soluongmoi) && soluong > 0 && soluongcu > 0 && soluongmoi > 0)
                {
                    if (soluongcu < soluongmoi)
                    {
                        MessageBox.Show("số lượng xuất phải nhỏ hơn hoặc bằng số lượng tồn trong kho.");
                    }
                    else
                    {
                        bool result = XuatHangHoaBLL.AddXuatHangHoa(XuatHangHoa);

                        if (result)
                        {
                            MessageBox.Show("Xuất hàng thành công");
                            LoadData2();

                            ResetTextBoxes2();
                        }
                        else
                        {
                            MessageBox.Show("Xuất hàng thất bại");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thực hiển dữ liệu: " + ex.Message);
            }
        }
        private void btnsua2_Click(object sender, EventArgs e)
        {
           

            if (!Regex.IsMatch(textBox18.Text, @"^[a-zA-Z0-9]+$"))
            {
                MessageBox.Show("Mã hóa đơn không được bỏ trống");
                return;
            }

            try
            {
                XuatHangHoa XuatHangHoa = new XuatHangHoa();
                XuatHangHoa.mahang = textBox10.Text;
                XuatHangHoa.tenhang = textBox9.Text;

                XuatHangHoa.mahd = textBox18.Text;
                XuatHangHoa.manv = textBox19.Text;
                int soluong;
                if (int.TryParse(textBox8.Text, out soluong)) // chuyển giá trị của textbox sang kiểu int
                {
                    if (soluong <= 0)
                    {
                        MessageBox.Show("Số lượng không được âm. Vui lòng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        XuatHangHoa.soluong = soluong;
                    }
                }
                else
                {
                    // xử lý khi textbox không chứa giá trị hợp lệ (ví dụ: giá trị không phải kiểu số nguyên)
                    // ví dụ:
                    MessageBox.Show("Giá trị không hợp lệ, đã chuyển về giá trị 0!");
                }
                XuatHangHoa.donvitinh = comboBox4.Text;
                float dongianhap;
                if (float.TryParse(textBox7.Text, out dongianhap)) // chuyển giá trị của textbox sang kiểu int
                {
                    if (dongianhap <= 0)
                    {
                        MessageBox.Show("Đơn giá nhập không được âm. Vui lòng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        XuatHangHoa.dongianhap = dongianhap;
                    }
                }
                else
                {
                    // xử lý khi textbox không chứa giá trị hợp lệ (ví dụ: giá trị không phải kiểu số nguyên)
                    // ví dụ:
                    MessageBox.Show("Giá trị không hợp lệ, đã chuyển về giá trị 0!");
                }


                XuatHangHoa.ngayxuat = dateTimePicker3.Text;

                XuatHangHoa.mancc = comboBox3.Text;
                XuatHangHoa.ghichu = richTextBox1.Text;

                int soluongcu, soluongmoi;
                if (float.TryParse(textBox7.Text, out dongianhap) && dongianhap > 0 && int.TryParse(textBox3.Text, out soluongcu) && int.TryParse(textBox8.Text, out soluongmoi) && soluong > 0 && soluongcu > 0 && soluongmoi > 0)
                {
                    if (soluongcu < soluongmoi)
                    {
                        MessageBox.Show("số lượng xuất phải nhỏ hơn hoặc bằng số lượng tồn trong kho.");
                    }
                    else
                    {
                        bool result = XuatHangHoaBLL.UpdateXuatHangHoa(XuatHangHoa);
                        if (result)
                        {
                            MessageBox.Show("Sửa thông tin hàng thành công");
                            LoadData2();
                            ResetTextBoxes2();
                        }
                        else
                        {
                            MessageBox.Show("Sửa thông tin hàng thất bại");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thực hiển dữ liệu: " + ex.Message);
            }
        }

        private void btnxoa2_Click(object sender, EventArgs e)
        {

            if (!Regex.IsMatch(textBox18.Text, @"^[a-zA-Z0-9]+$"))
            {
                MessageBox.Show("Mã hóa đơn không được bỏ trống");
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này không?", "Xác nhận xóa", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    string mahd = textBox18.Text;
                    bool result = XuatHangHoaBLL.DeleteXuatHangHoa(mahd);
                    if (result)
                    {
                        MessageBox.Show("Xóa hàng xuất thành công");
                        LoadData2();
                        ResetTextBoxes2();
                    }
                    else
                    {
                        MessageBox.Show("Xóa hàng xuất thất bại");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thực hiển dữ liệu: " + ex.Message);
                }
            }
        }

        private void btnclear2_Click(object sender, EventArgs e)
        {
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox7.Clear();
        }

        private void btnrefresh2_Click(object sender, EventArgs e)
        {
            LoadData2();
            ResetTextBoxes2();
            dateTimePicker3.Text = DateTime.Now.ToString();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];
                textBox10.Text = row.Cells["mahang2"].Value.ToString();
                textBox9.Text = row.Cells["tenhang2"].Value.ToString();
                textBox8.Text = row.Cells["soluong2"].Value.ToString();
                textBox7.Text = row.Cells["dongianhap2"].Value.ToString();
                dateTimePicker3.Text = row.Cells["ngayxuat2"].Value.ToString();
                comboBox4.Text = row.Cells["donvitinh2"].Value.ToString();
                comboBox3.Text = row.Cells["mancc2"].Value.ToString();
                richTextBox1.Text = row.Cells["ghichu2"].Value.ToString();
                textBox18.Text = row.Cells["mahd"].Value.ToString();
                textBox19.Text = row.Cells["manv"].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {



            //if (!Regex.IsMatch(textBox11.Text, @"^[a-zA-Z0-9]+$"))
            //{
            //    MessageBox.Show("Mã hàng không được bỏ trống");
            //    return;
            //}
            bool timThay = false;

            DateTime ngayXuat;
            if (DateTime.TryParse(textBox11.Text, out ngayXuat))
            {
                //SqlConnection con = new SqlConnection("Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True");
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlDataAdapter da = new SqlDataAdapter("select * from tb_xuathanghoa where ngayxuat = '" + ngayXuat.ToString("yyyy-MM-dd") + "'  ", con);
                    DataTable dt = new DataTable();
                    con.Open();
                    da.Fill(dt);
                    dataGridView2.DataSource = dt;
                    con.Close();

                    if (dt.Rows.Count > 0)
                    {
                        // Nếu tìm thấy bản ghi, đặt cờ là true và không thực hiện đoạn code sau
                        timThay = true;
                    }
                }
            }
            else
            {
                string mahd = textBox18.Text;
                if (!string.IsNullOrEmpty(mahd))
                {
                    XuatHangHoa XuatHangHoa = XuatHangHoaBLL.GetXuatHangHoaByTenXuatHangHoa(mahd);


                    if (XuatHangHoa != null)
                    {
                        List<XuatHangHoa> XuatHangHoas = new List<XuatHangHoa>();
                        XuatHangHoas.Add(XuatHangHoa);

                        bindingSource.DataSource = XuatHangHoas;
                        dataGridView2.DataSource = bindingSource;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy hóa đơn " + mahd);
                        LoadData();
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập  hàng hóa  để tìm kiếm");
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox10.Text = textBox1.Text;
            textBox9.Text = textBox2.Text;
            textBox8.Text = "";
            textBox7.Text = textBox4.Text;
            comboBox4.Text = comboBox1.Text;
            comboBox3.Text = comboBox2.Text;
        }

        private void xuiFlatTab1_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmHangHoa newForm = new FrmHangHoa();
            newForm.FormBorderStyle = FormBorderStyle.Sizable;
            // Hiển thị form mới
            newForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RpNhapHangHoa formReport = new RpNhapHangHoa();
            formReport.ShowDialog();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage3)
            {
                LoadData();
            }
            else if (tabControl1.SelectedTab == tabPage4)
            {
                LoadData2();
            }
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //dem so luong ban ghi
            int recordCount = 0;
            recordCount = dataGridView1.RowCount;
            label13.Text = recordCount.ToString();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox5.SelectedItem.ToString() == "Hàng Hóa Sắp Hết Hạn")
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        //SqlConnection con = new SqlConnection("Data Source=vutringoc;Initial Catalog=xmart;Integrated Security=True");
                        SqlCommand cmd = new SqlCommand("SELECT * FROM tb_nhaphanghoa WHERE DATEDIFF(day, GETDATE(), hansudung) <= 3", con);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        con.Open();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                        con.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi truy vấn dữ liệu: " + ex.Message);
                }
                
            }


            else if (comboBox5.SelectedItem.ToString() == "Hàng Hóa Đã Hết Hạn Sử Dụng")
            {
                // Thực hiện hành động tương ứng với Item 2

                try
                {
                    //SqlConnection con = new SqlConnection("Data Source=vutringoc;Initial Catalog=xmart;Integrated Security=True");
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand("SELECT * FROM tb_nhaphanghoa WHERE hansudung < GETDATE()", con);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        con.Open();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                        con.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi truy vấn dữ liệu: " + ex.Message);
                }

                
            }
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
        
        private void button15_Click(object sender, EventArgs e)
        {

            // Kiểm tra TextBox17
            if (!Regex.IsMatch(textBox17.Text, @"^[a-zA-Z0-9]+$"))
            {
                MessageBox.Show("Mã hàng không được bỏ trống");
                return;
            }
            if (!Regex.IsMatch(textBox20.Text, @"^[a-zA-Z0-9]+$"))
            {
                MessageBox.Show("Mã hóa đơn không được bỏ trống");
                return;
            }
            if (!Regex.IsMatch(textBox21.Text, @"^[a-zA-Z0-9]+$"))
            {
                MessageBox.Show("Mã nhân viên không được bỏ trống");
                return;
            }
            // Kiểm tra TextBox15
            //if (!Regex.IsMatch(textBox15.Text, @"^[a-zA-Z0-9]+$"))
            //{
            //    MessageBox.Show("Tên hàng không được bỏ trống");
            //    return;
            //}

            if (string.IsNullOrWhiteSpace(textBox15.Text))
            {
                MessageBox.Show("Tên hàng không được bỏ trống");
                return;
            }

            // Kiểm tra TextBox16
            if (!Regex.IsMatch(textBox16.Text, @"^[0-9]+$"))
            {
                MessageBox.Show("Giá nhập không được bỏ trống");
                return;
            }

            // Kiểm tra TextBox14
            if (!Regex.IsMatch(textBox14.Text, @"^[0-9]+$"))
            {
                MessageBox.Show("Giá bán không được bỏ trống");
                return;
            }
            if (!Regex.IsMatch(textBox13.Text, @"^[0-9]+$"))
            {
                MessageBox.Show("Số lượng không được bỏ trống");
                return;
            }
            //Đoạn mã trên sử dụng phương thức IsMatch của lớp Regex để kiểm tra xem các giá trị trong các TextBox có phù hợp với biểu thức chính quy "^[a-zA-Z0-9]+$" hay không. Biểu thức chính quy này chỉ cho phép các kí tự chữ cái hoặc số và bắt buộc phải có ít nhất 1 kí tự. Nếu có giá trị không phù hợp, bạn sẽ hiển thị một hộp thoại thông báo lỗi và không thêm sản phẩm.



            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn thêm sản phẩm này không?", "Xác nhận thêm", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {


                try
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();

                        // Kiểm tra xem mã hóa đơn đã tồn tại trong bảng hay chưa
                        SqlCommand cmdCheck = new SqlCommand("SELECT COUNT(*) FROM tb_nhaphanghoa WHERE mahang = @mahang", con);
                        cmdCheck.Parameters.AddWithValue("@mahang", textBox17.Text);
                        int count = (int)cmdCheck.ExecuteScalar();

                        if (count > 0) // Mã hóa đơn đã tồn tại, thực hiện UPDATE
                        {
                            SqlCommand cmdUpdate = new SqlCommand("UPDATE tb_nhaphanghoa SET soluong = soluong + @soluong WHERE mahang = @mahang", con);
                            cmdUpdate.Parameters.AddWithValue("@mahang", textBox17.Text);
                            //cmdUpdate.Parameters.AddWithValue("@tenhang", textBox15.Text);
                            cmdUpdate.Parameters.AddWithValue("@soluong", textBox13.Text);
                            //cmdUpdate.Parameters.AddWithValue("@donvitinh", comboBox6.Text);
                            //cmdUpdate.Parameters.AddWithValue("@dongianhap", textBox17.Text);
                            //cmdUpdate.Parameters.AddWithValue("@dongiaban", textBox14.Text);
                            //cmdUpdate.Parameters.AddWithValue("@ngaynhap", dateTimePicker1.Value);
                            //cmdUpdate.Parameters.AddWithValue("@hansudung", dateTimePicker2.Value);
                            //cmdUpdate.Parameters.AddWithValue("@mancc", comboBox7.Text);

                            int ret = cmdUpdate.ExecuteNonQuery();

                            if (ret == 1)
                            {
                                // MessageBox.Show("Cập nhật dữ liệu thành công");
                                load_data();
                            }
                            else
                            {
                                MessageBox.Show("Lỗi khi cập nhật dữ liệu");
                            }
                        }
                        else // Mã hóa đơn chưa tồn tại, thực hiện INSERT
                        {
                            SqlCommand cmdInsert = new SqlCommand("INSERT INTO tb_nhaphanghoa (mahang, tenhang, soluong, donvitinh, dongianhap, dongiaban, ngaynhap, hansudung, mancc) VALUES (@mahang, @tenhang, @soluong, @donvitinh, @dongianhap, @dongiaban, @ngaynhap, @hansudung, @mancc)", con);
                            cmdInsert.Parameters.AddWithValue("@mahang", textBox17.Text);
                            cmdInsert.Parameters.AddWithValue("@tenhang", textBox15.Text);
                            cmdInsert.Parameters.AddWithValue("@soluong", textBox13.Text);
                            cmdInsert.Parameters.AddWithValue("@donvitinh", comboBox6.Text);
                            cmdInsert.Parameters.AddWithValue("@dongianhap", textBox16.Text);
                            cmdInsert.Parameters.AddWithValue("@dongiaban", textBox14.Text);
                            cmdInsert.Parameters.AddWithValue("@ngaynhap", dateTimePicker1.Value);
                            cmdInsert.Parameters.AddWithValue("@hansudung", dateTimePicker2.Value);
                            cmdInsert.Parameters.AddWithValue("@mancc", comboBox7.Text);
                            int ret = cmdInsert.ExecuteNonQuery();

                            if (ret == 1)
                            {
                                //MessageBox.Show("Thêm dữ liệu thành công");
                                load_data();
                            }
                            else
                            {
                                MessageBox.Show("Lỗi khi cập nhật dữ liệu");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thực hiển dữ liệu: " + ex.Message);
                }
                try
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand("insert into tb_nhaphanghoa1 values('"+textBox20.Text+"', '" + textBox17.Text + "',  '" + textBox15.Text + "',  '" + textBox13.Text + "', '" + comboBox6.Text + "',  '" + textBox16.Text + "',  '" + textBox14.Text + "',  '" + dateTimePicker1.Text + "' ,'" + dateTimePicker2.Text + "' , '" + comboBox7.Text + "', '"+textBox21.Text+"')", con);
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm dữ liệu: " + ex.Message);
                }
            }

        }

        private void button17_Click(object sender, EventArgs e)
        {
            
            
            if (!Regex.IsMatch(textBox20.Text, @"^[a-zA-Z0-9]+$"))
            {
                MessageBox.Show("Mã hóa đơn không được bỏ trống");
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn sửa sản phẩm này không?", "Xác nhận xóa", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();
                        SqlCommand cmdUpdate = new SqlCommand("UPDATE tb_nhaphanghoa1 SET tenhang = @tenhang, soluong = @soluong, donvitinh = @donvitinh, dongianhap = @dongianhap, dongiaban = @dongiaban, ngaynhap = @ngaynhap, hansudung = @hansudung, mancc = @mancc, mahang = @mahang, manv = @manv WHERE mahd = @mahd", con);
                        cmdUpdate.Parameters.AddWithValue("@mahang", textBox17.Text);
                        cmdUpdate.Parameters.AddWithValue("@tenhang", textBox15.Text);
                        cmdUpdate.Parameters.AddWithValue("@soluong", textBox13.Text);
                        cmdUpdate.Parameters.AddWithValue("@donvitinh", comboBox6.Text);
                        cmdUpdate.Parameters.AddWithValue("@dongianhap", textBox16.Text);
                        cmdUpdate.Parameters.AddWithValue("@dongiaban", textBox14.Text);
                        cmdUpdate.Parameters.AddWithValue("@ngaynhap", dateTimePicker1.Value);
                        cmdUpdate.Parameters.AddWithValue("@hansudung", dateTimePicker2.Value);
                        cmdUpdate.Parameters.AddWithValue("@mancc", comboBox7.Text);
                        cmdUpdate.Parameters.AddWithValue("@manv", textBox21.Text);
                        cmdUpdate.Parameters.AddWithValue("@mahd", textBox20.Text);

                        int ret = cmdUpdate.ExecuteNonQuery();

                        if (ret == 1)
                        {
                            // MessageBox.Show("Cập nhật dữ liệu thành công");
                            load_data();
                        }
                        else
                        {
                            MessageBox.Show("Lỗi khi cập nhật dữ liệu");
                        }
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi sửa dữ liệu: " + ex.Message);
                }
            
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(textBox20.Text, @"^[a-zA-Z0-9]+$"))
            {
                MessageBox.Show("Mã hóa đơn không được bỏ trống");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này không?", "Xác nhận xóa", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {

                    // Thực hiện delete vào database
                    //SqlConnection con = new SqlConnection("Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True");

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand("delete tb_nhaphanghoa1 where mahd = '" + textBox20.Text + "' ", con);
                        con.Open();
                        int ret = cmd.ExecuteNonQuery();
                        con.Close();

                        // Nếu delete thành công, đặt DialogResult của Form là OK
                        if (ret == 1)
                        {
                            //MessageBox.Show("Xóa dữ liệu thành công");
                            //this.DialogResult = DialogResult.OK;
                            load_data();
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
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            // Tạo một đối tượng Random để sinh chuỗi ngẫu nhiên
            Random random = new Random();

            // Tạo một chuỗi mới gồm 8 kí tự ngẫu nhiên
            string randomString = new string(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz", 8)
                                            .Select(s => s[random.Next(s.Length)]).ToArray());

            // Hiển thị chuỗi ngẫu nhiên trong TextBox1
            textBox17.Text = randomString;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            load_data();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            bool timThay = false;
            DateTime ngayNhap;
            if (DateTime.TryParse(textBox12.Text, out ngayNhap))
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlDataAdapter da = new SqlDataAdapter("select * from tb_nhaphanghoa1 where ngaynhap = '" + ngayNhap.ToString("yyyy-MM-dd") + "'  ", con);
                    DataTable dt = new DataTable();
                    con.Open();
                    da.Fill(dt);
                    dataGridView3.DataSource = dt;
                    con.Close();
                    if (dt.Rows.Count > 0)
                    {
                        // Nếu tìm thấy bản ghi, đặt cờ là true và không thực hiện đoạn code sau
                        timThay = true;
                    }
                }
            }

            else
            {
                string tenhang = textBox12.Text;
                if (!string.IsNullOrEmpty(tenhang))
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        SqlDataAdapter da = new SqlDataAdapter("select * from tb_nhaphanghoa1 where mahd= '" + textBox12.Text + "'", con);
                        DataTable dt = new DataTable();
                        con.Open();
                        da.Fill(dt);
                        dataGridView3.DataSource = dt;
                        con.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập hàng hóa cấp để tìm kiếm");
                }
            }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView3.Rows[e.RowIndex];
                textBox17.Text = row.Cells["mahang3"].Value.ToString();
                textBox15.Text = row.Cells["tenhang3"].Value.ToString();
                textBox13.Text = row.Cells["soluong3"].Value.ToString();
                textBox16.Text = row.Cells["dongianhap3"].Value.ToString();
                textBox14.Text = row.Cells["dongiaban3"].Value.ToString();
                comboBox6.Text = row.Cells["donvitinh3"].Value.ToString();
                comboBox7.Text = row.Cells["mancc3"].Value.ToString();
                dateTimePicker1.Text = row.Cells["ngaynhap3"].Value.ToString();
                dateTimePicker2.Text = row.Cells["hansudung3"].Value.ToString();
                textBox20.Text = row.Cells["mahd3"].Value.ToString();
                textBox21.Text = row.Cells["manv3"].Value.ToString();

            }


            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //ExportToExcel(dataGridView3);

            // Lấy dữ liệu từ database
            Modify md = new Modify();
            string mahd = textBox20.Text;

            DataTable dt = md.nhaphang(mahd);

            // Tạo instance của form ThongKeDoanhSoThang2
            RpNhapHangHoa1 frm = new RpNhapHangHoa1(this);

            // Hiển thị form chứa control reportViewer1
            frm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ database
            Modify md = new Modify();
            string mahd = textBox18.Text;
            
            DataTable dt = md.xuathang(mahd);

            // Tạo instance của form ThongKeDoanhSoThang2
            RpXuatHangHoa frm = new RpXuatHangHoa(this);

            // Hiển thị form chứa control reportViewer1
            frm.Show();
        }
        public string Getmahd()
        {
            return textBox18.Text;
        }
        public string Getmahd1()
        {
            return textBox20.Text;
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

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

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

        private void textBox18_TextChanged(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            // Tạo một đối tượng Random để sinh chuỗi ngẫu nhiên
            Random random = new Random();

            // Tạo một chuỗi mới gồm 8 kí tự ngẫu nhiên
            string randomString = new string(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz", 8)
                                            .Select(s => s[random.Next(s.Length)]).ToArray());

            // Hiển thị chuỗi ngẫu nhiên trong TextBox1
            textBox18.Text = randomString;
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            // Tạo một đối tượng Random để sinh chuỗi ngẫu nhiên
            Random random = new Random();

            // Tạo một chuỗi mới gồm 8 kí tự ngẫu nhiên
            string randomString = new string(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz", 8)
                                            .Select(s => s[random.Next(s.Length)]).ToArray());

            // Hiển thị chuỗi ngẫu nhiên trong TextBox1
            textBox20.Text = randomString;
        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox20.Clear();
            textBox21.Clear();
            textBox13.Clear();
            textBox14.Clear();
            textBox15.Clear();
            textBox16.Clear();

        }
    }
        
}
