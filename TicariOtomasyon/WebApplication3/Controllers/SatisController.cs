using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models.Siniflar;

namespace WebApplication3.Controllers
{
    public class SatisController : Controller
    {
        public IActionResult Index()
        {
            using (Context context = new Context())
            {
                var satis = context.SatisHarekets.Include(u => u.Urun).Include(p => p.Personel).Include(c => c.Cari)
                    .ToList();
                return View(satis);
            }
        }

        [HttpGet]
        public IActionResult YeniSatis()
        {
            using (Context context = new Context())
            {
                List<SelectListItem> urun = (from x in context.Uruns.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.UrunAdi,
                                                 Value = x.UrunId.ToString(),

                                             }).ToList();
                List<SelectListItem> cari = (from x in context.Caris.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CariAdi,
                                                 Value = x.CariId.ToString()
                                             }).ToList();
                List<SelectListItem> personel = (from x in context.Personels.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.PersonelAdi,
                                                     Value = x.PersonelId.ToString()
                                                 }).ToList();
                ViewBag.dgr1 = urun;
                ViewBag.dgr2 = cari;
                ViewBag.dgr3 = personel;
                return View();
            }
        }

        [HttpPost]
        public IActionResult YeniSatis(SatisHareket satis)
        {
            using (Context context = new Context())
            {

                satis.SatisTarih = DateTime.Parse(DateTime.Now.ToShortDateString());
                context.SatisHarekets.Add(satis);
                context.SaveChanges();
                return RedirectToAction("Index");

            }
        }

        public ActionResult SatisGetir(int id)
        {
            using (Context context = new Context())
            {
                List<SelectListItem> urun = (from x in context.Uruns.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.UrunAdi,
                                                 Value = x.UrunId.ToString(),

                                             }).ToList();
                List<SelectListItem> cari = (from x in context.Caris.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CariAdi,
                                                 Value = x.CariId.ToString()
                                             }).ToList();
                List<SelectListItem> personel = (from x in context.Personels.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.PersonelAdi,
                                                     Value = x.PersonelId.ToString()
                                                 }).ToList();
                ViewBag.dgr1 = urun;
                ViewBag.dgr2 = cari;
                ViewBag.dgr3 = personel;

                var satis = context.SatisHarekets.Find(id);
                return View("SatisGetir", satis);
            }
        }

        public ActionResult SatisGuncelle(SatisHareket satis)
        {
            using (Context context = new Context())
            {
                var sat = context.SatisHarekets.Find(satis.SatisId);
                sat.CariId = satis.CariId;
                sat.Adet = satis.Adet;
                sat.Fiyat = satis.Fiyat;
                sat.PersonelId = satis.PersonelId;
                sat.SatisTarih = satis.SatisTarih;
                sat.ToplamTutar = satis.ToplamTutar;
                sat.UrunId = satis.UrunId;
                context.SaveChanges();
                return RedirectToAction("Index");

            }
        }

        public ActionResult SatisDetay(int id)
        {
            using (Context context = new Context())
            {
                var satis = context.SatisHarekets.Include(u => u.Urun).Include(p => p.Personel).Include(c => c.Cari)
                    .Where(x => x.SatisId == id).ToList();
                return View(satis);
            }
        }
    }
}
