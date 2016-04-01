using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Application
{
    public static class MySqlHelper
    {
        private static MySqlConnection GetConnection(bool open = true,
            bool convertZeroDatetime = false, bool allowZeroDatetime = false)
        {
            string cs = ConfigurationManager.ConnectionStrings["Default"].ToString();
            var csb = new MySqlConnectionStringBuilder(cs);
            csb.AllowZeroDateTime = allowZeroDatetime;
            csb.ConvertZeroDateTime = convertZeroDatetime;
            var conn = new MySqlConnection(csb.ConnectionString);
            if (open) conn.Open();
            return conn;
        }
    }
}
