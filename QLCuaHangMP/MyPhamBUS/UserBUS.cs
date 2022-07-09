using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPhamDAO;
using MyPhamOBJ;

namespace MyPhamBUS
{
    public class UserBUS
    {
        UserDAO ud = new UserDAO();
        KhachHangDAO kd = new KhachHangDAO();
        public UserOBJ CheckLogin(string manv, string pw)
        {
            return ud.GetUser(manv, pw);
        }
        public KhachHang CheckKhachHang(string makh, string pw)
        {
            return kd.GetKhachHang(makh, pw);
        }
        public KhachHang ReadCustomer()
        {
            return kd.ReadCustomer();
        }
        public List<KhachHang> GetKhachHang()
        {
            return kd.GetKhachHang();
        }
        public string AddKhachHang(KhachHang khachhang)

        {
            string mkh = Guid.NewGuid().ToString();
            khachhang.MaKH = mkh;
            return kd.AddKhachHang(khachhang);
        }
    }
}
