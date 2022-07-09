using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using MyPhamOBJ;

namespace MyPhamDAO
{
    public class DongSPDAO
    {
        DataHelper dh = new DataHelper();
        public List<DongSP> GetDongSP()
        {
            DataTable dt = dh.GetDataTable("select * from DongSP");
            List<DongSP> List_dong = new List<DongSP>();
            foreach (DataRow r in dt.Rows)
            {
                DongSP fd = new DongSP(r[0].ToString(), r[1].ToString()/*, r[2].ToString()*/);
                List_dong.Add(fd);
            }
            return List_dong;
        }
        public List<DongSP> ToList(DataTable dt)
        {
            List<DongSP> l = new List<DongSP>();
            foreach (DataRow dr in dt.Rows)
            {
                DongSP s = new DongSP(dr[0].ToString(), dr[1].ToString()/*, dr[2].ToString()*/);
                l.Add(s);

            }
            return l;
        }
        public string ThemDongSP(DongSP dong)
        {
            string d = "insert into DongSP values('" +
                dong.MaDong + "','" +
                dong.TenDong + "')";
                
            return dh.ExcuteNonQuery(d);
        }
        public string XoaDongSP(string madong)
        {
            string d = "delete from DongSP where MaDong='" + madong + "'";
            string s = dh.ExcuteNonQuery(d);
            dh.Close();
            return s;
        }
        public string SuaDongSP(DongSP dong)
        {
            string d = "update DongSP set" +
                "TenDong='" + dong.TenDong + "'," +
                "where MaDong='" + dong.MaDong + "'";
            return dh.ExcuteNonQuery(d);
        }
    }
}
