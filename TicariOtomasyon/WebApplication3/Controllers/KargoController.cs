using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models.Siniflar;

namespace WebApplication3.Controllers
{
    public class KargoController : Controller
    {
        public IActionResult Index(string p)
        {
            using (Context context = new Context())
            {
                var kargo = from x in context.KargoDetays select x;
                if (!string.IsNullOrEmpty(p))
                {
                    kargo = kargo.Where(y => y.TakipKodu.Contains(p));
                }
                return View(kargo.ToList());
            }

        }
        [HttpGet]
        public IActionResult YeniKargo()
        {
            Random rnd = new Random();
            string[] karakter = { "A", "B", "C", "D" };
            int k1, k2, k3;
            k1 = rnd.Next(0, karakter.Length);
            k2 = rnd.Next(0, karakter.Length);
            k3 = rnd.Next(0, karakter.Length);
            int s1, s2, s3;
            s1 = rnd.Next(100, 1000);
            s2 = rnd.Next(10, 99);
            s3 = rnd.Next(10, 99);
            string kod = s1.ToString() + karakter[k1] + s2 + karakter[k2] + s3 + karakter[k3];
            ViewBag.kod = kod;
            return View();
        }

        [HttpPost]
        public IActionResult YeniKargo(KargoDetay kargo)
        {
            using (Context context = new Context())
            {
                context.KargoDetays.Add(kargo);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public IActionResult KargoTakip(string id)
        {
            using (Context context = new Context())
            {
                var takip = context.KargoTakips.Where(x => x.TakipKodu == id).ToList();
                return View(takip);

            }
        }
    }
}
