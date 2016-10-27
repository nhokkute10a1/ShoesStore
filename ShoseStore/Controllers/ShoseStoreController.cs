using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoseStore.Models;
using PagedList;
using PagedList.Mvc;

namespace ShoseStore.Controllers
{
    public class ShoseStoreController : Controller
    {
        //
        // GET: /ShoseStore/
        dbShoseStoreDataContext data = new dbShoseStoreDataContext();
        private List<SANPHAM>Layspmoi(int count)
        {
            //lay sp theo ngay cap nhap,giam dan
            return data.SANPHAMs.OrderByDescending(a => a.NGAYCAPNHAP).Take(count).ToList();
        }

        public ActionResult Index()
        {
            var spmoi = Layspmoi(5);
            return View(spmoi);
        }
        private List<SANPHAM>Laysp(int count)
        {
            //lay sp theo ngay cap nhap,tang dan
            return data.SANPHAMs.OrderBy(a => a.NGAYCAPNHAP).Take(count).ToList();
        }   
        public ActionResult SpCu()
        {
            var spcu = Laysp(5);
            return PartialView(spcu);
        }
        public ActionResult LoaiSpNu()
        {
            var loaisp = from sp in data.LOAISPs where sp.GIOITINH == null || sp.GIOITINH== false  select sp;
            return PartialView(loaisp);
        }
        public ActionResult LoaiSpNam()
        {
            var loaisp = from sp in data.LOAISPs where sp.GIOITINH == null || sp.GIOITINH == true select sp;
            return PartialView(loaisp);
        }
        public ActionResult Nhasanxuat()
        {
            var nhasanxuat = from nsx in data.NHASANXUATs select nsx;
            return PartialView(nhasanxuat);
        }
          public  ActionResult SptheoLoai(int id,int? page)
        {
            //tao bien quy dinh so sp tren moi trang
            int pageSize = 5;
            //tao bien so trang
            int pageNum = (page ?? 1);

            var sp = from s in data.SANPHAMs where s.MALOAI == id select s;
            return View(sp.ToPagedList(pageNum, pageSize));
        }
        public ActionResult SptheoNsx(int id, int? page)
        {
            //tao bien quy dinh so sp tren moi trang
            int pageSize = 5;
            //tao bien so trang
            int pageNum = (page ?? 1);

            var snsx = from nsx in data.SANPHAMs where nsx.MANSX == id select nsx;
            return View(snsx.ToPagedList(pageNum, pageSize));
        }

        public ActionResult Details(int id)
        {
            var sp = from s in data.SANPHAMs where s.MASP == id select s;
            return View(sp.Single());
        }

	}
}