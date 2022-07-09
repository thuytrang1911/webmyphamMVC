using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPhamOBJ
{
    public class DongSP
    {
        public string MaDong { get; set; }
        public string TenDong { get; set; }
        //public string MaTH { get; set; }
        public DongSP(string madong, string tendong/*, string math*/)
        {
            this.MaDong = madong;
            this.TenDong = tendong;
            //this.MaTH = math;

        }
    }
}
