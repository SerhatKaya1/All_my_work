using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitabeviApp.Models
{
    public class Kitap
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public int BasimYili { get; set; }
        public int SayfaSayisi { get; set; }
        public int KategoriId { get; set; }
        public Kategori Kategori { get; set; }
        public int YazarId { get; set; }
        public Yazar Yazar { get; set; }
        public string Ozet { get; set; }
        public bool AnaSayfa { get; set; }
    }
}