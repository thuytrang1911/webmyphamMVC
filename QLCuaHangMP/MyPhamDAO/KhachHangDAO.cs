using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MyPhamOBJ;

namespace MyPhamDAO
{
    public class KhachHangDAO
    {
        DataHelper dh = new DataHelper();
        public KhachHang GetKhachHang(string us, string pas)
        {
            string sql = "select*from KhachHang where (TenKH=N'" + us + "')and(MatKhau='" + pas + "')";
            DataTable dt = dh.GetDataTable(sql);
          
            if (dt.Rows.Count <= 0)
                return null;
            else
            {
                KhachHang k = new KhachHang(
                        dt.Rows[0][0].ToString(),
                        dt.Rows[0][1].ToString(),
                        dt.Rows[0][2].ToString(),
                        dt.Rows[0][3].ToString(),
                        dt.Rows[0][4].ToString());
                return k;
            }
           
        }
        public KhachHang ReadCustomer()
        {
            DataHelper dh = new DataHelper();
            string sql = "Select *from KhachHang";
            DataTable dt = dh.GetDataTable(sql);
            if (dt.Rows.Count <= 0)
            {
                return null;
            }
            else
            {
                KhachHang cs = new KhachHang(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString(),
                    dt.Rows[0][2].ToString(), dt.Rows[0][3].ToString(), dt.Rows[0][4].ToString());
                return cs;
            }
        }
        public List<KhachHang> ToList(DataTable dt)
        {
            List<KhachHang> l = new List<KhachHang>();
            foreach (DataRow dr in dt.Rows)
            {
                KhachHang kh = new KhachHang(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(),
                    dr[3].ToString(), dr[4].ToString());
                l.Add(kh);

            }
            return l;
        }
        public List<KhachHang> GetKhachHang()
        {
            DataTable dt = dh.GetDataTable("Select * from KhachHang");
            
            return ToList(dt);
        }
        public string AddKhachHang(KhachHang khachhang)
        {
            string st = "insert into KhachHang values('" +
                 khachhang.MaKH + "',N'" +
                 khachhang.TenKH + "','" +
                 khachhang.SdtKH + "',N'" +
                 khachhang.DiaChi + "','" +
                 khachhang.MatKhau + "')";


            return dh.ExcuteNonQuery(st);
        }
    }
}
