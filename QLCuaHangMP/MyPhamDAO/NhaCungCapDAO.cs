using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MyPhamOBJ;

namespace MyPhamDAO
{
    public class NhaCungCapDAO
    {
        DataHelper dh = new DataHelper();
        public List<NhaCungCap>ToList(DataTable dt)
        {
            List<NhaCungCap> l = new List<NhaCungCap>();
            foreach(DataRow dr in dt.Rows)
            {
                NhaCungCap n = new NhaCungCap(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString());
                l.Add(n);
            }
            return l;
        }
        public List<NhaCungCap> GetNhaCungCaps()
        {
            DataTable dt = dh.GetDataTable("Select*from NhaCungCap");
            dh.Close();
            return ToList(dt);
        }
        public string ThemNCC(NhaCungCap ncc)
        {
            string n = "insert into NhaCungCap values('" +
                ncc.MaNCC + "','" +
                ncc.TenNCC + "','" +
                ncc.DiaChi + "','" +
                ncc.SDT + "')";
            return dh.ExcuteNonQuery(n);
        }
        public string XoaNCC(string mancc)
        {
            string n = "delete from NhaCungCap where MaNCC='" + mancc + "'";
            string s = dh.ExcuteNonQuery(n);
            dh.Close();
            return s;
        }
        public string SuaNCC(NhaCungCap ncc)
        {
            string n = "update NhaCungCap set" +
                "TenNCC='" + ncc.TenNCC + "'," +
                "DiaChi='" + ncc.DiaChi + "'" +
                "SDT='" + ncc.SDT + "'" + 
                "where MaNCC='" + ncc.MaNCC + "'";
            return dh.ExcuteNonQuery(n);
        }
    }
}
