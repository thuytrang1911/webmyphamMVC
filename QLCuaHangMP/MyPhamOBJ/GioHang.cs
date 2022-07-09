using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPhamOBJ
{
    /// <summary>
    /// Model Giỏ hàng
    /// </summary>
    public class GioHang
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public string Anh { get; set; }
        public int SoLuong { get; set; }
        public int Gia { get; set; }
        public int ThanhTien { get; set; }
        public GioHang(string masp,string tensp, string anh,int sl,int gia,int tongtien)
        {
            this.MaSP = masp;
            this.TenSP = tensp;
            this.Anh = anh;
            this.SoLuong = sl;
            this.Gia = gia;
            this.ThanhTien = tongtien;
        }
        public GioHang() { }
    }
}
