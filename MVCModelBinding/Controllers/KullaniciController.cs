using MVCModelBinding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCModelBinding.Controllers
{
    public class KullaniciController : Controller
    {
        KullaniciContext db = new KullaniciContext();

        public ActionResult Giris()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Giris(string KullaniciAdi, string Sifre)
        //{
        //    return View();
        //}

        [HttpPost]
        public ActionResult Giris(Kullanici k)
        {
            var kisi = db.Kullanicilar.FirstOrDefault(x =>
            x.KullaniciAdi == k.KullaniciAdi && x.Sifre == k.Sifre);

            if (kisi == null)
            {
                ViewBag.Error = "Giriş başarısız";
                return View();
            } else
            {
                Session["Giris"] = kisi.KullaniciAdi;
                return RedirectToAction("Index","Home");
            }
        }

        public ActionResult Cikis()
        {
            Session["Giris"] = null;
            return RedirectToAction("Index","Home");
        }

        public ActionResult Kayit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Kayit(Kullanici k, string SifreTekrar)
        {
            if(k.Sifre != SifreTekrar)
            {
                ViewBag.Error = "Şifreler eşleşmiyor";
                return View();
            }

            try
            {
                db.Kullanicilar.Add(k);
                db.SaveChanges();
            } catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }

            Session["Giris"] = k.KullaniciAdi;
            return RedirectToAction("Index", "Home");
           
        }
    }
}