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
    public class SanPhamDAO
    {
        DataHelper dh = new DataHelper();
        public List<SanPham> GetSanPham()
        {
            DataTable dt = dh.GetDataTable("Select * from SanPham");
            //dh.Close();
            return ToList(dt);
        }

        public List<SanPham> ToList(DataTable dt)
        {
            List<SanPham> l = new List<SanPham>();
            foreach (DataRow dr in dt.Rows)
            {
                SanPham s = new SanPham(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), 
                    dr[3].ToString(), int.Parse(dr[4].ToString()), dr[5].ToString(), dr[6].ToString(), 
                    dr[7].ToString(),  dr[8].ToString(), dr[9].ToString(), dr[10].ToString());
                l.Add(s);

            }
            return l;
        }
        public List<SanPham> GetSanPhamDong(string MaDong)
        {
            string sqlselect;
            if (MaDong != "")
            {
                sqlselect = "select*from SanPham where MaDong ='" + MaDong + "'";

            }
            else
                sqlselect = "select*from SanPham";
            DataTable dt = dh.GetDataTable(sqlselect);
            return ToList(dt);
        }

        public List<SanPham> GetSanPhamTH(string MaTH)
        {
            string sqlselect;
            if (MaTH != "")
            {
                sqlselect = "select*from SanPham where MaTH ='" + MaTH + "'";

            }
            else
                sqlselect = "select*from SanPham";
            DataTable dt = dh.GetDataTable(sqlselect);
            return ToList(dt);
        }

        public List<SanPham> LaySPBanChay()
        {
            List<SanPham> l = new List<SanPham>();
            SqlDataReader dr = dh.ExcuteReader("exec SanPhamBanChay");
            while (dr.Read())
            {
                SanPham sp = new SanPham();
                sp.MaSP = dr["MaSP"].ToString();
                sp.TenSP = dr["TenSP"].ToString();
                sp.MaDong = dr["MaDong"].ToString();
                sp.MaTH = dr["MaTH"].ToString();
                sp.GiaBan = Convert.ToInt32(dr["GiaBan"]);
                sp.KieuDang = dr["KieuDang"].ToString();
                sp.DungLuong = dr["DungLuong"].ToString();
                sp.MuiHuong = dr["MuiHuong"].ToString();
                sp.MauSac = dr["MauSac"].ToString();
                sp.MoTa = dr["MoTa"].ToString();
                sp.Anh = dr["Anh"].ToString();
                
                l.Add(sp);
            }
            return l;
        }

        public SanPham GetSanPham(string MaSP)
        {
            DataTable dt = dh.GetDataTable("select*from SanPham where MaSP='" + MaSP + "'");
            //SanPham sp = new SanPham();
            if (dt.Rows.Count <= 0)
            {
                return null;
            }
            else
            {
                DataRow dr = dt.Rows[0];
                SanPham s = new SanPham(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(),
                    int.Parse(dr[4].ToString()), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString(),
                    dr[9].ToString(), dr[10].ToString());
                return s;
            }
        }
        //lấy sp phân trang
        public SanPhamList GetSanPham(int pageIndex, int pageSize, string productName, string madong)
        {
            SanPhamList sql = new SanPhamList();
            List<SanPham> l = new List<SanPham>();
            SqlDataReader dr = dh.StoreReaders("GetSanPhams", pageIndex, pageSize, productName, madong);
            while (dr.Read())
            {
                SanPham s = new SanPham(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(),
                    int.Parse(dr[4].ToString()), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString(),
                    dr[9].ToString(), dr[10].ToString());
                l.Add(s);
            }
            sql.SanPhams = l;
            dr.NextResult();
            while (dr.Read())
            {
                sql.totalCount = dr["totalCount"].ToString();
            }
            return sql;

        }

        public string AddProduct(SanPham sp)
        {
            string sql = "insert into SanPham values('" + 
                sp.MaSP + "','" +
                sp.TenSP + "','" +
                sp.MaDong + "','" +
                sp.MaTH + "','" +
                sp.GiaBan+"','"+
                sp.KieuDang + "','" +
                sp.DungLuong + "','" +
                sp.MuiHuong + "','" +
                sp.MauSac + "','" +
                sp.MoTa + "','" +
                sp.Anh + "')";
            return dh.ExcuteNonQuery(sql);
        }
        public string DeleteProduct(string id)
        {

            string st = "delete from SanPham where MaSP='" + id + "'";
            string s = dh.ExcuteNonQuery(st);
            dh.Close();
            return s;
        }
        public string EditProduct(SanPham s)
        {
            string st = "update SanPham set " +
                "TenSP='" + s.TenSP + "'," +
                "MaDong='" + s.MaDong + "'," +
                "MaTH='" + s.MaTH + "'," +
                "GiaBan='" + s.GiaBan + "'," +
                "KieuDang='" + s.KieuDang + "'," +
                "DungLuong='" + s.DungLuong + "'," +
                "MuiHuong='" + s.MuiHuong + "'," +
                "MauSac='" + s.MauSac + "'," +
                "MoTa='" + s.MoTa + "'," +
                "Anh='" + s.Anh + "'" + "where MaSP='" + s.MaSP + "'";

            //string st = "update SanPham set " +
            //    "TenSP='" + s.TenSP + "'," +
            //    "MaDong='" + s.MaDong + "'," +
            //    "MaTH='" + s.MaTH + "'," +
            //    "GiaBan='" + s.GiaBan + "'," +
            //    "KieuDang='" + s.KieuDang +
            //    "DungLuong='" + s.DungLuong + "'," +
            //    "MuiHuong='" + s.MuiHuong + "'," +
            //    "MauSac='" + s.MauSac + "'," +
            //    "MoTa='" + s.MoTa + "'," +
            //    "Anh='" + s.Anh + "'where MaSP='" + s.MaSP + "'";
            return dh.ExcuteNonQuery(st);
        }
    }
}
