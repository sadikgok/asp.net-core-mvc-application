using Microsoft.AspNetCore.Mvc;
using PagedList;
using WebApplication3.Models.Siniflar;

namespace WebApplication3.Controllers
{
    public class KategoriController : Controller
    {


        Context _context = new Context();
        public IActionResult Index(int sayfa=1)
        {
            var degerler = _context.Kategoris.ToList().ToPagedList(sayfa, 10);
            return View(degerler);
        }

        [HttpGet]
        public IActionResult KategoriEkle()
        {
            return View();
        }


        [HttpPost]
        public ActionResult KategoriEkle(Kategori k)
        {
            _context.Kategoris.Add(k);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var kategori = _context.Kategoris.Find(id);
            return View("KategoriGetir", kategori);
        }

        public ActionResult KategoriGuncelle(Kategori k)
        {
            var kategori = _context.Kategoris.Find(k.KategoriId);
            kategori.KategoriAd = k.KategoriAd;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
