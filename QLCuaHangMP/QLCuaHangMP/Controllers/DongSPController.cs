using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyPhamBUS;
using MyPhamOBJ;

namespace QLCuaHangMP.Controllers
{
    public class DongSPController : Controller
    {
        // GET: DongSP
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetDongSP()
        {
            DongSPBUS bl = new DongSPBUS();
            List<DongSP> l = bl.GetDongSP();
            return Json(l, JsonRequestBehavior.AllowGet);
        }
    }
}