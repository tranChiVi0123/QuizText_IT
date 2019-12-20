using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinHocDaiCuong.DAL
{
    public class DataHelper
    {
        public SqlConnection cnn { get; set; }

        public DataHelper(string s)
        {
            this.cnn = new SqlConnection();
            cnn.ConnectionString = s;

        }

        public DataTable getTable(string que)
        {
            SqlDataAdapter ad = new SqlDataAdapter(que, this.cnn);
            DataTable dt = new DataTable();
            this.cnn.Open();
            ad.Fill(dt);
            this.cnn.Close();
            return dt;
        }

        public void ExcuteNonQuery(string que)
        {
            SqlCommand cmd = new SqlCommand(que, this.cnn);
            this.cnn.Open();
            cmd.ExecuteNonQuery();
            this.cnn.Close();
        }

        public int ExecuteScalar(string que)
        {
            SqlCommand cmd = new SqlCommand(que, this.cnn);
            this.cnn.Open();
            int a = (int)cmd.ExecuteScalar();
            this.cnn.Close();
            return a;
        }


    }
}
