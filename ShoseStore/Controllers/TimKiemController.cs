using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoseStore.Models;

using PagedList.Mvc;
using PagedList;


namespace ShopTheThao.Controllers
{
    public class TimkiemController : Controller
    {
        dbShoseStoreDataContext db =new dbShoseStoreDataContext();
        // GET: /Timkiem/
        [HttpPost]
        public ActionResult KQTimKiem(FormCollection f, int? page)
        {
            string Stukhoa = f["txtTimKiem"].ToString();
            ViewBag.Tukhoa = Stukhoa;
            List<SANPHAM> lstKQTK = db.SANPHAMs.Where(n => n.TENSP.Contains(Stukhoa)).ToList();

            int pageNumber = (page ?? 1);

            int pageSize = 6;
            if (lstKQTK.Count == 0)
            {
                ViewBag.Thongbao = "Không tìm thấy kết quả nào phù hợp với từ khóa của bạn!";
                return View(lstKQTK.OrderBy(n => n.TENSP).ToPagedList(pageNumber, pageSize));
            }
            else
            {
                ViewBag.Thongbao = "Đã tìm thấy " + lstKQTK.Count + " kêt quả.";
                return View(lstKQTK.OrderBy(n => n.TENSP).ToPagedList(pageNumber, pageSize));
            }
        }
        [HttpGet]
        public ActionResult KQTimKiem(string Stukhoa, int? page)
        {
            ViewBag.Tukhoa = Stukhoa;
            List<SANPHAM> lstKQTK = db.SANPHAMs.Where(n => n.TENSP.Contains(Stukhoa)).ToList();

            int pageNumber = (page ?? 1);

            int pageSize = 6;
            if (lstKQTK.Count == 0)
            {
                ViewBag.Thongbao = "Không tìm thấy kết quả nào phù hợp với từ khóa của bạn!";
                return View(lstKQTK.OrderBy(n => n.TENSP).ToPagedList(pageNumber, pageSize));
            }
            else
            {
                ViewBag.Thongbao = "Đã tìm thấy " + lstKQTK.Count + " kêt quả.";
                return View(lstKQTK.OrderBy(n => n.TENSP).ToPagedList(pageNumber, pageSize));
            }
        }
    }
}