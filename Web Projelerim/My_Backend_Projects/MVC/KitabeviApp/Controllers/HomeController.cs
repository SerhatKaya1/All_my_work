using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using KitabeviApp.Models;
using Microsoft.EntityFrameworkCore;
using KitabeviApp.ViewModels;

namespace KitabeviApp.Controllers;

public class HomeController : Controller
{
    KitabeviContext context = new KitabeviContext();
    public IActionResult Index()
    {
        List<Kitap> kitaplar = context
                .Kitaplar
                .Include(k => k.Kategori)
                .Include(k => k.Yazar)
                .ToList();
        List<KitapListViewModel> kitapListViewModels = kitaplar
            .Select(k => new KitapListViewModel()
            {
                Id = k.Id,
                Ad = k.Ad,
                BasimYili = k.BasimYili,
                SayfaSayisi = k.SayfaSayisi,
                YazarAd = k.Yazar.Ad,
                KategoriAd = k.Kategori.Ad
            }).ToList();
        return View(kitapListViewModels);
    }
    public IActionResult KategoriListesi()
    {
        var kategoriler = context.Kategoriler.ToList();
        return View(kategoriler);
    }
    public IActionResult YazarListesi()
    {
        var yazarlar = context.Yazarlar.ToList();
        return View(yazarlar);
    }
    public IActionResult KitapListesi(int? id = null)
    {
        List<Kitap> kitaplar = null;
        if (id == null)
        {
            kitaplar = context
                .Kitaplar
                .Include(k => k.Kategori)
                .Include(k => k.Yazar)
                .ToList();
        }
        else
        {
            kitaplar = context
                .Kitaplar
                .Where(c => c.KategoriId == id)
                .Include(k => k.Kategori)
                .Include(k => k.Yazar)
                .ToList();
        }

        List<KitapListViewModel> kitapListViewModels = kitaplar
            .Select(k => new KitapListViewModel()
            {
                Id = k.Id,
                Ad = k.Ad,
                BasimYili = k.BasimYili,
                SayfaSayisi = k.SayfaSayisi,
                YazarAd = k.Yazar.Ad,
                KategoriAd = k.Kategori.Ad
            }).ToList();
        return View(kitapListViewModels);
    }
    public IActionResult Detay(int id)
    {
        var kitap = context
            .Kitaplar
            .Where(k => k.Id == id)
            .Include(k => k.Yazar)
            .Include(k => k.Kategori)
            .FirstOrDefault();
        return View(kitap);
    }
    public IActionResult KategoriEkle()
    {
        return View();
    }
    [HttpPost]
    public IActionResult KategoriEkle(Kategori kategori)
    {
        context.Kategoriler.Add(kategori);
        context.SaveChanges();
        return RedirectToAction("KategoriListesi");
    }

    public IActionResult YazarEkle()
    {
        return View();
    }
    [HttpPost]
    public IActionResult YazarEkle(YazarViewModel yazarViewModel)
    {
        if (ModelState.IsValid)
        {
            Yazar yazar = new Yazar()
            {
                Ad = yazarViewModel.Ad,
                DogumYili = yazarViewModel.DogumYili,
                Cinsiyet = yazarViewModel.Cinsiyet
            };
            context.Yazarlar.Add(yazar);
            context.SaveChanges();
            return RedirectToAction("YazarListesi");
        }
        return View();
    }

    public IActionResult KitapEkle()
    {
        ViewBag.Kategoriler = context.Kategoriler.ToList();
        ViewBag.Yazarlar = context.Yazarlar.ToList();
        return View();
    }
    [HttpPost]
    public IActionResult KitapEkle(Kitap kitap)
    {
        context.Kitaplar.Add(kitap);
        context.SaveChanges();
        return RedirectToAction("KitapListesi");
    }

    public IActionResult KategoriGuncelle(int id)
    {
        // Kategori kategori = context.Kategoriler.Where(k=>k.Id==id).FirstOrDefault();
        Kategori kategori = context.Kategoriler.Find(id);
        return View(kategori);
    }

    [HttpPost]
    public IActionResult KategoriGuncelle(Kategori kategori)
    {
        context.Kategoriler.Update(kategori);
        context.SaveChanges();
        return RedirectToAction("KategoriListesi");
    }

    public IActionResult YazarGuncelle(int id)
    {
        // Yazar yazar = context.Yazarlar.Where(k=>k.Id==id).FirstOrDefault();
        Yazar yazar = context.Yazarlar.Find(id);
        return View(yazar);
    }

    [HttpPost]
    public IActionResult YazarGuncelle(Yazar yazar)
    {
        context.Yazarlar.Update(yazar);
        context.SaveChanges();
        return RedirectToAction("YazarListesi");
    }
    public IActionResult KategoriSil(int id)
    {
        Kategori kategori = context.Kategoriler.Find(id);
        return View(kategori);
    }
    [HttpPost]
    public IActionResult KategoriSil(Kategori kategori)
    {
        context.Kategoriler.Remove(kategori);
        context.SaveChanges();
        return RedirectToAction("KategoriListesi");
    }

    public IActionResult YazarSil(int id)
    {
        Yazar yazar = context.Yazarlar.Find(id);
        return View(yazar);
    }
    [HttpPost]
    public IActionResult YazarSil(Yazar yazar)
    {
        context.Yazarlar.Remove(yazar);
        context.SaveChanges();
        return RedirectToAction("YazarListesi");
    }

    public IActionResult KitapGuncelle(int id)
    {
        Kitap kitap = context.Kitaplar.Find(id);
        // KitapViewModel kitapModel = new KitapViewModel();
        // kitapModel.Kitap=kitap;
        // kitapModel.Yazarlar=context.Yazarlar.ToList();
        // kitapModel.Kategoriler=context.Kategoriler.ToList();
        var liste = context.Yazarlar.Select(y => y.Ad).ToList();
        KitapViewModel kitapViewModel = new KitapViewModel()
        {
            Kitap = kitap,
            Yazarlar = context.Yazarlar.ToList(),
            Kategoriler = context.Kategoriler.ToList()
        };
        return View(kitapViewModel);
    }

    [HttpPost]
    public IActionResult KitapGuncelle(Kitap kitap)
    {
        context.Kitaplar.Update(kitap);
        context.SaveChanges();
        return RedirectToAction("KitapListesi");
    }


    public IActionResult KitapSil(int id)
    {
        Kitap kitap = context.Kitaplar.Find(id);
        ViewBag.Kategoriler = context.Kategoriler.ToList();
        ViewBag.Yazarlar = context.Yazarlar.ToList();
        return View(kitap);
    }
    [HttpPost]
    public IActionResult KitapSil(Kitap kitap)
    {
        context.Kitaplar.Remove(kitap);
        context.SaveChanges();
        return RedirectToAction("KitapListesi");
    }

    public IActionResult KategoriyeGoreKitapListesi(int id)
    {
        List<Kitap> kitaplar = context
            .Kitaplar
            .Where(k => k.KategoriId == id)
            .Include(k => k.Kategori)
            .Include(k => k.Yazar)
            .ToList();

        List<KitapListViewModel> kitapListViewModels = kitaplar
            .Select(k => new KitapListViewModel()
            {
                Id = k.Id,
                Ad = k.Ad,
                BasimYili = k.BasimYili,
                SayfaSayisi = k.SayfaSayisi,
                YazarAd = k.Yazar.Ad,
                KategoriAd = k.Kategori.Ad
            }).ToList();
        ViewBag.Tip="Kategori";
        return View("Index", kitapListViewModels);

    }
    public IActionResult YazaraGoreKitapListesi(int id)
    {
        List<Kitap> kitaplar = context
            .Kitaplar
            .Where(k => k.YazarId == id)
            .Include(k => k.Kategori)
            .Include(k => k.Yazar)
            .ToList();

        List<KitapListViewModel> kitapListViewModels = kitaplar
            .Select(k => new KitapListViewModel()
            {
                Id = k.Id,
                Ad = k.Ad,
                BasimYili = k.BasimYili,
                SayfaSayisi = k.SayfaSayisi,
                YazarAd = k.Yazar.Ad,
                KategoriAd = k.Kategori.Ad
            }).ToList();
        ViewBag.Tip="Yazar";
        return View("Index", kitapListViewModels);

    }

}
