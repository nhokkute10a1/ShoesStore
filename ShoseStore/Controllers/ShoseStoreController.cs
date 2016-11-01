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
            dynamic model = new System.Dynamic.ExpandoObject();
            model.sp = (from s in data.SANPHAMs where s.MASP == id select s).Single();
            model.size = from p in data.SIZEs
                         where p.MASP == id
                         group p by new { p.SIZE1 }
                             into mygroup
                         select mygroup.FirstOrDefault();
          //  Session["MaLoai"] = (from a in data.SANPHAMs
                             //    where a.MASP == id
                             //    select a.MALOAI).FirstOrDefault();
            model.SPLienQuan = from a in data.SANPHAMs
                               from b in data.LOAISPs
                               where (a.MALOAI == b.MALOAI) &&(a.MASP!=id)&& (b.MALOAI == (from a in data.SANPHAMs
                                                                             where a.MASP == id
                                                                             select a.MALOAI).FirstOrDefault())
                               select a;
            // ViewBag.size = new SelectList(data.SIZEs.Where(s => s.MASP == id).ToList(),"Size","Size");
            return View(model);
        }

        [HttpGet]
        public ActionResult Sizetheosp(int id)
        {

            var item = from a in data.SIZEs
                       where a.MASP == id
                       select a;
            return PartialView(item);
        }
	}
}