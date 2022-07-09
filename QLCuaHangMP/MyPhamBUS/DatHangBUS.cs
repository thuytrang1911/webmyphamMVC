using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPhamDAO;
using MyPhamOBJ;

namespace MyPhamBUS
{
    public class DatHangBUS
    {
        public void DatHang(KhachHang k,DonHang d, List<CTDonHang> lct)
        {
            //tạo mã đơn hàng
            string mdh = Guid.NewGuid().ToString();
            d.MaDH = mdh;
            //gán mã đơn hàng cho chi tiết đơn hàng
            for(int i = 0; i < lct.Count; i++)
            {
                lct[i].MaDH = mdh;
            }
            DonHangDAO dd = new DonHangDAO();
            CTDonHangDAO dct = new CTDonHangDAO();
            dd.ThemDonHang(d);
            dct.LuuChiTietDH(lct);
            //dd.AddOrder(d);
            //dct.SaveDetailOrdered(lct);
        }
        KhachHangDAO kh = new KhachHangDAO();
        public KhachHang GetKhachHang(string makh,string pw)
        {
            return kh.GetKhachHang(makh, pw);
        }
    }
}
