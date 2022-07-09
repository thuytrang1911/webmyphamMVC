using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyPhamBUS;
using MyPhamOBJ;

namespace QLCuaHangMP.Controllers
{
    public class CTSanPhamController : Controller
    {
        // GET: CTSanPham
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetSanPham(string MaSP)
        {
            CTSanPhamBUS pb = new CTSanPhamBUS();
            SanPham p = pb.GetSanPham(MaSP);
            return Json(p, JsonRequestBehavior.AllowGet);
        }
    }
}