using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPhamOBJ
{
    public class NhaCungCap
    {
        public string MaNCC { get; set; }
        public string TenNCC { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public NhaCungCap(string mancc,string tenncc, string dc,string sdt)
        {
            this.MaNCC = mancc;
            this.TenNCC = tenncc;
            this.DiaChi = dc;
            this.SDT = sdt;
        }
        public NhaCungCap() { }
    }
}
