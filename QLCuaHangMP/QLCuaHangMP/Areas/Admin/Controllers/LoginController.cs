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
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Login(string us, string pw)
        {
            UserBUS lb = new UserBUS();
            UserOBJ u = lb.CheckLogin(us, pw);
            if (u == null)//tài khoản k đúng
            {
                return Json(u, JsonRequestBehavior.AllowGet);
            }
            else
            {
                FormsAuthentication.SetAuthCookie(us, false);
                return Json(u, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}