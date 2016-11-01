using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShoseStore.Models;

namespace ShoseStore.Models
{
    public class GioHang
    {
        // tao doi tuong data chu du lieu tu model len 
        dbShoseStoreDataContext data = new dbShoseStoreDataContext();
        public int iMasp{set;get;}
        public string iTensp { set; get; }
        public string iAnhbia { set; get; }
        public Double dDongia { set; get; }
        public int iSoluong { set; get; }
        public int iSize { set; get; }
        public Double iThanhtien 
        {
            get { return iSoluong * dDongia; }
        }
        //khoi tao gio hang theo masp voi so luong mac dinh la 1
        public GioHang(int masp,int size,int soluong)
        {
            iMasp = masp;
            SANPHAM sp = data.SANPHAMs.SingleOrDefault(n => n.MASP == iMasp);
            iTensp = sp.TENSP;
            iAnhbia = sp.ANHBIA;
            dDongia = double.Parse(sp.GIABAN.ToString());
            iSize = size;
            iSoluong = soluong;
        }
    }
}