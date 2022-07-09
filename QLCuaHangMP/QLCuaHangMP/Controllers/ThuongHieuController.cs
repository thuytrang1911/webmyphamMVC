using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyPhamBUS;
using MyPhamOBJ;

namespace QLCuaHangMP.Controllers
{
    public class ThuongHieuController : Controller
    {
        // GET: ThuongHieu
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetThuongHieu()
        {
            ThuongHieuBUS lth = new ThuongHieuBUS();
            List<ThuongHieu> l = lth.GetThuongHieu();
            return Json(l, JsonRequestBehavior.AllowGet);
        }
    }
}