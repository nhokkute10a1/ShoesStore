using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoseStore.Models;

namespace ShoseStore.Controllers
{
    public class UserAccountController : Controller
    {
        //
        // GET: /UserAccount/
        dbShoseStoreDataContext db = new dbShoseStoreDataContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult SignUp()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult SignUp(FormCollection f, KHACHHANG kh)
        {
            var hoten = f["HoTenKH"];
            var tendn = f["TenDN"];
            var matkhau = f["Matkhau"];
            var matkhaunhaplai = f["Matkhaunhaplai"];
            var email = f["Email"];
            var diachi = f["Diachi"];
            var dienthoai = f["Dienthoai"];
            Console.WriteLine(f["Ngaysinh"]);
            //var ngaysinh = String.Format("0:{dd/MM/yyyy}",f["Ngaysinh"]);
            var ngaysinh = String.Format("{0:MM/dd/yyyy}", f["Ngaysinh"]);
            //if (String.IsNullOrEmpty(hoten))
            //{
            //    ViewData["Loi1"] = "Họ tên khách hàng không được để trống";
            //}
            //if (String.IsNullOrEmpty(tendn))
            //{
            //    ViewData["Loi2"] = "Phải nhập tên đăng nhập";
            //}
            //if (String.IsNullOrEmpty(matkhau))
            //{
            //    ViewData["Loi3"] = "Phải nhập mật khẩu";
            //}
            //if (matkhau != matkhaunhaplai)
            //{
            //    ViewData["Loi4"] = "Mật khẩu nhập lại không khớp";
            //}
            //else if (String.IsNullOrEmpty(matkhaunhaplai))
            //{
            //    ViewData["Loi4"] = "Phải nhập mật khẩu nhập lại";
            //}
            //if (String.IsNullOrEmpty(email))
            //{
            //    ViewData["Loi5"] = "Email không được để trống";
            //}
            //if (String.IsNullOrEmpty(dienthoai))
            //{
            //    ViewData["Loi6"] = "Điện thoại không được để trống";
            //}
            //else
            //{
            kh.HOTEN = hoten;
            kh.TAIKHOAN = tendn;
            kh.MATKHAU = matkhau;
            kh.EMAIL = email;
            kh.DIACHI = diachi;
            kh.SDT = dienthoai;
            kh.NGAYSINH = DateTime.Parse(ngaysinh);
            db.KHACHHANGs.InsertOnSubmit(kh);
            db.SubmitChanges();
            return RedirectToAction("Index", "ShoseStore");
            //}
            //return this.SignUp();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection f)
        {
            var tendn = f["TenDN"];
            var matkhau = f["Matkhau"];
            //if (String.IsNullOrEmpty(tendn))
            //{
            //    ViewData["Loi1"] = "Phải nhập tên đăng nhập";
            //}
            //else if (String.IsNullOrEmpty(matkhau))
            //{
            //    ViewData["Loi2"] = "Phải nhập mật khẩu";
            //}
            //else
            //{
            KHACHHANG kh = db.KHACHHANGs.SingleOrDefault(n => n.TAIKHOAN == tendn && n.MATKHAU == matkhau);
            if (kh != null)
            {
                //ViewBag.Thongbao = "Đăng nhập thành công";
                Session["Taikhoan"] = kh;
                //return RedirectToAction("Index", "ShoseStore");
                return Json(new { result="success" });
            }
            else
            {
                //ViewBag.Thongbao = "Tài khoản hoặc mật khẩu không đúng";
                //return this.Login();
                return Json(new { result="error", message= "Tài khoản hoặc mật khẩu không đúng" });
            }
            
            //}
            
            
        }
        public ActionResult DangXuat()
        {
            Session["TaiKhoan"] = null;
            return RedirectToAction("Index", "ShoseStore");
        }
    }
}