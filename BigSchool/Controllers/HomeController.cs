using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BigSchool.Models;

namespace BigSchool.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            QuanLyRapPhimDataContext QuanlyCinema = new QuanLyRapPhimDataContext();
            List<Phim> dsphim = QuanlyCinema.Phims.ToList();
            return View(dsphim);
        }

      
        public ActionResult IndexKhachHang()
        {
            QuanLyRapPhimDataContext QuanlyCinema = new QuanLyRapPhimDataContext();
            List<Khach_Hang> dskhachhang = QuanlyCinema.Khach_Hangs.ToList();
            return View(dskhachhang);
        }
        public ActionResult DetailsKhachHang(int id)
        {
            QuanLyRapPhimDataContext context = new QuanLyRapPhimDataContext();
            Khach_Hang c = context.Khach_Hangs.FirstOrDefault(x => x.MaKH == id);
            return View(c);
        }
      
        
        public ActionResult LichChieu()
        {
            QuanLyRapPhimDataContext QuanlyCinema = new QuanLyRapPhimDataContext();
            List<Lich_Chieu> lc = QuanlyCinema.Lich_Chieus.ToList();
            return View(lc);
        }
        public ActionResult DatVe(int lc, string idphim)
        {
            QuanLyRapPhimDataContext context = new QuanLyRapPhimDataContext();
            return View(context.P_Ve(lc, idphim));
        }
        public ActionResult ThanhToan()
        {
            QuanLyRapPhimDataContext context = new QuanLyRapPhimDataContext();
            HoaDon hd = new HoaDon();

            if (Request.Form.Count > 0)
            {
                hd.MaKH = int.Parse(Request.Form["makh"]);
                hd.TenPhim = Request.Form["tenphim"];
                hd.TongTien = Request.Form["gia"];
                hd.DateTime = DateTime.Now;
                context.HoaDons.InsertOnSubmit(hd);
                context.SubmitChanges();
                return Redirect("~/Home/Index");
            }
            return View();
        }
        public ActionResult DetailsPhim(int id)
        {
            QuanLyRapPhimDataContext context = new QuanLyRapPhimDataContext();
            Phim c = context.Phims.FirstOrDefault(x => x.Maphim == id);
            return View(c);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}