using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SieuThiMiniXmart
{
    public class Modify
    {

        String connectionString = DatabaseConnection.GetConnectionString();

        public DataTable GetNhapHangHoa()
        {
            //SqlConnection con = new SqlConnection("Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True");
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from tb_nhaphanghoa", con);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                return dt;
            }
        }
        public DataTable Getdoanhsothang()
        {
            //SqlConnection con = new SqlConnection("Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True");
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT tb_hoadon.mahd, tb_hoadon.tenkh, tb_hoadon.tennl, tb_hoadon.ngaylap, tb_hoadon.makh, tb_hoadon.manv, SUM(tb_cthd.thanhtien) AS sumthanhtien FROM tb_hoadon INNER JOIN tb_cthd ON tb_hoadon.mahd = tb_cthd.mahd GROUP BY tb_hoadon.mahd, tb_hoadon.tenkh, tb_hoadon.tennl, tb_hoadon.ngaylap, tb_hoadon.makh, tb_hoadon.manv", con);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                return dt;
            }
        }

        public DataTable LayDuLieuThang(int thang, int nam)
        {
            // Chuỗi kết nối tới SQL Server
            //string connectionString = "Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // Chuỗi truy vấn SQL để lấy dữ liệu
                string query = "SELECT tb_hoadon.mahd, tb_hoadon.tenkh, tb_hoadon.tennl, tb_hoadon.ngaylap, tb_hoadon.makh, tb_hoadon.manv, SUM(tb_cthd.thanhtien) AS sumthanhtien " +
                           "FROM tb_hoadon INNER JOIN tb_cthd ON tb_hoadon.mahd = tb_cthd.mahd " +
                           "WHERE MONTH(tb_hoadon.ngaylap) = @thang AND YEAR(tb_hoadon.ngaylap) = @nam " +
                           "GROUP BY tb_hoadon.mahd, tb_hoadon.tenkh, tb_hoadon.tennl, tb_hoadon.ngaylap, tb_hoadon.makh, tb_hoadon.manv";

                // Tạo kết nối đến SQL Server
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Tạo đối tượng SqlCommand để thực hiện truy vấn
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thêm tham số @thang và @nam vào câu truy vấn
                        command.Parameters.AddWithValue("@thang", thang);
                        command.Parameters.AddWithValue("@nam", nam);

                        // Tạo đối tượng SqlDataAdapter để lấy dữ liệu từ SQL Server vào DataTable
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            // Tạo DataTable để chứa dữ liệu lấy từ SQL Server
                            DataTable table = new DataTable();
                            adapter.Fill(table);

                            return table;
                        }
                    }
                }
            }
        }

        public DataTable xuathang(string mahd)
        {
            // Chuỗi kết nối tới SQL Server
            //string connectionString = "Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // Chuỗi truy vấn SQL để lấy dữ liệu
                string query = "SELECT * from tb_xuathanghoa WHERE mahd = @mahd ";

                // Tạo kết nối đến SQL Server
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Tạo đối tượng SqlCommand để thực hiện truy vấn
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thêm tham số @thang và @nam vào câu truy vấn
                        command.Parameters.AddWithValue("@mahd", mahd);

                        // Tạo đối tượng SqlDataAdapter để lấy dữ liệu từ SQL Server vào DataTable
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            // Tạo DataTable để chứa dữ liệu lấy từ SQL Server
                            DataTable table = new DataTable();
                            adapter.Fill(table);

                            return table;
                        }
                    }
                }
            }
        }
        public DataTable nhaphang(string mahd)
        {
            // Chuỗi kết nối tới SQL Server
            //string connectionString = "Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // Chuỗi truy vấn SQL để lấy dữ liệu
                string query = "SELECT * from tb_nhaphanghoa1 WHERE mahd = @mahd ";

                // Tạo kết nối đến SQL Server
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Tạo đối tượng SqlCommand để thực hiện truy vấn
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thêm tham số @thang và @nam vào câu truy vấn
                        command.Parameters.AddWithValue("@mahd", mahd);

                        // Tạo đối tượng SqlDataAdapter để lấy dữ liệu từ SQL Server vào DataTable
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            // Tạo DataTable để chứa dữ liệu lấy từ SQL Server
                            DataTable table = new DataTable();
                            adapter.Fill(table);

                            return table;
                        }
                    }
                }
            }
        }

        public DataTable InHDmuahang1(string mahd)
        {
            // Chuỗi kết nối tới SQL Server
            //string connectionString = "Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // Chuỗi truy vấn SQL để lấy dữ liệu
                string query = "SELECT tb_hoadon.MAHD, tenkh, tennl,tenhang, soluong, dongia, tb_cthd.thanhtien FROM tb_hoadon, tb_cthd where tb_cthd.mahd =tb_hoadon.mahd and tb_cthd.mahd = @mahd";

                // Tạo kết nối đến SQL Server
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Tạo đối tượng SqlCommand để thực hiện truy vấn
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thêm tham số @thang và @nam vào câu truy vấn
                        command.Parameters.AddWithValue("@mahd", mahd);


                        // Tạo đối tượng SqlDataAdapter để lấy dữ liệu từ SQL Server vào DataTable
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            // Tạo DataTable để chứa dữ liệu lấy từ SQL Server
                            DataTable table = new DataTable();
                            adapter.Fill(table);

                            return table;
                        }
                    }
                }
            }
        }
        public DataTable InHDmuahang(string mahd)
        {
            // Chuỗi kết nối tới SQL Server
            //string connectionString = "Data Source = vutringoc; Initial Catalog = xmart; Integrated Security = True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // Chuỗi truy vấn SQL để lấy dữ liệu
                string query = "SELECT tb_hoadon.MAHD, tenkh, tennl,tenhang, soluong, dongia, tb_cthd.thanhtien, sodiemdoi, giamgia, tb_doidiem.thanhtien ,ngaylap FROM tb_hoadon, tb_cthd, tb_doidiem where tb_cthd.mahd =tb_hoadon.mahd and tb_hoadon.mahd = tb_doidiem.mahd and tb_cthd.mahd = @mahd";

                // Tạo kết nối đến SQL Server
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Tạo đối tượng SqlCommand để thực hiện truy vấn
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thêm tham số @thang và @nam vào câu truy vấn
                        command.Parameters.AddWithValue("@mahd", mahd);


                        // Tạo đối tượng SqlDataAdapter để lấy dữ liệu từ SQL Server vào DataTable
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            // Tạo DataTable để chứa dữ liệu lấy từ SQL Server
                            DataTable table = new DataTable();
                            adapter.Fill(table);

                            return table;
                        }
                    }
                }
            }
        }
    }
}
