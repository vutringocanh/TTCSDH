using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DatabaseConnection
    {
        public static string GetConnectionString()
        {
            return @"Data Source=NGOC\SQLEXPRESS;Initial Catalog=xmart;Integrated Security=True";
        }

    }
}
