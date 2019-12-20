using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinHocDaiCuong.DAL;
using TinHocDaiCuong.DTO;

namespace TinHocDaiCuong.BLL
{
    
    public class SV_BLL
    {
        public SV_DAL dal { get; set; }

        public SV_BLL()
        {
            this.dal = new SV_DAL();
        }
        public int checkSV_BLL(SV s)
        {
            return dal.checkSV_DAL(s);
        }

        public SV getSV_BLL (string s)
        {
            return dal.getSV_DAL(s);
        }
        public SV GetSVbyName_BLL(string s)
        {
            return dal.GetSVbyName_DAL(s);
        }
    }
}
