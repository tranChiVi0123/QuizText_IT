using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinHocDaiCuong.DTO
{
    class Admin
    {
        private string tenDangNhap = "admin";
        private string matKhau = "admin";

        public string TenDangNhap { get => tenDangNhap; set => tenDangNhap = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
    }
}
