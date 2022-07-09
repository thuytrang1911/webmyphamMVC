using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MyPhamOBJ;

namespace MyPhamDAO
{
    public class ThuongHieuDAO
    {
        DataHelper dh = new DataHelper();
        public List<ThuongHieu> GetThuongHieu()
        {
            DataTable dt = dh.GetDataTable("select * from ThươngHieu");
            List<ThuongHieu> List_th = new List<ThuongHieu>();
            foreach (DataRow r in dt.Rows)
            {
                ThuongHieu th = new ThuongHieu(r[0].ToString(), r[1].ToString());
                List_th.Add(th);
            }
            return List_th;
        }
        public List<ThuongHieu> ToList(DataTable dt)
        {
            List<ThuongHieu> t = new List<ThuongHieu>();
            foreach (DataRow dr in dt.Rows)
            {
                ThuongHieu s = new ThuongHieu(dr[0].ToString(), dr[1].ToString());
                t.Add(s);

            }
            return t;
        }
    }
}
