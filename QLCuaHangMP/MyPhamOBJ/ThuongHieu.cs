using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPhamOBJ
{
    public class ThuongHieu
    {
        public string MaTH { get; set; }
        public string TenTH { get; set; }
        public ThuongHieu(string math, string tenth)
        {
            this.MaTH = math;
            this.TenTH = tenth;
        }
    }
}

