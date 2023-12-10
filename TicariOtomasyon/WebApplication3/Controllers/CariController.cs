using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models.Siniflar;

namespace WebApplication3.Controllers
{
    public class CariController : Controller
    {
        public IActionResult Index()
        {
            using (Context contex = new Context())
            {
                var cari = contex.Caris.Where(x => x.Durum == true).ToList();
                return View(cari);
            }

        }

        [HttpGet]
        public ActionResult YeniCari()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniCari(Cari cari)
        {
            using (Context contex = new Context())
            {
                cari.Durum = true;
                contex.Caris.Add(cari);
                contex.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult CariSil(int id)
        {
            using (Context contex = new Context())
            {
                var cari = contex.Caris.Find(id);
                cari.Durum = false;
                contex.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult CariGetir(int id)
        {
            using (Context contex = new Context())
            {
                var cari = contex.Caris.Find(id);
                return View("CariGetir", cari);
            }
        }

        public ActionResult CariGuncelle(Cari cari)
        {
            using (Context contex = new Context())
            {
                if (!ModelState.IsValid)
                {
                    return View("CariGetir");
                }
                var caris = contex.Caris.Find(cari.CariId);
                caris.CariAdi = cari.CariAdi;
                caris.CariSoyadi = cari.CariSoyadi;
                caris.Durum = true;
                caris.CariMail = cari.CariMail;
                caris.CariUnvani = cari.CariUnvani;
                caris.CariSehir = cari.CariSehir;
                caris.CariTelefon = cari.CariTelefon;
                contex.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult MusteriSatis(int id)
        {
            using (Context contex = new Context())
            {
                var degerler = contex.SatisHarekets.Include(u => u.Urun).Include(c => c.Cari).Include(p => p.Personel)
                    .Where(x => x.CariId == id).ToList();
                var deger = contex.Caris.Where(c => c.CariId == id).Select(c => c.CariAdi + " " + c.CariSoyadi).FirstOrDefault();
                ViewBag.Deger = deger;
                return View(degerler);
            }
        }
    }
}
