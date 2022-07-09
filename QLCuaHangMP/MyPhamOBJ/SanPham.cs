using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyPhamOBJ
{
    public class SanPham
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public string MaDong { get; set; }
        public string MaTH { get; set; }
        public int GiaBan { get; set; }
        public string KieuDang { get; set; }
        public string DungLuong { get; set; }
        public string MuiHuong { get; set; }
        public string MauSac { get; set; }
        public string MoTa { get; set; }
        public string Anh { get; set; }
        public SanPham(string masp, string tensp, string madong,
                       string math, int gia, string kieudang, string dungluong,
                       string muihuong, string mausac, string mota,
                       string anh)
        {
            this.MaSP = masp;
            this.TenSP = tensp;
            this.MaDong = madong;  
            this.MaTH = math;
            this.GiaBan = gia;
            this.KieuDang = kieudang;
            this.DungLuong = dungluong;
            this.MuiHuong = muihuong;
            this.MauSac = mausac;
            this.MoTa = mota;
            this.Anh = anh;
        }
        public SanPham() { }
    }
}