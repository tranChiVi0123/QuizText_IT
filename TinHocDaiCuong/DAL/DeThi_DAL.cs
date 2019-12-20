using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using TinHocDaiCuong.DTO;


namespace TinHocDaiCuong.DAL
{
    public class DeThi_DAL
    {
        public DataHelper dh { get; set; }

        public DeThi_DAL()
        {
            this.dh = new DataHelper("Data Source=DESKTOP-8A7T99L;Initial Catalog=CuoiKi;Integrated Security=True");
        }

        public DataTable Get_DeThi()
        {
            int Ma_DT=0;
            Random random = new Random();
            int count = random.Next(1, 2);
            switch (count)
            {
                case 1: Ma_DT = 111;
                    break;
                case 2: Ma_DT = 222;
                    break;
                
            }
            string query = "layDeThi @maDT = "+Ma_DT.ToString();
            DataTable dt = dh.getTable(query);
            return dt;
        }
        
        public void Luu_diem_DAL(String mssv,float diem)
        {
            string query = "UPDATE SV SET Điểm = "+diem+" WHERE MSSV = '"+mssv+"' ";
            dh.ExcuteNonQuery(query);
        }

        public DataTable GetAllDeThi_DAL()
        {
            string query = "GetAllDeThi";
            DataTable dt = dh.getTable(query);
            return dt;
        }
        
    }
}
