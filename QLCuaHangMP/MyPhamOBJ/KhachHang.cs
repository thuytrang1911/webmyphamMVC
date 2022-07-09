using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPhamOBJ
{
    public class KhachHang
    {
        public string MaKH { get; set; }
        public string TenKH { get; set; }
        public string SdtKH { get; set; }
        public string DiaChi { get; set; }
        public string MatKhau { get; set; }
        public KhachHang(string makh,string tenkh,string sdt,string dc,string mk)
        {
            this.MaKH = makh;
            this.TenKH = tenkh;
            this.SdtKH = sdt;
            this.DiaChi = dc;
            this.MatKhau = mk;
        }
        public KhachHang() { }
    }
}
