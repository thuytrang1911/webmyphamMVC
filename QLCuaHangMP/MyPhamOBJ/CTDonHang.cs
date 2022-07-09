using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPhamOBJ
{
    public class CTDonHang
    {
        public string MaDH { get; set; }
        public string MaSP { get; set; }
        public int SoLuong { get; set; }
        public int DonGia { get; set; }
        public CTDonHang(string madh, string masp, int sl, int gia)
        {
            this.MaDH = madh;
            this.MaSP = masp;
            this.SoLuong = sl;
            this.DonGia = gia;
        }
        public CTDonHang() { }
    }
}
