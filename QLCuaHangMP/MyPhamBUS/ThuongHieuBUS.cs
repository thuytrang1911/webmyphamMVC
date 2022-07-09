using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPhamDAO;
using MyPhamOBJ;

namespace MyPhamBUS
{
    public class ThuongHieuBUS
    {
        ThuongHieuDAO lth = new ThuongHieuDAO();
        public List<ThuongHieu> GetThuongHieu()
        {
            return lth.GetThuongHieu();
        }
    }
}
