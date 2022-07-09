using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyPhamBUS;
using MyPhamOBJ;

namespace QLCuaHangMP.Controllers
{
    [Route("SanPham")]
    public class SanPhamController : Controller
    {
        // GET: SanPham
        SanPhamBUS pb = new SanPhamBUS();
        public ActionResult Index()
        {
            List<SanPham> lp = pb.GetSanPham();
            return View(lp);
        }

        public ActionResult ThuongHieu()
        {
            return View();
        }

        public ActionResult TrangDiem()
        {
            return View();
        }
        public ActionResult SPBanChay()
        {
            return View();
        }

        [Route("/GetSanPham")]
        public JsonResult GetSanPham()
        {
            List<SanPham> lp = pb.GetSanPham();
            //@ViewBag.SoSanPham = lp.Count;
            return Json(lp, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSanPhamPT(int pageIndex, int pagesize, string productname, string madong)
        {
            SanPhamList spl = pb.GetSanPhamPT(pageIndex, pagesize, productname, madong);
            return Json(spl, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSanPhamDong(string MaDongSP)
        {
            List<SanPham> lp = pb.GetSanPhamDong(MaDongSP);
            return Json(lp, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSanPhamTH(string MaTH)
        {
            List<SanPham> lp = pb.GetSanPhamTH(MaTH);
            return Json(lp, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDSSPBanChay()
        {
            List<SanPham> lsp = pb.GetSPBanChay();

            return Json(lsp, JsonRequestBehavior.AllowGet);
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