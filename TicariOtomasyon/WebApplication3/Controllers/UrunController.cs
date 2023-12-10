using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models.Siniflar;

namespace WebApplication3.Controllers
{
    public class UrunController : Controller
    {
        Context _context = new Context();
        public ActionResult Index(string p)
        {
            var urunler = from x in _context.Uruns.Include(x => x.Kategori) select x;
            if (!string.IsNullOrEmpty(p))
            {
                urunler = urunler.Where(y => y.UrunAdi.Contains(p));
            }
            //var urun = _context.Uruns.Include(x => x.Kategori).Where(x => x.Durum == true).ToList();
            return View(urunler.ToList());
        }

        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> list = (from x in _context.Kategoris.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.KategoriAd,
                                             Value = x.KategoriId.ToString()
                                         }).ToList();
            ViewBag.Kategoriid = list;
            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(Urun urun)
        {
            urun.Durum = true;
            _context.Uruns.Add(urun);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunSil(int id)
        {
            var deger = _context.Uruns.Find(id);
            deger.Durum = false;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> list = (from x in _context.Kategoris.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.KategoriAd,
                                             Value = x.KategoriId.ToString()
                                         }).ToList();
            ViewBag.Kategoriid = list;
            var urun = _context.Uruns.Find(id);
            return View("UrunGetir", urun);
        }

        public ActionResult UrunGuncelle(Urun urun)
        {
            var urn = _context.Uruns.Find(urun.UrunId);
            urn.AlisFiyati = urun.AlisFiyati;
            urn.Durum = urun.Durum;
            urn.KategoriId = urun.KategoriId;
            urn.Marka = urun.Marka;
            urn.SatisFiyati = urun.SatisFiyati;
            urn.Stok = urun.Stok;
            urn.UrunAdi = urun.UrunAdi;
            urn.UrunGorsel = urun.UrunGorsel;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunListesi()
        {
            using (Context context = new Context())
            {
                var urun = context.Uruns.Include(x => x.Kategori).ToList();
                return View(urun);
            }
        }
    }
}
