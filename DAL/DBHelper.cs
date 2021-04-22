using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV_3LAYER.DAL
{
    class DBHelper
    {
        private static DBHelper _Instance;
        private SqlConnection cnn;
        public static DBHelper Instance
        {
            get
            {
                if (_Instance == null)
                {
                    string s = @"Data Source=LAPTOP-J9EC1DVO\SQLEXPRESS;Initial Catalog=QUANLYSINHVIEN;Integrated Security=True";
                    _Instance = new DBHelper(s);
                }
                return _Instance;
            }
            private set { }
        }
        private DBHelper(string s)
        {
            cnn = new SqlConnection(s);
        }
        public DataTable GetRecords(string sql)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
            DataSet ds = new DataSet();
            cnn.Open();
            da.Fill(dt);
            cnn.Close();
            return dt;
        }
        public void ExecuteDB(string sql)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(sql, cnn);
                cnn.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                //de chac chan la cnn se duoc close sau khi duoc Open
                cnn.Close();
            }
        }
    }
}
