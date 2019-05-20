using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCModelBinding.Models
{
    public class Kategori
    {
        [Key]
        public int Id { get; set; }
        public string KategoriAdi { get; set; }
        public virtual List<AlinanNot> AlinanNotlar { get; set; }
    }

    public class AlinanNot
    {
        public int Id { get; set; }
        public string Yazi { get; set; }
        [ForeignKey("Kategori")]
        public int KategoriId { get; set; }
        public virtual Kategori Kategori { get; set; }
    }
}