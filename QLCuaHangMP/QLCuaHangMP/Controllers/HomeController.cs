using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyPhamBUS;
using MyPhamOBJ;
using Newtonsoft.Json;

namespace QLCuaHangMP.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DangKy()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public PartialViewResult GetMenu()
        {
            return PartialView("Menu");
        }

        SanPhamBUS sb = new SanPhamBUS();
        DongSPBUS lb = new DongSPBUS();
        ThuongHieuBUS tb = new ThuongHieuBUS();
        [HttpGet]
        public JsonResult GetSanPham(string MaDongSP)
        {
            List<SanPham> lsp = sb.GetSanPhamDong(MaDongSP);
            return Json(lsp, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetDongSP()
        {
            DongSPBUS bl = new DongSPBUS();
            List<DongSP> l = bl.GetDongSP();
            return Json(l, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetThuongHieu()
        {
            List<ThuongHieu> l = tb.GetThuongHieu();
            return Json(l, JsonRequestBehavior.AllowGet);
        }
        
        //[HttpPost]
        public JsonResult Login(string us, string pas, bool rp)
        {
            UserBUS ub = new UserBUS();
            //b1: lẤY về tài khoản người dùng
            KhachHang kh = ub.CheckKhachHang(us, pas);
            
            
            if (kh == null)// đăng nhập ko thành công
            {
                Session["login"] = "0";
                Session["khach"] = "";
                //return Json(new { login = "0", khach = kh }, JsonRequestBehavior.AllowGet);
            }
            else //đăng nhập thành công
            {
                //if (!rp)
                //{
                //    kh.MatKhau = "";

                //}
                Session["login"] = "1";
                Session["khach"] = JsonConvert.SerializeObject(kh);
                Session.Timeout = 360;
                //return Json(new { login = "1", khach = kh }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { login = Session["login"], Khach = kh }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Logout()
        {
            Session.Remove("login");
            Session.Remove("khach");
            return Json(0, JsonRequestBehavior.AllowGet);
        }
        UserBUS pb = new UserBUS();
        public JsonResult LayDSKH()
        {
            List<KhachHang> lkh = pb.GetKhachHang();
            return Json(lkh, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Signup(KhachHang kh)
        {
            
            string res = pb.AddKhachHang(kh);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}