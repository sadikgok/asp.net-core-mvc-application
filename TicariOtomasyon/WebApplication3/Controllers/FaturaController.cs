using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models.Siniflar;

namespace WebApplication3.Controllers
{
    public class FaturaController : Controller
    {
        public IActionResult Index()
        {
            using (Context context = new Context())
            {
                var fatura = context.Faturas.ToList();
                return View(fatura);
            }
        }

        [HttpGet]
        public ActionResult FaturaEkle()
        {

            return View();
        }
        [HttpPost]
        public ActionResult FaturaEkle(Fatura fatura)
        {
            using (Context context = new Context())
            {
                context.Faturas.Add(fatura);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult FaturaGetir(int id)
        {
            using (Context context = new Context())
            {
                var fatura = context.Faturas.Find(id);
                return View("FaturaGetir", fatura);
            }
        }

        public ActionResult FaturaGuncelle(Fatura fatura)
        {
            using (Context context = new Context())
            {
                var fat = context.Faturas.Find(fatura.FaturaId);
                fat.FaturaSeriNo = fatura.FaturaSeriNo;
                fat.FaturaSıraNo = fatura.FaturaSıraNo;
                fat.Saat = fatura.Saat;
                fat.Tarih = fatura.Tarih;
                fat.TeslimAlan = fatura.TeslimAlan;
                fat.TeslimEden = fatura.TeslimEden;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult FaturaDetay(int id)
        {
            using (Context context = new Context())
            {
                var kalem = context.FaturaKalems.Where(x => x.FaturaId == id).ToList();
                return View(kalem);
            }
        }

        [HttpGet]
        public ActionResult YeniKalem()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKalem(FaturaKalem faturaKalem)
        {
            using (Context context = new Context())
            {
                context.FaturaKalems.Add(faturaKalem);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Dinamik()
        {
            using (Context context = new Context())
            {
                DinamikFatura dinamikFatura = new DinamikFatura();
                dinamikFatura.deger1 = context.Faturas.ToList();
                dinamikFatura.deger2 = context.FaturaKalems.ToList();
                return View(dinamikFatura);
            }
        }

        public IActionResult FaturaKaydet(string FaturaSeriNo, string FaturaSıraNo, DateTime Tarih, string VergiDairesi, string Saat, string TeslimEden, string TeslimAlan, string Toplam, FaturaKalem[] kalemler)
        {
            using (Context context = new Context())
            {
                Fatura fatura = new Fatura();
                fatura.FaturaSeriNo = FaturaSeriNo;
                fatura.FaturaSıraNo = FaturaSıraNo;
                fatura.Tarih = Tarih;
                fatura.VergiDairesi = VergiDairesi;
                fatura.Saat = Saat;
                fatura.TeslimAlan = TeslimAlan;
                fatura.TeslimEden = TeslimEden;
                fatura.ToplamTutar = decimal.Parse(Toplam);
                context.Add(fatura);
                context.SaveChanges();
                return Json("İşlem Başarılı");

            }
        }
    }

}
