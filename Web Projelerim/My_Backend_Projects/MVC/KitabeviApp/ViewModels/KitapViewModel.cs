using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KitabeviApp.Models;

namespace KitabeviApp.ViewModels
{
    public class KitapViewModel
    {
        public Kitap Kitap { get; set; }
        public List<Yazar> Yazarlar { get; set; }
        public List<Kategori> Kategoriler { get; set; }
    }
}