using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Application
{
    public static class DBUtility
    {
        /// <summary>
        /// 获取MySql数据库的连接
        /// </summary>
        /// <param name="open"></param>
        /// <param name="convertZeroDatetime"></param>
        /// <param name="allowZeroDatetime"></param>
        /// <returns></returns>
        public static MySqlConnection GetMySqlConnection(bool open = true, bool convertZeroDatetime = false, bool allowZeroDatetime = false)
        {
            string cs = ConfigurationManager.ConnectionStrings["Default"].ToString();
            var csb = new MySqlConnectionStringBuilder(cs);
            csb.AllowZeroDateTime = allowZeroDatetime;
            csb.ConvertZeroDateTime = convertZeroDatetime;
            var conn = new MySqlConnection(csb.ConnectionString);
            if (open) conn.Open();
            return conn;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="querySql">查询SQL语句</param>
        /// <param name="sorting">排序</param>
        /// <param name="skipCount">跳跃的个数</param>
        /// <param name="maxResultCount">返回的个数</param>
        /// <returns></returns>
        public static string GetPagedAndSortedSql(string querySql, string sorting, int skipCount, int maxResultCount)
        {
            return string.Format("{0} ORDER BY {1} LIMIT {2},{3}", querySql, sorting, skipCount, maxResultCount);
        }


        /// <summary>
        /// 获取计算总数的SQL语句
        /// </summary>
        /// <param name="querySql">查询sql语句</param>
        /// <returns></returns>
        public static string GetCountSql(string querySql)
        {
            return string.Format("select count(1) from ({0})T", querySql);
        }
    }
}
