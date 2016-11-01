using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoseStore.Models;
using System.Net.Mail;
using System.Text;

namespace ShoseStore.Models
{
    public class GioHangController : Controller
    {
        dbShoseStoreDataContext db = new dbShoseStoreDataContext();
        // GET: GioHang
        public List<GioHang> Laygiohang()
        {
            List<GioHang> listhang = Session["GioHang"] as List<GioHang>;
            if(listhang==null)
            {
                listhang = new List<GioHang>();
                Session["GioHang"] = listhang;
            }
            return listhang;
        }
        
        //them gio hang
        public ActionResult Themgiohang(int imasp,int iSize,int Soluong, string strUrl)
        {
            //lay gio hang
            List<GioHang> listhang = Laygiohang();
            // kt gio hang ton tai hay chua
            GioHang sanpham = listhang.Find(n => n.iMasp == imasp&&n.iSize==iSize);
            if (sanpham == null)
            {
                sanpham = new GioHang(imasp,iSize,Soluong);
                listhang.Add(sanpham);
                return Redirect(strUrl);
            }
            else
            {
                sanpham.iSoluong = sanpham.iSoluong + Soluong;
                return Redirect(strUrl);
            }
        }
        //tong so luong
        public int Tongsoluong()
        {
            int sNumber = 0;
            List<GioHang> listhang = Session["GioHang"] as List<GioHang>;
            if(listhang!=null)
            {
                sNumber = listhang.Sum(n=>n.iSoluong);    
            }
            return sNumber;
        }
        //tong so luong tien
        public double Tongtien()
        {
            double sTien = 0;
            List<GioHang> listhang = Session["GioHang"] as List<GioHang>;
            if (listhang != null)
            {
                sTien = listhang.Sum(n => n.iThanhtien);
            }
            return sTien;
        }
        // xay dung trang gio hang
        public ActionResult GioHang()
        {
            List<GioHang> listhang = Laygiohang();
            if(listhang.Count==0)
            {
                return RedirectToAction("Index", "ShoseStore");
            }
            ViewBag.Tongsoluong = Tongsoluong();
            ViewBag.Tongtien = Tongtien();
            return View(listhang);
        }
        //dung partial de hien thi thong tin gio hang
        public ActionResult GiohangPartial()
        {
            ViewBag.Tongsoluong = Tongsoluong();
            ViewBag.Tongtien = Tongtien();
            return PartialView();
        }
        //xoa gio hang
        public ActionResult Xoagiohang(int imasp,int isize)
        {
            List<GioHang> listhang = Laygiohang();
            GioHang sp = listhang.SingleOrDefault(n => n.iMasp == imasp&&n.iSize==isize);
            //ton tai cho sua
            if(sp!=null)
            {
                listhang.RemoveAll(n=>n.iMasp==imasp&&n.iSize==isize);
                return RedirectToAction("GioHang");
            }
            if(listhang.Count==0)
            {
                return RedirectToAction("Index", "ShoseStore");
            }
            return RedirectToAction("GioHang");
        }
        //cap nhap gio hang
        public ActionResult Capnhapgiohang(int imasp,int isize,FormCollection f)
        {
            List<GioHang> listhang = Laygiohang();
            GioHang sp = listhang.SingleOrDefault(n => n.iMasp == imasp&&n.iSize==isize);
            if(sp!=null)
            {
                sp.iSoluong = int.Parse(f["txtSoluong"].ToString());
            }
            return RedirectToAction("GioHang");
        }
        //Xoa tat ca
        public ActionResult XoaAll()
        {
            List<GioHang> listhang = Laygiohang();
            listhang.Clear();
            return RedirectToAction("Index", "ShoseStore");
        }
        [HttpGet]
        public ActionResult DatHang()
        {
            //kt ten dang nhap
            //if (Session["Taikhoan"] == null || Session["Taikhoan"].ToString() == "")
            //{
            //    //kt lai van de nay
            //    return RedirectToAction("UserAccount", "ShoseStore");
            //}
            //if (Session["Giohang"] == null)
            //{
            //    return RedirectToAction("Index", "ShoseStore");
            //}
            //lay gio hang tu session
            List<GioHang> listhang = Laygiohang();
            ViewBag.Tongsoluong = Tongsoluong();
            ViewBag.Tongtien = Tongtien();
            return View(listhang);
        }
        [HttpPost]
        public ActionResult DatHang(FormCollection f)
        {
            //them don dat hang
            DONDATHANG ddh = new DONDATHANG();
            KHACHHANG kh = (KHACHHANG)Session["Taikhoan"];
            List<GioHang> listhang = Laygiohang();
            ddh.MAKH = kh.MAKH;
            ddh.NGAYDH = DateTime.Now;
            var ngaygiao = String.Format("{0:dd/MM/yyyy}", f["ngaygiao"]);
            ddh.NGAYGIAO = DateTime.Parse(ngaygiao);
            ddh.TINHTRANGGIAO = false;
            ddh.DATHANHTOAN = false;
            db.DONDATHANGs.InsertOnSubmit(ddh);
            db.SubmitChanges();
            //them chi tiet don hang
            foreach (var item in listhang)
            {
                CTHOADON ctdh = new CTHOADON();
                ctdh.MADDH = ddh.MADDH;
                ctdh.MASP = item.iMasp;
                ctdh.SOLUONG = item.iSoluong;
                ctdh.DONGIA = (decimal)item.dDongia;
                ctdh.SIZE =item.iSize;
                ctdh.THANHTIEN = (decimal)item.iThanhtien;
                db.CTHOADONs.InsertOnSubmit(ctdh);
            }
            //Mail
            StringBuilder Body = new StringBuilder();
            Body.Append("<p>Cảm ơn quý khách đã sử dụng sản phẩm của chúng tôi, chúng tôi sẽ liên lạc lại cho quý khách trong thời gian sớm nhất:</p>");
            Body.Append("<table>");
            Body.Append("<tr><td colspan='2'><h4>Thông tin khách hàng</h4></td></tr>");
            Body.Append("<tr><td>Họ và tên:</td><td>"+kh.HOTEN+"/td></tr>");
            Body.Append("<tr><td>Số điện thoại:</td><td>" + kh.SDT+ "</td></tr>");
            Body.Append("<tr><td>Địa chỉ:</td><td>" + kh.DIACHI+ "</td></tr>");
            Body.Append("<tr><td>Email:</td><td>" + kh.EMAIL + "</td></tr>");
            //Body.Append("<tr><td>Nguồn khách:</td><td>Google.com</td></tr>");
            Body.Append("</table>");
            
            MailMessage mail = new MailMessage();
            mail.To.Add(kh.EMAIL);// cai nay la mail khach hang 
            mail.From = new MailAddress("khongxacdinh95@gmail.com");
            mail.Subject = "Tiêu đề của mail được gửi";
            mail.Body = Body.ToString();// phần thân của mail ở trên
            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("khongxacdinh95@gmail.com", "khoaleyeuthuytran");// tài khoản Gmail của bạn
            smtp.EnableSsl = true;
            smtp.Timeout = 30000;


            smtp.Send(mail);
            //
            db.SubmitChanges();
            Session["GioHang"] = null;
            return RedirectToAction("Xacnhandonhang", "GioHang");
        }
        public ActionResult Xacnhandonhang()
        {
            return View();
        }
    }
}