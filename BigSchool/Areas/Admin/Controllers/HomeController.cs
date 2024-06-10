using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BigSchool.Models;

namespace BigSchool.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            QuanLyRapPhimDataContext QuanlyCinema = new QuanLyRapPhimDataContext();
            List<Phim> dsphim = QuanlyCinema.Phims.ToList();
            return View(dsphim);
        }
        public ActionResult IndexPhim()
        {
            QuanLyRapPhimDataContext QuanlyCinema = new QuanLyRapPhimDataContext();
            List<Phim> dsphim = QuanlyCinema.Phims.ToList();
            return View(dsphim);
        }
        public ActionResult CreatePhim()
        {
            if (Request.Form.Count > 0)
            {
                QuanLyRapPhimDataContext QuanlyCinema = new QuanLyRapPhimDataContext();
                Phim p = new Phim();
                p.Maphim = int.Parse(Request.Form["Maphim"]);
                p.Tenphim = Request.Form["TenPhim"];
                p.Mota = Request.Form["Mota"];
                p.Thoiluong = Request.Form["Thoiluong"];
                p.Ngaykhoichieu = Request.Form["Ngaykhoichieu"];
                p.Daodien = Request.Form["Daodien"];
                p.Namsx = int.Parse(Request.Form["Namsx"]);
                p.Matheloai = int.Parse(Request.Form["MaTheLoai"]);
                p.Theloai = Request.Form["Theloai"];
                p.MaLP = int.Parse(Request.Form["MaLP"]);
                p.Loaiphim = Request.Form["Loaiphim"];
                p.GiaLP = int.Parse(Request.Form["GiaLP"]);
                p.Trailer = Request.Form["Trailer"];
                HttpPostedFileBase file = Request.Files["Apphich"];
                if (file != null)
                {
                    var tenFile = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/img"), tenFile);
                    file.SaveAs(path);
                    p.Apphich = file.FileName;
                }
                QuanlyCinema.Phims.InsertOnSubmit(p);
                QuanlyCinema.SubmitChanges();
                return RedirectToAction("IndexPhim");
            }
            return View();
        }
        public ActionResult DetailsPhim(int id)
        {
            QuanLyRapPhimDataContext context = new QuanLyRapPhimDataContext();
            Phim c = context.Phims.FirstOrDefault(x => x.Maphim == id);
            return View(c);
        }
        public ActionResult EditPhim(int id)
        {
            QuanLyRapPhimDataContext QuanlyCinema = new QuanLyRapPhimDataContext();
            Phim p = QuanlyCinema.Phims.FirstOrDefault(x => x.Maphim == id);
            if (Request.Form.Count == 0)
            {
                return View(p);
            }
            p.Maphim = int.Parse(Request.Form["Maphim"]);
            p.Tenphim = Request.Form["TenPhim"];
            p.Mota = Request.Form["Mota"];
            p.Thoiluong = Request.Form["Thoiluong"];
            p.Ngaykhoichieu = Request.Form["Ngaykhoichieu"];
            p.Daodien = Request.Form["Daodien"];
            p.Namsx = int.Parse(Request.Form["Namsx"]);
            p.Matheloai = int.Parse(Request.Form["MaTheLoai"]);
            p.Theloai = Request.Form["Theloai"];
            p.MaLP = int.Parse(Request.Form["MaLP"]);
            p.Loaiphim = Request.Form["Loaiphim"];
            p.GiaLP = int.Parse(Request.Form["GiaLP"]);
            p.Trailer = Request.Form["Trailer"];
            HttpPostedFileBase file = Request.Files["Apphich"];
            if (file != null)
            {
                var tenFile = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/img"), tenFile);
                file.SaveAs(path);
                p.Apphich = file.FileName;
            }
            QuanlyCinema.SubmitChanges();
            return RedirectToAction("IndexPhim");
        }
        public ActionResult DeletePhim(int id)
        {
            QuanLyRapPhimDataContext context = new QuanLyRapPhimDataContext();
            Phim p = context.Phims.FirstOrDefault(x => x.Maphim == id);
            if (p != null)
            {
                context.Phims.DeleteOnSubmit(p);
                context.SubmitChanges();
            }
            return RedirectToAction("IndexPhim");
        }
        public ActionResult IndexVE()
        {
            QuanLyRapPhimDataContext QuanlyCinema = new QuanLyRapPhimDataContext();
            List<VE> dsve = QuanlyCinema.VEs.ToList();
            return View(dsve);
        }
        public ActionResult CreateVE()
        {
            if (Request.Form.Count > 0)
            {
                QuanLyRapPhimDataContext QuanlyCinema = new QuanLyRapPhimDataContext();
                VE v = new VE();
                v.MaKH = int.Parse(Request.Form["MaKH"]);
                v.Maphim = int.Parse(Request.Form["Maphim"]);
                v.MaLC = int.Parse(Request.Form["MaLC"]);
                v.Maghe = int.Parse(Request.Form["Maghe"]);
                v.Maphong = Request.Form["MaPhong"];
                v.Tenphim = Request.Form["Tenphim"];
                v.Giochieu = Request.Form["Giochieu"];
                v.Ngaychieu = Request.Form["Ngaychieu"];
                v.Phongso = int.Parse(Request.Form["Phongso"]);
                v.Gheso = int.Parse(Request.Form["Gheso"]);
                v.Thoiluong = Request.Form["Thoiluong"];
                v.Maphong = Request.Form["MaPhong"];

                var ghe = QuanlyCinema.Ghes.FirstOrDefault(x => x.Maghe == v.Maghe);
                var lc = QuanlyCinema.Lich_Chieus.FirstOrDefault(x => x.MaLC == v.MaLC);
                var phim = QuanlyCinema.Phims.FirstOrDefault(x => x.Maphim == v.Maphim);

                var giave = ghe.Giaghe + lc.GiaXC + phim.GiaLP;
                v.Gia = giave;

                QuanlyCinema.VEs.InsertOnSubmit(v);
                QuanlyCinema.SubmitChanges();
                return RedirectToAction("IndexVE");
            }
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult EditVE(int id)
        {

            QuanLyRapPhimDataContext QuanlyCinema = new QuanLyRapPhimDataContext();
            VE v = QuanlyCinema.VEs.FirstOrDefault(x => x.Mave == id);
            if (Request.Form.Count == 0)
            {
                return View(v);
            }
            v.MaKH = int.Parse(Request.Form["MaKH"]);
            v.Maphim = int.Parse(Request.Form["Maphim"]);
            v.MaLC = int.Parse(Request.Form["MaLC"]);
            v.Maghe = int.Parse(Request.Form["Maghe"]);
            v.Maphong = Request.Form["MaPhong"];
            v.Tenphim = Request.Form["Tenphim"];
            v.Giochieu = Request.Form["Giochieu"];
            v.Ngaychieu = Request.Form["Ngaychieu"];
            v.Phongso = int.Parse(Request.Form["Phongso"]);
            v.Gheso = int.Parse(Request.Form["Gheso"]);
            v.Thoiluong = Request.Form["Thoiluong"];
            v.Maphong = Request.Form["MaPhong"];

            QuanlyCinema.SubmitChanges();
            return RedirectToAction("IndexPhim");
        }
        public ActionResult DetailsVe(int id)
        {
            QuanLyRapPhimDataContext context = new QuanLyRapPhimDataContext();
            VE c = context.VEs.FirstOrDefault(x => x.Mave == id);
            return View(c);
        }
        public ActionResult DeleteVE(int id)
        {
            QuanLyRapPhimDataContext context = new QuanLyRapPhimDataContext();
            VE k = context.VEs.FirstOrDefault(x => x.Mave == id);
            if (k != null)
            {
                context.VEs.DeleteOnSubmit(k);
                context.SubmitChanges();
            }
            return RedirectToAction("IndexVE");
        }
        public ActionResult IndexKhachHang()
        {
            QuanLyRapPhimDataContext QuanlyCinema = new QuanLyRapPhimDataContext();
            List<Khach_Hang> dskhachhang = QuanlyCinema.Khach_Hangs.ToList();
            return View(dskhachhang);
        }
        public ActionResult CreateKhachHang()
        {
            if (Request.Form.Count > 0)
            {
                QuanLyRapPhimDataContext QuanlyCinema = new QuanLyRapPhimDataContext();
                Khach_Hang kh = new Khach_Hang();
                kh.MaKH = int.Parse(Request.Form["MaKh"]);
                kh.Hoten = Request.Form["Hoten"];
                kh.Email = Request.Form["email"];
                kh.CMND = int.Parse(Request.Form["CMND"]);
                kh.SDT = int.Parse(Request.Form["SDT"]);
                kh.Ngaysinh = Request.Form["Ngaysinh"];
                kh.Diachi = Request.Form["Diachi"];
                kh.Diemtichluy = int.Parse(Request.Form["Diemtichluy"]);
                QuanlyCinema.Khach_Hangs.InsertOnSubmit(kh);
                QuanlyCinema.SubmitChanges();
                return RedirectToAction("IndexKhachHang");

            }
            return View();

        }
        public ActionResult EditKhachHang(int id)
        {
            QuanLyRapPhimDataContext QuanlyCinema = new QuanLyRapPhimDataContext();
            Khach_Hang k = QuanlyCinema.Khach_Hangs.FirstOrDefault(x => x.MaKH == id);
            if (Request.Form.Count == 0)
            {
                return View(k);
            }
            k.MaKH = int.Parse(Request.Form["MaKH"]);
            k.Hoten = Request.Form["Hoten"];
            k.Ngaysinh = Request.Form["Ngaysinh"];
            k.Diachi = Request.Form["Diachi"];
            k.Email = Request.Form["email"];
            k.SDT = int.Parse(Request.Form["SDT"]);
            k.CMND = int.Parse(Request["CMND"]);
            k.Diemtichluy = int.Parse(Request["Diemtichluy"]);
            QuanlyCinema.SubmitChanges();
            return RedirectToAction("IndexKhachHang");
        }
        public ActionResult DetailsKhachHang(int id)
        {
            QuanLyRapPhimDataContext context = new QuanLyRapPhimDataContext();
            Khach_Hang c = context.Khach_Hangs.FirstOrDefault(x => x.MaKH == id);
            return View(c);
        }
        public ActionResult DeleteKhachHang(int id)
        {
            QuanLyRapPhimDataContext context = new QuanLyRapPhimDataContext();
            Khach_Hang k = context.Khach_Hangs.FirstOrDefault(x => x.MaKH == id);
            if (k != null)
            {
                context.Khach_Hangs.DeleteOnSubmit(k);
                context.SubmitChanges();
            }
            return RedirectToAction("IndexKhachHang");
        }
        public ActionResult LichChieu()
        {
            QuanLyRapPhimDataContext QuanlyCinema = new QuanLyRapPhimDataContext();
            List<Lich_Chieu> lc = QuanlyCinema.Lich_Chieus.ToList();
            return View(lc);
        }
        public ActionResult CreateLichChieu()
        {
            if (Request.Form.Count > 0)
            {
                QuanLyRapPhimDataContext QuanlyCinema = new QuanLyRapPhimDataContext();
                Lich_Chieu l = new Lich_Chieu();
                l.MaLC = int.Parse(Request.Form["MaLC"]);
                l.MaXC = int.Parse(Request.Form["MaXC"]);
                l.Ngaychieu = Request.Form["Ngaychieu"];
                l.Giochieu = Request.Form["Giochieu"];
                l.Trangthai = Request.Form["Trangthai"];
                l.GiaXC = int.Parse(Request.Form["GiaXC"]);

                QuanlyCinema.Lich_Chieus.InsertOnSubmit(l);
                QuanlyCinema.SubmitChanges();
                return RedirectToAction("IndexLichChieu");
            }
            return View();
        }
        public ActionResult EditLichChieu(int id)
        {
            QuanLyRapPhimDataContext context = new QuanLyRapPhimDataContext();
            Lich_Chieu l = context.Lich_Chieus.FirstOrDefault(x => x.MaLC == id);
            if (Request.Form.Count == 0)
            {
                return View(l);
            }
            l.MaLC = int.Parse(Request.Form["MaLC"]);
            l.MaXC = int.Parse(Request.Form["MaXC"]);
            l.Ngaychieu = Request.Form["Ngaychieu"];
            l.Giochieu = Request.Form["Giochieu"];
            l.Trangthai = Request.Form["Trangthai"];
            l.GiaXC = int.Parse(Request.Form["GiaXC"]);
            context.SubmitChanges();
            return RedirectToAction("IndexLichChieu");
        }
        public ActionResult DetailsLichChieu(int id)
        {
            QuanLyRapPhimDataContext context = new QuanLyRapPhimDataContext();
            Lich_Chieu c = context.Lich_Chieus.FirstOrDefault(x => x.MaLC == id);
            return View(c);
        }
        public ActionResult DeleteLichChieu(int id)
        {
            QuanLyRapPhimDataContext context = new QuanLyRapPhimDataContext();
            Lich_Chieu p = context.Lich_Chieus.FirstOrDefault(x => x.MaLC == id);
            if (p != null)
            {
                context.Lich_Chieus.DeleteOnSubmit(p);
                context.SubmitChanges();
            }
            return RedirectToAction("IndexLichChieu");
        }
        public ActionResult IndexGhe()
        {
            QuanLyRapPhimDataContext QuanlyCinema = new QuanLyRapPhimDataContext();
            List<Ghe> dsGhe = QuanlyCinema.Ghes.ToList();
            return View(dsGhe);
        }
        public ActionResult CreateGhe()
        {
            if (Request.Form.Count > 0)
            {
                QuanLyRapPhimDataContext QuanlyCinema = new QuanLyRapPhimDataContext();
                Ghe g = new Ghe();
                g.Maghe = int.Parse(Request.Form["Maghe"]);
                g.Gheso = Request.Form["Gheso"];
                g.Maphong = int.Parse(Request.Form["Maphong"]);
                g.Phongso = int.Parse(Request.Form["Phongso"]);
                g.MaLG = int.Parse(Request.Form["MaLG"]);
                g.TenLG = Request.Form["TenLG"];
                g.Giaghe = int.Parse(Request.Form["Giaghe"]);

                QuanlyCinema.Ghes.InsertOnSubmit(g);
                QuanlyCinema.SubmitChanges();
                return RedirectToAction("IndexGhe");
            }
            return View();
        }
        public ActionResult EditGhe(int id)
        {
            QuanLyRapPhimDataContext context = new QuanLyRapPhimDataContext();
            Ghe g = context.Ghes.FirstOrDefault(x => x.Maghe == id);
            if (Request.Form.Count == 0)
            {
                return View(g);
            }
            g.Maghe = int.Parse(Request.Form["Maghe"]);
            g.Gheso = Request.Form["Gheso"];
            g.Maphong = int.Parse(Request.Form["Maphong"]);
            g.Phongso = int.Parse(Request.Form["Phongso"]);
            g.MaLG = int.Parse(Request.Form["MaLG"]);
            g.TenLG = Request.Form["TenLG"];
            g.Giaghe = int.Parse(Request.Form["Giaghe"]);

            context.SubmitChanges();
            return RedirectToAction("IndexGhe");
        }
        public ActionResult DetailsGhe(int id)
        {
            QuanLyRapPhimDataContext context = new QuanLyRapPhimDataContext();
            Ghe c = context.Ghes.FirstOrDefault(x => x.Maghe == id);
            return View(c);
        }
        public ActionResult DeleteGhe(int id)
        {
            QuanLyRapPhimDataContext context = new QuanLyRapPhimDataContext();
            Ghe g = context.Ghes.FirstOrDefault(x => x.Maghe == id);
            if (g != null)
            {
                context.Ghes.DeleteOnSubmit(g);
                context.SubmitChanges();
            }
            return RedirectToAction("IndexGhe");
        }
        public ActionResult IndexRap()
        {
            QuanLyRapPhimDataContext QuanlyCinema = new QuanLyRapPhimDataContext();
            List<Rap_phim> dsRapphim = QuanlyCinema.Rap_phims.ToList();
            return View(dsRapphim);
        }
        public ActionResult CreateRap()
        {
            if (Request.Form.Count > 0)
            {
                QuanLyRapPhimDataContext QuanlyCinema = new QuanLyRapPhimDataContext();
                Rap_phim g = new Rap_phim();
                g.Marap = int.Parse(Request.Form["Marap"]);
                g.Tenrap = Request.Form["Tenrap"];
                g.Diachi = Request.Form["Diachi"];

                QuanlyCinema.Rap_phims.InsertOnSubmit(g);
                QuanlyCinema.SubmitChanges();
                return RedirectToAction("IndexRap");
            }
            return View();
        }
        public ActionResult EditRap(int id)
        {
            QuanLyRapPhimDataContext context = new QuanLyRapPhimDataContext();
            Rap_phim g = context.Rap_phims.FirstOrDefault(x => x.Marap == id);
            if (Request.Form.Count == 0)
            {
                return View(g);
            }
            g.Marap = int.Parse(Request.Form["Marap"]);
            g.Tenrap = Request.Form["Tenrap"];
            g.Diachi = Request.Form["Diachi"];

            context.SubmitChanges();
            return RedirectToAction("IndexRap");
        }
        public ActionResult DetailsRap(int id)
        {
            QuanLyRapPhimDataContext context = new QuanLyRapPhimDataContext();
            Rap_phim c = context.Rap_phims.FirstOrDefault(x => x.Marap == id);
            return View(c);
        }
        public ActionResult DeleteRap(int id)
        {
            QuanLyRapPhimDataContext context = new QuanLyRapPhimDataContext();
            Rap_phim k = context.Rap_phims.FirstOrDefault(x => x.Marap == id);
            if (k != null)
            {
                context.Rap_phims.DeleteOnSubmit(k);
                context.SubmitChanges();
            }
            return RedirectToAction("IndexRap");
        }
        public ActionResult IndexLoaiPhim()
        {
            QuanLyRapPhimDataContext QuanlyCinema = new QuanLyRapPhimDataContext();
            List<Loai_Phim> dsphim = QuanlyCinema.Loai_Phims.ToList();
            return View(dsphim);
        }
        public ActionResult CreateLoaiPhim()
        {
            if (Request.Form.Count > 0)
            {
                QuanLyRapPhimDataContext QuanlyCinema = new QuanLyRapPhimDataContext();
                Loai_Phim p = new Loai_Phim();
                p.MaLP = int.Parse(Request.Form["MaLP"]);
                p.Loaiphim = Request.Form["Loaiphim"];
                p.GiaLP = int.Parse(Request.Form["GiaLP"]);
                QuanlyCinema.Loai_Phims.InsertOnSubmit(p);
                QuanlyCinema.SubmitChanges();
                return RedirectToAction("IndexLoaiPhim");
            }
            return View();
        }
        public ActionResult EditLoaiPhim(int id)
        {
            QuanLyRapPhimDataContext QuanlyCinema = new QuanLyRapPhimDataContext();
            Loai_Phim p = QuanlyCinema.Loai_Phims.FirstOrDefault(x => x.MaLP == id);
            if (Request.Form.Count == 0)
            {
                return View(p);
            }
            p.MaLP = int.Parse(Request.Form["MaLP"]);
            p.Loaiphim = Request.Form["Loaiphim"];
            p.GiaLP = int.Parse(Request.Form["GiaLP"]);
            QuanlyCinema.SubmitChanges();
            return RedirectToAction("IndexLoaiPhim");
        }
        public ActionResult DeleteLoaiPhim(int id)
        {
            QuanLyRapPhimDataContext context = new QuanLyRapPhimDataContext();
            Loai_Phim p = context.Loai_Phims.FirstOrDefault(x => x.MaLP == id);
            if (p != null)
            {
                context.Loai_Phims.DeleteOnSubmit(p);
                context.SubmitChanges();
            }
            return RedirectToAction("IndexLoaiPhim");
        }
        public ActionResult DetailsLoaiPhim(int id)
        {
            QuanLyRapPhimDataContext context = new QuanLyRapPhimDataContext();
            Loai_Phim c = context.Loai_Phims.FirstOrDefault(x => x.MaLP == id);
            return View(c);
        }
        public ActionResult IndexXuatChieu()
        {
            QuanLyRapPhimDataContext QuanlyCinema = new QuanLyRapPhimDataContext();
            List<Xuat_Chieu> dsRapphim = QuanlyCinema.Xuat_Chieus.ToList();
            return View(dsRapphim);

        }
        public ActionResult CreateXuatChieu()
        {
            if (Request.Form.Count > 0)
            {
                QuanLyRapPhimDataContext QuanlyCinema = new QuanLyRapPhimDataContext();
                Xuat_Chieu x = new Xuat_Chieu();
                x.MaXC = int.Parse(Request.Form["MaXC"]);
                x.Giochieu = Request.Form["Giochieu"];
                x.GiaXC = int.Parse(Request.Form["GiaXC"]);

                QuanlyCinema.Xuat_Chieus.InsertOnSubmit(x);
                QuanlyCinema.SubmitChanges();
                return RedirectToAction("IndexXuatChieu");
            }
            return View();
        }
        public ActionResult EditXuatChieu(int id)
        {
            QuanLyRapPhimDataContext context = new QuanLyRapPhimDataContext();
            Xuat_Chieu g = context.Xuat_Chieus.FirstOrDefault(x => x.MaXC == id);
            if (Request.Form.Count == 0)
            {
                return View(g);
            }
            g.MaXC = int.Parse(Request.Form["MaXC"]);
            g.Giochieu = Request.Form["Giochieu"];
            g.GiaXC = int.Parse(Request.Form["GiaXC"]);

            context.SubmitChanges();
            return RedirectToAction("IndexXuatChieu");
        }
        public ActionResult DetailstXuatChieu(int id)
        {
            QuanLyRapPhimDataContext context = new QuanLyRapPhimDataContext();
            Xuat_Chieu c = context.Xuat_Chieus.FirstOrDefault(x => x.MaXC == id);
            return View(c);
        }
        public ActionResult DeleteXuatChieu(int id)
        {
            QuanLyRapPhimDataContext context = new QuanLyRapPhimDataContext();
            Xuat_Chieu p = context.Xuat_Chieus.FirstOrDefault(x => x.MaXC == id);
            if (p != null)
            {
                context.Xuat_Chieus.DeleteOnSubmit(p);
                context.SubmitChanges();
            }
            return RedirectToAction("IndexXuatChieu");
        }
    }
}
