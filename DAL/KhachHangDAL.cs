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
    public class KhachHangDAL
    {
        string connectionString = DatabaseConnection.GetConnectionString();
        public List<KhachHang> GetAllKhachHang()
        {
            List<KhachHang> KhachHangs = new List<KhachHang>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM tb_KhachHang";
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    KhachHang KhachHang = new KhachHang();
                    KhachHang.makh = reader["makh"].ToString();
                    KhachHang.tenkh = reader["tenkh"].ToString();
                    KhachHang.diachi = reader["diachi"].ToString();
                    KhachHang.namsinh = reader["namsinh"].ToString();
                    KhachHang.sdt = reader["sdt"].ToString();
                    KhachHang.gioitinh = reader["gioitinh"].ToString();
                    KhachHang.diem = Convert.ToInt32(reader["diem"]);
                    KhachHang.email = reader["email"].ToString();
                    KhachHangs.Add(KhachHang);
                }
                reader.Close();
            }
            return KhachHangs;
        }
        public List<KhachHang> GetKhachHangByTenKhachHang(string tenkh)
        {
            List<KhachHang> khachhangs = new List<KhachHang>();
            string query = "SELECT * FROM tb_khachhang WHERE tenkh LIKE @tenkh";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@tenkh", "" + tenkh + "");
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            KhachHang KhachHang = new KhachHang();
                            KhachHang.makh = reader["makh"].ToString();
                            KhachHang.tenkh = reader["tenkh"].ToString();
                            KhachHang.diachi = reader["diachi"].ToString();
                            KhachHang.sdt = reader["sdt"].ToString();
                            KhachHang.email = reader["email"].ToString();
                            KhachHang.namsinh = reader["namsinh"].ToString();
                            KhachHang.diem = Convert.ToInt32(reader["diem"]);
                            KhachHang.gioitinh = reader["gioitinh"].ToString();
                            khachhangs.Add(KhachHang);
                        }
                    }
                }
            }
            return khachhangs;

        }
        public bool AddKhachHang(KhachHang KhachHang)
        {
            bool result = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "INSERT INTO tb_KhachHang (makh, tenkh,gioitinh,namsinh, diachi, sdt, email, diem) VALUES (@makh, @tenkh, @gioitinh, @namsinh, @diachi, @sdt, @email, @diem )";
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.AddWithValue("@makh", KhachHang.makh);
                command.Parameters.AddWithValue("@tenkh", KhachHang.tenkh);
                command.Parameters.AddWithValue("@gioitinh", KhachHang.gioitinh);
                command.Parameters.AddWithValue("@namsinh", KhachHang.namsinh);
                command.Parameters.AddWithValue("@diachi", KhachHang.diachi);
                command.Parameters.AddWithValue("@sdt", KhachHang.sdt);
                command.Parameters.AddWithValue("@email", KhachHang.email);
                command.Parameters.AddWithValue("@diem", KhachHang.diem);
                connection.Open();
                int rows = command.ExecuteNonQuery();



                //chen them cau lenh update thì lam như thế này
                //int rows2 = command1.ExecuteNonQuery();
                if (rows > 0  /* and rows2*/)
                {
                    result = true;
                }
            }
            return result;
        }

        public bool UpdateKhachHang(KhachHang KhachHang)
        {
            bool result = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "UPDATE tb_KhachHang SET tenkh=@tenkh,gioitinh = @gioitinh, namsinh = @namsinh,  diachi = @diachi, sdt = @sdt, email = @email, diem = @diem  WHERE makh=@makh";
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.AddWithValue("@makh", KhachHang.makh);
                command.Parameters.AddWithValue("@tenkh", KhachHang.tenkh);
                command.Parameters.AddWithValue("@diachi", KhachHang.diachi);
                command.Parameters.AddWithValue("@sdt", KhachHang.sdt);
                command.Parameters.AddWithValue("@email", KhachHang.email);
                command.Parameters.AddWithValue("@namsinh", KhachHang.namsinh);
                command.Parameters.AddWithValue("@gioitinh", KhachHang.gioitinh);
                command.Parameters.AddWithValue("@diem", KhachHang.diem);
                connection.Open();
                int rows = command.ExecuteNonQuery();
                if (rows > 0)
                {
                    result = true;
                }
            }
            return result;
        }
        public bool DeleteKhachHang(string makh)
        {
            bool result = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "DELETE FROM tb_KhachHang WHERE makh=@makh";
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.AddWithValue("@makh", makh);
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
