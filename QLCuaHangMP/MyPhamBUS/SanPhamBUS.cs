using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPhamDAO;
using MyPhamOBJ;

namespace MyPhamBUS
{
    public class SanPhamBUS
    {
        SanPhamDAO pd = new SanPhamDAO();
        public List<SanPham> GetSanPham()
        {
            return pd.GetSanPham();
        }
        public List<SanPham> GetSanPhamDong(string MaDongSP)
        {
            return pd.GetSanPhamDong(MaDongSP);
        }
        public List<SanPham> GetSanPhamTH(string MaTH)
        {
            return pd.GetSanPhamTH(MaTH);
        }

        public SanPhamList GetSanPhamPT(int pageIndex, int pagesize, string productname, string madong)
        {
            return pd.GetSanPham(pageIndex, pagesize, productname, madong);
        }

        public List<SanPham> GetSPBanChay()
        {
            return pd.LaySPBanChay();
        }

        public string AddProduct(SanPham s)
        {
            s.TenSP = s.TenSP.Trim();
            return pd.AddProduct(s);
        }
        public string EditProduct(SanPham s)
        {
            return pd.EditProduct(s);
        }
        public string DeleteProduct(string id)
        {
            return pd.DeleteProduct(id);
        }
    }
}
