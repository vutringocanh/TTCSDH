using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;
using System.Data.SqlClient;

namespace DAL
{
    public class XuatHangHoaDAL
    {
        string connectionString = DatabaseConnection.GetConnectionString();
        public List<XuatHangHoa> GetAllXuatHangHoa()
        {
            List<XuatHangHoa> XuatHangHoas = new List<XuatHangHoa>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM tb_XuatHangHoa";
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    XuatHangHoa XuatHangHoa = new XuatHangHoa();
                    XuatHangHoa.mahd = reader["mahd"].ToString();
                    XuatHangHoa.manv = reader["manv"].ToString();
                    XuatHangHoa.mahang = reader["mahang"].ToString();
                    XuatHangHoa.tenhang = reader["tenhang"].ToString();
                    XuatHangHoa.soluong = Convert.ToInt32(reader["soluong"]);
                    XuatHangHoa.donvitinh = reader["donvitinh"].ToString();
                    XuatHangHoa.dongianhap = Convert.ToSingle(reader["dongianhap"]);
                    XuatHangHoa.ngayxuat = reader["ngayxuat"].ToString();
                    XuatHangHoa.mancc = reader["mancc"].ToString();
                    XuatHangHoa.ghichu = reader["ghichu"].ToString();

                    XuatHangHoas.Add(XuatHangHoa);
                }
                reader.Close();
            }
            return XuatHangHoas;
        }
        public XuatHangHoa GetXuatHangHoaByTenXuatHangHoa(string mahd)
        {
            XuatHangHoa XuatHangHoa = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM tb_XuatHangHoa WHERE mahd=@mahd";
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.AddWithValue("@mahd", mahd);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    XuatHangHoa  = new XuatHangHoa();
                    XuatHangHoa.mahang = reader["mahang"].ToString();
                    XuatHangHoa.tenhang = reader["tenhang"].ToString();
                    XuatHangHoa.soluong = Convert.ToInt32(reader["soluong"]);
                    XuatHangHoa.donvitinh = reader["donvitinh"].ToString();
                    XuatHangHoa.dongianhap = Convert.ToSingle(reader["dongianhap"]);
                    XuatHangHoa.ngayxuat = reader["ngayxuat"].ToString();
                    XuatHangHoa.mancc = reader["mancc"].ToString();
                    XuatHangHoa.ghichu = reader["ghichu"].ToString();
                    XuatHangHoa.mahd = reader["mahd"].ToString();
                    XuatHangHoa.manv = reader["manv"].ToString();
                }
                reader.Close();
            }
            return XuatHangHoa;
        }

        public bool AddXuatHangHoa1(XuatHangHoa XuatHangHoa, Action<string> onError)
        {
            bool result = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Lấy giá trị soluong trong bảng NhapHangHoa dựa trên giá trị mahang của sản phẩm trong bảng XuatHangHoa
                string selectQuery1 = "SELECT soluong FROM tb_NhapHangHoa WHERE mahang = @mahang";
                SqlCommand selectCommand1 = new SqlCommand(selectQuery1, connection);
                selectCommand1.Parameters.AddWithValue("@mahang", XuatHangHoa.mahang);
                connection.Open();
                SqlDataReader reader1 = selectCommand1.ExecuteReader();
                int soluongNhap = 0;
                if (reader1.Read())
                {
                    soluongNhap = (int)reader1["soluong"];
                }
                reader1.Close();

                // Kiểm tra nếu số lượng xuất lớn hơn số lượng nhập thì báo lỗi
                if (XuatHangHoa.soluong > soluongNhap)
                {
                    onError("Số lượng hàng hóa xuất vượt quá số lượng hàng hóa nhập!");
                    return result;
                }

                // Xử lý thêm sản phẩm vào cơ sở dữ liệu và cập nhật số lượng
                // ...
                string sqlQuery = "INSERT INTO tb_XuatHangHoa (mahd, mahang, tenhang, soluong, donvitinh,dongianhap, ngayxuat,mancc, ghichu, manv ) VALUES (@mahd, @mahang,@tenhang,@soluong,@donvitinh,@dongianhap,@ngayxuat,@mancc,@ghichu, @manv)";
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.AddWithValue("@mahd", XuatHangHoa.mahd);
                command.Parameters.AddWithValue("@mahang", XuatHangHoa.mahang);
                command.Parameters.AddWithValue("@tenhang", XuatHangHoa.tenhang);
                command.Parameters.AddWithValue("@soluong", XuatHangHoa.soluong);
                command.Parameters.AddWithValue("@donvitinh", XuatHangHoa.donvitinh);
                command.Parameters.AddWithValue("@dongianhap", XuatHangHoa.dongianhap);
                command.Parameters.AddWithValue("@ngayxuat", XuatHangHoa.ngayxuat);
                command.Parameters.AddWithValue("@mancc", XuatHangHoa.mancc);
                command.Parameters.AddWithValue("@ghichu", XuatHangHoa.ghichu);
                command.Parameters.AddWithValue("@manv", XuatHangHoa.manv);
                connection.Open();
                int rows = command.ExecuteNonQuery();
                if (rows > 0)
                {
                    // Lấy thông tin sản phẩm cần cập nhật số lượng
                    string selectQuery = "SELECT soluong FROM tb_NhapHangHoa WHERE mahang = @mahang";
                    SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
                    selectCommand.Parameters.AddWithValue("@mahang", XuatHangHoa.mahang);
                    SqlDataReader reader = selectCommand.ExecuteReader();
                    int soluong = 0;
                    if (reader.Read())
                    {
                        soluong = (int)reader["soluong"];
                    }
                    reader.Close();

                    // Tính toán số lượng mới của sản phẩm
                    int soluongMoi = soluong - XuatHangHoa.soluong;

                    // Cập nhật số lượng mới vào bảng "nhaphoadon"
                    string updateQuery = "UPDATE tb_NhapHangHoa SET soluong = @soluong WHERE mahang = @mahang";
                    SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                    updateCommand.Parameters.AddWithValue("@mahang", XuatHangHoa.mahang);
                    updateCommand.Parameters.AddWithValue("@soluong", soluongMoi);
                    int updatedRows = updateCommand.ExecuteNonQuery();
                    if (updatedRows > 0)
                    {
                        // Cập nhật số lượng hàng hóa thành công
                        result = true;
                    }
                }

            }
            return result;
        }

        public bool AddXuatHangHoa(XuatHangHoa XuatHangHoa)
        {

            bool result = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "INSERT INTO tb_XuatHangHoa (mahd, mahang, tenhang, soluong, donvitinh,dongianhap, ngayxuat,mancc, ghichu, manv ) VALUES (@mahd, @mahang,@tenhang,@soluong,@donvitinh,@dongianhap,@ngayxuat,@mancc,@ghichu, @manv)";
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.AddWithValue("@mahd", XuatHangHoa.mahd);
                command.Parameters.AddWithValue("@mahang", XuatHangHoa.mahang);
                command.Parameters.AddWithValue("@tenhang", XuatHangHoa.tenhang);
                command.Parameters.AddWithValue("@soluong", XuatHangHoa.soluong);
                command.Parameters.AddWithValue("@donvitinh", XuatHangHoa.donvitinh);
                command.Parameters.AddWithValue("@dongianhap", XuatHangHoa.dongianhap);
                command.Parameters.AddWithValue("@ngayxuat", XuatHangHoa.ngayxuat);
                command.Parameters.AddWithValue("@mancc", XuatHangHoa.mancc);
                command.Parameters.AddWithValue("@ghichu", XuatHangHoa.ghichu);
                command.Parameters.AddWithValue("@manv", XuatHangHoa.manv);
                connection.Open();
                int rows = command.ExecuteNonQuery();
                if (rows > 0)
                {
                    // Lấy thông tin sản phẩm cần cập nhật số lượng
                    string selectQuery = "SELECT soluong FROM tb_NhapHangHoa WHERE mahang = @mahang";
                    SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
                    selectCommand.Parameters.AddWithValue("@mahang", XuatHangHoa.mahang);
                    SqlDataReader reader = selectCommand.ExecuteReader();
                    int soluong = 0;
                    if (reader.Read())
                    {
                        soluong = (int)reader["soluong"];
                    }
                    reader.Close();

                    // Tính toán số lượng mới của sản phẩm
                    int soluongMoi = soluong - XuatHangHoa.soluong;

                    // Cập nhật số lượng mới vào bảng "nhaphoadon"
                    string updateQuery = "UPDATE tb_NhapHangHoa SET soluong = @soluong WHERE mahang = @mahang";
                    SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                    updateCommand.Parameters.AddWithValue("@mahang", XuatHangHoa.mahang);
                    updateCommand.Parameters.AddWithValue("@soluong", soluongMoi);
                    int updatedRows = updateCommand.ExecuteNonQuery();
                    if (updatedRows > 0)
                    {
                        // Cập nhật số lượng hàng hóa thành công
                        result = true;
                    }
                }
            }
            return result;
        }



        public bool UpdateXuatHangHoa(XuatHangHoa XuatHangHoa){
            bool result = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "UPDATE tb_XuatHangHoa SET tenhang=@tenhang, soluong = @soluong, donvitinh = @donvitinh, dongianhap = @dongianhap,ngayxuat = @ngayxuat ,ghichu = @ghichu ,  mahang=@mahang, manv = @manv   WHERE mahd = @mahd";
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.AddWithValue("@mahang", XuatHangHoa.mahang);
                command.Parameters.AddWithValue("@tenhang", XuatHangHoa.tenhang);
                command.Parameters.AddWithValue("@soluong", XuatHangHoa.soluong);
                command.Parameters.AddWithValue("@donvitinh", XuatHangHoa.donvitinh);
                command.Parameters.AddWithValue("@dongianhap", XuatHangHoa.dongianhap);
                command.Parameters.AddWithValue("@ngayxuat", XuatHangHoa.ngayxuat);
                command.Parameters.AddWithValue("@mancc", XuatHangHoa.mancc);
                command.Parameters.AddWithValue("@ghichu", XuatHangHoa.ghichu);
                command.Parameters.AddWithValue("@manv", XuatHangHoa.manv);
                command.Parameters.AddWithValue("@mahd", XuatHangHoa.mahd);
                connection.Open();
                int rows = command.ExecuteNonQuery();
                if (rows > 0)
                {
                    result = true;
                }
            }
            return result;
        }
        public bool DeleteXuatHangHoa(string mahd)
        {
            bool result = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "DELETE FROM tb_XuatHangHoa WHERE mahd=@mahd";
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.AddWithValue("@mahd", mahd);
                connection.Open();
                int rows = command.ExecuteNonQuery();
                if (rows > 0)
                {
                    result = true;
                }
            }
            return result;
        }

    }
}
