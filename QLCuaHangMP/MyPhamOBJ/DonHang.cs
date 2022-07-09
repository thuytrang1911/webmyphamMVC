using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPhamOBJ
{
    public class DonHang
    {
        public string MaDH { get; set; }
        public string MaKH { get; set; }
        public string DiaChiNhan { get; set; }
        public string TinhTrang { get; set; }
        public string GhiChu { get; set; }
        public DateTime NgayDat { get; set; }
        public int ThanhTien { get; set; }
        public string SDT { get; set; }
        public DonHang(string madh, string makh, string dc, string tihtrang, 
            string ghichu, DateTime ngaydat, int tt, string sdt)
        {
            this.MaDH = madh;
            this.MaKH = makh;
            this.DiaChiNhan = dc;
            this.TinhTrang = tihtrang;
            this.GhiChu = ghichu;
            this.NgayDat = ngaydat;
            this.ThanhTien = tt;
            this.SDT = sdt;
        }
        public DonHang() { }
    }
}
