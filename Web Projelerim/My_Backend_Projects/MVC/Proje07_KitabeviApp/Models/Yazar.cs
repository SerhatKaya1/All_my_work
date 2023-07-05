using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitabeviApp.Models
{
    public class Yazar
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public int DogumYili { get; set; }
        public char Cinsiyet { get; set; }
    }
}