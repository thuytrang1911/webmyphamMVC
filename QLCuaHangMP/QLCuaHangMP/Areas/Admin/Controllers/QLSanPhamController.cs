using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyPhamOBJ;
using MyPhamBUS;
using System.Web.Security;

namespace QLCuaHangMP.Areas.Admin.Controllers
{
    [Authorize]
    public class QLSanPhamController : Controller
    {
        SanPhamBUS pb = new SanPhamBUS();
        DongSPBUS db = new DongSPBUS();
        ThuongHieuBUS th = new ThuongHieuBUS();
        // GET: Admin/QLSanPham
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetSanPham()
        {

            List<SanPham> l = pb.GetSanPham();
            return Json(l, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetDongSP()
        {
            List<DongSP> ld = db.GetDongSP();
            return Json(ld, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetThuongHieu()
        {
            List<ThuongHieu> lth = th.GetThuongHieu();
            return Json(lth, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteSanPham(string id)
        {
            string st = pb.DeleteProduct(id);
            return Json(st, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult EditSanPham(SanPham s)
        {
            string res = pb.EditProduct(s);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult AddSanPham(SanPham s)
        {
            string res = pb.AddProduct(s);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        
    }
}