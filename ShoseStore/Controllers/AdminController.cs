using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoseStore.Models;
using PagedList;
using PagedList.Mvc;
using System.IO;
using ShoseStore.Authentication;

namespace ShoseStore.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        dbShoseStoreDataContext db = new dbShoseStoreDataContext();
        [SessionFilter]
        public ActionResult Index()
        {
            return View();
        }

        //SessionFilter: khi muốn sử dụng cho action nào thì bỏ lên nó, mỗi khi action đó chạy thì
        //SessionFIlter sẽ luôn chạy trước
        [SessionFilter]
        public ActionResult SanPham(int ?page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 5;
            return View(db.SANPHAMs.ToList().OrderBy(n=>n.MASP).ToPagedList(pageNumber,pageSize));
        }
        //thêm mới
        [SessionFilter]
        [HttpGet]
        public ActionResult Create()
        {
            //Dua du lieu vao dropdownlist
            ViewBag.MaLoai = new SelectList(db.LOAISPs.ToList().OrderBy(n => n.TENLOAI), "MALOAI", "TENLOAI");
            ViewBag.MaNSX = new SelectList(db.NHASANXUATs.ToList().OrderBy(n => n.TENNSX), "MANSX", "TENNSX");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(SANPHAM sp,HttpPostedFileBase fileupload)
        {
            //dua du lieu vao 
            ViewBag.MaLoai = new SelectList(db.LOAISPs.ToList().OrderBy(n => n.TENLOAI), "MALOAI", "TENLOAI");
            ViewBag.MaNSX = new SelectList(db.NHASANXUATs.ToList().OrderBy(n => n.TENNSX), "MANSX", "TENNSX");
            //kt dg dan 
            if (fileupload == null)
            {
                ViewBag.Thongbao = "Vui lòng chọn ảnh";
                return View();
            }
            //them vao csdl
            else
            {
                if (ModelState.IsValid)
                {
                    //luu ten file
                    var filename = Path.GetFileName(fileupload.FileName);
                    // luu dg dan
                    var path = Path.Combine(Server.MapPath("~/images/sanpham"), filename);
                    // kt hinh da ton tai hay chua
                    if (System.IO.File.Exists(path))
                    {
                        ViewBag.Thongbao = "Hình ảnh đã tồn tại";
                    }
                    else
                    {
                        //luu file vao duong dan
                        fileupload.SaveAs(path);
                    }
                    sp.ANHBIA = filename;
                    db.SANPHAMs.InsertOnSubmit(sp);
                    db.SubmitChanges();
                }
                return RedirectToAction("SanPham");
            }   
        }

        //Sửa Sản phẩm
        [SessionFilter]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            // lay ra doi tuong sach theo ma
            SANPHAM sp = db.SANPHAMs.SingleOrDefault(n => n.MASP == id);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.MaLoai = new SelectList(db.LOAISPs.ToList().OrderBy(n => n.TENLOAI), "MALOAI", "TENLOAI",sp.MALOAI);
            ViewBag.MaNSX = new SelectList(db.NHASANXUATs.ToList().OrderBy(n => n.TENNSX), "MANSX", "TENNSX",sp.MANSX);
            return View(sp);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(SANPHAM sp, HttpPostedFileBase fileupload)
        {
            ViewBag.MaLoai = new SelectList(db.LOAISPs.ToList().OrderBy(n => n.TENLOAI), "MALOAI", "TENLOAI");
            ViewBag.MaNSX = new SelectList(db.NHASANXUATs.ToList().OrderBy(n => n.TENNSX), "MANSX", "TENNSX");
            // kiem tra duong dan file
            /*if (fileupload == null)
            {
                ViewBag.Thongbao = "Vui lòng chọn ảnh";
                return View(sach);
            }*/
            // them vao csdl


            if (ModelState.IsValid)
            {
                // can phai lay sach tu csdl ra
                var thisSanpham = db.SANPHAMs.Single(s => s.MASP == sp.MASP);

                // luu ten file, luu y them using System.IO
                if (fileupload != null)
                {
                    var filename = Path.GetFileName(fileupload.FileName);
                    // luu duong dan cua file
                    var path = Path.Combine(Server.MapPath("~/images/sanpham"), filename);
                    //kt lai anh da ton tai hay chua
                    if (System.IO.File.Exists(@path))

                    {
                        ViewBag.Thongbao = "Hình ảnh đã tồn tại";
                        return this.Edit(thisSanpham.MASP);
                    }
                    else
                    {
                        //luu file vao duong dan
                        fileupload.SaveAs(path);
                        thisSanpham.ANHBIA = filename;
                    }

                }



                //rui moi luu vao csdl
                // ly do vi sao thi ko pit
                UpdateModel(thisSanpham);
                db.SubmitChanges();
            }
            return RedirectToAction("SanPham");

        }



        //Hien thi  san pham
        [SessionFilter]
        public ActionResult Details(int id)
        {
            // lay ra doi tuong sach theo ma
            SANPHAM sp = db.SANPHAMs.SingleOrDefault(n => n.MASP == id);
            ViewBag.MASP = sp.MASP;
            if(sp==null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sp);
        }

        //Xoa San pham
        [SessionFilter]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            SANPHAM sp = db.SANPHAMs.SingleOrDefault(m => m.MASP == id);
            ViewBag.MASP = sp.MASP;
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sp);
        }

        [SessionFilter]
        [HttpPost,ActionName("Delete")]
        public ActionResult Xacnhanxoa(int id)
        {
            SANPHAM sp = db.SANPHAMs.SingleOrDefault(m => m.MASP == id);
            ViewBag.MASP = sp.MASP;
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.SANPHAMs.DeleteOnSubmit(sp);
            db.SubmitChanges();
            return RedirectToAction("SanPham");
        }



        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection f)
        {
            var tendn = f["username"];
            var matkhau = f["password"];
            if(String.IsNullOrEmpty(tendn))
            {
                ViewData["Loi1"] = "Phải nhập tên đăng nhập";
            }
            else if(String.IsNullOrEmpty(matkhau))
            {
                ViewData["Loi2"] = "Phải nhập mật khẩu";
            }
            else
            {
                Admin ad = db.Admins.SingleOrDefault(n => n.UserAdmin == tendn && n.PassAdmin == matkhau);
                if (ad != null)
                {
                    Session["adminname"] = ad.UserAdmin;
                    return RedirectToAction("Index", "Admin");
                }
                else
                    ViewBag.Thongbao = "Tên đăng nhập hoặc mật khẩu không đúng";
            }
            return View();
        }

        public ActionResult Logout() {
            Session.Remove("adminname");
            return RedirectToAction("Login");
        }
        
    }
}