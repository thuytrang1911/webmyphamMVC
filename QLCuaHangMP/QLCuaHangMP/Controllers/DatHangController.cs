using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyPhamOBJ;
using MyPhamBUS;
using Newtonsoft.Json;

namespace QLCuaHangMP.Controllers
{
    public class DatHangController : Controller
    {
        // GET: DatHang
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DonHang()
        {
            return View();
        }

        [HttpGet]

        //public JsonResult GetCustomer()
        //{
        //    UserBUS lb = new UserBUS();
        //    KhachHang u = lb.ReadCustomer();
        //    string l = "0";
        //    if (Session["login"] != null)
        //    {
        //        l = Session["login"].ToString();
        //    }
        //    string p = "";
        //    if (l == "1")
        //    {
        //        //string t = Session["khach"].ToString();
        //        Session["khach"] = JsonConvert.SerializeObject(u);
        //        //u = JsonConvert.DeserializeObject<Customer>(t) as Customer;

        //    }
        //    return Json(new { login = 1, khach = u }, JsonRequestBehavior.AllowGet);
        //}

        public JsonResult ReadCustomer()
        {
            string l = "0";
            if (Session["login"] != null)
            {
                l = Session["login"].ToString();
            }
            KhachHang k = null;
            string p = "";
            if (l == "1")
            {
                p = Session["login"].ToString();
                k = JsonConvert.DeserializeObject(Session["khach"].ToString()) as KhachHang;
            }
            Console.Write(p);
            return Json(new { login = l, Khach = k }, JsonRequestBehavior.AllowGet);
            
        }
        public JsonResult GetCustomer()
        {
            string l = "0";
            if (Session["login"] != null)
            {
                l = Session["login"].ToString();
            }
            KhachHang u = null;
            string p = "";
            if (l == "1")
            {
                string t = Session["khach"].ToString();
                //Session["khach"] = JsonConvert.SerializeObject(u);
                u = JsonConvert.DeserializeObject<KhachHang>(t) as KhachHang;

            }
            return Json(new { login = l, khach = u }, JsonRequestBehavior.AllowGet);
            
        }
        DatHangBUS db = new DatHangBUS();
        public JsonResult DatHang(string khachhang, string tong, string dsdonhang)
        {

            KhachHang u = JsonConvert.DeserializeObject<KhachHang>(khachhang);
            List<CTDonHang> ctdh = JsonConvert.DeserializeObject<List<CTDonHang>>(dsdonhang);
            DonHang d = new DonHang();
            d.MaKH = u.MaKH;
            d.DiaChiNhan = u.DiaChi;
            d.TinhTrang = "0";
            d.ThanhTien = int.Parse(tong);
            d.SDT = u.SdtKH;
            db.DatHang(u, d, ctdh);
            return Json(0, JsonRequestBehavior.AllowGet);


        }
        [HttpPost]
        public JsonResult Login(string makh, string pw)
        {

            DatHangBUS lb = new DatHangBUS();
            KhachHang u = lb.GetKhachHang(makh, pw);
            if (u == null) //Tài khoản không đúng
            {
                return Json(u, JsonRequestBehavior.AllowGet);
            }
            else
            {
                //Chuyển đối tượng
                string output = JsonConvert.SerializeObject(u);
                //Tạo cook lưu ttin khách hàng
                HttpCookie ck = new HttpCookie("Khach", output);
                //Thiết lập thời gian tồn tại
                ck.Expires = DateTime.Now.AddDays(2);
                Response.Cookies.Add(ck);
                //Tao cook lưu ttin về trạng thái login
                HttpCookie ckl = new HttpCookie("login", "1");
                //Thiết lập thời gian tồn tại
                ck.Expires = DateTime.Now.AddDays(2);
                //Ghi biến cook về brower
                Response.Cookies.Add(ckl);
                return Json(u, JsonRequestBehavior.AllowGet);

                //FormsAuthentication.SetAuthCookie(makh, false);
                //return Json(u, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
