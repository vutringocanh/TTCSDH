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
    public class NhaCungCapDAL
    {
        //private string connectionString;
        string connectionString = DatabaseConnection.GetConnectionString();
        //public NhaCungCapDAL()
        //{
        //    connectionString = @"Data Source=vutringoc;Initial Catalog=xmart;Integrated Security=True";
        //}
        public List<NhaCungCap> GetAllNhaCungCap()
        {
            List<NhaCungCap> NhaCungCaps = new List<NhaCungCap>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM tb_nhacungcap";
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    NhaCungCap NhaCungCap = new NhaCungCap();
                    NhaCungCap.mancc = reader["mancc"].ToString();
                    NhaCungCap.tenncc = reader["tenncc"].ToString();
                    NhaCungCap.diachi = reader["diachi"].ToString();
                    NhaCungCap.sdt = reader["sdt"].ToString();
                    NhaCungCap.email = reader["email"].ToString();
                    NhaCungCap.ghichu = reader["ghichu"].ToString();
                    NhaCungCaps.Add(NhaCungCap);
                }
                reader.Close();
            }
            return NhaCungCaps;
        }
        public List<NhaCungCap> GetNhaCungCapByTenNhaCungCap(string tenncc)
        {
            List<NhaCungCap> nhaCungCaps = new List<NhaCungCap>();
            string query = "SELECT * FROM tb_nhacungcap WHERE tenncc LIKE @tenncc";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@tenncc", "" + tenncc + "");
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            NhaCungCap nhaCungCap = new NhaCungCap();
                            nhaCungCap.mancc = reader["mancc"].ToString();
                            nhaCungCap.tenncc = reader["tenncc"].ToString();
                            nhaCungCap.diachi = reader["diachi"].ToString();
                            nhaCungCap.sdt = reader["sdt"].ToString();
                            nhaCungCap.email = reader["email"].ToString();
                            nhaCungCap.ghichu = reader["ghichu"].ToString();
                            nhaCungCaps.Add(nhaCungCap);
                        }
                    }
                }
            }
            return nhaCungCaps;
        }
        public bool AddNhaCungCap(NhaCungCap NhaCungCap)
        {
            bool result = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "INSERT INTO tb_nhacungcap (mancc, tenncc, diachi, sdt, email, ghichu) VALUES (@mancc, @tenncc, @diachi, @sdt, @email, @ghichu )";
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.AddWithValue("@mancc", NhaCungCap.mancc);
                command.Parameters.AddWithValue("@tenncc", NhaCungCap.tenncc);
                command.Parameters.AddWithValue("@diachi", NhaCungCap.diachi);
                command.Parameters.AddWithValue("@sdt", NhaCungCap.sdt);
                command.Parameters.AddWithValue("@email", NhaCungCap.email);
                command.Parameters.AddWithValue("@ghichu", NhaCungCap.ghichu);
                connection.Open();
                int rows = command.ExecuteNonQuery();
                if (rows > 0)
                {
                    result = true;
                }
            }
            return result;
        }

        public bool UpdateNhaCungCap(NhaCungCap NhaCungCap)
        {
            bool result = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "UPDATE tb_nhacungcap SET tenncc=@tenncc, diachi = @diachi, sdt = @sdt, email = @email, ghichu = @ghichu  WHERE mancc=@mancc";
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.AddWithValue("@mancc", NhaCungCap.mancc);
                command.Parameters.AddWithValue("@tenncc", NhaCungCap.tenncc);
                command.Parameters.AddWithValue("@diachi", NhaCungCap.diachi);
                command.Parameters.AddWithValue("@sdt", NhaCungCap.sdt);
                command.Parameters.AddWithValue("@email", NhaCungCap.email);
                command.Parameters.AddWithValue("@ghichu", NhaCungCap.ghichu);
                connection.Open();
                int rows = command.ExecuteNonQuery();
                if (rows > 0)
                {
                    result = true;
                }
            }
            return result;
        }
        public bool DeleteNhaCungCap(string mancc)
        {
            bool result = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "DELETE FROM tb_nhacungcap WHERE mancc=@mancc";
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.AddWithValue("@mancc", mancc);
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
