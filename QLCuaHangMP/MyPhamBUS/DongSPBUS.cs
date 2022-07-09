using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPhamDAO;
using MyPhamOBJ;

namespace MyPhamBUS
{
    public class DongSPBUS
    {
        DongSPDAO ldb = new DongSPDAO();
        public List<DongSP> GetDongSP()
        {
            return ldb.GetDongSP();
        }
        public string ThemDongSP(DongSP dong)
        {
            return ldb.ThemDongSP(dong);
        }
        public string SuaDongSP(DongSP dong)
        {
            return ldb.SuaDongSP(dong);
        }
        public string XoaDongSP(string madong)
        {
            return ldb.XoaDongSP(madong);
        }
    }
}
