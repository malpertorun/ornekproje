using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCModelBinding.Models
{
    public class Kullanici
    {
        [Key]
        [Display(Name ="Kullanıcı Adı")]
        public string KullaniciAdi { get; set; }
        [Display(Name ="Şifre")]
        public string Sifre { get; set; }
        [Display(Name = "Ad Soyad")]
        public string AdSoyad { get; set; }
        [Display(Name ="Doğum Tarihi")]
        public DateTime DogumTarihi { get; set; }
        [Display(Name ="Çalışıyor Mu")]
        public bool CalisiyorMu { get; set; }

    }
}