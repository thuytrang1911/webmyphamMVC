using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPhamOBJ;

namespace MyPhamDAO
{
    public class CTDonHangDAO
    {
        DataHelper dh = new DataHelper();
        public void LuuChiTietDH(List<CTDonHang>lct)
        {
            for(int i = 0; i < lct.Count; i++)
            {
                string st = "insert into CTDonHang values('" +
                    lct[i].MaDH + "','" +
                    lct[i].MaSP + "','" +
                    lct[i].SoLuong + "','" +
                    lct[i].DonGia + "')";
                dh.ExcuteNonQuery(st);
            }
        }
        public void SaveDetailOrdered(List<CTDonHang> lct)
        {
            for (int i = 0; i < lct.Count; i++)
            {
                var sql = $"insert into CTDonHang values ('{lct[i].MaDH}','{lct[i].MaSP}', N'{lct[i].SoLuong}', '{lct[i].DonGia}')";
                dh.ExcuteNonQuery(sql);
            }
        }
    }
}
