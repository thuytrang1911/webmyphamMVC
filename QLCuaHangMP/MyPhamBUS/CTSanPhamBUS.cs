using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPhamDAO;
using MyPhamOBJ;

namespace MyPhamBUS
{
    public class CTSanPhamBUS
    {
        SanPhamDAO pd = new SanPhamDAO();
        public SanPham GetSanPham(string MaSP)
        {
            return pd.GetSanPham(MaSP);
        }
    }
}
