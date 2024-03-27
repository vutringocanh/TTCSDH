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
    public class NhapHangHoaDAL
    {
        string connectionString = DatabaseConnection.GetConnectionString();
        public List<NhapHangHoa> GetAllNhapHangHoa()
        {
            List<NhapHangHoa> NhapHangHoas = new List<NhapHangHoa>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM tb_NhapHangHoa";
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    NhapHangHoa NhapHangHoa = new NhapHangHoa();
                    NhapHangHoa.mahang = reader["mahang"].ToString();
                    NhapHangHoa.tenhang = reader["tenhang"].ToString();
                    NhapHangHoa.soluong = Convert.ToInt32(reader["soluong"]);
                    NhapHangHoa.donvitinh = reader["donvitinh"].ToString();
                    NhapHangHoa.dongianhap = Convert.ToSingle(reader["dongianhap"]);
                    NhapHangHoa.dongiaban = Convert.ToSingle(reader["dongiaban"]);
                    NhapHangHoa.ngaynhap = reader["ngaynhap"].ToString();
                    NhapHangHoa.hansudung = reader["hansudung"].ToString();
                    NhapHangHoa.mancc = reader["mancc"].ToString();
                    NhapHangHoas.Add(NhapHangHoa);
                }
                reader.Close();
            }
            return NhapHangHoas;
        }
        public NhapHangHoa GetNhapHangHoaByTenNhapHangHoa(string tenhang)
        {
            NhapHangHoa NhapHangHoa = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM tb_NhapHangHoa WHERE tenhang=@tenhang";
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.AddWithValue("@tenhang", tenhang);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    NhapHangHoa = new NhapHangHoa();
                    NhapHangHoa.mahang = reader["mahang"].ToString();
                    NhapHangHoa.tenhang = reader["tenhang"].ToString();
                    NhapHangHoa.soluong = Convert.ToInt32(reader["soluong"]);
                    NhapHangHoa.donvitinh = reader["donvitinh"].ToString();
                    NhapHangHoa.dongianhap = Convert.ToSingle(reader["dongianhap"]);
                    NhapHangHoa.dongiaban = Convert.ToSingle(reader["dongiaban"]);
                    NhapHangHoa.ngaynhap = reader["ngaynhap"].ToString();
                    NhapHangHoa.hansudung = reader["hansudung"].ToString();
                    NhapHangHoa.mancc = reader["mancc"].ToString();
                }
                reader.Close();
            }
            return NhapHangHoa;
        }
        public bool AddNhapHangHoa(NhapHangHoa NhapHangHoa)
        {
            bool result = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "INSERT INTO tb_NhapHangHoa (mahang, tenhang, soluong, donvitinh,dongianhap, dongiaban, ngaynhap, hansudung,mancc ) VALUES (@mahang, @tenhang, @soluong, @donvitinh,@dongianhap,@dongiaban, @ngaynhap, @hansudung,@mancc)";
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.AddWithValue("@mahang", NhapHangHoa.mahang);
                command.Parameters.AddWithValue("@tenhang", NhapHangHoa.tenhang);
                command.Parameters.AddWithValue("@soluong", NhapHangHoa.soluong);
                command.Parameters.AddWithValue("@donvitinh", NhapHangHoa.donvitinh);
                command.Parameters.AddWithValue("@dongianhap", NhapHangHoa.dongianhap);
                command.Parameters.AddWithValue("@dongiaban", NhapHangHoa.dongiaban);
                command.Parameters.AddWithValue("@ngaynhap", NhapHangHoa.ngaynhap);
                command.Parameters.AddWithValue("@hansudung", NhapHangHoa.hansudung);
                command.Parameters.AddWithValue("@mancc", NhapHangHoa.mancc);
                
                connection.Open();
                int rows = command.ExecuteNonQuery();
                if (rows > 0)
                {
                    result = true;
                }
            }
            return result;
        }

        public bool UpdateNhapHangHoa(NhapHangHoa NhapHangHoa)
        {
            bool result = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "UPDATE tb_NhapHangHoa SET tenhang=@tenhang, soluong = @soluong, donvitinh = @donvitinh, dongianhap = @dongianhap, dongiaban = @dongiaban,ngaynhap = @ngaynhap , hansudung = @hansudung , mancc = @mancc  WHERE mahang=@mahang";
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.AddWithValue("@mahang", NhapHangHoa.mahang);
                command.Parameters.AddWithValue("@tenhang", NhapHangHoa.tenhang);
                command.Parameters.AddWithValue("@soluong", NhapHangHoa.soluong);
                command.Parameters.AddWithValue("@donvitinh", NhapHangHoa.donvitinh);
                command.Parameters.AddWithValue("@dongianhap", NhapHangHoa.dongianhap);
                command.Parameters.AddWithValue("@dongiaban", NhapHangHoa.dongiaban);
                command.Parameters.AddWithValue("@ngaynhap", NhapHangHoa.ngaynhap);
                command.Parameters.AddWithValue("@hansudung", NhapHangHoa.hansudung);
                command.Parameters.AddWithValue("@mancc", NhapHangHoa.mancc);
                connection.Open();
                int rows = command.ExecuteNonQuery();
                if (rows > 0)
                {
                    result = true;
                }
            }
            return result;
        }
        public bool DeleteNhapHangHoa(string mahang)
        {
            bool result = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "DELETE FROM tb_NhapHangHoa WHERE mahang=@mahang";
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.AddWithValue("@mahang", mahang);
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
