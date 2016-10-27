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
       /// <summary>
       /// Quản lý sản phẩm
       /// </summary>
       /// <param name="page"></param>
       /// <returns></returns>
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
                // can phai lay sach tu csdl ra
               
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

        /// <summary>
        /// Quan Ly Loai SP
        /// </summary>
        /// <returns></returns>
        [SessionFilter]
        public ActionResult LoaiSP(int ? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 7;
            return View(db.LOAISPs.ToList().OrderBy(n => n.MALOAI).ToPagedList(pageNumber, pageSize));
        }
        //thêm mới
        [SessionFilter]
        [HttpGet]
        public ActionResult CreateLoai()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateLoai(LOAISP loai)
        {
            var thisLoai = db.LOAISPs.Any((l => l.TENLOAI.Equals(loai.TENLOAI)));
           
            if (ModelState.IsValid)
            {
                if (thisLoai)
                {
                    ViewBag.Thongbao = "Tên loại đã tồn tại";
                    return View(loai);
                }

                db.LOAISPs.InsertOnSubmit(loai);
                db.SubmitChanges();
            }
            return RedirectToAction("LoaiSP",new { page = 1 });
        }
        //Sửa
        [SessionFilter]
        [HttpGet]
        public ActionResult EditLoai(int id)
        {
            // lay ra doi tuong sach theo ma
            LOAISP loai = db.LOAISPs.SingleOrDefault(n => n.MALOAI == id);
            if (loai == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(loai);
        }

        [HttpPost]
        public ActionResult EditLoai(LOAISP loai)
        {
            
            if (ModelState.IsValid)
            {
                // can phai lay sach tu csdl ra
                var thisLoai = db.LOAISPs.Any((l => l.TENLOAI.Equals(loai.TENLOAI)));
                if (thisLoai)
                {
                    ViewBag.Thongbao = "Tên loại đã tồn tại";
                    return View(loai);
                }

                //rui moi luu vao csdl
                // ly do vi sao thi ko pit
                UpdateModel(loai);
                db.SubmitChanges();
            }
            return RedirectToAction("LoaiSP",new { page = 1 });

        }

        //Xóa
        [SessionFilter]
        [HttpGet]
        public ActionResult DeleteLoai(int id)
        {
            LOAISP loai = db.LOAISPs.SingleOrDefault(m => m.MALOAI == id);
            ViewBag.MALOAI = loai.MALOAI;
            if (loai == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(loai);
        }      

        [HttpPost, ActionName("DeleteLoai")]
        public ActionResult Xacnhanxoaloai(int id)
        {
            LOAISP loai = db.LOAISPs.SingleOrDefault(m => m.MALOAI == id);
            ViewBag.MALOAI = loai.MALOAI;
            if (loai == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.LOAISPs.DeleteOnSubmit(loai);
            db.SubmitChanges();
            return RedirectToAction("LoaiSP");
        }

        /// <summary>
        /// Quản lý đơn đặt hàng
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        [SessionFilter]
        public ActionResult DonDatHang(int ? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 7;
            return View(db.DONDATHANGs.ToList().OrderBy(n => n.MADDH).ToPagedList(pageNumber, pageSize));
        }
        // sua thong tin
        [SessionFilter]
        [HttpGet]
        public ActionResult EditDDH(int id)
        {
            // lay ra doi tuong sach theo ma
            DONDATHANG ddh = db.DONDATHANGs.SingleOrDefault(n => n.MADDH == id);
            if (ddh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(ddh);
        }

        [HttpPost]
        public ActionResult EditDDH(DONDATHANG ddh)
        {

            if (ModelState.IsValid)
            {
                // can phai lay sach tu csdl ra
                var thisddh = db.DONDATHANGs.Single(n => n.MADDH == ddh.MADDH);

                //rui moi luu vao csdl
                // ly do vi sao thi ko pit
                UpdateModel(thisddh);
                db.SubmitChanges();
            }
            return RedirectToAction("DonDatHang");

        }

        //chi tiet don dat hang
        [SessionFilter]
        public ActionResult DetailsDDH(int id)
        {
            // lay ra doi tuong sach theo ma
            DONDATHANG ddh = db.DONDATHANGs.SingleOrDefault(n => n.MADDH == id);
            if (ddh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.MADDH = ddh.MADDH;
            return View(ddh);
        }

        /// <summary>
        /// Quản lý chi tiết đơn đặt hàng
        /// </summary>
        /// <returns></returns>
        public ActionResult CTDDH(int ? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 7;
            return View(db.CTHOADONs.ToList().OrderBy(n => n.MADDH).ToPagedList(pageNumber, pageSize));
        }
        //chi tiet - coi lại phần này lỗi
        public ActionResult DetailsCTDDH(int id)
        {
            // lay ra doi tuong sach theo ma
            CTHOADON cthd = db.CTHOADONs.SingleOrDefault(n => n.MADDH == id);
            if (cthd == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.MADDH = cthd.MADDH;
            return View(cthd);
        }
        /// <summary>
        /// Quản lý khách hàng
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult KhachHang(int ? page )
        {
            int pageNumber = (page ?? 1);
            int pageSize = 7;
            return View(db.KHACHHANGs.ToList().OrderBy(n => n.MAKH).ToPagedList(pageNumber, pageSize));
        }
        //chi tiết kh
        public ActionResult DetailsKH(int id)
        {
            // lay ra doi tuong sach theo ma
            KHACHHANG kh = db.KHACHHANGs.SingleOrDefault(n => n.MAKH == id);
            ViewBag.MAKH = kh.MAKH;
            if (kh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(kh);
        }

        /// <summary>
        /// Đăng Nhập - Đăng Xuất
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
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