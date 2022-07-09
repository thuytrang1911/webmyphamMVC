using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPhamOBJ;
using MyPhamDAO;
namespace MyPhamBUS
{
    public class NhaCungCapBUS
    {
        NhaCungCapDAO ccd = new NhaCungCapDAO();
        public List<NhaCungCap> GetNhaCungCaps()
        {
            return ccd.GetNhaCungCaps();
        }
        public string ThemNCC(NhaCungCap ncc)
        {
            return ccd.ThemNCC(ncc);
        }
        public string SuaNCC(NhaCungCap ncc)
        {
            return ccd.SuaNCC(ncc);
        }
        public string XoaNCC(string mancc)
        {
            return ccd.XoaNCC(mancc);
        }
    }
}
