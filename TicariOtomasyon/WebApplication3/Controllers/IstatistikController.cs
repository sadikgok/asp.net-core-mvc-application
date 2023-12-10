using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models.Siniflar;

namespace WebApplication3.Controllers
{
    public class IstatistikController : Controller
    {
        //Context context = new Context();
        public IActionResult Index()
        {
            using (Context context = new Context())
            {
                var deger1 = context.Caris.Count().ToString();
                ViewBag.d1 = deger1;
                var deger2 = context.Uruns.Count().ToString();
                ViewBag.d2 = deger2;
                var deger3 = context.Personels.Count().ToString();
                ViewBag.d3 = deger3;
                var deger4 = context.Kategoris.Count().ToString();
                ViewBag.d4 = deger4;
                var deger5 = context.Uruns.Sum(x => x.Stok).ToString();
                ViewBag.d1 = deger5;
                var deger6 = (from x in context.Uruns select x.Marka).Distinct().Count().ToString();
                ViewBag.d6 = deger6;
                var deger7 = context.Uruns.Count(x => x.Stok <= 20).ToString();
                ViewBag.d7 = deger7;
                var deger8 = (from x in context.Uruns orderby x.SatisFiyati descending select x.UrunAdi).FirstOrDefault();
                ViewBag.d8 = deger8;
                var deger9 = (from x in context.Uruns orderby x.SatisFiyati ascending select x.UrunAdi).FirstOrDefault();
                ViewBag.d9 = deger9;
                var deger10 = context.Uruns.Count(x => x.UrunAdi == "Buzdolabı").ToString();
                ViewBag.d10 = deger10;
                var deger11 = context.Uruns.Count(x => x.UrunAdi == "Laptop").ToString();
                ViewBag.d11 = deger11;
                var deger12 = context.Uruns.GroupBy(x => x.Marka).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
                ViewBag.d12 = deger12;
                var deger13 = context.Uruns.Where(u => u.UrunId == (context.SatisHarekets.GroupBy(x => x.UrunId).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault())).Select(k => k.UrunAdi).FirstOrDefault();
                ViewBag.d13 = deger13;
                var deger14 = context.SatisHarekets.Sum(x => x.ToplamTutar).ToString();
                ViewBag.d14 = deger14;

                DateTime bugun = DateTime.Today;
                var deger15 = context.SatisHarekets.Count(x => x.SatisTarih == bugun).ToString();
                ViewBag.d15 = deger15;
                var deger16 = context.SatisHarekets.Where(x => x.SatisTarih == bugun).Sum(y => y.ToplamTutar).ToString();

            }
            return View();
        }

        public IActionResult KolayTablolar()
        {
            using (Context context = new Context())
            {
                var sorgu = from x in context.Caris
                            group x by x.CariSehir into g
                            select new SinifGrup
                            {
                                Sehir = g.Key,
                                Sayi = g.Count(),
                            };
                return View(sorgu.ToList());
            }

        }

        public IActionResult _DepartmanPartial()
        {
            using (Context context = new Context())
            {
                var sorgu = from x in context.Personels
                            group x by x.DepartmanId into g
                            select new SinifGrup
                            {
                                Departman = g.Key,
                                DepartmanSayi = g.Count(),
                            };
                return PartialView( sorgu.ToList());
            }

        }
    }
}
