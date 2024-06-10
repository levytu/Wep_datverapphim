using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BigSchool.Models;

namespace BigSchool.Controllers
{
    public class CinemaController : Controller
    {
        // GET: Cinema
        
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
                Loai_Phim p= new Loai_Phim();
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
            p.MaLP= int.Parse(Request.Form["MaLP"]);
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

        /*QuanLyRapPhimDataContext context = new QuanLyRapPhimDataContext();
            if (Request.Form.Count > 0)
            {
                int idphim = int.Parse(Request.Form["idphim"]);
                int lc = int.Parse(Request.Form["lc"]);
                return View(context.P_Ve(idphim, lc));
            }*/

        
        public ActionResult DatVe(int lc,string idphim)
        {
            QuanLyRapPhimDataContext context = new QuanLyRapPhimDataContext();
            return View(context.P_Ve(lc, idphim));
        }

        public ActionResult ThanhToan()
        {
            QuanLyRapPhimDataContext context = new QuanLyRapPhimDataContext();
            HoaDon hd = new HoaDon();

            if(Request.Form.Count>0)
            {
                hd.MaKH = int.Parse(Request.Form["makh"]);
                hd.TenPhim = Request.Form["tenphim"];
                hd.TongTien = Request.Form["gia"];
                hd.DateTime = DateTime.Now;
                context.HoaDons.InsertOnSubmit(hd);
                context.SubmitChanges();
                return Redirect("~/Cinema/IndexPhim");
            }
            return View();
        }

        public ActionResult LichChieu()
        {
            QuanLyRapPhimDataContext QuanlyCinema = new QuanLyRapPhimDataContext();
            List<Lich_Chieu> lc = QuanlyCinema.Lich_Chieus.ToList();
            return View(lc);
        }
        public ActionResult IndexHoaDon()
        {
            QuanLyRapPhimDataContext QuanlyCinema = new QuanLyRapPhimDataContext();
            List<HoaDon> lc = QuanlyCinema.HoaDons.ToList();
            return View(lc);
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
                v.Gheso =  int.Parse(Request.Form["Gheso"]);
                v.Thoiluong = Request.Form["Thoiluong"];
                v.Maphong = Request.Form["MaPhong"];

                var ghe = QuanlyCinema.Ghes.FirstOrDefault(x=>x.Maghe == v.Maghe);
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
        public ActionResult IndexLoaiGhe()
        {
            QuanLyRapPhimDataContext QuanlyCinema = new QuanLyRapPhimDataContext();
            List<Loai_Ghe> dsGhe = QuanlyCinema.Loai_Ghes.ToList();
            return View(dsGhe);
        }
        public ActionResult CreateLoaiGhe()
        {
            if (Request.Form.Count > 0)
            {
                QuanLyRapPhimDataContext QuanlyCinema = new QuanLyRapPhimDataContext();
                Loai_Ghe g=new Loai_Ghe();
                g.MaLG= int.Parse(Request.Form["MaLG"]);
                g.TenLG = Request.Form["TenLG"];
                g.Giaghe = int.Parse(Request.Form["Giaghe"]);
                QuanlyCinema.Loai_Ghes.InsertOnSubmit(g);
                QuanlyCinema.SubmitChanges();
                return RedirectToAction("IndexLoaiGhe");
            }
            return View();
        }
        public ActionResult EditLoaiGhe(int id)
        {
            QuanLyRapPhimDataContext QuanlyCinema = new QuanLyRapPhimDataContext();
            Loai_Ghe g = QuanlyCinema.Loai_Ghes.FirstOrDefault(x => x.MaLG == id);
            if (Request.Form.Count == 0)
            {
                return View(g);
            }
            g.MaLG = int.Parse(Request.Form["MaLG"]);
            g.TenLG = Request.Form["TenLG"];
            g.Giaghe = int.Parse(Request.Form["Giaghe"]);
            QuanlyCinema.SubmitChanges();
            return RedirectToAction("IndexLoaiGhe");
        }
        public ActionResult DeleteLoaiGhe(int id)
        {
            QuanLyRapPhimDataContext context = new QuanLyRapPhimDataContext();
            Loai_Ghe p = context.Loai_Ghes.FirstOrDefault(x => x.MaLG == id);
            if (p != null)
            {
                context.Loai_Ghes.DeleteOnSubmit(p);
                context.SubmitChanges();
            }
            return RedirectToAction("IndexLoaiGhe");
        }
        public ActionResult DetailsLoaiGhe(int id)
        {
            QuanLyRapPhimDataContext context = new QuanLyRapPhimDataContext();
            Loai_Ghe c = context.Loai_Ghes.FirstOrDefault(x => x.MaLG == id);
            return View(c);
        }
        public ActionResult IndexGhe()
        {
            QuanLyRapPhimDataContext QuanlyCinema = new QuanLyRapPhimDataContext();
            List<Ghe> dsGhe = QuanlyCinema.Ghes.ToList();
            return View(dsGhe);
        }
        public ActionResult IndexRap()
        {
            QuanLyRapPhimDataContext QuanlyCinema = new QuanLyRapPhimDataContext();
            List<Rap_phim> dsRapphim = QuanlyCinema.Rap_phims.ToList();
            return View(dsRapphim);
        }
      
        public ActionResult DetailsPhim(int id)
        {
            QuanLyRapPhimDataContext context = new QuanLyRapPhimDataContext();
            Phim c = context.Phims.FirstOrDefault(x => x.Maphim == id);
            return View(c);
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
        public ActionResult DetailsVe(int id)
        {
            QuanLyRapPhimDataContext context = new QuanLyRapPhimDataContext();
            VE c = context.VEs.FirstOrDefault(x => x.Mave == id);
            return View(c);
        }
        public ActionResult IndexLichChieu()
        {
            QuanLyRapPhimDataContext QuanlyCinema = new QuanLyRapPhimDataContext();
            List<Lich_Chieu> dsRapphim = QuanlyCinema.Lich_Chieus.ToList();
            return View(dsRapphim);

        }
        public ActionResult CreateLichChieu()
        {
            if (Request.Form.Count > 0)
            {
                QuanLyRapPhimDataContext QuanlyCinema = new QuanLyRapPhimDataContext();
                Lich_Chieu l = new Lich_Chieu();
                l.MaLC = int.Parse(Request.Form["MaLC"]);
                l.Ngaychieu = Request.Form["Ngaychieu"];
                l.Giochieu = Request.Form["Giochieu"];
                l.Trangthai = Request.Form["Trangthai"];             
                QuanlyCinema.Lich_Chieus.InsertOnSubmit(l);
                QuanlyCinema.SubmitChanges();
                return RedirectToAction("IndexLichChieu");
            }
            return View();
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
        public ActionResult EditLichChieu(int id)
        {
            QuanLyRapPhimDataContext context = new QuanLyRapPhimDataContext();
            Lich_Chieu l= context.Lich_Chieus.FirstOrDefault(x=>x.MaLC == id);
            if (Request.Form.Count == 0)
            {
                return View(l);
            }
            l.MaLC = int.Parse(Request.Form["MaLC"]);
            l.Ngaychieu = Request.Form["Ngaychieu"];
            l.Giochieu = Request.Form["Giochieu"];
            l.Trangthai = Request.Form["Trangthai"];
            context.SubmitChanges();
            return RedirectToAction("IndexLichChieu");
        }
        public ActionResult DetailsLichChieu(int id)
        {
            QuanLyRapPhimDataContext context = new QuanLyRapPhimDataContext();
            Lich_Chieu c = context.Lich_Chieus.FirstOrDefault(x => x.MaLC == id);
            return View(c);
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

                QuanlyCinema.Ghes.InsertOnSubmit(g);
                QuanlyCinema.SubmitChanges();
                return RedirectToAction("IndexGhe");
            }
            return View();
        }
        public ActionResult DetailsGhe(int id)
        {
            QuanLyRapPhimDataContext context = new QuanLyRapPhimDataContext();
            Ghe c = context.Ghes.FirstOrDefault(x => x.Maghe == id);
            return View(c);
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

            context.SubmitChanges();
            return RedirectToAction("IndexGhe");
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
                x.MaXC= int.Parse(Request.Form["MaXC"]);
                x.Giochieu = Request.Form["Giochieu"];
                x.GiaXC= int.Parse(Request.Form["GiaXC"]);

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
    }
}
