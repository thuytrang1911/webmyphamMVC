using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyPhamDAO;
using MyPhamOBJ;

namespace QLCuaHangMP.Controllers
{
    public class GioHangController : Controller
    {
        // GET: GioHang
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult AddCart(SanPham sp)
        {
            if (Session["giohang"] == null)//nếu giỏ hàng chưa đc khởi tạo
            {
                Session["giohang"] = new List<GioHang>();//khởi tạo session[giohang] là 1 List<GioHang>
            }
            List<GioHang> giohang = Session["giohang"] as List<GioHang>;//gán qua biến giohang
            GioHang gh = null;
            if (giohang.Find(m => m.MaSP == sp.MaSP) != null) //sản phẩm có trong giỏ hàng
            {
                giohang.Find(m => m.MaSP == sp.MaSP).SoLuong = giohang.Find(m => m.MaSP == sp.MaSP).SoLuong + 1;
            }
            else   //sản phẩm chưa có trong giỏ hàng
            {
                gh = new GioHang();
                gh.MaSP = sp.MaSP;
                gh.TenSP = sp.TenSP;
                gh.Anh = sp.Anh;
                gh.SoLuong = 1;
                gh.Gia = sp.GiaBan;
                gh.ThanhTien = gh.Gia;
                giohang.Add(gh);
            }
            Session["giohang"] = giohang;//gán lại giỏ hàng đã cập nhật sp chọn mua lại cho session
            return Json(new { status = true }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCart()
        {
            int sl = 0;
            double ThanhTien = 0;
            List<GioHang> ct = new List<GioHang>();
            if (Session["giohang"] == null) //nếu giỏ hàng chưa đc khởi tạo
            {
                Session["giohang"] = new List<GioHang>();//khởi tạo giỏ hàng
                sl = 0;
                ThanhTien = 0;
            }
            else
            {
                ct = Session["giohang"] as List<GioHang>;
                ThanhTien = Convert.ToDouble(ct.Sum(s => s.Gia * s.SoLuong));
                sl = int.Parse(ct.Sum(s => s.SoLuong).ToString());
            }
            return Json(new { dsDonHang = ct, SoLuong = sl, ThanhTien = ThanhTien }, JsonRequestBehavior.AllowGet);

        }
        public JsonResult XoaSP(string masp)
        {
            List<GioHang> giohang = Session["giohang"] as List<GioHang>;
            for(int i = 0; i < giohang.Count; i++)
            {
                if (giohang[i].MaSP == masp)
                {
                    giohang.RemoveAt(i);
                    break;
                }
            }
            Session["giohang"] = giohang;//gán lại giỏ hàng đã cập nhật sp chọn mua lại cho session
            return Json(new { status = true }, JsonRequestBehavior.AllowGet);
        }
    }
}