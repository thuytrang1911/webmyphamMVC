using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPhamOBJ;

namespace MyPhamDAO
{
    public class DonHangDAO
    {
        DataHelper dh = new DataHelper();
        public string ThemDonHang(DonHang donhang)
        {
            string st = "insert into DonHang values('" +
                donhang.MaDH + "','" +
                donhang.MaKH + "','" +
                donhang.DiaChiNhan + "','" +
                donhang.TinhTrang + "','" +
                donhang.GhiChu + "',getDate(),'" +
                donhang.ThanhTien + "','" +
                donhang.SDT + "')";
            return dh.ExcuteNonQuery(st);
        }
        public string AddOrder(DonHang or)
        {
            var sql = $"insert into DonHang values ('{or.MaDH}', '{or.MaKH}', N'{or.DiaChiNhan}', N'{or.TinhTrang}',getdate(), '{or.ThanhTien}', '{or.SDT}')";
            return dh.ExcuteNonQuery(sql); ;
        }
    }
}
